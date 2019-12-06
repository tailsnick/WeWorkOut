function getGuide(eName) {
    alert("GUIDE HERE");

    $.ajax(
        {
            url: "Exercises/GetGuide",
            method: "POST",
            data:
            {
                exerciseName: eName
            },
            dataType: "json"
        }).done(function (result) {
            var desc = result.htmlDesc;
            $("#guideRenderArea").html(desc);

        }).fail(function (jqXHR, textStatus, errorThrown) {
            
        }).always(function () { });
}