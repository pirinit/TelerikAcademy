function createRandomDiv(element) {
    var rect = element.getBoundingClientRect();
    var div = document.createElement('div');
    var size = generateRandomNumberInRange(20, 100);
    var backgroundColor = generateRandomColor();
    var fontColor = generateRandomColor();
    var borderRadius = generateRandomNumberInRange(0, 100) + 'px';
    var borderColor = generateRandomColor();
    var borderWidth = generateRandomNumberInRange(1, 20);
    var posX = generateRandomNumberInRange(0, rect.right - rect.left - size - borderWidth * 2) + 'px';
    var posY = generateRandomNumberInRange(0, window.innerHeight - rect.top - size - borderWidth * 2) + 'px';
    size = size + 'px';
    borderWidth = borderWidth + 'px';

    div.style.width = size;
    div.style.height = size;
    div.style.backgroundColor = backgroundColor;
    div.style.color = fontColor;
    div.style.position = 'absolute';
    div.style.left = posX;
    div.style.top = posY;
    div.innerHTML = '<strong style=\'line-height: ' + size +'\'>div</strong>';
    div.style.textAlign = 'center';
    div.style.border = 'solid';
    div.style.borderRadius = borderRadius;
    div.style.borderWidth = borderWidth;
    div.style.borderColor = borderColor;
    element.appendChild(div);
}

function generateRandomNumberInRange(minSize, maxSize) {
    var number = Math.floor(Math.random() * (maxSize - minSize + 1) + minSize);
    return number;
}

function generateRandomColor() {
    var letters = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'];
    var color = '#';
    for (var i = 0; i < 6; i++ ) {
        color += letters[Math.round(Math.random() * 15)];
    }
    return color;
}

function clearAllDivs(elementId) {
    var parentElement = document.getElementById(elementId);
    parentElement.innerHTML = '';
    //var elementsToRemove = parentElement.getElementsByTagName('div');
    //while (elementsToRemove.length > 0) {
    //    parentElement.removeChild(elementsToRemove[0]);
    //}
}