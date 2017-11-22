import React from "react";
import PropTypes from "prop-types";
import ActivityListItem from "./ActivityListItem";

const ActivitiesList = ({ activities }) => {
  return (
    <div>
      <header>
        <h1> Activities</h1>
      </header>
      {activities.map(activity => <ActivityListItem key={activity.id} activity={activity} />)}
    </div>
  );
};

ActivitiesList.propTypes = {
   activities: PropTypes.array.isRequired
};

export default ActivitiesList;

// key={activity.id}
