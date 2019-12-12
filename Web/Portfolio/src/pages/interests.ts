import { formatDate, formatTime } from '../clock/clock';

window.onload = () => {
    let links = document.getElementsByClassName('contents');

    Array.from(links).forEach(link => {
        link.addEventListener('click', handleClick);
    });

    const date = document.getElementById('date');
    const time = document.getElementById('time');

    setInterval(() => {
        date.innerHTML = formatDate();
        time.innerHTML = formatTime();
    }, 1000);
};

const handleClick = () : void => {
    const targetId : string = (<HTMLElement>event.target).id;
    if (interests[targetId].isHidden) showInterest(targetId);
    else hideInterest(targetId);
};

const showInterest = (targetId : string) : void => {
    const content : InterestsNodeContent = interests[targetId];
    if (content.isHidden) {
        const targetElement = document.getElementById(targetId);
        const parentElement = targetElement.parentElement;
        const nextElement = targetElement.nextSibling;
        let contentWrapper = document.createElement('li');
        contentWrapper.setAttribute('id', `${targetId}-wrapper`);
        contentWrapper.setAttribute('class', 'interests');
        contentWrapper.appendChild(createElement('h2', content.header));
        contentWrapper.appendChild(createElement('p', content.values[0]));
        contentWrapper.appendChild(createElement('p', content.values[1]));
        parentElement.insertBefore(contentWrapper, nextElement);
        content.isHidden = false;
    }
};

const hideInterest = (targetId : string) : void  => {
    const content: InterestsNodeContent = interests[targetId];
    const contentWrapper = document.getElementById(`${targetId}-wrapper`);
    contentWrapper.remove();
    content.isHidden = true;
};

const createElement = (tagName: string, content : string) => {
    let element = document.createElement(tagName);
    element.innerHTML = content;
    return element;
};

enum InterestIds {
    Hobbies = 'Hobbies', 
    Books   = 'Books', 
    Music   = 'Music', 
    Films   = 'Films'
}

type InterestsNode = {
    [key in keyof typeof InterestIds]: InterestsNodeContent
}

interface InterestsNodeContent {
    header: string;
    values: string[];
    isHidden: boolean;
}

const interestContent: string =
    `Lorem ipsum dolor sit amet, consecteturadipiscing elit. Sed gravida
    dolor et ultricies placerat. Pellentesque in lectus at augue rutrum 
    volutpat vel sed tellus. Donec feugiat ac nibh et pharetra. Curabitur 
    fringilla lacinia nisl tempus mollis. Nam semper augue et ante ornare
    semper. Etiam nunc velit, pharetra eget fermentum tincidunt, lacinia 
    vitae sapien. Etiam quis elit tincidunt, consequat urna eget, vulputate
    libero. Donec dignissim ornare porttitor. Donec id augue turpis. Morbi massa 
    sem, dapibus at semper in, mollis a sem. Ut eu lacus ut leo aliquam laoreet. 
    Integer sed ex vel erat dictum finibus sit amet id mi. Duis lorem neque, 
    faucibus ut laoreet eu, sodales in orci. Nam mattis mauris sit amet lectus
    condimentum, in maximus massa ultrices. Fusce pharetra accumsan dui sed bibendum.`

const interests : InterestsNode = {
    'Hobbies': {
        header: 'My hobbies',
        values: [
            'My hobbies are supposed to be here',
            interestContent
        ],
        isHidden: true,
    },
    'Books': {
        header: 'My books',
        values: [
            'My books are supposed to be here',
            interestContent
        ],
        isHidden: true,
    },
    'Music': {
        header: 'My music',
        values: [
            'My music is supposed to be here',
            interestContent
        ],
        isHidden: true,
    },
    'Films': {
        header: 'My films',
        values: [
            'My films are supposed to be here',
            interestContent
        ],
        isHidden: true,
    }
};