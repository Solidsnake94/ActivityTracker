import React from "react";
import { Link } from "react-router-dom";

import { withStyles } from "material-ui/styles";
import List, { ListItem, ListItemIcon, ListItemText } from "material-ui/List";
import Collapse from "material-ui/transitions/Collapse";
import CheckBoxIcon from "material-ui-icons/CheckBox";
import ListIcon from "material-ui-icons/List";
import StarIcon from "material-ui-icons/Star";
import RunnerIcon from "material-ui-icons/DirectionsRun";
import DirectionsIcon from "material-ui-icons/Directions";
import Divider from 'material-ui/Divider';
import AddIcon from "material-ui-icons/Add";
import ChartIcon from "material-ui-icons/ShowChart";
import ExpandLess from "material-ui-icons/ExpandLess";
import ExpandMore from "material-ui-icons/ExpandMore";

import "../styles/DashboardNavSide.css";

import * as routes from "../constants/RouterConstants";

const styles = theme => ({
  root: {
    width: "100%",
    height: "100%",
    maxWidth: 300
  },
  nested: {
    paddingLeft: theme.spacing.unit * 4,
    marginBottom: "20px"
  },
  listItem: {
    marginBottom: "20px"
  }
});

class DashboardNavSide extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      openedListItems: [false, false, false]
    };
  }

  handleListItemClick = index => e => {
    this.setState((prevState, props) => {
      let list = [false, false, false];
      list[index] = !prevState.openedListItems[index];
      return { openedListItems: list };
    });
  };

  render() {
    const { classes } = this.props;

    return (
      // <div className="list-container">
      <List className={classes.root}>
        <ListItem className={classes.listItem} button>
          <ListItemIcon>
            <DirectionsIcon />
          </ListItemIcon>
          <ListItemText primary="Overview" />
          {/* {this.state.openedListItems[0] ? <ExpandLess /> : <ExpandMore />} */}
        </ListItem>
        <ListItem
          className={classes.listItem}
          button
          onClick={this.handleListItemClick(0)}
        >
          <ListItemIcon>
            <RunnerIcon />
          </ListItemIcon>
          <ListItemText primary="Activities" />
          {this.state.openedListItems[0] ? <ExpandLess /> : <ExpandMore />}
        </ListItem>
        <Collapse
          component="li"
          in={this.state.openedListItems[0]}
          timeout="auto"
          unmountOnExit
        >
          <List disablePadding>
            <Link to={routes.ALL_ACTIVITIES_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <ListIcon />
                </ListItemIcon>
                <ListItemText inset primary="All" />
              </ListItem>
            </Link>
            <Link to={routes.CREATE_ACTIVTIY_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <AddIcon />
                </ListItemIcon>
                <ListItemText inset primary="Create" />
              </ListItem>
            </Link>
            <Link to={routes.STATISTICS_ACTIVITY_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <ChartIcon />
                </ListItemIcon>
                <ListItemText inset primary="Statistics" />
              </ListItem>
            </Link>
          </List>
        </Collapse>

        <ListItem
          className={classes.listItem}
          button
          onClick={this.handleListItemClick(1)}
        >
          <ListItemIcon>
            <CheckBoxIcon />
          </ListItemIcon>
          <ListItemText primary="Goals" />
          {this.state.openedListItems[1] ? <ExpandLess /> : <ExpandMore />}
        </ListItem>
        <Collapse
          component="li"
          in={this.state.openedListItems[1]}
          timeout="auto"
          unmountOnExit
        >
          <List disablePadding>
            <Link to={routes.ALL_GOALS_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <ListIcon />
                </ListItemIcon>
                <ListItemText inset primary="All" />
              </ListItem>
            </Link>
            <Link to={routes.CREATE_GOAL_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <AddIcon />
                </ListItemIcon>
                <ListItemText inset primary="Create" />
              </ListItem>
            </Link>
            <Link to={routes.STATISTICS_GOAL_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <ChartIcon />
                </ListItemIcon>
                <ListItemText inset primary="Statistics" />
              </ListItem>
            </Link>
          </List>
        </Collapse>

        <ListItem
          className={classes.listItem}
          button
          onClick={this.handleListItemClick(2)}
        >
          <ListItemIcon>
            <StarIcon />
          </ListItemIcon>
          <ListItemText primary="Achievements" />
          {this.state.openedListItems[2] ? <ExpandLess /> : <ExpandMore />}
        </ListItem>
        <Collapse
          component="li"
          in={this.state.openedListItems[2]}
          timeout="auto"
          unmountOnExit
        >
          <List disablePadding>
            <Link to={routes.ALL_ACHIEVEMENTS_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <ListIcon />
                </ListItemIcon>
                <ListItemText inset primary="All" />
              </ListItem>
            </Link>
            <Link to={routes.STATISTICS_ACHIEVEMENTS_PATH}>
              <ListItem button className={classes.nested}>
                <ListItemIcon>
                  <ChartIcon />
                </ListItemIcon>
                <ListItemText inset primary="Statistics" />
              </ListItem>
            </Link>
          </List>
        </Collapse>
        <Divider />
        <ListItem className={classes.listItem} button>
          <ListItemText primary="Log Out" />
          {/* {this.state.openedListItems[0] ? <ExpandLess /> : <ExpandMore />} */}
        </ListItem>
      </List>
      //  </div>
    );
  }
}

export default withStyles(styles)(DashboardNavSide);
