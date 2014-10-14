$(document).ready(function () {
    var productLengthsCount = 0;
    addInputs(productLengthsCount);

    var imagesUploadCount = 0;
    addFileInputs(imagesUploadCount);

    $("#add-length").click(function () {
        productLengthsCount++;
        addInputs(productLengthsCount);
    });

    $("#add-upload-image").click(function () {
        imagesUploadCount++;
        addFileInputs(imagesUploadCount)
    })
});

function addFileInputs(elementsCount) {
    var formGroup = $('<div>', {
        class: 'form-group',
    });
    var labelContainer = $('<div>', {
    });
    var label = $('<label>', {
        for: 'images[' + elementsCount+']',
        text: 'Качи снимка :'
    });
    var inputContainer = $('<div>', {
    });
    var input = $('<input>', {
        type: 'file',
        id: 'images[' + elementsCount+']',
        name: 'images[' + elementsCount+']'
    });

    inputContainer.append(input);
    labelContainer.append(label);
    formGroup.append(labelContainer);
    formGroup.append(inputContainer);

    var container = $('#images-upload-container');

    container.prepend($('<hr>'));
    container.prepend(formGroup);
}
//<div class="form-group">
//               <div class="col-md-5">
//                   <label for="image">Upload Image:</label>
//               </div>
//               <div class="col-md-7">
//                   <input type="file" id="image" name="images[0]"/>
//               </div>
//           </div>
function addInputs(elementsCount) {
    var indexString = 'lengths[' + elementsCount + ']';
    var container = $('#lengths-container');

    container.prepend($('<hr>'));

    var formGroup = createInput(indexString + '.Pallet', 'Бройка');
    container.prepend(formGroup);

    formGroup = createInput(indexString + '.Weight', 'Килограми');
    container.prepend(formGroup);

    var formGroup = createInput(indexString + '.Code', 'Код');
    container.prepend(formGroup);

    var formGroup = createInput(indexString + '.Inches', 'Дължина');
    container.prepend(formGroup);
}

function createInput(property,text){
    var formGroup = $('<div>', {
        class: 'form-group',
    });
    var labelContainer = $('<div>', {
        class: 'col-md-4',
    });
    var label = $('<label>', {
        for: property,
        text: text
    });
    var inputContainer = $('<div>', {
        class: 'col-md-8',
    });
    var input = $('<input>', {
        class: 'form-control',
        type: 'number',
        id: property,
        name:property
    });

    inputContainer.append(input);
    labelContainer.append(label);
    formGroup.append(labelContainer);
    formGroup.append(inputContainer);

    return formGroup;
}