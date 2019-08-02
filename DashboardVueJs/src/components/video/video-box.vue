<template>
  <div class="video-box" v-bind:style="{ background: 'url(' + videoViewer.bgImage + ')' }">

    <timeSlider />

    <div id="dataviz" class="dataviz"> 
      <div v-for="person in people" v-bind:key="person.faceId" class="video-box__dataitem person" v-bind:style="{ height: person.faceRectangle.height/2 + 'px', width: person.faceRectangle.width/2 + 'px', top: person.faceRectangle.top/2 + 'px', left: person.faceRectangle.left/2 + 'px' }">
        <div class="person-popover" >
        <span v-for="(value,name) in person.faceAttributes.emotion" v-bind:key="name">
          {{ name }}: {{ value }}
        </span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import timeSlider from '@/components/sliders/time-slider.vue';

const defaultVideoOptions = {
  name: 'Video cam 1',
  bgImage: require('@/assets/images/cam-images/cam-upper-floor-1.png'),
  startTime: 9,
  endTime: 18,
  videoSizeW: '1920',
  videoSizeH: '1080',
};



export default {
  name: 'dataviz',
  components: {
    timeSlider: timeSlider,
  },
  props: {
    /**
       * The video details.
       */
    videoViewer: {
      type: Object,
      default() {
        return defaultVideoOptions;
      },
    },
  },
  data () {
    return {
      people: null
    }
  },
  mounted () {
    axios
      .get('https://raw.githubusercontent.com/DanBadham/museums-d3/master/data.json')
      .then(response => (this.people = response.data))
  }
}
</script> 