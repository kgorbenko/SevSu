import * as $ from 'jquery';

import { updateClockOnInterval } from '../shared/components/clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator, setFieldsForValidation, DateValidator } from '../shared/components/forms/forms';
import datepicker from '../shared/components/datepicker/datepicker';
import { visitPage } from '../shared/components/storage/storage';

import './contact.scss';
import '../shared/components/datepicker/datepicker.scss';

$(() => {
    visitPage('contact');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    datepicker();
    setFieldsForValidation(fields, document.forms.item(0));
});

const fields: FormComponent[] = [
    new FormComponent(
        'full-name-input',
        [
            new NameValidator(),
        ],
        'Type three space-separated words.'
    ),
    new FormComponent(
        'email-input',
        [
            new FieldFilledValidator(),
        ],
        'Email field should contain "@" character.'
    ),
    new FormComponent(
        'phone-input',
        [
            new PhoneNumberValidator(),
        ],
        'Type phone number in next format: +XXXXXXXXXX.'
    ),
    new FormComponent(
        'message-input',
        [
            new FieldFilledValidator(),
        ],
        'Message field should be filled.'
    ),
    new FormComponent(
        'datepicker-input',
        [
            new DateValidator()
        ],
        'Click on field to choose date.'
    )
];