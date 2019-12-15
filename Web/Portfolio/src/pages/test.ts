import { formatCurrentDate, formatCurrentTime } from '../clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator, DetailedAnswerValidator, setFieldsForValidation } from '../forms/forms';

window.onload = () => {
    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatCurrentDate();
        time.innerHTML = formatCurrentTime();
    }, 1000);

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