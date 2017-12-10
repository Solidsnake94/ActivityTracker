import React from "react";
import PropTypes from "prop-types";
import { Switch, Route, Redirect, Link } from "react-router-dom";

const DashboardOverview = props => {
  return (
    <div>
      <h2>
        Welcome to your dashboard Pawel
        <br />
      </h2>
    </div>
  );
};

DashboardOverview.propTypes = {};

export default DashboardOverview;
