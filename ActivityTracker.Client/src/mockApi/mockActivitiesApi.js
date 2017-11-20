import delay from "./delay";

const activities = [
    {
        id: 1,
        userId: 1,
        title: 'Running 12.11.17',
        date: new Date(),
        time: '5:00',
        distance: 50.0,
    }
];

class ActivitiesApi {

    static getAllActivities() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(...activities);
            }, delay);
        });
    }


}

export default ActivitiesApi;
