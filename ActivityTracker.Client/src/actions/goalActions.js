import * as types from "../constants/ActionTypes";
//import apiGoals from "../api/apiGoals";

export function loadGoals() {
  return async function(dispatch) {
    let goals;
    try {
      //goals = await apiGoals.getAllUserGoals(19);
      dispatch(loadGoalsSuccess(goals));
    } catch (e) {
      throw e;
    }
  };
}

export function loadGoalsSuccess(goals) {
  return {
    type: types.LOAD_GOALS_SUCCESS,
    goals
  };
}

export function loadGoalsError(error){
  return {
    type: types.LOAD_GOALS_ERROR,
    error
  }
}



// export function loadGoals(){

// }

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
