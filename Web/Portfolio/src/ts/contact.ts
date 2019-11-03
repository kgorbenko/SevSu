

const validatePhoneField = (value: string) : Boolean => value.match(/\+\d{11}/);

const validateThreeWordName = (value: string) : Boolean => value.match(/[A-Za-z]+ [A-Za-z]+ [A-Za-z]+/);

type ValidatorFunction = (value: string) => Boolean;
const validateFillness: ValidatorFunction = (value: string) : Boolean => value !== '';
class FormElement {
    componentId: string;
    value: string;
    errorMessages: string[];
    validators: FormElementValidator[];

    constructor(componentId: string, validators: FormElementValidator[]){
        this.componentId = componentId;
        this.validators = validators;
    };

    validate = () : void => {
        this.validators.forEach(validator => {
            const message = validator.errorMessage;
            if (validator.validate(this.value)) {
                this.errorMessages.splice(this.errorMessages.indexOf(message), 1);
            }
            else {
                this.errorMessages.push(message);
            }
        });
    };
}

interface FormElementValidator {
    validate: ValidatorFunction;
    errorMessage: string;
};

const fields: FormElement[] = [
    new FormElement(
        'full-name-input', [
            { validateFillness(value: string), errorMessage: 'error' },
        ]
    ),
];

window.onload = () => {
    const form = document.forms.item(0);
    form.addEventListener('change', validate);
};

const validateTextArea = (formElement : HTMLFormElement) : Boolean => {
    const result = formElement.value.split(' '); 
    return result.length <= 30;
};