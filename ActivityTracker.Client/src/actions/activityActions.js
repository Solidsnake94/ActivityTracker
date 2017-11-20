import * as types from "../constants/ActionTypes";
import activitiesApi from "../mockApi/mockActivitiesApi";

// =================================================
// Using thunk middleware to load activities;
export function loadActivities() {
  return function(dispatch) {
    return activitiesApi
      .getAllActivities()
      .then(activities => {
        dispatch(loadActivitiesSuccess(activities));
      })
      .catch(err => {
        throw err;
      });
  };
}

// If loaded activities successfully from API dispatch an action to the store
export function loadActivitiesSuccess(activities) {
  return {
    type: types.LOAD_ACTIVITIES_SUCCESS,
    activities: activities
  };
}

/**
 * @todo Write error handling code if api call failed
 */
// ==================================================

export function createActivity(activity) {
  return {
    type: types.CREATE_ACTIVITY,
    activity
  };
}

export function updateActivity(activity) {
  return {
    type: types.UPDATE_ACTIVITY,
    activity
  };
}

export function deleteActivity(activity) {
  return {
    type: types.DELETE_ACTIVITY,
    activity
  };
}

export const setActivityToComplete = activity => {
  return {
    type: types.SET_ACTIVITY_TO_COMPLETE,
    activity
  };
};
