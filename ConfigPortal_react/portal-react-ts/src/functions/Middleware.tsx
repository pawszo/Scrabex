import redux from 'react-redux';
import { ActionCreatorsMapObject, applyMiddleware} from '@reduxjs/toolkit'
import { createAction, apiMiddleware } from 'redux-api-middleware';
import { ThunkMiddleware, ThunkDispatch, ThunkAction, ThunkActionDispatch } from 'redux-thunk';
import { axiosMiddleware,  } from 'redux-axios-middleware';

const middleware = new thunkMiddleware(axiosMiddleware)
const thunkMiddleware = applyMiddleware(ThunkMiddleware)