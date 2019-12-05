function placeHolderFunction(ExerciseID, GoalType, GoalNum, GoalDeadline) {
    alert("GUIDE HERE");

    
}




function open_collapsible(goalID, exerciseID, exerciseName, quantity, measurementType, deadline) {

    var collapsible = $("#collapsible_" + goalID)[0];

    if (collapsible.style.display === "block") {
        collapsible.style.display = "none";
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
                alert("Got something from the DB!");


            }).fail(function (jqXHR, textStatus, errorThrown) {

            }).always(function () { });





    }

    



    

}