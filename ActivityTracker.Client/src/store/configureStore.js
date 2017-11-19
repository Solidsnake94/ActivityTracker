import { createStore, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";
import rootReducer from "../reducers/index";

const createStoreWithMiddleware = applyMiddleware(thunkMiddleware)(createStore);

const configureStore = initialState => {
  const store = createStoreWithMiddleware(rootReducer, initialState);

  return store;
};

export default configureStore;







