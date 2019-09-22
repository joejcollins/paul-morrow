export default function () {
  return [{
    title: 'All rooms',
    to: {
      name: 'all-rooms',
    },
    htmlBefore: '<i class="material-icons">home</i>',
    htmlAfter: '',
  }, {
    title: 'Upper floor - exhibition camera',
    htmlBefore: '<i class="material-icons">camera</i>',
    to: {
      name: 'room-cam',
    },
  }, {
    title: 'Upper floor - exhibition camera 2',
    htmlBefore: '<i class="material-icons">camera</i>',
    to: {
      name: 'room-cam',
    },
  }, {
    title: 'Lower floor - Hall camera',
    htmlBefore: '<i class="material-icons">camera</i>',
    to: {
      name: 'room-cam',
    },
  }, {
    title: 'Lower floor - Outdoor exhibition',
    htmlBefore: '<i class="material-icons">table_chart</i>',
    to: {
      name: 'room-cam',
    },
  }];
}
