const chessBoard = (n) => {
    const oddLine = ` #`.repeat(n / 2) + '\n';
    const evenLine = `# `.repeat(n / 2) + '\n';
    return (oddLine + evenLine).repeat(n / 2);
};