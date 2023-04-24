var advertisementWindow;
var scrollVal = 50;
var scrolledVal = 0;
function openAdvertisement() {
  advertisementWindow = open("advertisement.html", "", "width=500,height=500");
  var advertisementEvent = setInterval(function () {
    if (advertisementWindow.document.body.scrollHeight > scrolledVal) {
      advertisementWindow.scrollBy(scrollVal, scrollVal);
      scrolledVal += scrollVal;
    } else {
      clearInterval(advertisementEvent);
    }
  }, 100);
}
