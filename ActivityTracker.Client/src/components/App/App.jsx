import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";

import { MuiThemeProvider, createMuiTheme } from "material-ui/styles";
import purple from "material-ui/colors/purple";
import green from "material-ui/colors/green";
import red from "material-ui/colors/red";

import "./App.css";
import Dashboard from "../dashboard/Dashboard/Dashboard";
import StartingPage from "../startingPage/StartingPage/StartingPage";

const theme = createMuiTheme({
  palette: {
    primary: green, // Purple and green play nicely together.
    secondary: {
      ...green,
      A400: "#00e677"
    },
    error: red
  }
});

class App extends React.Component {
  // constructor(props) {
  //   super(props);
  // }

  // <MuiThemeProvider muiTheme={customTheme}>

  render() {
    // console.log(this.props);
    return (
      <MuiThemeProvider theme={theme}>
        <Switch>
          <Route exact path="/" component={StartingPage} />
          <Route path="/dashboard" component={Dashboard} />
        </Switch>
      </MuiThemeProvider>
    );
  }
}

export default App;
