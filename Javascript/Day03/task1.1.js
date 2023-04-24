var openWindow,
  windowHeight = innerHeight,
  windowWidth = innerWidth,
  moveByValue = 100,
  childInterval,
  Clicked = false;

function stopChild() {
  clearInterval(childInterval);
  Clicked = false;
  openWindow.close();
}

function openChild() {
  openWindow = open("child.html", "", "width=200,height=200");
  var topScroll = false;
  if (!Clicked) {
    openWindow.moveTo(screenX, screenY);
    Clicked = true;
  }
  childInterval = setInterval(function () {
    if (
      innerHeight > openWindow.screenY + openWindow.innerHeight &&
      !topScroll
    ) {
      openWindow.moveBy(moveByValue, moveByValue);
      openWindow.focus();
      openWindow.resizeTo(200, 200);

    } else {
      topScroll = true;
      if (topScroll && openWindow.screenY > 0) {
        openWindow.moveBy(-moveByValue, -moveByValue);
        openWindow.resizeTo(200, 200);
        openWindow.focus();
      } else {
        topScroll = false;
      }
    }
  }, 200);
}
