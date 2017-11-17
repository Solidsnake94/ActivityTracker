import React from 'react';
import './ChatInput.css'
import TextField from 'material-ui/TextField';
import FontIcon from 'material-ui/FontIcon';
import IconButton from 'material-ui/IconButton';

const textFieldStyle = {
    width: '90%',
};

class ChatInput extends React.Component {
    render() {
        return (
            <div className="chatInput">
                <TextField hintText="type your message" multiLine={true} style={textFieldStyle}/>
                <IconButton iconClassName="material-icons" tooltip="Send Message" style={{width: '10%'}}>send</IconButton>      
                {/* <i class="material-icons" >send</i> */}
            </div>
        );
    }
}

export default ChatInput;