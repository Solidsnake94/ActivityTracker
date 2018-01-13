import delay from "./delay";
import {ALL_USER_GOALS_URL} from '../constants/ApiConstants';
import {callApi} from '../utils/ApiUtils';

const goals = [
  {
    // Goal
    goalId: 1,
    userId: 1,
    goalName: "Run a marathon",
    startDate: new Date(),
    endDate: new Date(),
    targetDistance: 47.5,
    targetTime: "PT7H",
    completed: false,
    isPublic: false
  },
  {
    // Goal
    goalId: 2,
    userId: 1,
    goalName: "Run a marathon",
    startDate: new Date(),
    endDate: new Date(),
    targetDistance: 47.5,
    targetTime: "PT7H",
    completed: false,
    isPublic: false
  },
  {
    // Goal
    goalId: 3,
    userId: 1,
    goalName: "Run a marathon",
    startDate: new Date(),
    endDate: new Date(),
    targetDistance: 47.5,
    targetTime: "PT7H",
    completed: false,
    isPublic: false
  },
  {
    // Goal
    goalId: 4,
    userId: 1,
    goalName: "Run a marathon",
    startDate: new Date(),
    endDate: new Date(),
    targetDistance: 47.5,
    targetTime: "PT7H",
    completed: false,
    isPublic: false
  },
  {
    // Goal
    goalId: 5,
    userId: 1,
    goalName: "Run a marathon",
    startDate: new Date(),
    endDate: new Date(),
    targetDistance: 47.5,
    targetTime: "PT7H",
    completed: false,
    isPublic: false
  },
  {
    // Goal
    goalId: 6,
    userId: 1,
    goalName: "Run a marathon",
    startDate: new Date(),
    endDate: new Date(),
    targetDistance: 47.5,
    targetTime: "PT7H",
    completed: false,
    isPublic: false
  }
];

class ApiGoals {

  // static getAllGoals() {
  //   return new Promise((resolve, reject) => {
  //     setTimeout(() => {
  //       resolve(Object.assign([], goals));
  //     }, delay);
  //   });
  // }

  static async getAllUserGoals(userId) {
    const {json} = await callApi(ALL_USER_GOALS_URL.replace('{userId}',userId));
    return json;
  }

  
  
}

export default ApiGoals;
