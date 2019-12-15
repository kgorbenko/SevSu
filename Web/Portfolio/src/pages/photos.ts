import { updateClockOnInterval } from '../clock/clock';
import addLightbox from '../lightbox/lightbox';

window.onload = () => {
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    let photoWrapper = document.getElementsByClassName('photo-wrapper').item(0);
    
    photos.forEach(photo => {
        let img = document.createElement('img');
        img.setAttribute('src', photo);
        img.setAttribute('alt', 'photoalbum photo');
        photoWrapper.appendChild(img);
    });

    addLightbox(photoWrapper);
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