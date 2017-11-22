import React from "react";
import PropTypes from "prop-types"; 

const ActivityListItem = ({ activity }) => {
  return (
    <div>
        <h3>{activity.title}</h3>
        time: {activity.time}
    </div>
  );
};

ActivityListItem.propTypes = {
    activity: PropTypes.object.isRequired
};

export default ActivityListItem;