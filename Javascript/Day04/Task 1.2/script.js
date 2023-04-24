var interval;
startAnimation();
function startAnimation() {
  reset();
  var elements = document.getElementsByTagName("img");
  var counter = 0;
  interval = setInterval(function () {
    if (counter < elements.length) {
      if (counter > 0) {
        elements[counter - 1].src = "imgs/marble1.jpg";
        elements[counter].src = "imgs/marble3.jpg";
      } else elements[counter].src = "imgs/marble3.jpg";
      counter++;
    } else {
      elements[elements.length - 1].src = "imgs/marble1.jpg";
      elements[0].src = "imgs/marble3.jpg";
      counter = 1;
    }
  }, 1000);
}

function stop() {
  clearInterval(interval);
}

function reset() {
  var elements = document.getElementsByTagName("img");
  for (var i = 0; i < elements.length; i++) {
    elements[i].src = "imgs/marble1.jpg";
  }
}
