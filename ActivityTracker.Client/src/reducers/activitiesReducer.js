import * as types from "../constants/ActionTypes";
// const initialState = [
// ];

export default function activitiesReducer(state = [], action) {
  switch (action.type) {
    case types.LOAD_ACTIVITIES_SUCCESS: {
      console.log("activitiesReducer.action");
      console.log(action.activities);
      return action.activities;
    }

    case types.CREATE_ACTIVITY: {
      console.log("activiiesReducer.action");
      console.log("State create : " + state);
      return [
        Object.assign([], action.activity),
        ...state

      ];
    }

    case types.UPDATE_ACTIVITY: {
    }

    case types.DELETE_ACTIVITY: {
      const newState = Object.assign([], state);
      const indexOfActivityToDelete = state.findIndex(activity => {
        return activity.id == action.activity.id;
      });
      newState.splice(indexOfActivityToDelete, 1);
      return newState;
    }

    // case types.CREATE_ACTIVITY:
    //   // not sure if this will work
    //   return [...state, { ...action.activity }];

    default:
      return state;
  }
}
