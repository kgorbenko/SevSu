import { getGlobalHistory, getSessionHistory, visitPage } from '../storage/storage';

window.onload = () => {
    visitPage('history');
    const globalHistory = getGlobalHistory();
    for (let key in globalHistory) {
        const pageHistoryCell = document.querySelector(`.global-history .${key}`);
        pageHistoryCell.innerHTML = globalHistory[key];
    }
    const sessionHistory = getSessionHistory();
    for (let key in sessionHistory) {
        const pageHistoryCell = document.querySelector(`.session-history .${key}`);
        pageHistoryCell.innerHTML = sessionHistory[key];
    }
}