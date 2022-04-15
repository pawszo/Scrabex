import { initState, IProfileState, IState } from "../types/StateTypes";
import { IAction, IConsumerAction, IErrorAction } from "../types/ActionTypes";
import { User, AuthenticationResponse } from '../types/UserTypes';
import { 
    AUTH_ATTEMPT, 
    AUTH_FAIL, 
    AUTH_SUCCESS, 
    LOGOUT, 
    REGISTER_ATTEMPT, 
    REGISTER_FAIL, 
    REGISTER_SUCCESS, 
    RENEW_PASSWORD_ATTEMPT } from "../types/ActionTypes";

export const userReducer = (state: IState = initState, action: IAction) => {
    switch(action.type)
    {
        case AUTH_ATTEMPT: {
            let entry = (action as IConsumerAction<AuthenticationResponse>).payload;
            return {
                ... state,
                loading: true,
                userState: {}
                
            }
        }

        case AUTH_SUCCESS: 
        {
            let response = (action as IConsumerAction<AuthenticationResponse>).payload;

            return {
                ... state,
                loading: false
                //userState: 
                //User: consumerAction
                //loading = false
            }
        }
        
        

        case AUTH_FAIL: {
            let response = (action as IErrorAction).error;
            return {
                ... state,
                loading: false,
                error: response
            };
        }

        default: return state;
    }   
};