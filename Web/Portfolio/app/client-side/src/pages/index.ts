import * as $ from 'jquery';

import { updateClockOnInterval } from '../clock/clock';
import { visitPage } from '../storage/storage';

import '../scss/index.scss';

$(() => {
    visitPage('home');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
});