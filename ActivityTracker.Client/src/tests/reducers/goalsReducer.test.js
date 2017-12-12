import goalsReducer from '../../reducers/goalsReducer';
import goals from '../fixtures/goals';
import * as actionTypes from '../../constants/ActionTypes';

test("should set default state", () => {
    const state = goalsReducer(undefined, {
        type: '@@INIT'
    });
    expect(state).toEqual([]);
});

test("should load goals", () => {
    const action = {
        type: actionTypes.LOAD_GOALS_SUCCESS,
        goals: goals
    }

    const state = goalsReducer(undefined, action);
    expect(state[0]).toEqual(goals[0]);
});
