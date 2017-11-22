import React from "react";
import logo from "../../logo.svg";
import "./App.css";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";
import List from "../dashboard/sideNavigation/List/List";
import ActivitiesPage from "../dashboard/content/activities/ActivitiesPage";
import runningMan from "../../images/running-man.svg";

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <MuiThemeProvider>
        <div className="App">
          <header className="App-header">
            <h1 className="App-title">
              Activity Tracker - focus on running, rest leave to us !
            </h1>
            <img src={runningMan} className="App-logo" alt="logo" />
          </header>

          <div style={{ display: "flex", flexDirection: "row" }}>
            <div style={{ width: "20%", borderRight: "1px solid black", marginRight: "30px" }}>
              <List />
            </div>

            <ActivitiesPage />
          </div>
        </div>
      </MuiThemeProvider>
    );
  }
}

export default App;
