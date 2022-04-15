import { LoginDto, AuthenticationResponse, RegisterDto } from '../types/UserTypes';
import {
    AUTH_ATTEMPT, 
    AUTH_FAIL, 
    AUTH_SUCCESS, 
    LOGOUT, 
    REGISTER_ATTEMPT,
    REGISTER_FAIL,
    REGISTER_SUCCESS,
    RENEW_PASSWORD_ATTEMPT,
    RENEW_PASSWORD_SUCCESS,
    RENEW_PASSWORD_FAIL} from '../types/ActionTypes';

const tryAuthenticate = (entry: LoginDto) =>
{
    return  {
        type: AUTH_ATTEMPT,
        payload: entry
    };
};

const onAuthenticationSuccess = (result: AuthenticationResponse) =>
{
    return  {
        type: AUTH_SUCCESS,
        payload: result
    };
};

const onAuthenticationFail = (error : string) =>
{
    return  {
        type: AUTH_FAIL,
        payload: error
    };
};

function onLogout()
{
    return  {
        type: LOGOUT
    };
};

function tryRegister(entry: RegisterDto)
{
    return  {
        type: REGISTER_ATTEMPT,
        data: entry
    };
};

function onRegisterSuccess()
{
    return  {
        type: REGISTER_SUCCESS
    };
};

function onRegisterFail(response: any)
{
    return  {
        type: REGISTER_FAIL,
        data: response
    };
};

function tryRenewPassword(entry: LoginDto)
{
    return  {
        type: RENEW_PASSWORD_ATTEMPT,
        data: entry
    };
};

function onRenewPasswordSuccess(entry: LoginDto)
{
    return  {
        type: RENEW_PASSWORD_ATTEMPT,
        data: entry
    };
};