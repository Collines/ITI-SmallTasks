var interval;
var i = 1;
var moveValue = 50,
  leftElementStartVal = parseInt(
    getComputedStyle(document.getElementById("left")).left
  ),
  rightElementStartVal = parseInt(
    getComputedStyle(document.getElementById("right")).right
  ),
  topElementStartVal = parseInt(
    getComputedStyle(document.getElementById("top")).bottom
  );
var leftMovingRight = true,
  rightMovingLeft = true,
  bottomMovingTop = true,
  running = false;
function move(element) {
  if (!running) {
    running = true;
    element.innerText = running ? "stop" : "go";

    interval = setInterval(function () {
      //left element
      if (!isNaN(parseInt(document.getElementById("left").style.left))) {
        if (
          parseInt(document.getElementById("left").style.left) < 950 &&
          leftMovingRight
        ) {
          document.getElementById("left").style.left =
            parseInt(document.getElementById("left").style.left) +
            moveValue +
            "px";
        } else {
          leftMovingRight = false;
          if (
            parseInt(document.getElementById("left").style.left) > 0 &&
            !leftMovingRight
          ) {
            document.getElementById("left").style.left =
              parseInt(document.getElementById("left").style.left) -
              moveValue +
              "px";
          } else leftMovingRight = true;
        }
      } else {
        document.getElementById("left").style.left =
          leftElementStartVal + moveValue + "px";
      }

      //right element
      if (!isNaN(parseInt(document.getElementById("right").style.right))) {
        if (
          parseInt(document.getElementById("right").style.right) < 950 &&
          rightMovingLeft
        ) {
          document.getElementById("right").style.right =
            parseInt(document.getElementById("right").style.right) +
            moveValue +
            "px";
        } else {
          rightMovingLeft = false;
          if (
            parseInt(document.getElementById("right").style.right) > 0 &&
            !rightMovingLeft
          ) {
            document.getElementById("right").style.right =
              parseInt(document.getElementById("right").style.right) -
              moveValue +
              "px";
          } else rightMovingLeft = true;
        }
      } else {
        document.getElementById("right").style.right =
          rightElementStartVal + moveValue + "px";
      }

      //top element
      if (!isNaN(parseInt(document.getElementById("top").style.bottom))) {
        if (
          parseInt(document.getElementById("top").style.bottom) < 440 &&
          bottomMovingTop
        ) {
          document.getElementById("top").style.bottom =
            parseInt(document.getElementById("top").style.bottom) +
            moveValue +
            "px";
        } else {
          bottomMovingTop = false;
          if (
            parseInt(document.getElementById("top").style.bottom) > 0 &&
            !bottomMovingTop
          ) {
            document.getElementById("top").style.bottom =
              parseInt(document.getElementById("top").style.bottom) -
              moveValue +
              "px";
          } else bottomMovingTop = true;
        }
      } else {
        document.getElementById("top").style.bottom =
          rightElementStartVal + moveValue + "px";
      }
    }, 200);
  } else {
    clearInterval(interval);
    running = false;
    element.innerText = running ? "stop" : "go";
  }
}

function reset() {
  if (running) {
    clearInterval(interval);
    document.getElementById("left").style.left = leftElementStartVal;
    document.getElementById("right").style.right = rightElementStartVal;
    document.getElementById("top").style.bottom = topElementStartVal;
    running = false;
    document.getElementById("go").innerText = running ? "stop" : "go";
  } else {
    document.getElementById("left").style.left = leftElementStartVal;
    document.getElementById("right").style.right = rightElementStartVal;
    document.getElementById("top").style.bottom = topElementStartVal;
  }
}
