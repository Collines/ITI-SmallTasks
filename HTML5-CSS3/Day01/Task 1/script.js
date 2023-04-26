window.onload = (e) => {
  var Vid = document.getElementById("Vid");
  var VideoBar = document.getElementById("videobar");
  VideoBar.max = parseInt(Vid.duration.toFixed());
  var PlayBtn = document.getElementById("PlayBtn");
  var ResetBtn = document.getElementById("ResetBtn");
  var GoBackBtn = document.getElementById("GoBackBtn");
  var GoForwardBtn = document.getElementById("GoForwardBtn");
  var EndBtn = document.getElementById("EndBtn");
  var VolumeBar = document.getElementById("VolumeBar");
  var MuteBtn = document.getElementById("MuteBtn");
  var PlaybackSpeedBtn = document.getElementById("PlaybackSpeedBtn");

  var currTime = document.getElementById("currTime");
  var TotalTime = document.getElementById("TotalTime");
  TotalTime.innerHTML = parseInt(Vid.duration.toFixed());
  var PlaySpeed = document.getElementById("PlaySpeed");

  var videoBarInterval;
  PlayBtn.addEventListener("click", function () {
    if (Vid.paused) {
      Vid.play();
      this.innerHTML = "Pause";
      // videoBarInterval = setInterval(() => {
      //   updateData();
      // }, 1000);
    } else {
      Vid.pause();
      this.innerHTML = "Play";
      // clearInterval(videoBarInterval);
    }
  });

  Vid.ontimeupdate = function () {
    updateData();
  };

  ResetBtn.addEventListener("click", function () {
    Vid.currentTime = 0;
  });

  VideoBar.addEventListener("input", function () {
    Vid.currentTime = this.value;
    updateData();
  });

  GoBackBtn.addEventListener("click", function () {
    Vid.currentTime -= 5;
    updateData();
  });
  GoForwardBtn.addEventListener("click", function () {
    Vid.currentTime += 5;
    updateData();
  });

  EndBtn.addEventListener("click", function () {
    Vid.currentTime = Vid.duration;
    updateData();
  });

  VolumeBar.addEventListener("input", function () {
    Vid.volume = +this.value;
  });

  MuteBtn.addEventListener("click", function () {
    if (Vid.muted) {
      Vid.volume = 1;
      VolumeBar.value = 1;
      this.innerHTML = "Mute";
      Vid.muted = false;
    } else {
      Vid.volume = 0;
      VolumeBar.value = 0;
      Vid.muted = true;
      this.innerHTML = "Unmute";
    }
  });

  PlaybackSpeedBtn.addEventListener("click", function () {
    Vid.playbackRate = this.value;
    PlaySpeed.innerHTML = Vid.playbackRate + "x";
  });
  function updateData() {
    VideoBar.value = +Vid.currentTime.toFixed();
    currTime.innerHTML = +Vid.currentTime.toFixed();
  }
};
