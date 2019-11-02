window.onload = () => {
    let index = 0;
    const timeout = 100;
    const interval = setInterval(() => {
        if (index === photos.length - 1) {
            clearInterval(interval);
        }
        showPhoto(index);
        index += 1;
    }, timeout);
};

const showPhoto = (index : number) => {
    let photoWrapper = document.getElementsByClassName('photo-wrapper').item(0);
    let img = document.createElement('img');
    img.setAttribute('src', photos[index]);
    img.setAttribute('alt', 'photoalbum photo');
    photoWrapper.appendChild(img);
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
    'salt.jpg',
].map(image => image = `../images/${image}`);