import React from "react";
import Paper from "material-ui/Paper";
import IconButton from "material-ui/IconButton";
import DeleteIcon from "material-ui-icons/Delete";
import EditIcon from "material-ui-icons/Edit";
import Table, {
  TableBody,
  TableCell,
  TableHead,
  TableRow
} from "material-ui/Table";

function getRowTableCells(row) {
  let rowCells = [];

  Object.keys(row).forEach((element, index) => {
    console.log(row);
    if (element !== "id" && element !== "userId") {
      rowCells.push(
        <TableCell key={index}>{row[element].toString()}</TableCell>
      );
      // rowCells.push(<TableCell>{row[element]}</TableCell>)
    }
  });
  return rowCells;
}

function CommonTable(props) {
  return (
    <Paper>
      <Table>
        <TableHead>
          <TableRow>
            {props.headings.map(heading => (
              <TableCell key={heading}>{heading}</TableCell>
            ))}
            <TableCell padding="checkbox" />
          </TableRow>
        </TableHead>
        <TableBody>
          {props.rows.map(row => (
            <TableRow hover key={row.id}>
              {getRowTableCells(row)}
              <TableCell>
                <IconButton color="primary">
                  <EditIcon />
                </IconButton>
                <IconButton color="contrast">
                  <DeleteIcon />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
  );
}

export default CommonTable;
