import * as React from 'react';
import { Form, Stack, Button } from 'react-bootstrap'

interface RegisterFormProps {
    
}
 
interface RegisterFormState {
    isConsent : boolean
}
 
class RegisterForm extends React.Component<{},RegisterFormState> {
    state: RegisterFormState = {
        isConsent: false
    };
    handleConsentChange = (e : React.ChangeEvent<HTMLInputElement>) => {
        this.setState((state, props) => {
            return {isConsent: e.target.checked};
        });
    };
    render() { 
        return (
            <div id="register-form" className="d-flex align-middle justify-content-center">
               <form>
                 <Stack gap={0} direction="horizontal" className="mx-auto">
                     <br/><br/>
                   <h1 className="d-flex justify-content-center">Sign up</h1>
                   <hr />
                   <br />
                   <input
                     type="text"
                     className="form-control d-flex"
                     id="register-username"
                     placeholder="Login"
                     required
                   />
                   <br />
                   <input
                     type="password"
                     className="form-control d-flex"
                     id="register-password"
                     placeholder="Password"
                   />
                   <br />
                   <div className="form-check ml-2">
                     <input
                       className="form-check-input"
                       type="checkbox"
                       id="login-forgot-password"
                       onChange={this.handleConsentChange}
                       
                     />
                     <label
                       className="form-check-label ml-4"
                       htmlFor="login-forgot-password"
                     >
                       I give my consent to the terms of use.
                     </label>
                   </div><br/><br/>
                   <div className='d-grid'>
                   <Button className='btn btn-primary col-md-12'>
                        Submit
                   </Button>
                   <hr/>
                   <Button className='btn btn-secondary col-md-12'>
                        Sign up for free
                   </Button>
                   </div>
                 </Stack>
               </form>
             </div>
             /*
          <div id='register-form'>
            <form>
              <div className="form-group">
                <label htmlFor="register-email-textbox">Email address</label>
                <input
                  type="email"
                  className="form-control"
                  id="register-email-textbox"
                  placeholder="Must be a valid email address. e.g. 'name@example.com'"
                  required={true}
                />
              </div>
              <div className="form-group">
                <label htmlFor="register-login-textbox">Login</label>
                <input
                  type="text"
                  className="form-control"
                  id="register-login-textbox"
                  placeholder="5 or more characters. Must be unique. e.g. 'JohnDoe12'"
                  required={true}
                />
              </div>
              <div className="form-group">
                <label htmlFor="register-password-textbox">Password</label>
                <input
                  type="password"
                  className="form-control"
                  id="register-password-textbox"
                  placeholder="10 or more characters. Must contain letters, digits and special characters."
                  required={true}
                />
              </div>
              <div className="form-group">
                <label htmlFor="register-country-textbox">Country</label>
                <input
                  type="text"
                  className="form-control"
                  id="register-country-textbox"
                  placeholder="Your country code. e.g. 'US' or 'DE'"
                  maxLength={3}
                  required={true}
                />
              </div>
              <div className="form-group">
                <label htmlFor="register-consent-checkbox">Terms of use</label>
                <input 
                type="checkbox" 
                id='register-consent-checkbox'/>
              </div>
              <button type="submit" className="btn btn-primary">Register</button>
            </form>
          </div> */
        );
    }
}
 
export default RegisterForm;