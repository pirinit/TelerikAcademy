; trashGame = (function () {
    var highScores = JSON.parse(localStorage.getItem('highScores'));
    if (!highScores) {
        highScores = [];
    }
    showHighScores();

    function start() {
        debugger;
        var startTime = new Date();
        var display = document.getElementById('display');

        display.innerHTML = '';

        var trashCountString = document.getElementById('tb-trashCount').value;
        var trashCount = trashCountString ^ 0;
        display.style.position = 'relative';
        display.appendChild(createBin());

        var trashes = document.createDocumentFragment();
        for (var i = 0; i < trashCount; i++) {
            var trashCane = createTrash();
            trashCane.style.left = generateRandomNumberInRange(100, 800 - 50) + 'px';
            trashCane.style.top = generateRandomNumberInRange(100, 600 - 50) + 'px';
            trashCane.id = 'trashCane-' + i;

            trashes.appendChild(trashCane);
        }
        display.appendChild(trashes);

        function createBin() {
            var trashBin = document.createElement('img');
            trashBin.src = 'img/ClosedBin.png';
            trashBin.style.position = 'absolute';
            trashBin.style.width = '100px';

            trashBin.ondragover = function (event) {
                event.preventDefault();
                trashBin.src = 'img/SemiOpenedBin.png';
            }

            trashBin.ondragleave = function (event) {
                trashBin.src = 'img/ClosedBin.png';
            }

            trashBin.ondrop = function (event) {
                event.preventDefault();
                var draggedElementId = event.dataTransfer.getData("trash-id");
                var draggedElement = document.getElementById(draggedElementId);
                draggedElement.parentNode.removeChild(draggedElement);
                event.target.src = 'img/ClosedBin.png';

                trashCount--;
                if (trashCount == 0) {
                    endGame();
                }
            }
            return trashBin;
        }

        function createTrash() {
            var trashCane = document.createElement('img');
            trashCane.src = 'img/TrashCane.png';
            trashCane.style.position = 'absolute';
            trashCane.style.width = '50px';
            trashCane.draggable = true;

            trashCane.ondragstart = function (event) {
                event.dataTransfer.setData("trash-id", event.target.id);
            }

            trashCane.ondrag = function (event) {
                event.target.style.display = 'none';
            }

            trashCane.ondragend = function (event) {
                event.target.style.display = '';
            }
            return trashCane;
        }

        function generateRandomNumberInRange(minSize, maxSize) {
            var number = Math.floor(Math.random() * (maxSize - minSize + 1) + minSize);
            return number;
        }

        function endGame() {
            var endTime = new Date();
            var timeElapsed = endTime - startTime;
            var timeElapsedSeconds = timeElapsed / 1000;

            if (highScores.length < 5 || highScores[4].time > timeElapsed) {
                var userName = prompt('You have cleaned all canes in just ' + timeElapsedSeconds + ' seconds. Please enter your name:');
                var scoreEntry = { name: userName, time: timeElapsedSeconds };

                highScores.push(scoreEntry);

                highScores.sort(function (a, b) {
                    if (a.time < b.time) {
                        return -1;
                    }
                    if (a.time > b.time) {
                        return 1;
                    }
                    return 0;
                });
                if (highScores.length > 5) {
                    //delete last element
                    highScores.pop();
                }
                console.log(highScores);

                localStorage.setItem('highScores', JSON.stringify(highScores));
            }
            else {
                alert('You have cleaned all canes in ' + timeElapsedSeconds + ' seconds.');
            }
            debugger;
            showHighScores();
        }
    }

    function showHighScores() {
        var result = '--------- Highscores ---------\n';
        if (highScores.length != 0) {
            for (var i = 0, length = highScores.length; i < length; i++) {
                result += i + 1 + '. ' + highScores[i].name + ' - ' + highScores[i].time + ' seconds. \n';
            }
        }
        else {
            result += '\n empty';
        }

        alert(result);
    }

    function resetHighScores() {
        highScores = [];
        localStorage.setItem('highScores', JSON.stringify(highScores));
        showHighScores();
    }

    return {
        start: start,
        showHighScores: showHighScores,
        resetHighScores: resetHighScores
    }
}());