import ReactHtmlParser from 'react-html-parser'
import React from 'react';
import { Component } from 'react';

class WebBrowser extends Component {
    state = {  }
    render() { 
        let page = '<!DOCTYPE html><html lang="en"><meta charset="UTF-8"><title>Page Title</title>'
+ '<meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="">'
+ '<style></style><script src=""></script><body><img src="img_la.jpg" alt="LA" style="width:100%">'
+ '<div class=""><h1>This is a Heading</h1><p>This is a paragraph.</p><p>This is another paragraph.</p>'
+ '</div></body></html>'
        return (
            <div>
              { ReactHtmlParser(page) }
            </div>
         );
    }
}
 
export default WebBrowser;