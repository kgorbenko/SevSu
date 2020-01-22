const path = require('path');

module.exports = {
    mode: 'none',
    entry: {
        'simple-bar-chart': './simple-bar-chart/simple-bar-chart.js',
    },
    module: {
        rules: [
            {
                test: /\.s[ac]ss$/i,
                use: [
                    'style-loader',
                    'css-loader',
                    'sass-loader',
                ],
            },
        ],
    },
    devtool: 'inline-source-map',
    output: {
        path:  path.resolve(__dirname, "./bundles/"),
    }
};