import {  } from '../functions/Actions';
import { Dispatch } from 'redux';
import { PostActionTypes } from '../types/PostTypes';
export const getPosts = () => {
  return function (dispatch: Dispatch<PostActionTypes>) {
    const POST_URL = 'https://jsonplaceholder.typicode.com/posts';
    fetch(POST_URL, {
      method: 'GET'
    })
      .then(res => res.json())
      .then(data => {
        dispatch(getPostsAction(data));
        return data;
      });
  };
};