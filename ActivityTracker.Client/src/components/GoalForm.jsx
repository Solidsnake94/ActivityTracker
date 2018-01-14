import React, { Component } from "react";
import { withStyles } from "material-ui/styles";
import TextField from "material-ui/TextField";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";
import Checkbox from "material-ui/Checkbox";
import { FormGroup, FormControlLabel } from "material-ui/Form";
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
    alignSelf: "flex-end"
  }
});

function GoalForm(props) {
  const { classes } = props;
  return (
    <div>
      <Paper>
        <Toolbar>
          <Typography type="title" color="inherit">
            Create new goal
          </Typography>
        </Toolbar>
        <form className={classes.container}>
          <TextField label="Name" type="text" placeholder="Enter your name"/>
          <TextField label="Start Date" type="text"  placeholder="dd/mm/yyyy" />
          <TextField label="End Date" type="text" placeholder="dd/mm/yyyy"/>
          <TextField label="Target Distance" placeholder="Kilometers" type="text" />
          <TextField label="Target Time" placeholder="hh:mm:ss" type="text" />
          <FormGroup>
            <FormControlLabel
              label="Completed"
              control={
                <Checkbox
                  checked={true}
                  // onChange={(event, checked) => this.setState({ dense: checked })}
                  value="dense"
                />
              }
            />
            <FormControlLabel
              label="Is Public"
              control={
                <Checkbox
                  checked={true}
                  // onChange={(event, checked) => this.setState({ dense: checked })}
                  value="dense"
                />
              }
            />
            <Button raised color="primary" className={classes.button}>
              Create
            </Button>
          </FormGroup>
        </form>
      </Paper>
    </div>
  );
}

export default withStyles(styles)(GoalForm);
