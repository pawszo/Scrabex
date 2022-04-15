import React, { createContext, useReducer } from "react";
import { useStore } from './Store';

export function Filter() {
    const store = useStore();
    // you can also access store.dispatch here
    return <pre>{JSON.stringify(store, null, 2)}</pre>;
  }