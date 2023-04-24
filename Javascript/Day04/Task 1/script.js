var interval,
  globalCounter = 1;
function next() {
  if (globalCounter == 4) globalCounter = 0;
  document.getElementById("img").src = "imgs/0" + ++globalCounter + ".jpg";
}
function previous() {
  if (globalCounter == 1) globalCounter = 5;
  document.getElementById("img").src = "imgs/0" + --globalCounter + ".jpg";
}

function startSlideShow() {
  interval = setInterval(next, 1500);
}

function stopSlideShow() {
  clearInterval(interval);
}
