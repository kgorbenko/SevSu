const min = (...values) => {
    let min = values[0];
    for (let i = 1; i < values.length; i++) {
        if (values[i] < min) {
            min = values[i];
        }
    }
    return min;
};