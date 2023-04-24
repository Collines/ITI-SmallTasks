var message = "Welcome to Javascript";
var counter = 0;
var newWindow;
function showMessage() {
  newWindow = open("child.html", "", "width=500,height=500");
  var messageEvent = setInterval(function () {
    if (counter < message.length) {
      newWindow.document.getElementById("output").innerHTML =
        newWindow.document.getElementById("output").innerHTML +
        message[counter++];
    } else {
      clearInterval(messageEvent);
      newWindow.close();
    }
  }, 100);
}
