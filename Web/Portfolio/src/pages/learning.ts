window.onload = () => {
    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        const currentDate = new Date();
        date.innerHTML = `${currentDate.getDate()}.` +
                         `${currentDate.getMonth() + 1}.${currentDate.getFullYear()}, ` +
                         `${currentDate.toLocaleString(window.navigator.language, { weekday: 'long'})}`;
        time.innerHTML = currentDate.toLocaleString(window.navigator.language, { hour: '2-digit', minute: '2-digit', second: '2-digit' });
    }, 1000);
};