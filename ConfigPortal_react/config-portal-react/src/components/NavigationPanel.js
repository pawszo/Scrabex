import React from 'react';
import {Navbar} from 'react-bootstrap'
import {Container} from 'react-bootstrap'
import {Nav} from 'react-bootstrap'
import { Component } from 'react';

class NavigationPanel extends Component {
    state = {  } 
    render() { 
        return (
            <div id="navparent" style={
                {
                    height : "100%",
                    width : "100%" 
                }
            } >
                <div class="fixed-bottom">
                <Navbar bg="dark" variant="dark" class="fixed-bottom" style={{
                    //alignContent : "end"
                }}>
                   <Container>
                        <Navbar.Brand href="#home">Navbar</Navbar.Brand>
                        <Nav >
                            <Nav.Link href="#home">Home</Nav.Link>
                            <Nav.Link href="#features">Features</Nav.Link>
                            <Nav.Link href="#pricing">Pricing</Nav.Link>
                        </Nav>
                    </Container>
                </Navbar>
                </div>
                <div class="fixed-top">
                <Navbar bg="dark" variant="dark" class="fixed-top">
                   <Container>
                        <Navbar.Brand href="#config">Navbar</Navbar.Brand>
                        <Nav >
                            <Nav.Link href="#home">Home</Nav.Link>
                            <Nav.Link href="#features">Features</Nav.Link>
                            <Nav.Link href="#pricing">Pricing</Nav.Link>
                        </Nav>
                    </Container>
                </Navbar>
                </div>
            </div>
        );
    }
}
 
export default NavigationPanel;