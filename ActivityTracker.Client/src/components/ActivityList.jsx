import React from "react";
import PropTypes from "prop-types";
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

const ActivityList = props => {
  const rows = props.activities.map(activity => (
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
          <EditIcon />
        </IconButton>
        <IconButton color="contrast">
          <DeleteIcon />
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

ActivityList.propTypes = {
  activities: PropTypes.array.isRequired
};

export default ActivityList;
