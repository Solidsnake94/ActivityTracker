import React from 'react';
import logo from './logo.svg';
import './App.css';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import ChatBox from './components/chat/ChatBox/ChatBox';
import SideBarList from './components/side-bar/SideBarList/SideBarList';
import Header from './components/header/Header';

class App extends React.Component {

  constructor(props) {
    super(props);

  };

  render() {
    return (
      <MuiThemeProvider>
        <div className="App">

          <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
            <h1 className="App-title">Welcome to React</h1>
          </header>

          <p className="App-intro">
            To get started, edit <code>src/App.js</code> and save to reload.
          </p>

        </div>
      </MuiThemeProvider>

    );
  }
}

export default App;
