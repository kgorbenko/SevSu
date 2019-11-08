export {}

interface FormFilledValidator {
    errorMessage: string;
    validate(value: string): Boolean;
}

class FieldFilledValidator implements FormFilledValidator {
    errorMessage = 'This field should be filled';
    validate = (value: string) : Boolean => {
        return value !== '';
    };
}

class PhoneNumberValidator implements FormFilledValidator {
    errorMessage = 'Entered number is in incorrect format';
    validate = (value: string) : Boolean => {
        const pattern = /^[+][7|3]\d{9,11}$/g;
        return pattern.test(value);
    };
}

class NameValidator implements FormFilledValidator {
    errorMessage = 'Enter three space-separated words';
    validate = (value: string) : Boolean => {
        const pattern = /[A-Za-z]+ [A-Za-z]+ [A-Za-z]+/
        return pattern.test(value);
    };
}

class FormComponent {
    componentId: string;
    value: string;
    errorMessages: string[];
    validators: FormFilledValidator[];

    constructor(componentId: string, validators: FormFilledValidator[]){
        this.componentId = componentId;
        this.validators = validators;
        this.errorMessages = [];
    };

    validate = () : void => {
        this.validators.forEach(validator => {
            const message = validator.errorMessage;
            if (validator.validate(this.value)) {
                this.errorMessages.splice(this.errorMessages.indexOf(message), 1);
            }
            else {
                if (!this.errorMessages.includes(message)) {
                    this.errorMessages.push(message);
                }
            }
        });
    };
}

const fields: FormComponent[] = [
    new FormComponent(
        'full-name-input', 
        [
            new FieldFilledValidator(),
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
            new FieldFilledValidator(),
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
};

const validateField = (field: FormComponent) => {
    const errorsMessages = document.getElementById(`${field.componentId}-errors`);
    if (errorsMessages !== null) {
        errorsMessages.remove();
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
    contentWrapper.setAttribute('id', `${field.componentId}-errors`);
    contentWrapper.setAttribute('class', 'error-messages');
    field.errorMessages.forEach(message => {
        let messageListItem = document.createElement('li');
        messageListItem.innerHTML = message;
        contentWrapper.appendChild(messageListItem);
    });
    parentElement.insertBefore(contentWrapper, targetElement);
};