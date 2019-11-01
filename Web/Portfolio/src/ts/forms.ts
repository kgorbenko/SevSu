window.onload = () => {
    const form = document.forms.item(0);
    form.addEventListener('submit', validate);
};

const validate = () => {
    const form = document.forms.item(0);
    const formElements = <HTMLFormElement[]>Array.from(form.elements);

    formElements.forEach(element => {
        validateTextField(element) ?
            element.classList.remove('input-error') :
            element.classList.add('input-error');
    });

    if (formElements.some(x => x.classList.contains('input-error'))) {
        event.preventDefault();
    }
};

const validateTextField = (formElement : HTMLFormElement) : Boolean => formElement.value !== '';