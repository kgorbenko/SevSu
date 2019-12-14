import { formatCurrentDate, formatCurrentTime } from '../clock/clock';

window.onload = () => {
    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatCurrentDate();
        time.innerHTML = formatCurrentTime();
    }, 1000);
};