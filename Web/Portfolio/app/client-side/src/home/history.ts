import * as $ from 'jquery';

import { getGlobalHistory, getSessionHistory, visitPage } from '../shared/components/storage/storage';
import { updateClockOnInterval } from "../shared/components/clock/clock";

import './history.scss';

$(() => {
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    visitPage('history');
    const globalHistory = getGlobalHistory();
    for (let key in globalHistory) {
        $(`.global-history .${key}-page`).append(globalHistory[key]);
    }
    const sessionHistory = getSessionHistory();
    for (let key in sessionHistory) {
        $(`.session-history .${key}-page`).append(sessionHistory[key]);
    }
});