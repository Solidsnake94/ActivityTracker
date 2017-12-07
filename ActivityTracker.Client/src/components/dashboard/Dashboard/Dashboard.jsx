import React from "react";
import { Switch, Route, Redirect, Link } from "react-router-dom";

import "./Dashboard.css";
import Header from "../navTop/Header/Header";
import NavSide from "../navSide/List/List";
import WelcomeDashboard from "../content/WelcomeDashboard/WelcomeDashboard";
import ActivitiesContainer from "../../../containers/ActivitiesContainer/ActivitiesContainer";

const Dashboard = props => {
  console.log("dashboard.props");
  console.log(props);

  return (
    <div>
      <Header />
      <div className="dashboad-layout">
        <NavSide />
        <div style={{ display: "flex" }}>
          <Switch>
            <Route
              path={`${props.match.path}`}
              exact
              component={WelcomeDashboard}
            />
            <Route
              path={`${props.match.path}/activities`}
              component={ActivitiesContainer}
            />
            <Route
              path={`${props.match.path}/goals`}
              component={WelcomeDashboard}
            />
            <Route
              path={`${props.match.path}/achievements`}
              component={WelcomeDashboard}
            />
          </Switch>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
