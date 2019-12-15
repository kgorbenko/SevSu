export interface FormFilledValidator {
    errorMessage: string;
    validate(value: string): Boolean;
}

export class FieldFilledValidator implements FormFilledValidator {
    errorMessage = 'This field should be filled';
    validate = (value: string) : Boolean => {
        return value !== '';
    };
}

export class PhoneNumberValidator implements FormFilledValidator {
    errorMessage = 'Entered number is in incorrect format';
    validate = (value: string) : Boolean => {
        const pattern = /^[+][7|3]\d{9,11}$/g;
        return pattern.test(value);
    };
}

export class NameValidator implements FormFilledValidator {
    errorMessage = 'Enter three space-separated words';
    validate = (value: string) : Boolean => {
        const pattern = /[A-Za-z]+ [A-Za-z]+ [A-Za-z]+/
        return pattern.test(value);
    };
}

export class DetailedAnswerValidator implements FormFilledValidator {
    errorMessage = 'Too many words. Should be less than 30';
    validate = (value: string) : Boolean => {
        return value.split(' ').length <= 30;
    };
}

export class FormComponent {
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