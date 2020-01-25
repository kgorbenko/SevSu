import * as $ from 'jquery';

import { updateClockOnInterval } from '../clock/clock';
import { visitPage } from '../storage/storage';

$(() => {
    visitPage('interests');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    $('.contents').on('click', (event) => $(event.target).next().toggle());
});