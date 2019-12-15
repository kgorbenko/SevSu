import { createElement } from '../utils/utils'

const modalId = 'modal';
const modalClass = 'modal';
const modalPictureClass = 'modal-picture';
const modalCloseButtonClass = 'modal-close';

export const addModal = (modalTarget: Element) => {
    modalTarget.addEventListener('click', (event) => expandPhoto(event));

    window.onclick = (event) => {
        if (event.target === document.getElementById(modalId)) {
            collapsePhoto();
        }
    }
}

const expandPhoto = (event) => {
    const modal = createElement('div', { id: modalId, classList: [modalClass] });
    const image = createElement('img', { src: event.target.src, classList: [modalPictureClass] });
    const closeButton = createElement('div', { innerHTML: '&times', classList: [modalCloseButtonClass], onclick: () => collapsePhoto() });

    modal.appendChild(image);
    modal.appendChild(closeButton);
    document.body.appendChild(modal);
}

const collapsePhoto = () => {
    const modal = document.getElementById(modalClass);
    modal.remove();
}