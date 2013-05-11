var painter = (function () {
    var canvas = document.getElementById("canvas");
    var ctx = canvas.getContext("2d");
    var left, top, width, height;

    function updateInput() {
        var widthString = document.getElementById('tb-width').value;
        width = widthString ^ 0;
        var heightString = document.getElementById('tb-height').value;
        height = heightString ^ 0;
        var leftString = document.getElementById('tb-x').value;
        left = leftString ^ 0;
        var topString = document.getElementById('tb-y').value;
        top = topString ^ 0;
    }

    function drawHouse() {
        var LINE_COLOR = "rgb(0,0,0)";
        var WALL_COLOR = 'rgb(151,91,91)';
        var LINE_WIDTH = 4;
        updateInput();

        //house dimensions
        var roofHeight = height * 0.4;
        var mainHouseHeight = height * 0.6;
        var mainHouseTop = top + roofHeight;
        var mainHouseHorizontalPadding = width * 0.08;
        var mainHouseVerticalPadding = mainHouseHeight * 0.1;
        var windowWidth = width * 0.34;
        var windowsHeight = mainHouseHeight * 0.3
        
        //drawing
        drawMainHouse(left, mainHouseTop, width, mainHouseHeight);
        drawWindow(left + mainHouseHorizontalPadding, mainHouseTop + mainHouseVerticalPadding, windowWidth, windowsHeight);
        drawWindow(left + 3 * mainHouseHorizontalPadding + windowWidth, mainHouseTop + mainHouseVerticalPadding, windowWidth, windowsHeight);
        drawWindow(left + 3 * mainHouseHorizontalPadding + windowWidth, mainHouseTop + 2 * mainHouseVerticalPadding + windowsHeight, windowWidth, windowsHeight);
        drawRoof(left, top, width, roofHeight);
        drawDoor(left + width * 0.12, mainHouseTop + mainHouseHeight * 0.55, width * 0.26, mainHouseHeight * 0.45);

        function drawMainHouse(left, top, width, height) {
            ctx.fillStyle = WALL_COLOR;
            ctx.strokeStyle = LINE_COLOR;
            ctx.lineWidth = LINE_WIDTH;

            ctx.fillRect(left, top, width, height);
            ctx.strokeRect(left, top, width, height);
        }

        function drawWindow(left, top, width, height) {
            ctx.fillStyle = LINE_COLOR;
            ctx.strokeStyle = WALL_COLOR;
            ctx.lineWidth = LINE_WIDTH;

            ctx.fillRect(left, top, width, height);
            ctx.strokeRect(left, top, width, height);

            ctx.strokeRect(left, top, width / 2, height / 2);
            ctx.strokeRect(left + width / 2, top + height / 2, width / 2, height / 2);
        }

        function drawRoof(left, top, width, height) {
            debugger;
            ctx.fillStyle = WALL_COLOR;
            ctx.strokeStyle = LINE_COLOR;
            ctx.lineWidth = LINE_WIDTH;

            ctx.beginPath();
            ctx.moveTo(left, top + height);
            ctx.lineTo(left + width, top + height);
            ctx.lineTo(left + (width / 2), top);
            ctx.lineTo(left, top + height);
            ctx.fill();
            ctx.stroke();

            drawChimney();

            function drawChimney() {
                ctx.fillRect(left + width * 0.75, top + height * 0.25, width * 0.07, height * 0.5);

                ctx.beginPath();
                ctx.moveTo(left + width * 0.75, top + height * 0.75);
                ctx.lineTo(left + width * 0.75, top + height * 0.25);
                ctx.moveTo(left + width * 0.82, top + height * 0.75);
                ctx.lineTo(left + width * 0.82, top + height * 0.25);

                ctx.fill();
                ctx.stroke();

                drawEllipse(left + width * 0.75, top + height * 0.22, width * 0.07, height * 0.06);
            }
        }

        function drawDoor(left, top, width, height) {
            ctx.fillStyle = WALL_COLOR;
            ctx.strokeStyle = LINE_COLOR;
            ctx.lineWidth = LINE_WIDTH;

            //draw straight lines
            ctx.beginPath();
            ctx.moveTo(left, top + height);
            ctx.lineTo(left, top + height * 0.2);
            ctx.moveTo(left + width * 0.5, top + height);
            ctx.lineTo(left + width * 0.5, top);
            ctx.moveTo(left + width, top + height);
            ctx.lineTo(left + width, top + height * 0.2);
            ctx.stroke();

            //draw door handles
            ctx.beginPath();
            ctx.arc(left + width * 0.40, top + height * 0.65, width * 0.04, 0, 2 * Math.PI, false);
            ctx.stroke();
            ctx.beginPath();
            ctx.arc(left + width * 0.60, top + height * 0.65, width * 0.04, 0, 2 * Math.PI, false);
            ctx.stroke();

            //draw door top arcs
            debugger;
            //ctx.save();
            //ctx.translate(150, 100);
            //ctx.scale(width, height * 0.75);
            //ctx.beginPath();
            //ctx.arc(left + width * 0.5, top + height * 0.2, width * 0.5, 0, Math.PI, true);
            //ctx.stroke();
            //ctx.restore();
            drawHalfEllipse(left, top, width, height * 0.4);
        }
    }

    function drawHead() {
        var FACE_COLOR = 'rgb(144,202,215)';
        var FACE_STROKE_COLOR = 'rgb(30,81,92)';
        var HAT_COLOR = 'rgb(57,102,147)';
        var HAT_STROKE_COLOR = 'rgb(0,0,0)';
        var LINE_WIDTH = 4;
        updateInput();

        drawFace(left + width * 0.05, top + height * 0.5, width * 0.9, height * 0.5);
        drawHat(left, top, width, height * 0.6);

        function drawFace(left, top, width, height) {
            ctx.fillStyle = FACE_COLOR;
            ctx.strokeStyle = FACE_STROKE_COLOR;
            ctx.lineWidth = LINE_WIDTH;

            drawEllipse(left, top, width, height);
            drawEye(left + width * 0.1, top + height * 0.25, width * 0.2, height * 0.12);
            drawEye(left + width * 0.5, top + height * 0.25, width * 0.2, height * 0.12);
            drawNose(left + width * 0.25, top + height * 0.35, width * 0.15, height * 0.23);
            drawMouth(left + width * 0.3, top + height * 0.65, width * 0.35, height * 0.1);

            function drawEye(left, top, width, height) {
                drawEllipse(left, top, width, height);
                drawEllipse(left + width * 0.3, top + height * 0.2, width * 0.2, height * 0.7);
            }

            function drawNose(left, top, width, height) {
                ctx.beginPath();
                ctx.moveTo(left + width, top);
                ctx.lineTo(left, top + height);
                ctx.lineTo(left + width, top + height);

                ctx.stroke();
            }

            function drawMouth(left, top, width, height) {
                ctx.rotate(5 * Math.PI / 180);
                drawEllipse(left, top, width, height);
                ctx.rotate(-5 * Math.PI / 180);
            }
        }

        function drawHat(left, top, width, height) {
            ctx.fillStyle = HAT_COLOR;
            ctx.strokeStyle = HAT_STROKE_COLOR;
            drawEllipse(left, top + height * 0.7, width, height * 0.3);
            drawEllipse(left + width * 0.2, top + height * 0.6, width * 0.6, height * 0.3);

            ctx.fillRect(left + width * 0.2, top + height * 0.2, width * 0.6, height * 0.56);

            ctx.beginPath();
            ctx.moveTo(left + width * 0.2, top + height * 0.76);
            ctx.lineTo(left + width * 0.2, top + height * 0.16);
            ctx.moveTo(left + width * 0.8, top + height * 0.76);
            ctx.lineTo(left + width * 0.8, top + height * 0.16);
            ctx.fill();
            ctx.stroke();

            drawEllipse(left + width * 0.2, top + height * 0, width * 0.6, height * 0.3);
        }
    }

    function drawBycicle() {
        var FILL_COLOR = 'rgb(144,202,215)';
        var STROKE_COLOR = 'rgb(51,125,143)';
        var LINE_WIDTH = 2;
        updateInput();


        drawWheels();
        drawFrame();

        function drawWheels() {
            ctx.fillStyle = FILL_COLOR;
            ctx.strokeStyle = STROKE_COLOR;
            ctx.lineWidth = LINE_WIDTH;

            ctx.beginPath();
            ctx.arc(left + width*0.15, top + height * 0.5, width * 0.15, 0, 2 * Math.PI, true);
            ctx.fill();
            ctx.stroke();

            ctx.beginPath();
            ctx.arc(left + width * 0.85, top + height * 0.5, width * 0.15, 0, 2 * Math.PI, true);
            ctx.fill();
            ctx.stroke();
        }

        function drawFrame() {
            ctx.beginPath();
            //frame
            ctx.moveTo(left + width*0.15, top + height * 0.5);
            ctx.lineTo(left + width * 0.50, top + height * 0.5);
            ctx.lineTo(left + width * 0.80, top + height * 0.3);
            ctx.lineTo(left + width * 0.45, top + height * 0.3);
            ctx.lineTo(left + width * 0.15, top + height * 0.5);
            ctx.moveTo(left + width * 0.50, top + height * 0.5);
            ctx.lineTo(left + width * 0.42, top + height * 0.22);
            ctx.stroke();
            //pedals
            drawPedals();
            //seat
            ctx.beginPath();
            ctx.moveTo(left + width * 0.35, top + height * 0.22);
            ctx.lineTo(left + width * 0.49, top + height * 0.22);
            //front suspension
            ctx.moveTo(left + width * 0.85, top + height * 0.5);
            ctx.lineTo(left + width * 0.77, top + height * 0.15);
            //stearing
            ctx.lineTo(left + width * 0.90, top + height * 0.08);
            ctx.moveTo(left + width * 0.77, top + height * 0.15);
            ctx.lineTo(left + width * 0.64, top + height * 0.18);
            ctx.stroke();

            function drawPedals() {
                debugger;
                var radius = width * 0.05;
                var pedalAngle = 45;
                var x = left + width * 0.50;
                var y = top + height * 0.5;
                var deltaX = Math.sin(toRadians(pedalAngle)) * radius;
                var deltaY = Math.cos(toRadians(pedalAngle)) * radius;
                var deltaXPedals = Math.sin(toRadians(pedalAngle)) * radius * 2;
                var deltaYPedals = Math.cos(toRadians(pedalAngle)) * radius * 2;

                ctx.beginPath();
                ctx.arc(x, y,radius, 0, 2 * Math.PI, true);
                ctx.stroke();
                ctx.beginPath();
                
                ctx.moveTo(x - deltaX, y - deltaY);
                ctx.lineTo(x- deltaXPedals, y - deltaYPedals);
                ctx.moveTo(x + deltaX, y + deltaY);
                ctx.lineTo(x + deltaXPedals, y + deltaYPedals);

                //ctx.moveTo(left + width * 0.47, top + height * 0.47);
                //ctx.lineTo(left + width * 0.43, top + height * 0.43);
                //ctx.moveTo(left + width * 0.53, top + height * 0.53);
                //ctx.lineTo(left + width * 0.57, top + height * 0.57);
                ctx.stroke();
            }
        }
    }

    function toRadians(angle) {
        return angle * (Math.PI / 180);
    }

    function drawEllipseByCenter(cx, cy, w, h) {
        drawEllipse(cx - w / 2.0, cy - h / 2.0, w, h);
    }

    function drawEllipse(x, y, w, h) {
        var kappa = .5522848,
        ox = (w / 2) * kappa, // control point offset horizontal
        oy = (h / 2) * kappa, // control point offset vertical
        xe = x + w,           // x-end
        ye = y + h,           // y-end
        xm = x + w / 2,       // x-middle
        ym = y + h / 2;       // y-middle

        ctx.beginPath();
        ctx.moveTo(x, ym);
        ctx.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);
        ctx.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);
        ctx.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);
        ctx.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);
        ctx.closePath();
        ctx.fill();
        ctx.stroke();
    }

    function drawHalfEllipse(x, y, w, h) {
        var kappa = .5522848,
        ox = (w / 2) * kappa, // control point offset horizontal
        oy = (h / 2) * kappa, // control point offset vertical
        xe = x + w,           // x-end
        ye = y + h,           // y-end
        xm = x + w / 2,       // x-middle
        ym = y + h / 2;       // y-middle

        ctx.beginPath();
        ctx.moveTo(x, ym);
        ctx.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);
        ctx.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);
        //ctx.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);
        //ctx.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);
        //ctx.closePath();
        ctx.stroke();
    }

    function clear() {
        debugger;
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }

    return {
        drawHouse: drawHouse,
        drawHead: drawHead,
        drawBycicle: drawBycicle,
        clear: clear
    }
}());