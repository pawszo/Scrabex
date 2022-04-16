import redux from 'react-redux';
import React, { createContext, useReducer } from "react";
import { useDispatch, createStoreHook } from 'react-redux'
import { rootReducer, userReducer } from '../reducers/UserReducer';
import { IContext, initState } from '../types/StateTypes';
import { context } from '../functions/Context';

const { Provider } = context;

export const StateProvider = ({children} : any) => {
    const [state, dispatch] = useReducer (
        (state: any, action: IAction) => {
            rootReducer 
        }
    )

    return <Provider value={{state, dispatch}}>{children}</Provider>;
};