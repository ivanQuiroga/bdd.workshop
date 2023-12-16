function calculate(operator) {
    document.getElementById('operation').value = operator;
}

function calculateResult() {
    let num1 = parseFloat(document.getElementById('num1').value);
    let num2 = parseFloat(document.getElementById('num2').value);
    let operator = document.getElementById('operation').value;
    let result;

    switch (operator) {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            result = num1 / num2;
            break;
        case '√':
            result = Math.sqrt(num1);
            break;
    }

    document.getElementById('result').value = result;
}

function clearInput() {
    document.getElementById('operation').value = '';
}

function clearAll() {
    document.getElementById('num1').value = '';
    document.getElementById('num2').value = '';
    document.getElementById('operation').value = '';
    document.getElementById('result').value = '';
}