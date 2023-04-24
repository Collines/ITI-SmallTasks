var data;
var bandElement = document.getElementById("band");
var artistElement = document.getElementById("artist");
var xhr = new XMLHttpRequest();
xhr.open("GET", "rockbands.json");
xhr.send("");
xhr.onreadystatechange = function () {
  if (xhr.readyState === 4) {
    if (xhr.status === 200) {
      data = JSON.parse(xhr.responseText);
      for (var key in data) {
        var element = document.createElement("option");
        element.setAttribute("value", key);
        element.innerHTML = key;
        bandElement.append(element);
      }
    }
  }
};
function onBandSelect(element) {
  var artists = data[element.value];
  artistElement.innerHTML = "<option selected>please select</option>";
  if (Array.isArray(artists)) {
    for (var i = 0; i < artists.length; i++) {
      var element = document.createElement("option");
      element.setAttribute("value", artists[i].value);
      element.innerHTML = artists[i].name;
      artistElement.append(element);
    }
  }
}

function onArtistSelect(element) {
  open(element.value, "", "width=600,height=600");
}
