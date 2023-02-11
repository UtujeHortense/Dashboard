module.exports = {
    devServer: {
        proxy: {
            '^/auth': {
                target: 'https://connect.deezer.com/',
                ws: true,
                changeOrigin: true,
                pathRewrite: {'^/auth': ''}
            },
            '^/api': {
                target: 'https://api.deezer.com/',
                ws: true,
                changeOrigin: true,
                pathRewrite: {'^/api': ''}
            },
            '^/back': {
                target: 'https://localhost:5001/',
                ws: true,
                changeOrigin: true,
                pathRewrite: {'^/back': ''}
            },
            '^/weather': {
                target: 'http://api.weatherstack.com/',
                ws: true,
                changeOrigin: true,
                pathRewrite: {'^/weather': ''}
            }
        }
    }
};
