import { combineReducers } from "redux";
import activities from "../reducers/activitiesReducer";
import goals from "../reducers/goalsReducer";
import user from "../reducers/userReducer";

const rootReducer = combineReducers({
  activities,
  goals,
  // user
});

export default rootReducer;
