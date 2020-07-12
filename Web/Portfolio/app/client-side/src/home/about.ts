import * as $ from 'jquery';

import { updateClockOnInterval } from '../shared/components/clock/clock';
import { visitPage } from '../shared/components/storage/storage';

import './about.scss';

$(() => {
    visitPage('about');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
});