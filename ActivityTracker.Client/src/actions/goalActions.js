import * as types from "../constants/ActionTypes";
import apiGoals from '../api/apiGoals';

export function loadGoalsSuccess(goals) {
  return {
    type: types.LOAD_GOALS_SUCCESS,
    goals
  };
}

export function loadGoals() {
  return function(dispatch) {
    return apiGoals
      .getAllGoals()
      .then(goals => {
        dispatch(loadGoalsSuccess(goals));
      })
      .catch(err => {
        throw(err);
      });
  };
}






export function createGoal(activity) {
  return {
    type: types.CREATE_GOAL,
    activity
  };
}

export function updateGoal(activity) {
  return {
    type: types.UPDATE_GOAL,
    activity
  };
}

export function deleteGoal(activity) {
  return {
    type: types.DELETE_ACTIVITY,
    activity
  };
}

export const setGoalToComplete = activity => {
  return {
    type: types.SET_GOAL_TO_COMPLETE,
    activity
  };
};
