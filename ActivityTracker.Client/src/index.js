import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { BrowserRouter, Route } from "react-router-dom";

import registerServiceWorker from "./registerServiceWorker";

import configureStore from "./store/configureStore";
import App from "./components/App";

import { loadActivities } from "./actions/activityActions";
import { loadGoals } from "./actions/goalActions";

import ApiGoals from "./apiRest/apiGoals"; 



const store = configureStore();

//ApiGoals.getAllUserGoals(19)
store.dispatch(loadActivities());
store.dispatch(loadGoals());

console.log("redux store on app load:");
console.log(store.getState());

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <Route path="/" component={App} />
    </BrowserRouter>
  </Provider>,
  document.getElementById("root")
);

registerServiceWorker();
