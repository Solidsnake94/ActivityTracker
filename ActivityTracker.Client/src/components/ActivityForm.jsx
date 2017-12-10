import React, { Component } from "react";
import AppBar from "material-ui/AppBar";
import TextField from "material-ui/TextField";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";

import "../styles/ActivityForm.css";

class ActivityForm extends Component {
  render() {
    return (
      // <div className="activityForm">

      <div
        style={{ display: "flex", flexDirection: "column", alignItems: "center", padding: "50px" }}
      >
        <AppBar position="static" color="default">
          <Toolbar>
            <Typography type="title" color="inherit">
              Create new activity
            </Typography>
          </Toolbar>
        </AppBar>
        <TextField fullWidth label="Name" type="text" />
        <TextField fullWidth label="Time" type="text" />
        <TextField fullWidth label="Date" type="text" />
      </div>

      // </div>
    );
  }
}

export default ActivityForm;
