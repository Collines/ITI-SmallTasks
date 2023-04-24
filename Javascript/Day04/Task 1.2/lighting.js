var elements = document.getElementsByTagName("img");
var phase = 1;
var interval = setInterval(() => {
  switch (phase) {
    case 1:
      for (var i = 0; i < elements.length; i++) {
        if (i != 3) {
          elements[i].src = "imgs/marble3.jpg";
        } else {
          elements[i].src = "imgs/marble2.jpg";
        }
      }
      phase++;
      break;
    case 2:
      for (var i = 0; i < elements.length; i++) {
        if (i != 3) {
          elements[i].src = "imgs/marble1.jpg";
        } else {
          elements[i].src = "imgs/marble3.jpg";
        }
      }
      phase++;
      break;
    case 3:
      for (var i = 0; i < elements.length; i++) {
        if (i != 3) {
          elements[i].src = "imgs/marble2.jpg";
        } else {
          elements[i].src = "imgs/marble1.jpg";
        }
      }
      phase = 1;
      break;
    default:
      break;
  }
}, 1300);
