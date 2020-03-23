const path = require('path');

module.exports = {
    mode: 'none',
    entry: {
        index: './src/pages/index.ts',
        about: './src/pages/about.ts',
        interests: './src/pages/interests.ts',
        learning: './src/pages/learning.ts',
        photos: './src/pages/photos.ts',
        contact: './src/pages/contact.ts',
        test: './src/pages/test.ts',
        history: './src/pages/history.ts',
        interestsCoffee: './src/coffee/interests.coffee',
        photosCoffee: './src/coffee/photos.coffee',
        contactCoffee: './src/coffee/contact.coffee'
    },
    devtool: 'inline-source-map',
    module: {
        rules: [
            { test: /\.coffee$/, use: [ 'coffee-loader']},
            { test: /\.tsx?$/, use: 'ts-loader', exclude: /node_modules/ },
            { test: /\.css$/i, use: [ 'style-loader', 'css-loader' ] },
            { test: /\.s[ac]ss$/i, use: [ 'style-loader', 'css-loader', 'sass-loader' ] }
        ],
    },
    resolve: {
        extensions: [ '.tsx', '.ts', '.js' ],
    },
    output: {
        path:  path.resolve(__dirname, "./js/"),
    }
};