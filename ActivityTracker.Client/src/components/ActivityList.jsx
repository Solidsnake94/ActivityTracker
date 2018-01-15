import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { withRouter, Link } from 'react-router-dom';

import PropTypes from "prop-types";

import * as activityAction from '../actions/activityActions';

import { TableHead, TableCell, TableRow } from "material-ui/Table";
import { mapArrayToTableHeadings } from "../utils/TableUtils";
import { tryParseToDate } from "../utils/DateUtils";
import BaseTable from "./BaseTable";
import IconButton from "material-ui/IconButton";
import DeleteIcon from "material-ui-icons/Delete";
import EditIcon from "material-ui-icons/Edit";


const headings = mapArrayToTableHeadings([
  "Created Date",
  "Time",
  "distanceInKilometers"
]);

class ActivityList extends React.Component {
  constructor(props) {
    super(props);
    this.deleteActivity = this.deleteActivity.bind(this);
    this.updateActivity = this.updateActivity.bind(this);
  }

  deleteActivity(id) {
    console.log("this is the id : " + id);
    this.props.actions.deleteActivity(id);
  }

  updateActivity(activity) {
    console.log("update Activity " + activity.activityID);    
  }

  render() {
    const rows = this.props.activities.map(activity => (

      <TableRow hover key={activity.activityId}>
        {Object.keys(activity)
          .filter(prop => {
            return prop.includes("Id") || prop.includes("ID") ? false : true;
          })
          .map(activityProp => (
            <TableCell key={activityProp}>
              {tryParseToDate(activity[activityProp])}
            </TableCell>
          ))}
        <TableCell>
          <IconButton color="primary">
            <EditIcon onClick={() => this.updateActivity(activity)} />
          </IconButton>
          <IconButton color="contrast">
            <DeleteIcon onClick={() => this.deleteActivity(activity.activityID)} />
          </IconButton>
        </TableCell>
      </TableRow>
    ));
    return (
      <div>
        <header>
          <h1> Activities</h1>
        </header>
        <BaseTable headings={headings} rows={rows} />
      </div>
    );
  };
}



ActivityList.propTypes = {
  activities: PropTypes.array.isRequired
};

function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(activityAction, dispatch)
  };
}
export default connect(null, mapDispatchToProps)(ActivityList);
