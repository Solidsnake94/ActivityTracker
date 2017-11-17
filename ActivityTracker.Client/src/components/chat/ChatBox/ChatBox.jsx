import React from 'react';
import Divider from 'material-ui/Divider';
import ChatHeader from '../ChatHeader/ChatHeader';
import ChatContent from '../ChatContent/ChatContent';
import ChatInput from '../ChatInput/ChatInput';
import './ChatBox.css';


class ChatBox extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div className="chatBox">
                {/* <ChatHeader /> */}
                <ChatContent />
                <Divider/>
                <ChatInput />
            </div>
        );
    }
}

export default ChatBox;