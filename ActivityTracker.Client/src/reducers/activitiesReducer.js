import * as types from "../constants/ActionTypes";

// const initialState = [
// ];

export default function activitiesReducer(state=[], action) {
  switch (action.type) {
    case types.LOAD_ACTIVITIES_SUCCESS: {
      console.log("activitiesReducer.action");
      console.log(action.activities);
      return action.activities;
    }

    // case types.CREATE_ACTIVITY:
    //   // not sure if this will work
    //   return [...state, { ...action.activity }];

    default:
      return state;
  }
}
