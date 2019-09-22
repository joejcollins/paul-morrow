<template>
    <div class="time-slider time-slider--top">
        <d-slider v-model="sliderValue"
            :value="['0', '2.00']"
            :options="{ pips: { mode: 'steps', stepped: true, density: 2 } }"
            :connect="true" 
            :range="{ min: 0, max: 12 }"/>
        <span class="time-slider__info">Time range: {{ sliderValue }} hours</span>
    </div>
</template>

<script>
    export default {
        name: 'time-slider',
        data() {
            return {
                sliderValue: ['0', '2']
            }
        }
    }
</script>