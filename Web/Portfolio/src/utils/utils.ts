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