import * as React from 'react';
import { useState } from 'react';
import { Button } from 'react-bootstrap';

interface BrowserProps {
    
}
 
interface BrowserState {
    body: string
}
 
class Browser extends React.Component<BrowserProps, BrowserState> {
    constructor(props: BrowserProps) {
        super(props);
        this.state = {body :  '<div>READY</div>'};
    }
    render() { 
        return (  
            <div className='container-fluid flex-fill' id='browser'>
                <div className='mt-3 mb-3 ml-5 mr-5 d-flex row'>
                    <input className="form-control" type="text" placeholder="website url"/>
                </div>
                <div className="flex-fill row ml-5 mr-5" style={
                    {height: '70vh' }
                    }>
                        <div className="flex-fill" id='browser-display' style={
                    { backgroundColor: 'red' }
                    }></div>
                </div>
            </div>
        );
    }
}
 
export default Browser;