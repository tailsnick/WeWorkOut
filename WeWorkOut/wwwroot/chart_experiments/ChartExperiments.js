function addDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}

var x_axis_label = "DATE";
var y_axis_label = "REPS";
var chart_title = "Goal: 12 push-ups";
var data_label = "push-ups";
var goal_label = "GOAL";
deadline_label = "DEADLINE";
var goal_quantity = 12;
var deadline = new Date(2019, 11, 30);

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




// Axis bounds
var x_axis_min;
var x_axis_max;
var y_axis_min;
var y_axis_max;

// Compute axis bounds of the graph
if (data == null || data.length < 2) {
    x_axis_min = addDays(Date().now(), -6);
    x_axis_max = Date().now();
    y_axis_min = 0;
    y_axis_max = goal_quantity + 2;
}
else {
    x_axis_min = data[0].x;
    if (data[data.length - 1] > deadline) {
        x_axis_max = data[data.length - 1].x;        
    }
    else {
        x_axis_max = deadline;    
    }

    y_axis_min = 0;
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
x_axis_max = addDays(x_axis_max, 1);
y_axis_max += 2;


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
var deadline_line = [
    {
        x: deadline,
        y: y_axis_min
    }, {
        x: deadline,
        y: y_axis_max
    }
]

console.log(data.length);

red = 'rgb(252, 9, 5)';
opaque_orange = 'rgba(244, 207, 112, 0.5)';
orange = 'rgba(252, 135, 5, 1)';
yellow = 'rgb(255, 205, 86)';
cyan = 'rgb(75, 192, 192)';
white = 'rgb(255, 255, 255)';

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

window.onload = function () {
    var ctx = document.getElementById('canvas').getContext('2d');
    window.myLine = new Chart(ctx, config);
};




