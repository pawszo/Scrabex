import redux from 'react-redux';
import React, { createContext, useReducer } from "react";
import { useDispatch } from 'react-redux'
import { rootReducer, userReducer } from '../functions/Reducers';
import { IContext, initState } from '../types/StateTypes';
import { context } from '../functions/Context';

const { Provider } = context;

export const StateProvider = ({children} : any) => {
    const [state, dispatch] = useReducer (
        (state: any, action: IAction)
    )

    return <Provider value={{state, dispatch}}>{children}</Provider>;
};