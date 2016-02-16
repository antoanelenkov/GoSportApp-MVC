var citiesDropDown = $('#city-drop-down');
var neighbourhoodsDropDown = $('#neighbour-drop-down');

citiesDropDown.on('change', function () {
    var selectedCity = $('option:selected', citiesDropDown).text    ();
    getAllNeighbourhoods(selectedCity);
})

function getAllNeighbourhoods(city) {
    $.ajax({
        type: 'POST',
        url: 'GetAllNeighbours',
        dataType: 'json',
        data: JSON.stringify({ city: city }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            neighbourhoodsDropDown.html('');

            if (!data.length) {
                neighbourhoodsDropDown.append(
                    $('<option></option>').val("None").html("None")
                );
            }

            for (var i = 0; i < data.length; i++) {
                neighbourhoodsDropDown.append(
                    $('<option></option>').val(data[i].Id).html(data[i].Neighborhood)
                );
            }
        },
        error: function (data) {
            console.log('error: ' + data)
        }
    });
}