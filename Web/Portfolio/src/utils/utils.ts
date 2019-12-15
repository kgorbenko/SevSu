interface ICreateElementParameters {
    id?: string;
    classList?: string[];
    src?: string;
    innerHTML?: string;
    onclick?: () => void;
}

export const createElementWithClass = (elementType: string, className?: string) => {
    const element = document.createElement(elementType);
    if (className) {
        element.className = className;
    }
    return element;
}

export const createElementWithInnerHTML = (elementType: string, innerHTML?: string) => {
    const element = document.createElement(elementType);
    if (innerHTML) {
        element.innerHTML = innerHTML;
    }
    return element;
}

export const createElementWithId = (elementType: string, id?: string) => {
    const element = document.createElement(elementType);
    if (id) {
        element.id = id;
    }
    return element;
}

export const createElementWithAttribute = (elementType: string, attributeName?: string, attributeValue?: string) => {
    const element = document.createElement(elementType);
    if (attributeName && attributeValue) {
        element.setAttribute(attributeName, attributeValue);
    }
    return element;
}

export const createElement = (elementType: string, objectParams: ICreateElementParameters) => {
    return Object.assign(document.createElement(elementType), objectParams);
}