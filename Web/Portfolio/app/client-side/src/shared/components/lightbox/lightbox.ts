import * as $ from 'jquery';

let body = $('body');
const lightbox = () => $('#lightbox');
const lightboxImage = () => $('#lightbox img');
const lightboxPrevArrow = () => $('.lightbox-arrow-left');
const lightboxNextArrow = () => $('.lightbox-arrow-right');

let currentPhoto;
let photos;

export default (photosPaths: string[]) => {
    photos = photosPaths;
    $('.photo-wrapper img').on('click', (event) => expandLightbox(event));

    lightbox().on('click', (event) => {
        if (event.target !== document.querySelector('.lightbox-content') &&
        event.target !== lightboxNextArrow().get(0) && event.target !== lightboxPrevArrow().get(0)) {
            collapseLightbox();
        }
    })
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