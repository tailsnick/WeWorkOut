function placeHolderFunction(ExerciseID, GoalType, GoalNum) {
    alert("GUIDE HERE");

    $.ajax(
        {
            url: "Progress/GetSubmitedData",
            method: "POST",
            data:
            {
                exerciseID: ExerciseID
            },
            dataType: "json"
        }).done(function (result) {

            //////////////PLACE HOLDER CODE!!!!!!!//////////

            //Use the graph here.
            /*if (GoalType == "Time") {
    foreach(var record in result)
    {
        Console.WriteLine(record.TimeQuantity);
        Console.WriteLine(record.SubmitDate);
    }
}
if (GoalType == "Weight") {
    foreach(var record in result)
    {
        Console.WriteLine(record.WeightQuantity);
        Console.WriteLine(record.SubmitDate);
    }
}
if (GoalType == "Reps") {
    foreach(var record in result)
    {
        Console.WriteLine(record.RepQuantity);
        Console.WriteLine(record.SubmitDate);
    }
}
if (GoalType == "Distance") {
    foreach(var record in result)
    {
        Console.WriteLine(record.DistanceQuantity);
        Console.WriteLine(record.SubmitDate);
    }
}
}*/

            //////////////////////////////////////////////////

        }).fail(function (jqXHR, textStatus, errorThrown) {

}).always(function () { });
}