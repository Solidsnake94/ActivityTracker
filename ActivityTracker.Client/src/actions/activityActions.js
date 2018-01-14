import * as types from "../constants/ActionTypes";
import apiActivities from "../apiRest/apiActivities";

// =================================================
// Using thunk middleware to load activities;

export function loadActivitiesSuccess(activities) {
  return {
    type: types.LOAD_ACTIVITIES_SUCCESS,
    activities
  };
}

export function loadActivities() {
  return async function (dispatch) {
    let activities;
    try {
      activities = await apiActivities.getAllUserActivities(19);
      dispatch(loadActivitiesSuccess(activities));
    } catch (e) {
      throw e;
    }
  };
}


export function createActivitySucccess(activity) {
  return { type: types.CREATE_ACTIVITY, activity }
}

export function createActivity(activity) {
  return async function (dispatch) {
    let activity;
    try {
      activity = await apiActivities.createUserActivity(activity);
      dispatch(createActivitySucccess(activity));
    } catch (e) {
      throw e;
    }
  };
}


export function deleteActivitySuccess(activity) {
  return {
    type: types.DELETE_ACTIVITY,
    activity
  };
}

export function deleteActivity(activity) {
  return async function (dispatch) {
    let response;
    try {
      response = await apiActivities.deleteActivity(activity);
      dispatch(deleteActivitySuccess(response));
    } catch (e) {
      throw e;
    }
  }
}

  // return function(dispatch) {
  //   return apiActivities
  //     .getAllActivities()
  //     .then(activities => {
  //       console.log("getAllActivities");
  //       console.log(activities);
  //       dispatch(loadActivitiesSuccess(activities));
  //     })
  //     .catch(err => {
  //       throw(err);
  //     });
  // };


// If loaded activities successfully from API dispatch an action to the store

// export function loadActivitiesError() {
//   return{

//   };
// }

/**
 * @todo Write error handling code if api call failed
 */
// ==================================================


// export function updateActivity(activity) {
//   return {
//     type: types.UPDATE_ACTIVITY,
//     activity
//   };
// }



// export const setActivityToComplete = activity => {
//   return {
//     type: types.SET_ACTIVITY_TO_COMPLETE,
//     activity
//   };
// };
