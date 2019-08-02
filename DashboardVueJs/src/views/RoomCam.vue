<template>
  <d-container fluid class="main-content-container px-0 py-0">
    <!-- Page Header -->
    <!-- <div class="page-header row no-gutters py-4">
      <div class="col-12 col-sm-4 text-center text-sm-left mb-0">
        <span class="text-uppercase page-subtitle">Bristol Museums &amp; Art Gallery</span>
        <h3 class="page-title">Front hall - Today 15:35:22</h3>
      </div>
    </div> -->

    <!-- Video container -->
    <d-row>
      <d-col>
        <video-box />
      </d-col>
    </d-row>

     <!-- Stats container -->
     <p class="ml-4 mt-3">Cam stats (today - 9am to 11.56am)</p>
    <d-row>
      <d-col lg="4" md="12" sm="12" class="pl-5 pr-2">
        <d-row>
        <d-col v-for="(post, idx) in CamStatsOne" :key="idx" lg="6" md="12" sm="12" class="mb-4">
          <d-card class="card-small card-post card-post--1">
            <d-card-body>
              <span class="text-muted text-uppercase">{{ post.title }}</span>
              <h5 class="card-title">
                <a href="#" class="text-fiord-blue">{{ post.result }}</a>
              </h5>
            </d-card-body>
          </d-card>
        </d-col>
        </d-row>
      </d-col>
      <d-col lg="8" md="12" sm="12" class="pr-5">
        <d-row>
      <d-col v-for="(post, idx) in CamStatsTwo" :key="idx" lg="4" md="12" sm="12" class="mb-4">
        <d-card class="card-small card-post card-post--1">
          <d-card-body>
            <span class="text-muted text-uppercase">{{ post.title }}</span>
            <h5 class="card-title">
              <a href="#" class="text-fiord-blue">{{ post.result }}</a>
            </h5>
          </d-card-body>
        </d-card>
      </d-col>
      </d-row>
      </d-col>
    </d-row>

  </d-container>
</template>

<script>
import VideoBox from '@/components/video/video-box.vue';

// Camera stats
const CamStatsOne = [{
  title: 'Visitors',
  result: '100',
},{
  title: 'Average age',
  result: '25',
},{
  title: 'Male/female',
  result: '50/50',
},{
  title: 'Beards',
  result: '24',
}];

const CamStatsTwo = [{
  title: 'Smile score',
  result: '0.8',
},{
  title: 'Neutral',
  result: '0.5',
},{
  title: 'Happiness',
  result: '0.75',
},{
  title: 'Anger',
  result: '0.05',
}];

export default {
  name: 'room-dash',
  components: {
    videoBox: VideoBox,
  },
  data() {
    return {
      CamStatsOne,
      CamStatsTwo,
    };
  },
};
</script>

