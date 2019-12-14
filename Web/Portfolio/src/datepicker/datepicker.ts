import { createElementWithClass, createElementWithInnerHTML, createElementWithId } from '../utils/utils';
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

let isShown = false;

export const init = () => {
    datepickerInput().addEventListener('click', showDatePicker);
    window.addEventListener('click', (event) => removeDatePicker(event));
}

const insertDate = (event) => {
    const selectedYear = (yearSelect() as HTMLFormElement).value;
    const selectedMonthNumber = months.indexOf((monthSelect() as HTMLFormElement).value) + 1;
    const selectedDate = event.target.innerHTML;
    const date = new Date(selectedYear, selectedMonthNumber - 1, selectedDate);

    (datepickerInput() as HTMLFormElement).value = formatDate(date);
}

const showDatePicker = () => {
    if (!isShown) {
        datepickerInput().parentNode.insertBefore(createDatePicker(), datepickerInput().nextSibling);
        Array.from(dateList().childNodes).forEach(listItem => {
            listItem.addEventListener('click', (event) => insertDate(event));
        })
        yearSelect().addEventListener('change', updateDatesList);
        monthSelect().addEventListener('change', updateDatesList);
        isShown = true;
    }
}

const removeDatePicker = (event) => {
    if (isShown && !datepicker().contains(event.target as Node) && event.target !== datepickerInput()) {
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
    dateListWrapper.appendChild(createDateList(date.getFullYear(), date.getMonth() - 1));
    datepicker.appendChild(dateListWrapper);

    return datepicker;
}

const updateDatesList = () => {
    const selectedYear = (yearSelect() as HTMLFormElement).value;
    const selectedMonthNumber = months.indexOf((monthSelect() as HTMLFormElement).value);
    const dateListWrapper = dateList().parentElement;

    dateList().remove();
    const newDateList = createDateList(selectedYear, selectedMonthNumber + 1);
    newDateList.addEventListener('click', (event) => insertDate(event));
    dateListWrapper.appendChild(newDateList);
}

const createYearsSelect = () => {
    const selectYear = createElementWithId('select', datepickerYearSelectId);
    getYears().forEach(year => {
        selectYear.appendChild(createElementWithInnerHTML('option', year));
    });
    (selectYear as HTMLFormElement).value = new Date().getFullYear();
    return selectYear;
}

const createMonthSelect = () => {
    const selectMonth = createElementWithId('select', datepickerMonthSelectId);
    months.forEach(month => {
        selectMonth.appendChild(createElementWithInnerHTML('option', month));
    });
    (selectMonth as HTMLFormElement).value = months[new Date().getMonth()];
    return selectMonth;
}

const createDateList = (year, month) => {
    let dateList = createElementWithId('ul', datepickerDateListId);
    getDays(getNumberOfDaysInSpecificMonth(year, month)).forEach(date => {
        dateList.appendChild(createElementWithInnerHTML('li', date));
    });

    return dateList;
}

const getNumberOfDaysInSpecificMonth = (year, month) => {
    return new Date(year, month, 0).getDate();
}

const getYears = () => {
    let years = [];
    for (let i = 1900; i <= 2100; i++) {
        years.push(i);
    }

    return years;
}

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

const getDays = (n : number) => {
    let dates = [];
    for (let i = 1; i <= n; i++) {
        dates.push(i);
    }

    return dates;
}