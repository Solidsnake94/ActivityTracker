import moment from "moment";

// function _isDate(element){
//   return element instanceof Date
// }

export function tryParseToDate(element) {
  if (element.toString() === "true" || element.toString() === "false") {
    return element.toString();
  } else if (!isNaN(element)) {
    return element;
  } else {
    let date = moment(element);
    return date.isValid() ? date.format("D/M/Y [h:] HH [m:] mm") : element;
  }
}
