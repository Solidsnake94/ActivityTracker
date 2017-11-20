import * as types from '../constants/ActionTypes';

export function createGoal(activity){
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
    }
}