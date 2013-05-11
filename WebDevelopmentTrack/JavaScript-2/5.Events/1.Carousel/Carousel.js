; var carousel = (function () {
    var carouselDiv = document.getElementById('carousel');
    
    var carouselElement = document.createElement('div');
    carouselElement.className = 'carouselElement';

    var carouselElements = [];
    var forward = true;
    var setIntervalHandler;
    function start() {
        // check for re-start 
        if (carouselElements.length > 0) {
            deleteAllChild(carouselDiv);
            carouselElements = [];
            stop();
        }
        //insert elements in carousel
        for (var i = 0; i < 10; i++) {
            var currentElement = carouselElement.cloneNode(true)
            currentElement.innerText = 'element' + i;
            currentElement.style.left = -600 + 200 * i + 'px';
            carouselElements.push(currentElement);
            carouselDiv.appendChild(currentElement);
        }
        //start rotation
        setIntervalHandler = setInterval(moveCarouselElements, 4000);
    }

    function stop() {
        clearInterval(setIntervalHandler);
    }

    function left() {
        forward = false;
        moveCarouselElements();
    }

    function right() {
        forward = true;
        moveCarouselElements();
    }

    function moveCarouselElements() {
        var element;
        for (var i = 0, length = carouselElements.length; i < length; i++) {
            carouselElements[i].style.display = '';
        }
        if (forward) {
            element = carouselElements.shift();
            element.style.display = 'none';
            carouselElements.push(element);
        }
        else {
            element = carouselElements.pop();
            element.style.display = 'none';
            carouselElements.unshift(element);
        }
        for (var i = 0, length = carouselElements.length; i < length; i++) {
            carouselElements[i].style.left = -600 + 200 * i + 'px';
        }
    }

    function deleteAllChild(element) {
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    return {
        start: start,
        stop: stop,
        left: left,
        right: right
    }
}());