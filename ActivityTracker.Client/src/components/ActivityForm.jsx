import React, { Component } from "react";
import { withStyles } from "material-ui/styles";
import TextField from "material-ui/TextField";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";
import { FormGroup, FormControlLabel } from "material-ui/Form";
import Checkbox from "material-ui/Checkbox";
import Paper from "material-ui/Paper";
import Button from "material-ui/Button";

import "../styles/ActivityForm.css";

const styles = theme => ({
  container: {
    display: "flex",
    flexDirection: "column",
    padding: "30px"
  },
  button: {
    maxWidth: "50px",
    alignSelf: "flex-end",
    marginTop: "50px"
  }
});

function ActivityForm(props) {
  const { classes } = props;

  return (
    // <div className="activityForm">

    <div>
      <Paper>
        <Toolbar>
          <Typography type="title" color="inherit">
            Create new goal
          </Typography>
        </Toolbar>
        <form className={classes.container}>
          <TextField label="Created Date" type="text" />
          <TextField label="Time" type="text" />
          <TextField label="Distance (KM)" type="text" />
          <Button raised color="primary" className={classes.button}>
            Primary
          </Button>
        </form>
      </Paper>
    </div>

    // </div>
  );
}

export default withStyles(styles)(ActivityForm);
