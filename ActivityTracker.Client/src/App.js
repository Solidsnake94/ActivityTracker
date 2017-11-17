import React from 'react';
import logo from './logo.svg';
import './App.css';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import ChatBox from './components/chat/ChatBox/ChatBox';
import SideBarList from './components/side-bar/SideBarList/SideBarList';
import Header from './components/header/Header';
import { subscribeToTimer } from './api';

class App extends React.Component {

  constructor(props) {
    super(props);

    subscribeToTimer((timestamp) => {
      this.setState({
        timestamp: timestamp
      });
    });

  };

  state = {
    timestamp: 'no timestamp'
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

          <div className="App-chat-container">
            <Header />
            <div style={{ display: 'flex', flexDirection: 'row' }}>
              <SideBarList />
              <ChatBox />
            </div>

            <div>
              This is value of the timestamp: {this.state.timestamp}          
            </div>

          </div>

        </div>
      </MuiThemeProvider>

    );
  }
}

export default App;
