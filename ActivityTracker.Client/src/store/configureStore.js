import { createStore, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";
import reduxImmutableStateInvariant from "redux-immutable-state-invariant";
import rootReducer from "../reducers/index";

//const createStoreWithMiddleware = applyMiddleware(thunkMiddleware)(createStore);

const configureStore = initialState => {
  // const store = createStoreWithMiddleware(rootReducer, initialState);
  // return store;

  return createStore(
    rootReducer,
    initialState,
    // reduxImmutableStateInvariant only for development. Later to change, add check
    applyMiddleware(thunkMiddleware, reduxImmutableStateInvariant())
  );
};

export default configureStore;
