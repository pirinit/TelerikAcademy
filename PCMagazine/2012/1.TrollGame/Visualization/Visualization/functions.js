var rowOffset;
var colOffset;
var removedRocks = 0;
var removedRocksCurrent = 0;
var matrixSize = 30;
var turnNumber = 0;
var m = new Array();
var turns = new Array();
var play = true;
var isMatrixBig = false;
function PlayNext() {
    if (play == true) {
        SetInitialPossition();
        if (m.length > matrixSize) {
            isMatrixBig = true;
        }
        play = false;
    }
    ClearCellClasses();
    var move = turns[turnNumber][0];
    var row = turns[turnNumber][1];
    var col = turns[turnNumber][2];
    m[row][col] = m[row][col] + move;
    removedRocks += -move;
    ShowFocus(row, col);
    CheckNeighbors(row, col);
    ShowMatrix();
    turnNumber++;
    document.getElementById('removedRocks').innerText = removedRocks;
    document.getElementById('turnNumber').innerText = turnNumber;
}

function ShowMatrix(){
	for(var row = 0; row<matrixSize; row++)
	{
		for(var col = 0; col<matrixSize; col++)
		{
			var content =(0 <= row+rowOffset && row+rowOffset < matrixSize && 0 <= col+colOffset && col+colOffset <matrixSize)? m[row+rowOffset][col+colOffset] : ' ';
			document.getElementById(row + '-' + col).innerHTML = content;
		}
	}	
}

function ClearCellClasses() {
    for (var row = 0; row < matrixSize; row++) {
        for (var col = 0; col < matrixSize; col++) {
            document.getElementById(row + '-' + col).className = "cell";
        }
    }
}
function ShowFocus(focusedCellRow, focusedCellCol) {
    rowOffset = focusedCellRow - (matrixSize / 2);
    colOffset = focusedCellCol - (matrixSize / 2);
    document.getElementById((focusedCellRow - rowOffset) + '-' + (focusedCellCol - colOffset)).className = "selected";
}

function CheckNeighbors(row, col)
{
    removedRocksCurrent = 0;
    if (m[row][col] == 0) {
        return;
    }
	if(row-1 > -1 && m[row][col] == m[row-1][col]){
	    removedRocksCurrent = removedRocksCurrent + m[row - 1][col];
		m[row - 1][col] = 0;

		document.getElementById((row - 1 - rowOffset) + "-" + (col - colOffset)).className = "demolished";
	}
	if (row + 1 < matrixSize && m[row][col] == m[row + 1][col]) {
	    removedRocksCurrent = removedRocksCurrent + m[row + 1][col];
	    m[row + 1][col] = 0;
	    document.getElementById((row + 1 - rowOffset) + "-" + (col - colOffset)).className = "demolished";
	}
	if (col - 1 > -1 && m[row][col] == m[row][col-1]) {
	    removedRocksCurrent = removedRocksCurrent + m[row][col - 1];
	    m[row][col - 1] = 0;
	    document.getElementById((row - rowOffset) + "-" + (col - 1 - colOffset)).className = "demolished";
	}
	if (col + 1 < matrixSize && m[row][col] == m[row][col+1]) {
	    removedRocksCurrent = removedRocksCurrent + m[row][col + 1];
	    m[row][col + 1] = 0;
	    document.getElementById((row - rowOffset) + "-" + (col + 1 - colOffset)).className = "demolished";
	}
	if (removedRocksCurrent > 0) {
	    removedRocksCurrent = removedRocksCurrent + m[row][col];
	    m[row][col] = 0;
	    removedRocks = removedRocks + removedRocksCurrent;
	}
}