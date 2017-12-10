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

// export function filterIdsElementsfromArray(array) {
//   let filteredArray = array.map(item => {

//     var filteredKeys = Object.keys(item).filter(key => {
//       return !key.includes("Id");
//     });
//     let filteredObj = {};
//     filteredKeys.forEach(key => {
//       filteredObj[key] = item[key];
//     });
//     return filteredObj;
//   });

//   return filteredArray;
// }

// export function mapArrayToEditableTableBody(array) {
//   {
//     array.map(row => (
//       <TableRow hover key={row.id}>
//         {getRowTableCells(row)}
//         <TableCell>
//           <IconButton color="primary">
//             <EditIcon />
//           </IconButton>
//           <IconButton color="contrast">
//             <DeleteIcon />
//           </IconButton>
//         </TableCell>
//       </TableRow>
//     ));
//   }
// }

// function getRowTableCells(row) {
//   let rowCells = [];

//   Object.keys(row).forEach((element, index) => {
//     console.log(row);
//     if (element !== "id" && element !== "userId") {
//       rowCells.push(
//         <TableCell key={index}>{row[element].toString()}</TableCell>
//       );
//       // rowCells.push(<TableCell>{row[element]}</TableCell>)
//     }
//   });
//   return rowCells;
//}
