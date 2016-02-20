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
});





