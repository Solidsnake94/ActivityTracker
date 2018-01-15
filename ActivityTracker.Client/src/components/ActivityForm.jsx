import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import * as activityAction from '../actions/activityActions';

import { withStyles } from "material-ui/styles";
import TextField from "material-ui/TextField";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";
import { FormGroup, FormControlLabel } from "material-ui/Form";
import Checkbox from "material-ui/Checkbox";
import Paper from "material-ui/Paper";
import Button from "material-ui/Button";
import Select from 'material-ui/Select'
import Input, { InputLabel } from 'material-ui/Input';
import { MenuItem } from 'material-ui/Menu';

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

class ActivityForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      createdActivity: {
        createdDate: "",
        time: "",
        distanceInKilometers: "",
        userId: "2",
        activityTypeID: ""
      }
    }
    console.log("State" + this.state);

    this.onSubmitForm = this.onSubmitForm.bind(this);
    this.onChange = this.onChange.bind(this);
  }

  onChange(event) {
    const target = event.target;
    const name = target.name;
    const value = target.type === "checkbox" ? target.checked : target.value;
    console.log(value);
    this.setState(prevState => ({
      createdActivity: {
        ...prevState.createdActivity,
        [name]: value
      }
    }
  ));
  }
  onSubmitForm(e) {
    e.preventDefault();

    console.log("createdActivity : "+this.state.createdActivity);
    this.props.actions.createActivity(this.state.createdActivity)
      .then(() => this.props.history.push("/dashboard/activities/all"));
  }
  render() {
    const { classes } = this.props;
    return (
      // <div className="activityForm">

      <div>
        <Paper>
          <Toolbar>
            <Typography type="title" color="inherit">
              Create new activity
          </Typography>
          </Toolbar>
          <form
            className={classes.container}

          >
          <InputLabel htmlFor="age-simple">Activity Type</InputLabel>
          <Select
            value={this.state.createdActivity.activityTypeID}
            onChange={this.onChange}
            input={<Input name="activityTypeID" id="age-simple" />}
          >
            <MenuItem value="">
              None
            </MenuItem>
            <MenuItem value={1}>Running</MenuItem>
            <MenuItem value={2}>Swimming</MenuItem>
            <MenuItem value={3}>Cycling</MenuItem>
            <MenuItem value={4}>Walking</MenuItem>
          </Select>
            <TextField label="Created Date" type="text" placeholder="ex: 01 Jan 18"
            onChange={this.onChange}
            name="createdDate"
            />
            <TextField label="Time" type="text" placeholder="hh:mm:ss"
            onChange={this.onChange}
            name="time"
            />
            <TextField label="Distance" type="text" placeholder="Kilometers"
            onChange={this.onChange}
            name="distanceInKilometers"
            />
            <Button raised color="primary" className={classes.button} onClick={this.onSubmitForm}>
              create
          </Button>
          </form>
        </Paper>
      </div>

      // </div>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(activityAction, dispatch)
  };
}

export default connect(null, mapDispatchToProps)(withStyles(styles)(ActivityForm));

