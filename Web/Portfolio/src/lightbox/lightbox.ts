import * as $ from 'jquery';

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
    $('#lightbox img').attr('src', currentPhoto);
    $('#lightbox').toggle();
    $('.lightbox-arrow-left').on('click', prevButtonClickHandler);
    $('.lightbox-arrow-right').on('click', nextButtonClickHandler);
};

const collapseLightbox = () => $('#lightbox').toggle();

const prevButtonClickHandler = () => {
    const currentIndex = photos.indexOf(currentPhoto);
    if (currentIndex === 0 || currentIndex === -1) return;
    currentPhoto = photos[currentIndex - 1];
    $(`.lightbox-picture`).attr('src', currentPhoto);
};

const nextButtonClickHandler = () => {
    const currentIndex = photos.indexOf(currentPhoto);
    if (currentIndex === photos.length - 1 || currentIndex === -1) return;
    currentPhoto = photos[currentIndex + 1];
    $(`.lightbox-picture`).attr('src', currentPhoto);
};