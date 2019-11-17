const fizzBuzz = (n) => {
    let line = [];
    for (let i = 1; i <= n; i++) {
        if (i % 3 === 0 && i % 5 === 0) line.push('FizzBuzz');
        else if (i % 3 === 0) line.push('Fizz');
        else if (i % 5 === 0) line.push('Buzz');
        else line.push(i);
    }
    return line.join(', ');
};