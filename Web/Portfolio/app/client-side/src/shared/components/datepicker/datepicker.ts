import { createElementWithClass, createElementWithInnerHTML, createElementWithId } from '../../utils/dom';
import { formatDate } from '../clock/clock';

const datepickerId = 'datepicker';
const datepickerInputId = 'datepicker-input';
const datepickerYearSelectId = 'datepicker-year';
const datepickerMonthSelectId = 'datepicker-month';
const datepickerDateListId = 'datepicker-date-list';
const elementWrapperClass = 'element-wrapper';

const datepicker = () => document.querySelector('#' + datepickerId);
const datepickerInput = () => document.querySelector('#' + datepickerInputId);
const yearSelect = () => document.querySelector('#' + datepickerYearSelectId);
const monthSelect = () => document.querySelector('#' + datepickerMonthSelectId);
const dateList = () => document.querySelector('#' + datepickerDateListId);

let selectedYear, selectedMonthNumber, selectedDate;
let isShown = false;

export default () => {
    datepickerInput().addEventListener('click', showDatePicker);
    window.addEventListener('click', (event) => removeDatePicker(event));
}

const insertDate = (event) => {
    if (event.target !== dateList()) {
        selectedYear = (yearSelect() as HTMLFormElement).value;
        selectedMonthNumber = months.indexOf((monthSelect() as HTMLFormElement).value);
        selectedDate = event.target.innerHTML;
        const date = new Date(selectedYear, selectedMonthNumber, selectedDate);

        (datepickerInput() as HTMLElement).focus();
        (datepickerInput() as HTMLFormElement).value = formatDate(date);
        (datepickerInput() as HTMLElement).blur();
    }
};

const showDatePicker = () => {
    if (!isShown) {
        datepickerInput().parentNode.insertBefore(createDatePicker(), datepickerInput().nextSibling);
        Array.from(dateList().childNodes).forEach(listItem => {
            listItem.addEventListener('click', (event) => insertDate(event));
        });
        yearSelect().addEventListener('change', updateDatesList);
        monthSelect().addEventListener('change', updateDatesList);
        isShown = true;
    }
};

const removeDatePicker = (event) => {
    if (isShown && !datepicker().contains(event.target as Node) && event.target !== datepickerInput()) {
        (datepickerInput() as HTMLElement).blur();
        datepicker().remove();
        isShown = false;
    }
};

const createDatePicker = () => {
    const date = new Date();
    let datepicker = createElementWithId('div', datepickerId);
    let yearAndMonthSelectsWrapper = createElementWithClass('div', elementWrapperClass);
    let dateListWrapper = createElementWithClass('div', elementWrapperClass);
    yearAndMonthSelectsWrapper.appendChild(createYearsSelect());
    yearAndMonthSelectsWrapper.appendChild(createMonthSelect());
    datepicker.appendChild(yearAndMonthSelectsWrapper);
    dateListWrapper.appendChild(createDatesList(selectedYear || date.getFullYear(), selectedMonthNumber + 1 || date.getMonth() - 1));
    datepicker.appendChild(dateListWrapper);

    return datepicker;
};

const updateDatesList = () => {
    const selectedYear = (yearSelect() as HTMLFormElement).value;
    const selectedMonthNumber = months.indexOf((monthSelect() as HTMLFormElement).value);
    const dateListWrapper = dateList().parentElement;

    dateList().remove();
    const newDateList = createDatesList(selectedYear, selectedMonthNumber + 1);
    newDateList.addEventListener('click', (event) => insertDate(event));
    dateListWrapper.appendChild(newDateList);
};

const createYearsSelect = () => {
    const selectYear = createElementWithId('select', datepickerYearSelectId);
    getYears().forEach(year => {
        selectYear.appendChild(createElementWithInnerHTML('option', year));
    });
    (selectYear as HTMLFormElement).value = selectedYear || new Date().getFullYear();
    return selectYear;
};

const createMonthSelect = () => {
    const selectMonth = createElementWithId('select', datepickerMonthSelectId);
    months.forEach(month => {
        selectMonth.appendChild(createElementWithInnerHTML('option', month));
    });
    (selectMonth as HTMLFormElement).value = months[selectedMonthNumber] || months[new Date().getMonth()];
    return selectMonth;
};

const createDatesList = (year, month) => {
    let dateList = createElementWithId('ul', datepickerDateListId);
    getDays(getNumberOfDaysInMonth(year, month)).forEach(date => {
        dateList.appendChild(createElementWithInnerHTML('li', date));
    });
    return dateList;
};

const getNumberOfDaysInMonth = (year, month) => {
    return new Date(year, month, 0).getDate();
};

const getYears = () => {
    let years = [];
    for (let i = 2000; i <= 2025; i++) {
        years.push(i);
    }
    return years;
};

const getDays = (n : number) => {
    let days = [];
    for (let i = 1; i <= n; i++) {
        days.push(i);
    }
    return days;
};

const months = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
];