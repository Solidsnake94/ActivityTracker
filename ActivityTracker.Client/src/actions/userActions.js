import * as types from "../constants/ActionTypes";
import apiUser from "../apiRest/apiUser";



// === REGISTER USER ===
export function registerUser(user) {
  return async function (dispatch) {
    try {
      let registration = await apiUser.registerUser(user); 
      dispatch(registerUserSuccess());
    }catch (e){
      dispatch(registerUserError());
    }
  }
}

export function registerUserSuccess() {
  return {
    type: types.REGISTER_USER_SUCCESS
  };
}

export function registerUserError() {
  return {
    type: types.REGISTER_USER_ERROR
  };
}



// === LOGIN USER === 

export function loginUser(user) {
  return async function (dispatch) {
    try {

    }catch (e){

    }
  }
}

export function loginUserSuccess() {
  return {
    type: types.LOGIN_USER_SUCCESS
  };
}

export function loginUserError() {
  return {
    type: types.LOGIN_USER_ERROR
  };
}





