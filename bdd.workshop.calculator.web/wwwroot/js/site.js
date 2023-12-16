// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function calculate(operator) {
    document.getElementById('Command').value = operator;
}

function calculateResult() {
    let A_TheNumber = parseFloat(document.getElementById('A_TheNumber').value);
    let B_TheNumber = parseFloat(document.getElementById('B_TheNumber').value);
    let operator = document.getElementById('Command').value;
    let result;

    switch (operator) {
        case '+':
            result = A_TheNumber + B_TheNumber;
            break;
        case '-':
            result = A_TheNumber - B_TheNumber;
            break;
        case '*':
            result = A_TheNumber * B_TheNumber;
            break;
        case '/':
            result = A_TheNumber / B_TheNumber;
            break;
        case '√':
            result = Math.sqrt(A_TheNumber);
            break;
    }

    document.getElementById('result').value = result;
}

function clearInput() {
    document.getElementById('Command').value = '';
}

function clearAll() {
    document.getElementById('A_TheNumber').value = '';
    document.getElementById('B_TheNumber').value = '';
    document.getElementById('Command').value = '';
    document.getElementById('result').value = '';
}