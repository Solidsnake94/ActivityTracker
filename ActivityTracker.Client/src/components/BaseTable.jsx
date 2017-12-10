import React from "react";
import Paper from "material-ui/Paper";
import Table, { TableBody, TableHead } from "material-ui/Table";

function CommonTable(props) {
  return (
    <Paper>
      <Table>
        <TableHead>{props.headings}</TableHead>
        <TableBody>{props.rows}</TableBody>
      </Table>
    </Paper>
  );
}

export default CommonTable;
