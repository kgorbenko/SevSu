import { formatDate, formatTime } from '../clock/clock';

window.onload = () => {
    let photoWrapper = document.getElementsByClassName('photo-wrapper').item(0);
    
    photos.forEach(photo => {
        let img = document.createElement('img');
        img.setAttribute('src', photo);
        img.setAttribute('alt', 'photoalbum photo');
        photoWrapper.appendChild(img);
    });
    photoWrapper.addEventListener('click', (event) => expandPhoto(event));
    window.onclick = (event) => {
        if (event.target === document.getElementById('modal')) {
            collapsePhoto();
        }
    }

    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatDate();
        time.innerHTML = formatTime();
    }, 1000);
};

const expandPhoto = (event) => {
    const modal = document.createElement('div');
    modal.id = 'modal';
    modal.classList.add('modal');

    const image = document.createElement('img');
    image.setAttribute('src' ,event.target.src);
    image.classList.add('modal-picture');

    const closeButton = document.createElement('div');
    closeButton.innerHTML = '&times';
    closeButton.setAttribute('class', 'modal-close');
    closeButton.onclick = onclick = (() => collapsePhoto());

    modal.appendChild(closeButton);
    modal.appendChild(image);
    document.body.appendChild(modal);
};

const collapsePhoto = () => {
    const modal = document.getElementById('modal');
    modal.remove();
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
    'castle.jpg',
    'shimpanze.jpg',
].map(image => image = `../images/${image}`);