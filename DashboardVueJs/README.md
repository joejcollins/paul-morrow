
<p>
Museums Dashboard - original prototype built using the Shards VueJs (lite version) dashboard to make visual build quicker. This provides a navigation system, and 2 main templates/views - homepage and video data page, and the implementation of NoUiSlider, Icons and a number of pre-built components if needed. ChartsJs was also part of the Shards template system. 
</p>

<p>Azure Face API Data - In this prototype we are using a simple call to an external JSON file, which is essentially a copy of the JSON returned by Azure. This is to give a simple idea of what we could implement visually with the returned data. </p>

### Quick Start

* Install dependencies by running `yarn`.
* Run `yarn serve` to start the local development server.
* 😎 **That's it!** You're ready to start building awesome dashboards.

<br />

### Project Structure

* All templates are located inside `src/views` and most of them are self-contained.
* There's only one single layout defined (Default) inside `src/layouts`, however the current structure provides an easy way of extending the UI kit.
* The `src/components` directory hosts all template-specific subcomponents in their own subdirectory.
* Almost all components have their styles isolated in SFC, however, some global styles are also placed inside `src/assets/scss` next to Shards Dashboard Lite's base styles.
* The `src/utils` directory contains generic Chart.js utilities.

<br />

### Built using...

#### Shards VueJs provided the following
* [Shards Vue](https://designrevision.com/downloads/shards-vue)
* [Chart.js](http://www.chartjs.org/)
* [Vue Datepicker](https://github.com/charliekassel/vuejs-datepicker)
* [NoUiSlider](https://refreshless.com/nouislider/)
* [Quill](https://quilljs.com/)
* [Material Icons](http://material.io/icons)
* [FontAwesome Icons](http://fontawesome.io)

<br />

### Changelog

Please check out the [CHANGELOG](CHANGELOG.md).
