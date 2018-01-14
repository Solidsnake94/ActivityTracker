import React from "react";

import "../styles/StartingPage.css";

import { withStyles } from "material-ui/styles";

import AppBar from "material-ui/AppBar";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";
import Paper from "material-ui/Paper";
import Button from "material-ui/Button"

import NavTop from "./DashboardNavTop";

const styles = theme => ({
  button: {
    maxWidth: "50px",
    alignSelf: "flex-end"
  }
});

const StartingPage = props => {
  const login = e => {
    props.history.push("/login");
  };
  const register = e => {
    props.history.push("/register");
  };


  return (
    <div>
      <NavTop />
      <Paper>
        <Typography type="headline" component="h3">
          Welcome activity enthusiast
                </Typography>

        <Typography component="p">
          Create activities and goals and let us track them for you
        </Typography>
        <Typography component="p">
          If it is your first time using our platform you can register  <a onClick={register}>here </a> or you if are are already a member of our community, login in <a onClick={login}>here</a>
        </Typography>
        

      </Paper>
    </div>
  );
};

export default withStyles(styles)(StartingPage);
