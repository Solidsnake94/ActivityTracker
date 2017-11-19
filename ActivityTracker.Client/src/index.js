import React from "react";
import ReactDOM from "react-dom";
// import { createStore } from 'redux';
import { Provider } from "react-redux";
//import { Router, Route } from 'react-router';
import { BrowserRouter, Route } from "react-router-dom";

import registerServiceWorker from "./registerServiceWorker";

import configureStore from "./store/configureStore";
import App from "./components/App/App";

const store = configureStore();

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <Route path="/" component={App} />
    </BrowserRouter>
  </Provider>,
  document.getElementById("root")
);

registerServiceWorker();
