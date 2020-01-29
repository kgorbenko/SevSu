import * as $ from 'jquery';

export interface IModalOptions {
    message?: string;
    confirmButtonText?: string;
    cancelButtonText?: string;
    confirmAction?: () => void;
    cancelAction?: () => void;
}

const body = $('body');
const getModal = () => $('.modal');
const message = 'Do you really want to do this?';
const confirmButtonText = 'Yes';
const cancelButtonText = 'No';

export default (options: IModalOptions) => {
    $('.modal-message').text(options.message || message);
    $('.modal-confirm-button').text(options.confirmButtonText || confirmButtonText).off('click').on('click', getAction(options.confirmAction));
    $('.modal-cancel-button').text(options.cancelButtonText || cancelButtonText).off('click').on('click', getAction(options.cancelAction));
    expandModal();
}

const expandModal = () => {
    body.addClass('no-scroll');
    getModal().toggle();
};

const collapseModal = () => {
    body.removeClass('no-scroll');
    getModal().toggle();
};

const getAction = (action: () => void) => {
    if (action) {
        return () => { collapseModal(); action(); }
    }
    return () => collapseModal();
};