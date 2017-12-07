// Activities Routes & Paths
export const ALL_ACTIVITIES_PATH = "/dashboard/activities/all";
export const CREATE_ACTIVTIY_PATH = "/dashboard/activities/create";
export const UPDATE_ACTIVTITY_PATH = "/dashboard/activities/update/:id";
export const ACTIVITIES_ROUTES = [
  {
    path: ALL_ACTIVITIES_PATH,
    label: "All Activities"
  },
  {
    path: CREATE_ACTIVTIY_PATH,
    label: "Create Activity"
  },
  {
    path: UPDATE_ACTIVTITY_PATH,
    label: "Update Activity"
  }
];


// Goals Routes & Paths
export const ALL_GOALS_PATH = "/dashboard/goals/all";
export const CREATE_GOAL_PATH = "/dashboard/goals/create";
export const UPDATE_GOAL_PATH = "/dashboard/goals/update/:id";
export const GOALS_ROUTES = [
    {
      path: ALL_GOALS_PATH,
      label: "All Activities"
    },
    {
      path: CREATE_GOAL_PATH,
      label: "Create Goal"
    },
    {
      path: UPDATE_GOAL_PATH,
      label: "Update Goal"
    }
  ];

