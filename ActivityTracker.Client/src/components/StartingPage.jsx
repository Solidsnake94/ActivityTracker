import React from "react";
import AppBar from "material-ui/AppBar";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";

const StartingPage = props => {
  const login = e => {
    props.history.push("/dashboard");
  };

  return (
    <div>
      <AppBar position="static" color="default">
        <Toolbar>
          <Typography type="title" color="inherit">
            Title
          </Typography>
        </Toolbar>
      </AppBar>

      <h1> Landing Page </h1>
      <p> Create activities and goals and let us track them for you</p>
      <button onClick={login}> Log in to dashboard</button>
    </div>
  );
};

export default StartingPage;
