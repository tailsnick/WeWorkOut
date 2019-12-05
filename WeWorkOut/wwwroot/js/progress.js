function open_collapsible(goalID, exerciseID, exerciseName, quantity, measurementType, units, deadline) {

    var collapsible = $("#collapsible_" + goalID)[0];
    
    // Expand if collapsed, or collapse if expanded
    if (collapsible.style.display === "block") {
        collapsible.style.display = "none";
        // Need to update the value of the button
    }
    else {
        collapsible.style.display = "block";

        // Query the DB for all exercise records that are relevant to the goal
        var records;
        $.ajax(
            {
                url: "Progress/GetSubmittedData",
                method: "POST",
                data:
                {
                    exerciseID: exerciseID,
                    measurementType: measurementType
                }
            }).done(function (result) {
                var ctx = document.getElementById('canvas_' + goalID).getContext('2d');
                var config = get_chart_configuration(exerciseName, quantity, units, deadline, result.data);
                new Chart(ctx, config);


            }).fail(function (jqXHR, textStatus, errorThrown) {

            }).always(function () { });
    }

      

}

function addDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

// From 3 dates, returns the oldest (least recent) of the 3.
//   ALL ARGUMENTS MUST BE NON NULL, except for date3, which can
//   sometimes be null.  If it is, it won't be considered.
function oldestDate(date1, date2, date3) {
    // Only need to compare the first 2 args if the 3rd is null
    if (date3 == null) {
        if (date1 < date2) {
            return date1;
        }
        else {
            return date2;
        }
    }

    var date1_older_than_date2 = date1 < date2;
    var date2_older_than_date3 = date2 < date3;
    var date1_older_than_date3 = date1 < date3;

    if (date1_older_than_date2 & date1_older_than_date3) {
        return date1;
    }
    else if (!date1_older_than_date2 & date2_older_than_date3) {
        return date2;
    }
    else {
        return date3;
    }
}

// From 3 dates, returns the newest (most recent) of the 3.
//   ALL ARGUMENTS MUST BE NON NULL, except for date3, which can
//   sometimes be null.  If it is, it won't be considered.
function newestDate(date1, date2, date3) {
    // Only need to compare the first 2 args if the 3rd is null
    if (date3 == null) {
        if (date1 < date2) {
            return date2;
        }
        else {
            return date1;
        }
    }

    var date1_older_than_date2 = date1 < date2;
    var date2_older_than_date3 = date2 < date3;
    var date1_older_than_date3 = date1 < date3;

    if (!date1_older_than_date2 & !date1_older_than_date3) {
        return date1;
    }
    else if (date1_older_than_date2 & !date2_older_than_date3) {
        return date2;
    }
    else {
        return date3;
    }
}

