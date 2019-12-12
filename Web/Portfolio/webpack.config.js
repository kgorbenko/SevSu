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
        test: './src/pages/test.ts'
    },
    devtool: 'inline-source-map',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: [ '.tsx', '.ts', '.js' ],
    },
    output: {
        path:  path.resolve(__dirname, "./js/"),
    }
};