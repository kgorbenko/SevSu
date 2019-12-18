import { updateClockOnInterval } from '../clock/clock';
import { insertAfter, removeElementById, createElement, appendChildren } from '../utils/dom';

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

window.onload = () => {
    updateClockOnInterval(document.getElementById('date'), document.getElementById('time'), 1000);
    let interestsLinks = document.getElementsByClassName('contents');

    Array.from(interestsLinks).forEach(link => {
        link.addEventListener('click', handleClick);
    });
};

const handleClick = (event) : void => {
    const target = event.target as HTMLElement;
    if (interests[target.id].isHidden) {
        insertAfter(createInterestNode(target.id), target);
        interests[target.id].isHidden = false;
    } else {
        removeElementById(`${target.id}-expand`);
        interests[target.id].isHidden = true;
    }
}

const createInterestNode = (interestId: string) => {
    const interestContent = interests[interestId];
    const interestNode = createElement('li', { id: `${interestId}-expand`, classList: ['interests'] });
    appendChildren(interestNode,
        createElement('h2', { innerHTML: interestContent.header }),
        createElement('p', { innerHTML: interestContent.values[0] }),
        createElement('p', { innerHTML: interestContent.values[1] })
    );
    return interestNode;
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