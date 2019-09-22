import Vue from 'vue';
import Router from 'vue-router';

import AllRooms from './views/AllRooms.vue';
import RoomCam from './views/RoomCam.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  linkActiveClass: 'active',
  linkExactActiveClass: 'exact-active',
  scrollBehavior() {
    return { x: 0, y: 0 };
  },
  routes: [
    {
      path: '/',
      redirect: '/all-rooms',
    },
    {
      path: '/all-rooms',
      name: 'all-rooms',
      component: AllRooms,
    },
    {
      path: '/room-cam',
      name: 'room-cam',
      component: RoomCam,
    },
    {
      path: '*',
      redirect: '/errors',
    },
  ],
});
