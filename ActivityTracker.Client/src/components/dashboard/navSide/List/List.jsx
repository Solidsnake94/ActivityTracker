import React from "react";
import List, { ListItem, ListItemIcon, ListItemText } from "material-ui/List";
import CheckBoxIcon from "material-ui-icons/CheckBox";
import StarIcon from "material-ui-icons/Star";
import RunnerIcon from "material-ui-icons/DirectionsRun"

import "./List.css";
//import AppBar from 'material-ui/AppBar';

class SideList extends React.Component {
  render() {
    return (
      <div className="list-container">
        <List>
          <ListItem button>
            <ListItemIcon>
              <RunnerIcon />
            </ListItemIcon>
            <ListItemText primary="Activities" />
          </ListItem>
          <ListItem button>
            <ListItemIcon>
              <CheckBoxIcon />
            </ListItemIcon>
            <ListItemText primary="Goals" />
          </ListItem>
          <ListItem button>
            <ListItemIcon>
              <StarIcon />
            </ListItemIcon>
            <ListItemText primary="Achievements" />
          </ListItem>
        </List>
      </div>
    );
  }
}

export default SideList;
