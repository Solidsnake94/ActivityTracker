import React, { Component } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { Route, Link, Switch } from "react-router-dom";

import "../styles/GoalsContainer.css";
import * as goalActions from "../actions/goalActions";
import GoalForm from "../components/GoalForm";
import GoalList from "../components/GoalList";
import {
  ALL_GOALS_PATH,
  CREATE_GOAL_PATH,
  UPDATE_GOAL_PATH
} from "../constants/RouterConstants";

class GoalsContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <Switch>
        <Route
          path={ALL_GOALS_PATH}
          exact
          render={props => <GoalList goals={this.props.goals} />}
        />
        <Route path={CREATE_GOAL_PATH} exact component={GoalForm} />} />
        <Route path={UPDATE_GOAL_PATH} component={GoalForm} />} />
      </Switch>
    );
  }
}

GoalsContainer.propTypes = {
  goals: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired
};

// Maps selected part of the store state to the definied props - here state.activities
function mapStateToProps(state, ownProps) {
  return {
    goals: state.goals
  };
}

// Maps the dispatch functions definied in ./actions to props.actions.(ACTION_FUNC_NAME)
function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(goalActions, dispatch)
  };
}

// Binds the selected state and props to the component / container
export default connect(mapStateToProps, mapDispatchToProps)(GoalsContainer);
