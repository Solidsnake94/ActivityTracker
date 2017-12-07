import React from "react";
import PropTypes from "prop-types";
import ActivityListItem from "./ActivityListItem";
import Table from "../../../../common/Table/Table";

const ActivityList = ({ activities }) => {

  const getHeadings = activities => {
    if (activities && activities.length > 0) {
      let _headings = [];
      Object.keys(activities[0]).forEach(property => {
        if (property !== "id" && property !== "userId") {
          _headings.push(property.toUpperCase());
        }
      });
      return _headings;
    }
    return [];
  };

  const headings = getHeadings(activities);

  console.log(headings);

  return (
    <div>
      <header>
        <h1> Activities</h1>
      </header>
      <Table headings={headings} rows={activities} />
      {/* {activities.map(activity => <ActivityListItem key={activity.id} activity={activity} />)} */}
    </div>
  );
};

ActivityList.propTypes = {
  activities: PropTypes.array.isRequired
};

export default ActivityList;
