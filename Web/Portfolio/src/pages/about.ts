import { updateClockOnInterval } from '../clock/clock';
import { visitPage } from '../storage/storage';

window.onload = () => {
    visitPage('about');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
};