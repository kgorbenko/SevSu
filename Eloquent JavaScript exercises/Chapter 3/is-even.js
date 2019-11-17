const isEven = (number) => { 
    if (number === 0) return true;
    if (number === 1) return false;
    if (number < 0) return isEven(Math.abs(number));
    return isEven(number - 2);
};