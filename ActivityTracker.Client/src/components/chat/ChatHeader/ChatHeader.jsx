import React from 'react';
import './ChatHeader.css';
import AppBar from 'material-ui/AppBar';

class ChatHeader extends React.Component {
    render() {
        return (
           <AppBar iconElementLeft={<div/>} title="React Chat"  />
        );
    }
}

export default ChatHeader;