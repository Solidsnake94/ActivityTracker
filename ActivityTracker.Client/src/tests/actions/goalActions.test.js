import {createGoal, updateGoal, deleteGoal} from '../../actions/goalActions';
import goals from '../fixtures/goals';

import * as actionTypes from '../../constants/ActionTypes';
test('should create a goal',() => {
    const action = createGoal(goals[0]);

    expect(action).toEqual({
        type: actionTypes.CREATE_GOAL ,
        activity : goals[0]
    })
});

test('should update a goal',() => {
    const action = updateGoal(goals[0]);

    expect(action).toEqual({
        type: actionTypes.UPDATE_GOAL ,
        activity : goals[0]
    })
});

test('should delete a goal',() => {
    const action = deleteGoal(goals[0]);

    expect(action).toEqual({
        type: actionTypes.DELETE_ACTIVITY ,
        activity : goals[0]
    })
});
