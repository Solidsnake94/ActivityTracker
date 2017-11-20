import React, { PropTypes } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as activityActions from "../actions/activityActions";

class ActivitiesPage extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  componentWillMount() {}

  componentDidMount() {}

  componentWillReceiveProps(nextProps) {}

  shouldComponentUpdate(nextProps, nextState) {}

  componentWillUpdate(nextProps, nextState) {}

  componentDidUpdate(prevProps, prevState) {}

  componentWillUnmount() {}

  render() {
    return <div />;
  }
}

// Verifies that assinged elements from the store and actions are correct type
ActivitiesPage.propTypes = {
  activities: PropTypes.array.isRequired,
  actions: PropTypes.func.isRequired
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
export default connect(mapStateToProps, mapDispatchToProps)(ActivitiesPage);
