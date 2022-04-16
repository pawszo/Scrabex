import redux from 'react-redux';
import React, { createContext, useReducer } from "react";
import { useDispatch } from 'react-redux'
import { userReducer } from '../reducers/UserReducer';
import { IContext, initState } from '../types/StateTypes';

const createStore = redux.createStoreHook;

export const context = createContext<IContext>({
    state: initState,
    dispatch: () => {} //null
});

export function useStore() {
    const value = React.useContext(context);
    if (!value) throw new Error("useStore needs to be within StateProvider");

    return value;
};
