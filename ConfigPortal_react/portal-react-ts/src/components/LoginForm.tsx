import React, { useCallback, useEffect, useState } from 'react';
import { Button, Stack } from 'react-bootstrap';
import { LoginDto, User, AuthenticationResponse, UserDetail} from '../types/UserTypes';
import { useForm } from '../hooks/UseForm'; 
import { AppStore, client, useAppDispatch } from '../state/AppStore';
import UserSlice, { signIn, Authenticate } from '../slices/UserSlice';

function LoginForm() {
  
  const initialState : LoginDto = {login: "", password: "", forgotPassword: false};

  const { onChange, onSubmit, values } = useForm(
    loginCallback,
    initialState
  );

  async function loginCallback() 
  {
    //var response = () => Authenticate(values as LoginDto);
    var authAction = await AppStore.dispatch(Authenticate(values as LoginDto));
    
    
    if(response.status === 200)
    {
      const authResponse : AuthenticationResponse = await response.data.json();
      var userResponse = await client.get(`/user/${authResponse.id}`);
      const user : User = await userResponse.data.json();
      const dispatch = useAppDispatch();
      useEffect(() => dispatch(() => {token})))
    }
  };

  return(
             <div id="login-form" className="d-flex justify-content-center">
               <form 
               onSubmit={onSubmit}
               className="border rounded border-primary mt-3">
                 <Stack gap={0} direction="horizontal" className="m-5">
                   <h1 className="d-flex justify-content-center">Sign in</h1>
                   <hr />
                   <input
                     type="text"
                     className="form-control"
                     id="login"
                     placeholder="Login"
                     required
                     name = "login"
                     onChange={onChange}
                   />
                   <br />
                   <input
                     type="password"
                     className="form-control"
                     id="password"
                     placeholder="Password"
                     name="password"
                     onChange={onChange}
                   />
                   <div className="form-check mt-2">
                     <input
                       className="form-check-input"
                       type="checkbox"
                       name="forgotPassword"
                       id="forgotPassword"
                       onChange={onChange}
                     />
                     <label
                       className="form-check-label mb-5"
                       htmlFor="login-forgot-password"
                     >
                       Forgot password?
                     </label>
                   </div>
                   <Button className='btn btn-primary col-md-12' type="submit">
                        Submit
                   </Button>
                   <hr/>
                   <Button onClick={} className='btn btn-secondary col-md-12'>
                        Sign up for free
                   </Button>
                 </Stack>
               </form>
             </div>
           );
       };

export default LoginForm;