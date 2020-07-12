import * as $ from 'jquery';

import { updateClockOnInterval } from '../shared/components/clock/clock';
import { visitPage } from '../shared/components/storage/storage';
import modal from '../shared/components/modal/modal';

import './interests.scss';
import '../shared/components/modal/modal.scss';

$(() => {
    visitPage('interests');
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    $('.contents').on('click', (event) => $(event.target).next().toggle());
    $('#dialog').on('click', () => modal({ confirmAction: () => alert('lol') }));
});