import { updateClockOnInterval } from '../clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator, setFieldsForValidation, DateValidator } from '../forms/forms';
import datepicker from '../datepicker/datepicker';

window.onload = () => {
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
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