function get_chart_configuration(exerciseName, quantity, units, deadline, data) {
    // CHART DATA:
    var x_axis_label = "DATE";
    var y_axis_label = units.toUpperCase();
    var chart_title = exerciseName + " Goal: " + quantity + " " + units;
    var data_label = exerciseName.toUpperCase();
    var goal_label = "GOAL";
    var deadline_label = "DEADLINE";
    var goal_quantity = quantity;
    if (deadline === "") {
        deadline = null;
    }
    else {
        deadline = new Date(deadline); // Convert the deadline date string to a Date object
    }
    
    // Some colors used for charting
    var red = 'rgb(252, 9, 5)';
    var opaque_orange = 'rgba(244, 207, 112, 0.5)';
    var orange = 'rgba(252, 135, 5, 1)';
    var yellow = 'rgb(255, 205, 86)';
    var cyan = 'rgb(75, 192, 192)';
    var white = 'rgb(255, 255, 255)';

    // Compute axis bounds of the graph
    var x_axis_min;
    var x_axis_max;
    var y_axis_min;
    var y_axis_max;

    if (data === "" || data.length == 0) {
        x_axis_min = oldestDate(addDays(Date.now(), -6), x_axis_max = addDays(Date.now(), 0), deadline);
        x_axis_max = newestDate(addDays(Date.now(), -6), x_axis_max = addDays(Date.now(), 0), deadline);
        y_axis_min = 0;
        y_axis_max = goal_quantity + 2;
    }
    else {
        x_axis_min = oldestDate(new Date(data[0].x), new Date(data[data.length - 1].x), deadline);
        x_axis_max = newestDate(new Date(data[0].x), new Date(data[data.length - 1].x), deadline);
        y_axis_min = 0;
        // The maximum y axis value is either the goal, or the maximum measurement recorded so far
        var largest_measurement = 0;
        for (i = 0; i < data.length; i++) {
            if (data[i].y > largest_measurement) {
                largest_measurement = data[i].y;
            }
        }
        if (largest_measurement > goal_quantity) {
            y_axis_max = largest_measurement;
        }
        else {
            y_axis_max = goal_quantity;
        }
    }

    // Pad some of the axis bounds
    x_axis_min = addDays(x_axis_min, -1);
    x_axis_max = addDays(x_axis_max, 1);
    y_axis_max *= 1.2;


    // Horizontal line representing the goal to reach
    var goal_line = [
        {
            x: x_axis_min,
            y: goal_quantity
        }, {
            x: x_axis_max,
            y: goal_quantity
        }];

    // Vertical line representing the deadline (if applicable) to complete the goal by
    var deadline_line;
    if (deadline != null) {
        // This goal has a deadline.  Make a line that will represent it on the graph
        deadline_line = [
            {
                x: deadline,
                y: y_axis_min
            }, {
                x: deadline,
                y: y_axis_max
            }
        ];
    }
    else {
        // This goal does not have a deadline.  Make a line that won't render on the graph.
        deadline_line = [
            {
                x: x_axis_min,
                y: 0
            }, {
                x: x_axis_min,
                y: 0
            }
        ];
    }

    // Create configuration options for chart
    var config = {
        type: 'line',
        data: {
            datasets: [{                // User data
                label: data_label,
                backgroundColor: opaque_orange,
                borderColor: red,
                borderWidth: 4,
                pointBackgroundColor: orange,
                pointBorderWidth: 2,
                pointRadius: 8,
                pointHitRadius: 25,
                fill: true,
                data: data
            }, {                        // Goal line
                label: goal_label,
                borderColor: yellow,
                fill: false,
                data: goal_line,
                borderDash: [12, 12],
                borderWidth: 6,
                pointRadius: 0
            }, {                        // Deadline line
                label: deadline_label,
                borderColor: cyan,
                fill: false,
                data: deadline_line,
                borderDash: [12, 12],
                borderWidth: 8,
                pointRadius: 0
            }]
        },
        options: {

            responsive: true,
            title: {                // Graph title options
                display: true,
                text: chart_title,
                fontSize: 32,
                fontColor: white
            },

            scales: {
                xAxes: [{           // X Axis options
                    type: 'time',
                    time: {
                        unit: 'day',
                        unitStepSize: 1,
                        round: 'minute',
                        tooltipFormat: "MMM D, YYYY",
                        displayFormats: {
                            hour: 'MMM D, h:mm A'
                        }
                    },
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: x_axis_label,
                        fontColor: white,
                        fontSize: 24
                    },
                    ticks: {
                        minor: {
                            fontStyle: 'bold',
                            fontColor: white
                        }
                    },
                    gridLines: {
                        display: true,
                        color: white
                    },
                }],             // Y Axis options
                yAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: y_axis_label,
                        fontSize: 24,
                        fontColor: white
                    },
                    ticks: {
                        minor: {
                            fontStyle: 'bold',
                            fontColor: white
                        }
                    },
                    gridLines: {
                        display: true,
                        color: white
                    },
                }],
            },
            elements: {
                line: {
                    tension: 0.25   // Controls how straight or curvy the line is
                },
                point: {
                    radius: 0
                }
            },
            legend: {           // Legend options
                labels: {
                    fontColor: white
                },
                position: "bottom"
            }
        }
    };

    return config;
}

window.onload = function () {
    var data = [{
        x: new Date(2019, 11, 24),
        y: 5
    }, {
        x: new Date(2019, 11, 25),
        y: 10
    }, {
        x: new Date(2019, 11, 26),
        y: 8
    }, {
        x: new Date(2019, 11, 27),
        y: 11
    }];
    var ctx = document.getElementById('canvas').getContext('2d');
    var config = this.get_chart_configuration("Running", 12, "miles", "11/30/2019 12:00:00 AM", data);
    new Chart(ctx, config);
};
