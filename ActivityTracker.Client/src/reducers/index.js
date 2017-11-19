import { combineReducers } from "redux";
import activities from "../reducers/activites";
import goals from "../reducers/goals";
import user from "../reducers/user";

const rootReducer = combineReducers({
  activities,
  goals,
  user
});

export default rootReducer;
