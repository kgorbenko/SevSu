import * as $ from 'jquery';

let body = $('body');
const lightbox = () => $('#lightbox');
const lightboxImage = () => $('#lightbox img');
const lightboxPrevArrow = () => $('.lightbox-arrow-left');
const lightboxNextArrow = () => $('.lightbox-arrow-right');

let currentPhoto;
let photos;

export default (lightboxPhotosWrapper: Element, photosPaths: string[]) => {
    photos = photosPaths;
    lightboxPhotosWrapper.addEventListener('click', (event) => expandLightbox(event));

    window.onclick = (event) => {
        if (event.target === document.getElementById('lightbox')) {
            collapseLightbox();
        }
    }
}

const expandLightbox = (event) => {
    currentPhoto = event.target.getAttribute('src');
    lightbox().toggle();
    lightboxImage().attr('src', currentPhoto);
    body.addClass('no-scroll');
    lightboxPrevArrow().on('click', prevButtonClickHandler);
    lightboxNextArrow().on('click', nextButtonClickHandler);
};

const collapseLightbox = () => {
    lightbox().toggle();
    lightboxPrevArrow().off();
    lightboxNextArrow().off();
    body.removeClass('no-scroll');
};

const prevButtonClickHandler = () => {
    const currentIndex = photos.indexOf(currentPhoto);
    if (currentIndex === 0 || currentIndex === -1) return;
    currentPhoto = photos[currentIndex - 1];
    lightboxImage().fadeOut('fast', () => {
        lightboxImage().attr('src', currentPhoto).fadeIn('fast');
    });
};

const nextButtonClickHandler = () => {
    const currentIndex = photos.indexOf(currentPhoto);
    if (currentIndex === photos.length - 1 || currentIndex === -1) return;
    currentPhoto = photos[currentIndex + 1];
    lightboxImage().fadeOut('slow', function () {
        lightboxImage().attr('src', currentPhoto).fadeIn('slow');
    });
};