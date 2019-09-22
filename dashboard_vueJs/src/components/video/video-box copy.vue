<template>
  <div class="data-viewer">
    <div id="dataviz" class="dataviz">[Video content]</div>
  </div>
</template>

<script>
var request = new XMLHttpRequest();
request.open('GET', 'https://raw.githubusercontent.com/DanBadham/museums-d3/master/data.json', true);
request.onload = function() {
  if (this.status >= 200 && this.status < 400) {
  // Success!
  var data = JSON.parse(this.response);
  //console.log(data); 
  var el = document.querySelector('#dataviz');
  var output = '<div>'; 
  for ( var i = 0; i < data.length; i++) {
		var obj = data[i];
    // console.log(obj);
    var personName;
    var posX;
    var posY;
    var headWidth;
    var headPoseYaw;
    var emotion;
    var age;
    var gender;

    posX = obj.faceRectangle.left/2;
    posY = obj.faceRectangle.top/2;
    headWidth = obj.faceRectangle.width/4;
    headPoseYaw = obj.faceAttributes.headPose.yaw;
    emotion = obj.faceAttributes.emotion;
    age = obj.faceAttributes.age;
    gender = obj.faceAttributes.gender;

    var headPoseYawCss = "arrow-left";
    if(headPoseYaw>5){
      headPoseYawCss = "arrow-right";
    };

    output += '<div class="person" style="height:' + headWidth + 'px;width:' + headWidth + 'px;top:' + posY + 'px;left:' + posX + 'px;">'
    // + val.faceRectangle.top 
    + '<div class="person-view ' + headPoseYawCss + '"></div>'
    + '<span class="person-popover above">'
    + 'Gender: ' + gender + '</br>'
    + 'Age: ' + age + '</br>'
    + 'Happiness: ' + emotion.happiness + '</br>'
    + 'Sadness: ' + emotion.sadness + '</br>'
    + 'Surprise: ' + emotion.surprise + '</br>'
    + 'Neutral: ' + emotion.neutral + '</br>'
    + '</span>'
    + '</div>';
    
    // if we wanted to go down a level could of used something like this...
    // for ( var key in obj) {
		// 	personName = key;
    //   posX = obj[key].faceRectangle.left/2;
    //   console.log(posX);
    // }
    
		el.innerHTML += output;
	}

  } else {
    // We reached our target server, but it returned an error

  }
};

request.onerror = function() {
  // There was a connection error of some sort
};

request.send();

const defaultVideoOptions = {
  name: 'Video cam 1',
  image: require('@/assets/images/cam-images/cam-upper-floor-1.png'),
  startTime: 9,
  endTime: 18,
  videoSizeW: '1920',
  videoSizeH: '1080',
};

export default {
  name: 'video-box',
  props: {
    /**
       * The video details.
       */
    videoBox: {
      type: Object,
      default() {
        return defaultVideoOptions;
      },
    },
  },
};


</script>
