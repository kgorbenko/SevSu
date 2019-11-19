const reverse = (array) => {
    let reversed = [];
    for (let i = array.length - 1; i >= 0; i--) {
        reversed.push(array[i]);
    }
    return reversed;
};

const reverseInPlace = (array) => {
    for (let i = 0, j = array.length - 1; i < j; i++, j--) {
        const temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
};