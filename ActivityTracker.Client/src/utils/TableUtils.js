import React from "react";
import { TableHead, TableCell, TableRow } from "material-ui/Table";
import IconButton from "material-ui/IconButton";
import DeleteIcon from "material-ui-icons/Delete";
import EditIcon from "material-ui-icons/Edit";



export function mapArrayToTableHeadings(headings) {
  return (
    <TableRow>
      {headings.map(heading => <TableCell key={heading}>{heading}</TableCell>)}
      <TableCell padding="checkbox" />
    </TableRow>
  );
}
