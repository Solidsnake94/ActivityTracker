import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { BrowserRouter, Route } from "react-router-dom";

import registerServiceWorker from "./registerServiceWorker";

import configureStore from "./store/configureStore";
import App from "./components/App/App";

import { loadActivities } from "./actions/activityActions";

const store = configureStore();
store.dispatch(loadActivities());
console.log("get store");
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
