window.onload = () => {
    let photoWrapper = document.getElementsByClassName('photo-wrapper').item(0);
    const date = document.getElementById('date');
    const time = document.getElementById('time');
    photos.forEach(photo => {
        let img = document.createElement('img');
        img.setAttribute('src', photo);
        img.setAttribute('alt', 'photoalbum photo');
        photoWrapper.appendChild(img);
    });
    setInterval(() => {
        const currentDate = new Date();
        date.innerHTML = `${currentDate.getDate()}.` +
                            `${currentDate.getMonth() + 1}.${currentDate.getFullYear()}, ` +
                            `${currentDate.toLocaleString(window.navigator.language, { weekday: 'long'})}`;
        time.innerHTML = currentDate.toLocaleString(window.navigator.language, { hour: '2-digit', minute: '2-digit', second: '2-digit' });
    }, 1000);
};

const photos : string[] = [
    'picachu.jpg',
    'images.jpeg',
    'lion-king.jpg',
    'road.jpeg',
    'car.png',
    'bridge.jpg',
    'green.jpeg',
    'statue.jpg',
    'cock.jpg',
    'city.jpg',
    'fire.jpg',
    'rose.jpeg',
    'photo.jpg',
    'castrle.jpg',
    'shimpanze.jpg',
].map(image => image = `../images/${image}`);