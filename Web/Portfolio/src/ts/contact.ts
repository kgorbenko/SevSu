import { FormFilledValidator, PhoneNumberValidator, NameValidator, FormComponent} from './shared';

const fields: FormComponent[] = [
    new FormComponent(
        'full-name-input', 
        [
            new FormFilledValidator(),
            new NameValidator(),
        ],
    ),
    new FormComponent(
        'email-input',
        [
            new FormFilledValidator(),
        ]
    ),
    new FormComponent(
        'phone-input',
        [
            new FormFilledValidator(),
            new PhoneNumberValidator(),
        ]
    ),
    new FormComponent(
        'message-input',
        [
            new FormFilledValidator(),
        ]
    ),
];

window.onload = () => {
    const form = document.forms.item(0);
    form.addEventListener('change', validateForm);
    form.addEventListener('submit', checkErrorsOnSubmit);
};

const validateForm = () => {
    let firstError : FormComponent;
    fields.forEach(field => {
        const errorsMessages = document.getElementById(`${field.componentId}-errors`);
        if (errorsMessages !== null) {
            errorsMessages.remove();
        }
        field.value = (<HTMLFormElement>document.getElementById(field.componentId)).value;
        field.validate();
        if (field.errorMessages.length > 0) {
            showMessages(field);
            if (!firstError) {
                firstError = field;
            }
        }
        if (firstError) {
            document.getElementById(firstError.componentId).focus();
        }
    });
};

const checkErrorsOnSubmit = () => {
    if (fields.some(field => field.errorMessages.length > 0)) {
        event.preventDefault();
    }
};

const showMessages = (field: FormComponent) : void => {
    const targetElement = document.getElementById(field.componentId);
    const parentElement = targetElement.parentElement;
    let contentWrapper = document.createElement('div');
    contentWrapper.setAttribute('id', `${field.componentId}-errors`);
    contentWrapper.setAttribute('class', 'error-messages');
    field.errorMessages.forEach(message => {
        let messageListItem = document.createElement('li');
        messageListItem.innerHTML = message;
        contentWrapper.appendChild(messageListItem);
    });
    parentElement.insertBefore(contentWrapper, targetElement);
};