import { AnyAction } from '@reduxjs/toolkit';
import redux from 'react-redux';

export const AUTH_ATTEMPT = "AUTH_ATTEMPT";
export const AUTH_SUCCESS = "AUTH_SUCCESS";
export const AUTH_FAIL = "AUTH_FAIL";
export const LOGOUT = "LOGOUT";
export const REGISTER_ATTEMPT = "REGISTER_ATTEMPT";
export const REGISTER_SUCCESS = "REGISTER_SUCCESS";
export const REGISTER_FAIL = "REGISTER_FAIL";
export const RENEW_PASSWORD_ATTEMPT = "RENEW_PASSWORD_ATTEMPT";
export const RENEW_PASSWORD_SUCCESS = "RENEW_PASSWORD_SUCCESS";
export const RENEW_PASSWORD_FAIL = "RENEW_PASSWORD_FAIL";

export interface IAction extends AnyAction { type: string };

export interface IConsumerAction<T> extends IAction { payload: T };

export interface IErrorAction extends IAction {error: string};

