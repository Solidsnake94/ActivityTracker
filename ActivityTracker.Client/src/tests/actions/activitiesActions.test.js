import {createActivity, deleteActivity, createActivitySucccess, deleteActivitySuccess} from '../../actions/activityActions';
import activities from '../fixtures/activities';

import * as actionTypes from '../../constants/ActionTypes';
test('should create an activity',() => {
    const action = createActivitySucccess(activities[0]);

    expect(action).toEqual({
        type: actionTypes.CREATE_ACTIVITY ,
        activity : activities[0]
    })
});

test('should delete an activity',() => {
    const action = deleteActivitySuccess(activities[0]);
    console.log(action);
    expect(action).toEqual({
        type: actionTypes.DELETE_ACTIVITY ,
        activity : activities[0]
    })
});
