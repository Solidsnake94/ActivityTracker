import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import AppBar from "material-ui/AppBar";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";
import { withStyles } from "material-ui/styles";
import TextField from "material-ui/TextField";
import { FormGroup, FormControlLabel } from "material-ui/Form";
import Checkbox from "material-ui/Checkbox";
import Paper from "material-ui/Paper";
import Button from "material-ui/Button";

import * as userActions from "../actions/userActions";

import NavTop from "./DashboardNavTop";

class Register extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      user: {
        firstName: "",
        lastName: "",
        birthDate: "",
        email: "",
        password: "",
        powerUser: false
      }
    };

    this.registerUser = this.registerUser.bind(this);
    this.onChange = this.onChange.bind(this);
  }

  registerUser(event) {
    event.preventDefault();
    this.props.actions
      .registerUser(this.state.user)
      .then(() => this.props.history.push("/registerSuccess"));
  }

  onChange(event) {
    const target = event.target;
    const name = target.name;
    const value = target.type === "checkbox" ? target.checked : target.value;

    this.setState(prevState => ({
      user: {
        ...prevState.user,
        [name]: value
      }
    }));
  }

  render() {
    return (
      <div>
        <NavTop />
        <Paper>
          <Typography type="headline" component="h3">
            Register Form
          </Typography>
          <form className={this.props.container}>
            <TextField
              id="full-width"
              label="Name"
              InputLabelProps={{
                shrink: true
              }}
              placeholder="Enter name"
              fullWidth
              margin="normal"
              // value={this.state.user.firstName}
              onChange={this.onChange}
              name="firstName"
            />
            <TextField
              id="full-width"
              label="Last Name"
              InputLabelProps={{
                shrink: true
              }}
              placeholder="Enter last name"
              fullWidth
              margin="normal"
              //value={this.state.user.lastName}
              onChange={this.onChange}
              name="lastName"
            />
            <TextField
              id="full-width"
              label="Date of Birth"
              InputLabelProps={{
                shrink: true
              }}
              placeholder="dd/mm/yyyy"
              fullWidth
              margin="normal"
              // value={this.state.user.birthDate}
              onChange={this.onChange}
              name="birthDate"
            />
            <TextField
              id="full-width"
              label="Email"
              InputLabelProps={{
                shrink: true
              }}
              placeholder="Email"
              fullWidth
              margin="normal"
              //value={this.state.user.email}
              onChange={this.onChange}
              name="email"
            />
            <TextField
              id="full-width"
              label="Password"
              InputLabelProps={{
                shrink: true
              }}
              placeholder="Enter password"
              type="password"
              fullWidth
              margin="normal"
              //value={this.state.user.password}
              onChange={this.onChange}
              name="password"
            />
            <Button
              raised
              color="primary"
              className={this.props.button}
              onClick={this.registerUser}
            >
              Register
            </Button>
          </form>
        </Paper>
      </div>
    );
  }
}

// Maps the dispatch functions definied in ./actions to props.actions.(ACTION_FUNC_NAME)
function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(userActions, dispatch)
  };
}

export default connect(null, mapDispatchToProps)(Register);
