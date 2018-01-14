import activitiesReducer from '../../reducers/activitiesReducer';
import activities from '../fixtures/activities';
import * as actionTypes from '../../constants/ActionTypes';

test("should set default state", () => {
    const state = activitiesReducer(undefined, {
        type: '@@INIT'
    });
    expect(state).toEqual([]);
});

test("should load activities", () => {
    const action = {
        type: actionTypes.LOAD_ACTIVITIES_SUCCESS,
        activities: activities
    }

    const state = activitiesReducer(undefined, action);
    expect(state[0]).toEqual(activities[0]);
});
