window.onload = function () {
  var openedWindow;
  document.forms[0].onsubmit = function (event) {
    event.preventDefault();
    setCookie("name", document.getElementById("name").value);
    function getGender() {
      var ele = document.getElementsByName("gender");
      for (i = 0; i < ele.length; i++) {
        if (ele[i].checked) return ele[i].value;
      }
      return "";
    }
    setCookie("color", document.getElementsByName("color")[0].value);
    var gender = getGender() == "male" ? "imgs/1.jpg" : "imgs/2.jpg";
    setCookie("gender", gender);
    openedWindow = open("welcome.html", "", "height=500,width=1000;");
    openedWindow.onload = function () {
      if (!hasCookie("visits")) setCookie("visits", 1);
      else {
        setCookie("visits", parseInt(getCookie("visits")) + 1);
      }
      openedWindow.document.getElementById("gender").src = getCookie("gender");
      openedWindow.document.getElementById("welcMsg").innerHTML =
        "<span style='font-size:22px;'>Welcome <span style='color:" +
        getCookie("color") +
        ";font-weight:bold;'>" +
        getCookie("name") +
        "</span> you've visited this site " +
        getCookie("visits") +
        " times</span>";
    };
  };
  // cookie functions

  function getCookie(cookieName) {
    if (hasCookie(cookieName)) {
      var cookieStr = document.cookie.slice(
        document.cookie.indexOf(cookieName)
      );
      var startSplitIndex = cookieStr.search("=");
      var endSplitIndex =
        cookieStr.search(";") > 0 ? cookieStr.search(";") : cookieStr.length;
      var cookieValue = cookieStr.substring(startSplitIndex + 1, endSplitIndex);
      return cookieValue;
    } else return "";
  }

  function deleteCookie(cookieName) {
    if (hasCookie(cookieName)) {
      var date = new Date();
      date.setMonth(date.getMonth() - 1);
      document.cookie = cookieName + "=;expires=" + date.toUTCString();
      return true;
    }
  }

  function setCookie(cookieName, cookieValue, expireDate = "") {
    document.cookie =
      cookieName +
      "=" +
      cookieValue +
      (expireDate != "" ? ";expires=" + expireDate : ";");
  }

  function allCookieList() {
    var list = [];
    var cookies = document.cookie.split("; ");
    for (var i = 0; i < cookies.length; i++) {
      var el = cookies[i].split("=");
      list[el[0]] = el[1];
    }
    return list;
  }

  function hasCookie(cookieName) {
    return document.cookie.includes(cookieName);
  }
};
