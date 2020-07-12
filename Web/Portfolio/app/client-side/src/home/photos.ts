import * as $ from 'jquery';

import { updateClockOnInterval } from '../shared/components/clock/clock';
import { createElement } from '../shared/utils/dom';
import addLightbox from '../shared/components/lightbox/lightbox';
import { visitPage } from '../shared/components/storage/storage';

import './photos.scss';
import '../shared/components/lightbox/lightbox.scss';

$(() => {
    visitPage('photos');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    let photoWrapper = document.querySelector('.photo-wrapper');

    photos.forEach(photo => {
        let img = createElement('img', { src: photo, alt: 'photoalbum photo' });
        photoWrapper.appendChild(img);
    });

    addLightbox(photoWrapper, photos);
});

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
].map(image => `../client-side/images/${image}`);