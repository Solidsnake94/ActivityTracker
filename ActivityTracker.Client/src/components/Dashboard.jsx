import React from "react";
import { Switch, Route, Redirect, Link } from "react-router-dom";

import "../styles/Dashboard.css";
import NavTop from "./DashboardNavTop";
import NavSide from "./DashboardNavSide";
import DashboardOverview from "./DashboardOverview"
import ActivitiesContainer from "../containers/ActivitiesContainer";
import GoalsContainer from "../containers/GoalsContainer";

const Dashboard = props => {
  console.log("dashboard.props");
  console.log(props);

  return (
    <div>
      <NavTop />
      <div className="dashboard-main">
        <NavSide />
        <div className="dashboard-content">
        <Switch  >
          <Route
            path={`${props.match.path}`}
            exact
            component={DashboardOverview}
          />
          <Route
            path={`${props.match.path}/activities`}
            component={ActivitiesContainer}
          />
          <Route
            path={`${props.match.path}/goals`}
            component={GoalsContainer}
          />
          <Route
            path={`${props.match.path}/achievements`}
            component={DashboardOverview}
          />
        </Switch>
        </div>
        
      </div>
    </div>
  );
};

export default Dashboard;
