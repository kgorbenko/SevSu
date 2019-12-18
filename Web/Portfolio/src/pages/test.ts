import { updateClockOnInterval } from '../clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator, DetailedAnswerValidator, setFieldsForValidation } from '../forms/forms';
import { visitPage } from '../storage/storage';

window.onload = () => {
    visitPage('test');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    setFieldsForValidation(fields, document.forms.item(0));
};

const fields: FormComponent[] = [
    new FormComponent(
        'question3',
        [
            new FieldFilledValidator(),
            new DetailedAnswerValidator()
        ]
    ),
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