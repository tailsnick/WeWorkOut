// Test function fo make sure JS calls are happening
function make_annoying_alert() {
    alert("Hey! Hey! Hey!");
}

// Another function.
function exercise_option_changed() {
    var selected_option = $("#exercises_select option:selected").html();
    
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
            // Set the units select option to none
            $("#units_select").val("noneSelected");
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }).always(function () { });

}

function element_show_hide(element, show) {
    if (show)
        element.show();
    else
        element.hide();
}






