import * as $ from 'jquery';

import { updateClockOnInterval } from '../clock/clock';
import { createElement } from '../utils/dom';
import addLightbox from '../lightbox/lightbox';
import { visitPage } from '../storage/storage';

import '../scss/photos.scss';
import '../lightbox/lightbox.scss';

$ () ->
    visitPage 'photos'
    updateClockOnInterval (document.getElementById 'date'), (document.getElementById 'time'), 1000
    photoWrapper = document.querySelector '.photo-wrapper'

    photos.forEach (photo) ->
        img = createElement 'img', { src: photo, alt: 'photoalbum photo' }
        photoWrapper.appendChild(img)

    addLightbox photoWrapper, photos

photos = [
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
].map (image) -> "../images/#{image}"