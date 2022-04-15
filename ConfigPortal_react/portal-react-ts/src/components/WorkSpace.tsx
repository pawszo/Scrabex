import * as React from 'react'
import Browser from './Browser';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';
import { Document } from 'react-pdf';
import { BrowserRouter, BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Container } from 'react-bootstrap';
 
const WorkSpace = () => {
/*    const {setState} = useGlobalState();

    const switchScreen = (data: Partial<GlobalStateInterface>) => {
        setState((value) => ({...value, ...data}));
    }
*/
    return (
      <BrowserRouter>
          <Container className="container-fluid" id="workspace">
            <Routes>
              <Route path="/" element={<Browser />} />
              <Route path="/register" element={<RegisterForm />} />
              <Route path="/login" element={<LoginForm />} />
              <Route
                path="/legal"
                element={
                  <Document
                    file={
                      "https://drive.google.com/file/d/154KurjMq6AWFqbjxID1xBnrXTK6jTlVl/view?usp=sharing"
                    }
                  />
                }
              />
            </Routes>
          </Container>
      </BrowserRouter>
    );
};
 
export default WorkSpace;