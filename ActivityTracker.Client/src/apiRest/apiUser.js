import URLSearchParams from 'url-seach-params';

import {
  REGISTER_USER_URL,
  AUTHENTICATE_USER_URL
} from "../constants/ApiConstants";
import { callApi } from "../utils/ApiUtils";


class ApiUser {
  static async registerUser(user) {
    let options = {
      method: "POST",
      body: JSON.stringify(user),
      headers: new Headers({
        "Content-Type": "application/json"
      })
    };

    try {
      const { json, error } = await callApi(REGISTER_USER_URL, options);
      return json;
    } catch (e) {
      throw e;
    }
  }

  static async loginUser(user) {



    let options = {
      method: "POST",
      body: JSON.stringify(user),
      headers: new Headers({
        "Content-Type": "application/x-www-form-urlencoded",
        "Accept": "application/json"
      })
    };

    try {
      const { json, error } = await callApi(AUTHENTICATE_USER_URL, options);
      return json;
    } catch (e) {
      throw e;
    }
  }



}

export default ApiUser;
