//export const API_HOSTNAME = 'http://keaactivitytracker.azurewebsites.net/api';
export const API_HOSTNAME = 'http://localhost:55078/api';



// registration & authentication endpoints 
export const REGISTER_USER_URL = `${API_HOSTNAME}/auth/register`;
export const AUTHENTICATE_USER_URL = `${API_HOSTNAME}/token`;




// === activities endpoints ===
export const ALL_USER_ACTIVITIES_URL = `${API_HOSTNAME}/activities?userId={userId}`
export const CREATE_USER_ACTIVITY_URL = `${API_HOSTNAME}/activities/create`
export const DELETE_USER_ACTIVITY_URL = `${API_HOSTNAME}/activities/delete?activityId={activityId}`





// === goals endpoints ===
export const ALL_USER_GOALS_URL = `${API_HOSTNAME}/goals?userId={userId}`






// === achievements endpoints ===
export const ALL_USER_ACHIEVEMENTS_URL = `${API_HOSTNAME}/achievements?userId={userId}`






