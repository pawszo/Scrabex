import { createSlice, PayloadAction, createAction, createAsyncThunk } from '@reduxjs/toolkit';
import * as React from 'react';
import { User, UserDetail, LoginDto, RegisterDto, AuthenticationResponse, UserData } from '../types/UserTypes';
import { RootState, client } from '../state/AppStore';  

const anonUser = {
    AccessLevel : 0, 
    UserTitle : "anon",
    CountryCode : "NA",
    CreatedAt : new Date(),
    LastUpdate : new Date(),
    Id : 0,
    Details : {
        Id : 0,
        UserId : 0,
        Email : "N/A",
        ForgotPassword : false,
        LastUpdate : new Date(),
        Login : "anon",
        Password : new Int8Array()
    } as UserDetail} as User;

const initData : UserData = {
    User: anonUser,
    Token: ""
};

const UserSlice = createSlice(
{
    name: 'user',
    initialState: initData,
    reducers: {
        signIn(state, action: PayloadAction<User>) {
            state.User = action.payload;
        },
        signOut(state, action: PayloadAction<boolean>)
        {
            if(action.payload === true)
            {
                state = initData;
            }
        },
        authenticate(state, action: PayloadAction<AuthenticationResponse>)
        {
            state.Token = action.payload.token;
            state.User.Id = action.payload.id;
        },
        register(state, action: PayloadAction<RegisterDto>) {
            //todo
        }
    }
});

export const Authenticate = createAsyncThunk(
    'User/Login',
    async (credentials: LoginDto) => {
        const response = await client.post("/login", credentials);

        if(response.status === 200)
            return (await response.data.json() as AuthenticationResponse);

        //if(response.status === 202)
            return (await response.data.json());
    }
);

export const {signIn, register, signOut} = UserSlice.actions;

export default UserSlice;
