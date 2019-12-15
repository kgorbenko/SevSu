import { formatCurrentDate, formatCurrentTime } from '../clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator, setFieldsForValidation, DateValidator } from '../forms/forms';
import datepicker from '../datepicker/datepicker';

window.onload = () => {
    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatCurrentDate();
        time.innerHTML = formatCurrentTime();
    }, 1000);

    datepicker();
    setFieldsForValidation(fields, document.forms.item(0));
};

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
    new FormComponent(
        'datepicker-input',
        [
            new DateValidator()
        ]
    )
];