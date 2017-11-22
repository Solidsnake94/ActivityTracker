import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import reduxImmutableStateInvariant from "redux-immutable-state-invariant";
import rootReducer from "../reducers/index";

//const createStoreWithMiddleware = applyMiddleware(thunkMiddleware)(createStore);

// const configureStore = initialState => {
//   // const store = createStoreWithMiddleware(rootReducer, initialState);
//   // return store;

//   return createStore(
//     rootReducer,
//     // initialState,
//     // reduxImmutableStateInvariant only for development. Later to change, add check
//     //applyMiddleware(thunk, reduxImmutableStateInvariant())
//     applyMiddleware(thunk)
//   );
// };

// export default configureStore;


export default function configureStore(initialState) {
  return createStore(
    rootReducer,
    initialState,
    applyMiddleware(thunk, reduxImmutableStateInvariant())
  );
}
