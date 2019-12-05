function placeHolderFunction(ExerciseID, GoalType, GoalNum, GoalDeadline) {
    alert("GUIDE HERE");

    $.ajax(
        {
            url: "Progress/GetSubmittedData",
            method: "POST",
            data:
            {
                exerciseID: ExerciseID,
                goalType: GoalType
            },
            dataType: "json"
        }).done(function (result) {

            //////////////PLACE HOLDER CODE!!!!!!!//////////
            if (GoalDeadline == null) {

            }
            else {

            }

            //////////////////////////////////////////////////

        }).fail(function (jqXHR, textStatus, errorThrown) {

}).always(function () { });
}