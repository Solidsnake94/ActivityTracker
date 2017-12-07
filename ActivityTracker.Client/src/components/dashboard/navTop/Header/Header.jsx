import React, { Component } from "react";
import './Header.css'
import runningMan from "../../../../images/running-man.svg";

class Header extends Component {
  render() {
    return (
      <header className="header">
        <h1 className="title">
          Activity Tracker - focus on running, rest leave to us !
        </h1>
        <img src={runningMan} className="logo" alt="logo" />
      </header>
    );
  }
}

export default Header;
