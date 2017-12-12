import moment from 'moment';


function _isDate(element){
  return element instanceof Date
}

export function tryParseToDate(element){
  return _isDate(element) ? moment(element).format('D[.]M[.]Y H:m') : element
}