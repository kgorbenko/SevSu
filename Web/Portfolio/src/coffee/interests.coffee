import * as $ from 'jquery';

import { updateClockOnInterval } from '../clock/clock';
import { visitPage } from '../storage/storage';
import modal from '../modal/modal';

import '../scss/interests.scss';
import '../modal/modal.scss';

$ () ->
    visitPage 'interests'
    updateClockOnInterval (document.getElementById('date')), (document.getElementById 'time'), 1000
    $('.contents').on('click', (event) -> $(event.target).next().toggle())
    $('#dialog').on('click', () -> modal({ confirmAction: () -> alert 'lol' }))