export interface FormValidator {
    errorMessage: string;
    validate(value: string): Boolean;
}

export class FormFilledValidator implements FormValidator {
    errorMessage = 'This field should be filled';
    validate = (value: string) : Boolean => {
        return value !== '';
    };
}

export class PhoneNumberValidator implements FormValidator {
    errorMessage = 'Entered number is in incorrect format';
    validate = (value: string) : Boolean => {
        const pattern = /^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/g;
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

export class DetailedQuestionValidator implements FormValidator {
    errorMessage: 'Too much letters';
    validate = (value: string) : Boolean => {
        return value.split(' ').length <= 30;
    };
}

export class FormComponent {
    componentId: string;
    value: string;
    errorMessages: string[];
    validators: FormValidator[];

    constructor(componentId: string, validators: FormValidator[]){
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