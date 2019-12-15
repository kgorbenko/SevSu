import { createElement } from '../utils/utils'

const lightboxId = 'lightbox';
const lightboxClass = 'lightbox';
const lightboxPictureClass = 'lightbox-picture';
const lightboxCloseButtonClass = 'lightbox-close';

export default (lightboxPhotosWrapper: Element) => {
    lightboxPhotosWrapper.addEventListener('click', (event) => expandLightbox(event));

    window.onclick = (event) => {
        if (event.target === document.getElementById(lightboxId)) {
            collapseLightbox();
        }
    }
}

const expandLightbox = (event) => {
    const lightbox = createElement('div', { id: lightboxId, classList: [lightboxClass] });
    const image = createElement('img', { src: event.target.src, classList: [lightboxPictureClass] });
    const closeButton = createElement('div', { innerHTML: '&times', classList: [lightboxCloseButtonClass], onclick: () => collapseLightbox() });

    lightbox.appendChild(image);
    lightbox.appendChild(closeButton);
    document.body.appendChild(lightbox);
}

const collapseLightbox = () => {
    const lightbox = document.getElementById(lightboxId);
    lightbox.remove();
}