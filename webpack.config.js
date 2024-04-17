const path = require('path');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = {
    entry: './src/index.js', // Entry point for JavaScript
    output: {
        filename: 'bundle.min.js', // Output minified JavaScript file
        path: path.resolve(__dirname, 'dist/js') // Output directory
    },
    module: {
        rules: [
            {
                test: /\.css$/, // Apply CSS loader to .css files
                use: ['style-loader', 'css-loader']
            }
        ]
    },
    optimization: {
        minimizer: [new UglifyJsPlugin()] // Use UglifyJS plugin for JavaScript minification
    }
};
