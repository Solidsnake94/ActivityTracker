import delay from "./delay";

const achievements = [
  {
    achievementID: 1,
    name: "Runned 5 km today",
    userID: 1,
    description: ""
  },
  {
    achievementID: 2,
    name: "Runned 10 km today",
    userID: 1,
    description: ""
  },
  {
    achievementID: 3,
    name: "Runned 15 km today",
    userID: 1,
    description: ""
  },
  {
    achievementID: 4,
    name: "Runned 10 km this week",
    userID: 1,
    description: ""
  },
  {
    achievementID: 5,
    name: "Runned 20 km this week",
    userID: 1,
    description: ""
  },
  {
    achievementID: 6,
    name: "Runned 40 km this month",
    userID: 1,
    description: ""
  }
];

class AchievementsApi {
  static getAllAchievements() {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(Object.assign([], achievements));
      }, delay);
    });
  }
}

export default AchievementsApi;
