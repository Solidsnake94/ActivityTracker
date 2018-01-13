import delay from "./delay";
import { callApi } from "../utils/ApiUtils";
import {
  ALL_USER_ACTIVITIES_URL,
  CREATE_USER_ACTIVITY_URL
} from "../constants/ApiConstants";

//#region test activities
// const activities = [
//   {
//     activityID: 1,
//     createdDate: new Date(),
//     time: "00:00:00",
//     distanceInKilometers: 0.0,
//     userID: 0,
//     activityTypeID: 0,
//     goalID: null
//   },
//   {
//     activityID: 2,
//     createdDate: new Date(),
//     time: "00:00:00",
//     distanceInKilometers: 0.0,
//     userID: 0,
//     activityTypeID: 0,
//     goalID: null
//   },
//   {
//     activityID: 3,
//     createdDate: new Date(),
//     time: "00:00:00",
//     distanceInKilometers: 0.0,
//     userID: 0,
//     activityTypeID: 0,
//     goalID: null
//   },
//   {
//     activityID: 4,
//     createdDate: new Date(),
//     time: "00:00:00",
//     distanceInKilometers: 0.0,
//     userID: 0,
//     activityTypeID: 0,
//     goalID: null
//   },
//   {
//     activityID: 5,
//     createdDate: new Date(),
//     time: "00:00:00",
//     distanceInKilometers: 0.0,
//     userID: 0,
//     activityTypeID: 0,
//     goalID: null
//   },
//   {
//     activityID: 6,
//     createdDate: new Date(),
//     time: "00:00:00",
//     distanceInKilometers: 0.0,
//     userID: 0,
//     activityTypeID: 0,
//     goalID: null
//   }
// ];
//#endregion

class ActivitiesApi {
  // static getAllActivities() {
  //   return new Promise((resolve, reject) => {
  //     setTimeout(() => {
  //       resolve(Object.assign([], activities));
  //     }, delay);
  //   });
  // }

  static async getAllUserActivities(userId) {
    const { json } = await callApi(
      ALL_USER_ACTIVITIES_URL.replace("{userId}", userId)
    );
    return json;
  }

  static async createUserActivity(activity) {
    let options = {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-type": "application/json"
      },
      body: JSON.stringify(activity)
    };
    try {
      const response = await callApi(CREATE_USER_ACTIVITY_URL, options);
      return response;
    } catch (error) {
      console.log(error);
    }
  }
}

export default ActivitiesApi;
