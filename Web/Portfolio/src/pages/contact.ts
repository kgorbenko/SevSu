import { formatCurrentDate, formatCurrentTime } from '../clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator } from '../forms/forms';
import datepicker from '../datepicker/datepicker';

const fields: FormComponent[] = [
    new FormComponent(
        'full-name-input', 
        [
            new NameValidator(),
        ],
    ),
    new FormComponent(
        'email-input',
        [
            new FieldFilledValidator(),
        ]
    ),
    new FormComponent(
        'phone-input',
        [
            new PhoneNumberValidator(),
        ]
    ),
    new FormComponent(
        'message-input',
        [
            new FieldFilledValidator(),
        ]
    ),
];

window.onload = () => {
    const form = document.forms.item(0);
    
    form.addEventListener('submit', validateForm);
    fields.forEach(field => {
        const fieldElement = document.getElementById(field.componentId);
        fieldElement.addEventListener('change', () => validateField(field));
    });

    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatCurrentDate();
        time.innerHTML = formatCurrentTime();
    }, 1000);

    datepicker();
};

const validateField = (field: FormComponent) => {
    const errorsMessages = document.getElementById(`${field.componentId}-errors`);
    if (errorsMessages !== null) {
        errorsMessages.remove();
        document.getElementById(field.componentId).classList.remove('validation-failed');
    }
    field.value = (<HTMLFormElement>document.getElementById(field.componentId)).value;
    field.validate();
    if (field.errorMessages.length > 0) {
        showMessages(field);
    }
};

const validateForm = () => {
    let firstError : FormComponent;
    fields.forEach(field => {
        validateField(field);
        if (!firstError && field.errorMessages.length > 0) {
            firstError = field;
        }
    });
    if (firstError) {
        document.getElementById(firstError.componentId).focus();
    }
    if (fields.some(field => field.errorMessages.length > 0)) {
        event.preventDefault();
    }
};

const showMessages = (field: FormComponent) : void => {
    const targetElement = document.getElementById(field.componentId);
    const parentElement = targetElement.parentElement;
    let contentWrapper = document.createElement('div');
    targetElement.classList.add('validation-failed');
    contentWrapper.setAttribute('id', `${field.componentId}-errors`);
    contentWrapper.setAttribute('class', 'error-messages');
    field.errorMessages.forEach(message => {
        let messageListItem = document.createElement('li');
        messageListItem.innerHTML = message;
        contentWrapper.appendChild(messageListItem);
    });
    parentElement.insertBefore(contentWrapper, targetElement);
};