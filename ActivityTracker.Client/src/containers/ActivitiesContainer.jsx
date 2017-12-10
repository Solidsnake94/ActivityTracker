import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { Route, Link, Switch } from "react-router-dom";

import "../styles/ActivitiesContainer.css";
import * as activityActions from "../actions/activityActions";
import ActivityForm from "../components/ActivityForm";
import ActivityList from "../components/ActivityList";
import {
  ALL_ACTIVITIES_PATH,
  CREATE_ACTIVTIY_PATH,
  UPDATE_ACTIVTITY_PATH
} from "../constants/RouterConstants";

class ActivitiesContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { activities } = this.props;

    return (
      <Switch>
        <Route
          path={ALL_ACTIVITIES_PATH}
          exact
          render={props => <ActivityList activities={activities} />}
        />
        <Route path={CREATE_ACTIVTIY_PATH} exact component={ActivityForm} />
        <Route path={UPDATE_ACTIVTITY_PATH} component={ActivityForm} />
      </Switch>
    );
  }
}

// Verifies that assinged elements from the store and actions are correct type
ActivitiesContainer.propTypes = {
  activities: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired
};

// Maps selected part of the store state to the definied props - here state.activities
function mapStateToProps(state, ownProps) {
  return {
    activities: state.activities
  };
}

// Maps the dispatch functions definied in ./actions to props.actions.(ACTION_FUNC_NAME)
function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(activityActions, dispatch)
  };
}

// Binds the selected state and props to the component / container
export default connect(mapStateToProps, mapDispatchToProps)(
  ActivitiesContainer
);

//  withRouter()
