import * as $ from 'jquery';

import { updateClockOnInterval } from '../clock/clock';
import { FormComponent, NameValidator, FieldFilledValidator, PhoneNumberValidator, setFieldsForValidation, DateValidator } from '../forms/forms';
import datepicker from '../datepicker/datepicker';
import { visitPage } from '../storage/storage';

import '../scss/contact.scss';
import '../datepicker/datepicker.scss';
import '../../node_modules/tooltipster/dist/css/tooltipster.bundle.min.css';
import '../../node_modules/tooltipster/dist/css/plugins/tooltipster/sideTip/themes/tooltipster-sideTip-light.min.css';

$ () ->
    visitPage 'contact'
    updateClockOnInterval (document.getElementById 'date'), (document.getElementById 'time'), 1000
    datepicker()
    setFieldsForValidation fields, document.forms.item 0

fields = [
    new FormComponent(
        'full-name-input',
        [
            new NameValidator,
        ],
        'Type three space-separated words.'
    ),
    new FormComponent(
        'email-input',
        [
            new FieldFilledValidator,
        ],
        'Email field should contain "@" character.'
    ),
    new FormComponent(
        'phone-input',
        [
            new PhoneNumberValidator,
        ],
        'Type phone number in next format: +XXXXXXXXXX.'
    ),
    new FormComponent(
        'message-input',
        [
            new FieldFilledValidator,
        ],
        'Message field should be filled.'
    ),
    new FormComponent(
        'datepicker-input',
        [
            new DateValidator
        ],
        'Click on field to choose date.'
    )
];