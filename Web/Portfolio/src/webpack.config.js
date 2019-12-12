module.exports = {
    entry: {
        index: './ts/index.ts',
        about: './ts/about.ts',
        interests: './ts/learning.ts',
        learning: './ts/learning.ts',
        photos: './ts/photos.ts',
        contact: './ts/contact.ts',
        test: './ts/test.ts'
    },
    devtool: 'inline-source-map',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
            {
                test: /\.tsx?$/,
                use: 'babel-loader',
            }, 
        ],
    },
    output: {
        path:  __dirname + "/dist/js",
    },
}