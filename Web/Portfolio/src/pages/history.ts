import * as $ from 'jquery';

import { getGlobalHistory, getSessionHistory, visitPage } from '../storage/storage';

$(() => {
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