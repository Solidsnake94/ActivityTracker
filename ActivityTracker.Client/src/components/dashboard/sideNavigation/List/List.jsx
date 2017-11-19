import React from 'react';
import { List as MaterialUIList, ListItem as MaterialUIListItem } from 'material-ui/List';
import ContentInbox from 'material-ui/svg-icons/content/inbox';
import ActionGrade from 'material-ui/svg-icons/action/grade';
import ContentSend from 'material-ui/svg-icons/content/send';
import ContentDrafts from 'material-ui/svg-icons/content/drafts';
import './List.css'
//import AppBar from 'material-ui/AppBar';

class List extends React.Component {
    render() {
        return (
            <div className="list-container">
                <MaterialUIList>
                    <MaterialUIListItem primaryText="Inbox" leftIcon={<ContentInbox />} />
                    <MaterialUIListItem primaryText="Starred" leftIcon={<ActionGrade />} />
                    <MaterialUIListItem primaryText="Sent mail" leftIcon={<ContentSend />} />
                    <MaterialUIListItem primaryText="Drafts" leftIcon={<ContentDrafts />} />
                    <MaterialUIListItem primaryText="Inbox" leftIcon={<ContentInbox />} />
                </MaterialUIList>
            </div>

        );
    }
}

export default List;