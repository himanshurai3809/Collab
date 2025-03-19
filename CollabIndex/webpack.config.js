const path = require('path');

module.exports = {
    mode: 'production', // or 'development' if you're debugging
    entry: './js-src/solanaAdapter.js',
    output: {
        filename: 'solanaAdapter.bundle.js',
        path: path.resolve(__dirname, 'wwwroot/js'),
    },
};
