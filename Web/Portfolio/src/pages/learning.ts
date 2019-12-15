import { updateClockOnInterval } from '../clock/clock';

window.onload = () => {
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
};