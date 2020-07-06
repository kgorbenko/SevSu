import * as $ from 'jquery';

import { updateClockOnInterval } from '../clock/clock';
import { visitPage } from '../storage/storage';

import '../scss/about.scss';

$(() => {
    visitPage('about');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
});