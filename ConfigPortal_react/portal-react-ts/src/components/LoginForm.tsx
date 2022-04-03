import * as React from 'react';
import { Form, Button, Stack } from 'react-bootstrap';

interface LoginFormProps {  
    
}
 
interface LoginFormState {
    forgotPassword: boolean
}
 
class LoginForm extends React.Component<{},LoginFormState> {
    state: LoginFormState = {
        forgotPassword: false
    };
    handleCheckboxChange = (e : React.ChangeEvent<HTMLInputElement>) => {
        this.setState((state, props) => {
            return {forgotPassword: e.target.checked};
        });
    };
    render() {
        const { forgotPassword } = this.state;
           return (
             <div id="login-form" className="d-flex align-middle justify-content-center">
               <form>
                 <Stack gap={0} direction="horizontal" className="mx-auto">
                     <br/><br/>
                   <h1 className="d-flex justify-content-center">Sign in</h1>
                   <hr />
                   <br />
                   <input
                     type="text"
                     className="form-control d-flex"
                     id="login-username"
                     placeholder="Login"
                     required
                   />
                   <br />
                   <input
                     type="password"
                     className="form-control d-flex"
                     id="login-password"
                     placeholder="Password"
                     disabled={forgotPassword}
                   />
                   <br />
                   <div className="form-check ml-2">
                     <input
                       className="form-check-input"
                       type="checkbox"
                       id="login-forgot-password"
                       onChange={this.handleCheckboxChange}
                       
                     />
                     <label
                       className="form-check-label ml-4"
                       htmlFor="login-forgot-password"
                     >
                       Forgot password?
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
           );
       }
    }

 
export default LoginForm;