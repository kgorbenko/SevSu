export const formatDate = (date: Date): string => {
    return `${date.getDate()}.` +
           `${date.getMonth() + 1}.` +
           `${date.getFullYear()}`;
}

export const formatTime = (time : Date): string => {
    return time.toLocaleString(window.navigator.language, { hour: '2-digit', minute: '2-digit', second: '2-digit' });
};

const formatCurrentDate = () => {
    return formatDate(new Date());
};

const formatCurrentTime = (): string => {
    return formatTime(new Date());
};

export const updateClockOnInterval = (dateElement: HTMLElement, timeElement: HTMLElement, interval: number) => {
    dateElement.innerHTML = formatCurrentDate();
    timeElement.innerHTML = formatCurrentTime();
    setInterval(() => {
        dateElement.innerHTML = formatCurrentDate();
        timeElement.innerHTML = formatCurrentTime();
    }, interval);
};