import * as $ from 'jquery';
import 'tooltipster';

export interface FormValidator {
    errorMessage: string;
    validate(value: string): Boolean;
}

export class FieldFilledValidator implements FormValidator {
    errorMessage = 'This field should be filled';
    validate = (value: string) : Boolean => {
        return value !== '';
    };
}

export class PhoneNumberValidator implements FormValidator {
    errorMessage = 'Entered number is in incorrect format';
    validate = (value: string) : Boolean => {
        const pattern = /^[+][7|3]\d{9,11}$/g;
        return pattern.test(value);
    };
}

export class NameValidator implements FormValidator {
    errorMessage = 'Enter three space-separated words';
    validate = (value: string) : Boolean => {
        const pattern = /[A-Za-z]+ [A-Za-z]+ [A-Za-z]+/
        return pattern.test(value);
    };
}

export class DetailedAnswerValidator implements FormValidator {
    errorMessage = 'Too many words. Should be less than 30';
    validate = (value: string) : Boolean => {
        return value.split(' ').length <= 30;
    };
}

export class DateValidator implements FormValidator {
    errorMessage = 'Date was not in correct format';
    validate = (value: string) : Boolean => {
        const pattern = /^\d{1,2}\.\d{1,2}\.\d{4}$/;
        return pattern.test(value);
    };
}

export class FormComponent {
    componentId: string;
    errorMessages: string[];
    validators: FormValidator[];
    correctValueDescription: string;

    constructor(componentId: string, validators: FormValidator[], correctValueDescription: string){
        this.componentId = componentId;
        this.validators = validators;
        this.errorMessages = [];
        this.correctValueDescription = correctValueDescription;
    };

    value = () => (<HTMLFormElement>document.getElementById(this.componentId)).value;

    validate = () : void => {
        this.validators.forEach(validator => {
            const message = validator.errorMessage;
            if (validator.validate(this.value())) {
                if (this.errorMessages.includes(message)) {
                    this.errorMessages.splice(this.errorMessages.indexOf(message), 1);
                }
            }
            else {
                if (!this.errorMessages.includes(message)) {
                    this.errorMessages.push(message);
                }
            }
        });
    };
}

export const setFieldsForValidation = (fields: FormComponent[], form: HTMLFormElement) => {
    $(form).on('submit', (event) => validateForm(event, fields));
    fields.forEach(formComponent => {
        const field =  $(`#${formComponent.componentId}`);
        field.on('blur', () => validateField(formComponent));
        field.tooltipster({ content: formComponent.correctValueDescription, theme: 'tooltipster-light', side: 'right' });
    });
};

const validateForm = (event, fields) => {
    let firstError : FormComponent;
    fields.forEach(field => {
        validateField(field);
        if (!firstError && field.errorMessages.length > 0) {
            firstError = field;
        }
    });
    if (firstError) {
        $(`#${firstError.componentId}`).trigger('focus');
    }
    if (fields.some(field => field.errorMessages.length > 0)) {
        event.preventDefault();
    }
};

const validateField = (field: FormComponent) => {
    const presentErrorMessages = $(`#${field.componentId}-errors`);
    if (presentErrorMessages.length > 0) {
        presentErrorMessages.remove();
        $(`#${field.componentId}`).removeClass('validation-failed');
    }
    field.validate();
    if (field.errorMessages.length > 0) {
        showMessages(field);
    }
};

const showMessages = (field: FormComponent) => {
    const targetElement = $(`#${field.componentId}`).addClass('validation-failed');
    let contentWrapper = $('<div></div>').attr('id', `${field.componentId}-errors`).addClass('error-messages');
    field.errorMessages.forEach(message => contentWrapper.append($(`<li>${message}</li>`)));
    contentWrapper.insertBefore(targetElement);
};