// Allows a user to create a new goal
function create_record(e) {
    e.preventDefault();

    var exercise = $("#exercises_select").val();

    var weight_quantity;
    if ($('#weight_section').is(':visible')) {
        weight_quantity = $("#weight_quantity_input").val();
    }

    var distance_quantity;
    if ($('#distance_section').is(':visible')) {
        distance_quantity = $("#distance_quantity_input").val();
    }

    var time_quantity;
    if ($('#time_section').is(':visible')) {
        time_quantity = $("#time_quantity_input").val();
    }

    var reps_quantity;
    if ($('#reps_section').is(':visible')) {
        reps_quantity = $("#reps_quantity_input").val();
    }




    $.ajax(
        {
            url: "ExerciseRecords/CreateNewExerciseRecord",
            method: "POST",
            data:
            {
                exercise: exercise,
                weightQuantity: weight_quantity,
                distanceQuantity: distance_quantity,
                timeQuantity: time_quantity,
                repsQuantity: reps_quantity,
                submitDate: $("#date_input").val()
            }
        }).done(function (result) {
            alert("Success!  Refresh to see your new record.")
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }).always(function () { });
}

// Allows a user to delete one of their goals.
function delete_record(recordID) {
    if (confirm("Delete this record?")) {
        // Do the deleting
        $.ajax(
            {
                url: "ExerciseRecords/DeleteConfirmed",
                method: "POST",
                data:
                {
                    id: recordID
                }
            }).done(function (result) {
                // Delete the row from the table
                var delete_button = $("#delete_button_" + recordID)[0];
                var rowIndex = delete_button.parentElement.parentElement.rowIndex;
                $("#records_table")[0].deleteRow(rowIndex);
            }).fail(function (jqXHR, textStatus, errorThrown) {
                console.log("failed: ");
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            }).always(function () { });
    } else {
        // Do nothing, keep the goal.
    }
}


// Changes the available units for a goal once the user has selected an exercise
function exercise_option_changed() {
    var selected_option = $("#exercises_select").val();

    // As soon as an exercise is selected, these options become unavailable to the user
    element_show_hide($("#exerciseNoneOption"), false); 
    
    $.ajax(
        {
            url: "Exercises/GetValidUnits",
            method: "POST",
            data:
            {
                exerciseName : selected_option
            }
        }).done(function (result) {   
            // Show/hide the unit fields
            element_show_hide($("#weight_section"), result.weightValid);
            element_show_hide($("#distance_section"), result.distanceValid);
            element_show_hide($("#time_section"), result.timeValid);
            element_show_hide($("#reps_section"), result.repsValid);
    
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }).always(function () { });

}

// Shows or hides an option based on the boolean value 'show' provided
function element_show_hide(option, show) {
    if (show)
        option.show();
    else
        option.hide();
}



function modify_edit_goal(goalID) {
    // Show and hide the appropriate stuff
    $("#quantity_" + goalID).hide();
    $("#date_" + goalID).hide();
    $("#modify_edit_button_" + goalID).hide();

    var prev_quantity = $("#quantity_" + goalID).text();
    var prev_date = $("#date_" + goalID).text().replace('/', '-').replace('/', '-');

    $("#modify_quantity_" + goalID).show();
    $("#modify_date_" + goalID).show();
    $("#modify_submit_button_" + goalID).show();

    // Put the already existing data into the editable inputs so the user can see what they're editing
    $("#modify_quantity_" + goalID).val(prev_quantity);
    $("#modify_date_" + goalID).val(prev_date);
}

function modify_submit_goal(goalID) {
    var new_quantity = $("#modify_quantity_" + goalID).val();
    var new_date = $("#modify_date_" + goalID).val();

    $.ajax(
        {
            url: "Goals/EditGoal",
            method: "POST",
            data:
            {
                id: goalID,
                newQuantity: new_quantity,
                newDeadline: new_date
            }
        }).done(function (result) {
            alert("Success!")
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }).always(function () { });

    // Show and hide the appropriate stuff
    $("#quantity_" + goalID).show();
    $("#date_" + goalID).show();
    $("#modify_edit_button_" + goalID).show();

    $("#modify_quantity_" + goalID).hide();
    $("#modify_date_" + goalID).hide();
    $("#modify_submit_button_" + goalID).hide();

    // Change the updates in the table
    $("#quantity_" + goalID).text(new_quantity);
    $("#date_" + goalID).text(new_date.replace('-', '/').replace('-', '/'));
}