import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as activityActions from "../../../../actions/activityActions";
import ActivitiesList from "./ActivitiesList";
///actions/activityActions

class ActivitiesPage extends React.Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  // componentWillMount() {}

  // componentDidMount() {}

  // componentWillReceiveProps(nextProps) {}

  // shouldComponentUpdate(nextProps, nextState) {}

  // componentWillUpdate(nextProps, nextState) {}

  // componentDidUpdate(prevProps, prevState) {}

  // componentWillUnmount() {}

  render() {
    console.log(this.props);
    const {activities} = this.props;

    return (
      <div>
        <ActivitiesList activities={activities}/>
      </div>
    );
  }
}

// Verifies that assinged elements from the store and actions are correct type
ActivitiesPage.propTypes = {
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
export default connect(mapStateToProps, mapDispatchToProps)(ActivitiesPage);
