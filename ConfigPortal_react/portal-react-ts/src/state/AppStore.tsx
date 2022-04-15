import { configureStore, ThunkAction } from '@reduxjs/toolkit'
import axios from 'axios';
import { useDispatch } from 'react-redux';
import UserSlice from '../slices/UserSlice';

export const client = axios.create({
    baseURL: "https://localhost:7222/api",
    headers: {
        'Content-Type': 'application/json',
        'responseType': 'json'
}});

export const AppStore = configureStore({
    reducer: {
        user: UserSlice.reducer
    }
})


export type RootState = ReturnType<typeof AppStore.getState>;
export type AppDispatch = typeof AppStore.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();
//export type AppThunk = ThunkAction<void, {user: }