const triangle = (n) => {
    let triangle = [];
    for (let i = 1; i < n; i++) {
        triangle.push('#'.repeat(i));
    }
    return triangle.join('\n');
};