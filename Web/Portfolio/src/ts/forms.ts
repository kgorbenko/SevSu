window.onload = () => {
    const form = document.forms.item(0);
    form.addEventListener('change', () => { return validate(Array.from(form.querySelectorAll('input'))) } );
};

const validate = (inputElements: HTMLInputElement[]) : Boolean => {
    inputElements.forEach(input => {
        input.value === '' ? showMessage(input) : removeMessage(input);
    });
    return inputElements.some(element => element.value === '');
};

const showMessage = (input : HTMLInputElement) => {
    input.classList.add('input-error');
};

const removeMessage = (input : HTMLInputElement) => {
    input.classList.remove('input-error');
};