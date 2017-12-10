import React from "react";
import PropTypes from "prop-types";

import { TableHead, TableCell, TableRow } from "material-ui/Table";

import {
  mapArrayToTableHeadings,
} from "../utils/TableUtils";
import BaseTable from "./BaseTable";
import IconButton from "material-ui/IconButton";
import DeleteIcon from "material-ui-icons/Delete";
import EditIcon from "material-ui-icons/Edit";

const headings = mapArrayToTableHeadings([
  "Name",
  "Start",
  "End",
  "Target Distance",
  "Target Time",
  "Completed",
  "Is Public"
]);

const GoalList = props => {
  const rows = props.goals.map(goal => (
    <TableRow hover key={goal.goalId}>
      {Object.keys(goal)
        .filter(prop => {
          return prop.includes("Id") || prop.includes("ID") ? false : true;
        })
        .map(goalProp => (
          <TableCell key={goalProp}>{goal[goalProp].toString()}</TableCell>
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

  return <BaseTable headings={headings} rows={rows} />;
};

GoalList.propTypes = {
  goals: PropTypes.array.isRequired
};

export default GoalList;
