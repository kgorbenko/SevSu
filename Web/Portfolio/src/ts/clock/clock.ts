export const formatDate = () : string => {
    const currentDate = new Date();
    
    return `${currentDate.getDate()}.
            ${currentDate.getMonth() + 1}.
            ${currentDate.getFullYear()},
            ${currentDate.toLocaleString(window.navigator.language, { weekday: 'long'})}`;
};

export const formatTime = () : string => {
    const currentTime = new Date();
    return currentTime
           .toLocaleString(window.navigator.language, { hour: '2-digit', minute: '2-digit', second: '2-digit' });
};