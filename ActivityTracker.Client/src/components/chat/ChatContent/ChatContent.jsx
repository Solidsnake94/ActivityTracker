import React from 'react';
import Avatar from 'material-ui/Avatar';
import { List, ListItem } from 'material-ui/List';
import { cyan50 } from 'material-ui/styles/colors'

import './ChatContent.css';

const chatMsgMeStyle = {
    whiteSpace: 'pre-wrap',
    textAlign: 'left',
    backgroundColor: cyan50
}
const chatMsgDefaultStyle = {
    whiteSpace: 'pre-wrap',
    textAlign: 'left',
}

class ChatContent extends React.Component {
    constructor(props) {
        super(props);

    }

    // getMessages = () => {
    //     return 
    // }

    // getMessages() {
    //     return 
    // }

    render() {
        const messages = [
            {
                user: 'Pawel',
                text: 'This is a first message Im \n writing \n two lines.',
                letter: 'P',
                me: true
            },
            {
                user: 'Sara',
                text: 'This the second message                afaascs BBASDASd',
                letter: 'S',
                me: false
            },
            {
                user: 'Pawel',
                text: 'This the second message afaascs BBASDASd',
                letter: 'S',
                me: true
            },
            {
                user: 'Sara',
                text: 'This the second message afaascs BBASDASd',
                letter: 'S',
                me: false
            }
        ];
        const listItemMessages = messages.map((message) => {
            //let selectedStyle = 
            return <ListItem style={message.me ? chatMsgMeStyle : chatMsgDefaultStyle} 
                             disabled={true} 
                             leftAvatar={<Avatar>{message.letter}</Avatar>} 
                             primaryText={message.user}
                             secondaryText={message.text}/>
        });

        return (
            <List>
                {listItemMessages}
            </List>

        );
    }
}

export default ChatContent;