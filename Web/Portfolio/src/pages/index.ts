import { formatDate, formatTime } from './clock/clock';

window.onload = () => {
    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatDate();
        time.innerHTML = formatTime();
    }, 1000);
};