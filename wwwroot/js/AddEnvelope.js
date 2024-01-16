function addInput(container, plusButton, nrFields) {
    var inputGroup = document.createElement('div');
    inputGroup.classList.add('form-row');
    inputGroup.id = 'form-row-' + container.id;

    var nameInput = document.createElement('input');
    nameInput.setAttribute('type', 'text');
    nameInput.setAttribute('placeholder', 'Enter a name');

    var amountInput = document.createElement('input');
    amountInput.setAttribute('type', 'number');
    amountInput.setAttribute('placeholder', 'Enter an amount');
    amountInput.setAttribute('step', 0.01);

    var dueDateInput = null;

    if (nrFields > 2) {
        dueDateInput = document.createElement('input');
        dueDateInput.setAttribute('type', 'date');
        dueDateInput.setAttribute('placeholder', 'Enter a date');
    }

    var removeButton = document.createElement('button');
    removeButton.classList.add('btn-remove');
    removeButton.innerHTML = 'x';
    removeButton.onclick = function () {
        container.removeChild(inputGroup);
    };

    inputGroup.appendChild(nameInput);
    inputGroup.appendChild(amountInput);
    if (nrFields > 2) {
        inputGroup.appendChild(dueDateInput);
    }
    inputGroup.appendChild(removeButton);

    container.insertBefore(inputGroup, plusButton);
}

//function validateIncome(input, fieldName) {
//    console.log('validateIncome called with value: ' + input.value + ', fieldName: ' + fieldName);
//    var value = input.value;
//    if (isNaN(value)) {
//        alert(fieldName + ' must be a valid number!');
//        input.value = '';
//    }
//}
