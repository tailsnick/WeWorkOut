// Test function fo make sure JS calls are happening
function make_annoying_alert() {
    alert("Hey! Hey! Hey!");
}

// Changes the available units for a goal once the user has selected an exercise
function exercise_option_changed() {
    var selected_option = $("#exercises_select").val();

    // As soon as an exercise is selected, these options become unavailable to the user
    option_show_hide($("#unitsNoneOption"), false); 
    option_show_hide($("#exerciseNoneOption"), false); 
    
    $.ajax(
        {
            url: "Exercises/GetValidUnits",
            method: "POST",
            data:
            {
                exerciseName : selected_option
            }
        }).done(function (result) {   
            // Show/hide the options in the units select
            option_show_hide($("#weightOption"), result.weightValid);
            option_show_hide($("#distanceOption"), result.distanceValid);
            option_show_hide($("#timeOption"), result.timeValid);
            option_show_hide($("#repsOption"), result.repsValid);

            // Set the selected option for the units to the first visible option
            var options = $("#units_select")[0].options;
            for (i = 0; i < options.length; i++) {
                var option = options[i];
                var displayStatus = option.style.display;   // Visibility status of an option
                if (!(displayStatus === "none")) {
                    $("#units_select")[0].selectedIndex = i;    // Set the selected option to this option
                    i = options.length;
                }
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }).always(function () { });

}

// Shows or hides an option based on the boolean value 'show' provided
function option_show_hide(option, show) {
    if (show)
        option.show();
    else
        option.hide();
}

function create_goal(e) {
    e.preventDefault();


    var x = $(date_input).val();

    $.ajax(
        {
            url: "Goals/CreateNewGoal",
            method: "POST",
            data:
            {
                exercise: $(exercises_select).val(),
                quantity: $(quantity_input).val(),
                unitsType: $(units_select).val(),
                completionDate: $(date_input).val()
            }
        }).done(function (result) {
            alert("Success!")
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }).always(function () { });
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






