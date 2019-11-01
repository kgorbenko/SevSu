type FormElementValidator = (formElement: HTMLFormElement) => Boolean;

window.onload = () => {
    const form = document.forms.item(0);
    form.addEventListener('submit', validate);
};

const validate = () => {
    const form = document.forms.item(0);
    const formElements = <HTMLFormElement[]>Array.from(form.elements);
    const phoneInputElement = <HTMLFormElement>document.getElementById('phone-input');
    const fullNameTextField = <HTMLFormElement>document.getElementById('full-name-input');
    const textArea = <HTMLFormElement>document.getElementById('question3');

    formElements.forEach(element => {
        addOrRemoveErrorMessage(element, validateTextField);
    });

    addOrRemoveErrorMessage(fullNameTextField, validateFullNameField);
    addOrRemoveErrorMessage(phoneInputElement, validatePhoneField);
    addOrRemoveErrorMessage(textArea, validateTextArea);

    if (formElements.some(x => x.classList.contains('input-error'))) {
        event.preventDefault();
    }
};

const addOrRemoveErrorMessage = (formElement : HTMLFormElement, validator: FormElementValidator) : void => {
    return validator(formElement) ?
        formElement.classList.remove('input-error') :
        formElement.classList.add('input-error');
};

const validateTextArea = (formElement : HTMLFormElement) : Boolean => {
    const result = formElement.value.split(' '); 
    return result.length <= 30;
};

const validateTextField = (formElement : HTMLFormElement) : Boolean => formElement.value !== '';

const validatePhoneField = (formElement : HTMLFormElement) : Boolean => formElement.value.match(/\+\d{11}/);

const validateFullNameField = (formElement : HTMLFormElement) : Boolean => formElement.value.match(/[A-Za-z]+ [A-Za-z]+ [A-Za-z]+/);