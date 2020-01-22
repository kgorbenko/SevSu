import * as d3 from 'd3';

import './simple-bar-chart.scss';

let data = [4, 8, 15, 16, 23, 42];

let chart = d3.select('.chart');
let frameWidth = chart.property('offsetWidth');
let maxData = data.reduce((a, b) => { if (b > a) return b }, 0);

chart.selectAll('div')
    .data(data)
        .enter()
        .append('div')
        .style('width', (x) => `${ frameWidth / maxData * x }px`)
        .text(x => x);