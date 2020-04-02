const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const ManifestPlugin = require('webpack-manifest-plugin');

module.exports = {
    entry: "./src/index.ts",
    output: {
        path: path.resolve(__dirname, "wwwroot/dist"),
        filename: "[name].[chunkhash].js",
        publicPath: "/dist/"
    },
    resolve: {
        extensions: [".js", ".ts"]
    },
    module: {
        rules: [
            {
                test: /\.ts(x?)$/,
                use: "babel-loader"
            },
            {
                test: /\.s[ac]ss$/i,
                use: [MiniCssExtractPlugin.loader, "css-loader", 'sass-loader']
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        // new HtmlWebpackPlugin({
        //     template: "./src/index.html"
        // }),
        new MiniCssExtractPlugin({
            filename: "css/[name].[chunkhash].css"
        }),
        new ManifestPlugin({
            fileName: 'asset-manifest.json'
        })
    ]
};