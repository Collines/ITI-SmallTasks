var searchStr = window.location.search;
searchStr = searchStr
  .replace("?", "")
  .replace(/\+/g, " ")
  .replace("%40", "@")
  .split("&");
var user = {};
for (var i = 0; i < searchStr.length; i++) {
  var splittedVal = searchStr[i].split("=");
  user[splittedVal[0]] = splittedVal[1];
}
if (navigator.userAgent.match(/chrome|chromium|crios/i)) {
  user["browser"] = "Chrome";
} else {
  user["browser"] = "Other";
}
window.document.getElementById("wel").innerHTML =
  "<h1>Welcome " + user["title"] + ". " + user["name"] + "!</h1>";
window.document.getElementById("address").innerHTML =
  "Address: " + user["address"];
window.document.getElementById("gender").innerHTML =
  "Gender: " + user["gender"];
window.document.getElementById("email").innerHTML = "email: " + user["email"];
window.document.getElementById("mobile").innerHTML =
  "mobile: " + user["mobile"];

if (user["browser"] !== "Chrome") {
  document.getElementById("browser").innerHTML =
    "Please Use Chrome for better performance";
}
