; var flyingCircle = (function () {
    var radius = 0;
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext("2d");
    var STROKE_COLOR = 'black';
    var FILL_COLOR = 'yellow';
    var BALL_COLOR = 'red';
    var LINE_WIDTH = 0;
    var fieldMinWidth, fieldMaxWidth, fieldMinHeight, fieldMaxHeight;
    var circleSpeed = { x: 1, y: 1 };
    var circlePos = { x: 50, y: 50 };
    var setIntervalHandler = null;

    function start() {
        debugger;
        updateInput();
        ctx.strokeStyle = STROKE_COLOR;
        ctx.fillStyle = FILL_COLOR;
        ctx.lineWidth = LINE_WIDTH;
        
        //draw game field
        
        ctx.fillRect(0 + LINE_WIDTH / 2, 0 + LINE_WIDTH / 2, canvas.width - LINE_WIDTH, canvas.height - LINE_WIDTH);
        ctx.strokeRect(0 + LINE_WIDTH / 2, 0 + LINE_WIDTH / 2, canvas.width - LINE_WIDTH, canvas.height - LINE_WIDTH);

        ctx.fillStyle = BALL_COLOR;

        if (setIntervalHandler === null) {
            setIntervalHandler = setInterval(reDraw, 5);
        }
    }

    function reDraw() {
        if (circlePos.x <= fieldMinWidth || fieldMaxWidth <= circlePos.x) {
            circleSpeed.x *= -1;
        }

        if (circlePos.y <= fieldMinHeight|| fieldMaxHeight <= circlePos.y) {
            circleSpeed.y *= -1;
        }

        drawCircle(circlePos.x, circlePos.y);

        circlePos.x += circleSpeed.x;
        circlePos.y += circleSpeed.y;
    }

    function drawCircle(left, top) {
        ctx.beginPath();
        ctx.arc(left, top, radius, 0, 2 * Math.PI, false);
        ctx.fill();
        ctx.stroke();
    }

    function updateInput() {
        var radiusStr = document.getElementById('tb-radius').value;
        radius = radiusStr ^ 0;
        LINE_WIDTH = radius * 0.1;

        fieldMinWidth = 0 + radius + LINE_WIDTH;
        fieldMaxWidth = canvas.width - radius - LINE_WIDTH;
        fieldMinHeight = 0 + radius + LINE_WIDTH;
        fieldMaxHeight = canvas.height - radius - LINE_WIDTH;
    }

    function stop() {
        clearInterval(setIntervalHandler);
        setIntervalHandler = null;
    }
    return {
        start: start,
        stop: stop
    }
}());