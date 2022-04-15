import { User } from './UserTypes';
import { DASHBOARD } from './ScreenTypes';
import React from "react";
import { IAction } from './ActionTypes';

export interface IProfileState {
    user: User,
    token: string
};

export interface IState {
    profile : IProfileState,
    loading: boolean,
    screen: string,
    error: string
};

export interface IContext {
    state: IState
    dispatch: React.Dispatch<IAction>;
};

export const initFilter: string[] = [];

export const initUser : User = {
    AccessLevel : 0, 
    UserTitle : "anon",
    CountryCode : "NA",
    CreatedAt : new Date(),
    Id : 0,
    Details : {
        Id : 0,
        UserId : 0,
        Email : "N/A",
        ForgotPassword : false,
        LastUpdate : new Date(),
        Login : "anon",
        Password : new Int8Array()
    }
};

export const initState : IState = {
        profile: {
            user: initUser,
            token : ""
        } as IProfileState,
        loading: false,
        screen: DASHBOARD,
        error: ''
};


