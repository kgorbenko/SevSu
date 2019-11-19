const range = (start, end) => {
    let range = [];
    for (let i = start; i <= end; i++) {
        range.push(i);
    }
    return range;
};

const sum = (...values) => values.reduce((a, b) => a + b);