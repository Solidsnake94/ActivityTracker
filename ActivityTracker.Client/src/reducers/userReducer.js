import * as types from "../constants/ActionTypes";

const initialState = [
  // {
  //   activityId: "1",
  //   activityName: "Run a mile"
  // }
];

export default function activitiesReducer(state = initialState, action) {
  switch (action.type) {
    case types.LOGIN_USER:
      // not sure if this will work
      return [...state];

    default:
      return state;
  }
}
