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
    '../images/picachu.jpg',
    '../images/images.jpeg',
    '../images/lion-king.jpg',
    '../images/road.jpeg',
    '../images/car.png',
    '../images/bridge.jpg',
    '../images/green.jpeg',
    '../images/statue.jpg',
    '../images/cock.jpg',
    '../images/city.jpg',
    '../images/fire.jpg',
    '../images/rose.jpeg',
    '../images/photo.jpg',
    '../images/castrle.jpg',
    '../images/shimpanze.jpg',
    '../images/salt.jpg',
];