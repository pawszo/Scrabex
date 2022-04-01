import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import WebBrowser from './components/WebBrowser';
import reportWebVitals from './reportWebVitals';
import NavigationPanel from './components/NavigationPanel';
import 'bootstrap/dist/css/bootstrap.min.css';
import ReactHtmlParser, { processNodes, convertNodeToElement, htmlparser2 } from 'react-html-parser'

let page = '<!DOCTYPE html><html lang="en"><meta charset="UTF-8"><title>Page Title</title>'
+ '<meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="">'
+ '<style></style><script src=""></script><body><img src="img_la.jpg" alt="LA" style="width:100%">'
+ '<div class=""><h1>This is a Heading</h1><p>This is a paragraph.</p><p>This is another paragraph.</p>'
+ '</div></body></html>';
ReactDOM.render(
  <React.StrictMode>
    <NavigationPanel />
    <WebBrowser />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
