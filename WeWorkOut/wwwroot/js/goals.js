// Test function fo make sure JS calls are happening
function make_annoying_alert() {
    alert("Hey! Hey! Hey!");
}

// Another function.
function exercise_option_changed() {
    var selected_option = $("#exercises_select").val();

    // As soon as an exercise is selected, these options become unavailable to the user
    element_show_hide($("#unitsNoneOption"), false); 
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
            // Show/hide the options in the units select
            element_show_hide($("#weightOption"), result.weightValid);
            element_show_hide($("#distanceOption"), result.distanceValid);
            element_show_hide($("#timeOption"), result.timeValid);
            element_show_hide($("#repsOption"), result.repsValid);

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

// Shows or hides an element based on the boolean value 'show' provided
function element_show_hide(element, show) {
    if (show)
        element.show();
    else
        element.hide();
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






