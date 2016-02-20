var citiesDropDown = $('#city-drop-down');
var neighbourhoodsDropDown = $('#neighbour-drop-down');
var addImageBtn = $('#add-image-button');


//Event listeners
citiesDropDown.on('change', function () {
    var selectedCity = $('option:selected', citiesDropDown).text();
    getAllNeighbourhoods(selectedCity);
})

addImageBtn.on('click', function () {
    var lastFileName = $(":file").last().attr('name');
    var elementToAppendNewOne = $(":file").last().parent();
    numberOfimage = null;

    if (lastFileName) numberOfimage = lastFileName.substr(lastFileName.length - 1);

    if (!numberOfimage && isNaN(numberOfimage * 1)) {
        return;
    }
    var nextNumberOfImage = numberOfimage * 1 + 1;

    if (nextNumberOfImage.toString().length > 1) return;

    var html = ' <div class="col-md-5 upload"><input type="file" name="UplodadedImage' + nextNumberOfImage + '" /></div>';

    elementToAppendNewOne.after(html);
})



$('#profile-name').on('click', function () {
    if ($('#profile-name').is("label")) {
        var name = $('#profile-name').html();
        $('#profile-name').slice(0, 1).each(function () {
            $(this).replaceWith('<input id="profile-name" type="text" value="' + name + '"/>');
        });

        var cancelBtn = $('<button class="btn btn-alert">Cancel</button>')
        $('#profile-name').append(cancelBtn);

        cancelBtn.on('click', function () {
            $('#profile-name').slice(0, 1).each(function () {
                $(this).replaceWith('<label id="profile-name">' + name + '</label>');
            });
        })
    }
    else {
        var name = $('#profile-name').val();
        $('#profile-name').slice(0, 1).each(function () {
            $(this).replaceWith('<label id="profile-name">' + name + '</label>');
        });
    }
});



