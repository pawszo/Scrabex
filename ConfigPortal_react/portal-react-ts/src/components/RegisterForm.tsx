import * as React from 'react';
import { Form, Stack, Button, Tooltip } from 'react-bootstrap'
import LegalViewer from './LegalViewer';
import UserService from '../functions/UserService'

interface RegisterFormProps {
    
}
 
interface RegisterFormState {
    isConsent : boolean,
    isEmailValid : boolean,
    isLoginValid : boolean
}
 
const RegisterForm = () => {
  const [login, setLogin] = React.useState("");
  const [isConsent, setConsent] = React.useState("");

    };

    handleConsentChange = (e : React.ChangeEvent<HTMLInputElement>) => {
        this.setState((state, props) => {
            return {isConsent: e.target.checked};
        });
    };

    const submitForm = (data : FieldValues) => {
      let dto : LoginDto = {login: data.login, forgotPassword: data.forgotPassword, password: data.password};
      UserService.SignIn(dto);
    }

    render() { 
        return (
          <div
            id="register-form"
            className="d-flex justify-content-center mt-3"
          >
            <LegalViewer consentGiven={this.state.isConsent}/>
            <form className="border rounded border-primary">
              <Stack gap={0} direction="horizontal" className="m-5">
                <h1 className="d-flex justify-content-center">Sign up</h1>
                <hr />
                <input
                  type="email"
                  className="form-control"
                  id="register-email"
                  placeholder="Email" 
                  data-toggle='tooltip'
                  title="Must be a valid email address. e.g. 'name@example.com'"
                  required
                /><br/>
                <input
                  type="text"
                  className="form-control"
                  id="register-login"
                  data-toggle="tooltip"
                  title="5 or more characters. Must be unique. e.g. 'JohnDoe12'"
                  minLength={5}
                  placeholder='Login'
                  required
                />
                <br />
                <input
                  type="password"
                  className="form-control"
                  id="register-password"
                  placeholder="Password"
                  data-toggle="tooltip"
                  minLength={10}
                  title="10 or more characters. Must contain letters, digits and special characters."
                  required
                />
                <br />
                <input
                  type="text"
                  className="form-control"
                  id="register-country"
                  placeholder="Your country code"
                  title="Examples: UK, BG, PL, CZ, SK, CH, CA, CN"
                  maxLength={3}
                  required
                />
                <br />
                <input
                  type="text"
                  className="form-control d-flex"
                  id="register-title"
                  placeholder="Title"
                  title="Name, Fullname or company"
                  required
                /><br/>
                <div className="form-check ml-2">
                  <input
                    className="form-check-input"
                    type="checkbox"
                    id="register-consent"
                    onChange={this.handleConsentChange}
                    checked={this.state.isConsent}
                  />
                  <p
                    className="form-check-label ml-1"
                  >
                    I give my consent to the <a 
                    itemType='button' 
                    className='text-info'
                    data-toggle="modal"
                    data-target='#consent-modal'
                    onClick={() => {
                        setTimeout(
                            () => document.getElementsByClassName('modal-backdrop')[0]?.addEventListener("click", e => (e.target as HTMLDivElement).remove()),
                            2000);
                        }
                        }>terms of
                    service</a>
                  </p>
                </div>
                  <Button type='submit' className="btn btn-primary col-md-12 mt-5">Submit</Button>
                  <hr />
                  <Button className="btn btn-secondary col-md-12">
                    Sign in
                  </Button>
              </Stack>
            </form>
          </div>
        );
    }
}
 
export default RegisterForm;