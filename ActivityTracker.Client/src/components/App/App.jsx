import React from "react";
import logo from "../../logo.svg";
import "./App.css";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";
import List from "../dashboard/sideNavigation/List/List";
import runningMan from '../../images/running-man.svg';

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <MuiThemeProvider>
        <div className="App">
          <header className="App-header">
            <img src={runningMan} className="App-logo" alt="logo" />
            <h1 className="App-title">Activity Tracker - focus on running, rest leave to us ! </h1>
          </header>

          <div>
            <List />
          </div>
        </div>
      </MuiThemeProvider>
    );
  }
}

export default App;
