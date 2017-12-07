import delay from "./delay";

const activities = [
    {
        id: 1,
        userId: 1,
        title: 'Running 12.11.17',
        date: new Date(),
        time: '5:00',
        distance: 50.0,
    },
    {
        id: 2,
        userId: 1,
        title: 'Warmup ',
        date: new Date(),
        time: '5:00',
        distance: 17.0,
    },
    {
        id: 3,
        userId: 1,
        title: 'Another run',
        date: new Date(),
        time: '5:00',
        distance: 22.0,
    },
    {
        id: 4,
        userId: 1,
        title: 'Evening jog',
        date: new Date(),
        time: '3:50',
        distance: 10.0,
    },
    {
        id: 5,
        userId: 1,
        title: 'Weekend group run',
        date: new Date(),
        time: '4:00',
        distance: 35.0,
    }
];

class ActivitiesApi {

    static getAllActivities() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(Object.assign([],activities));
            }, delay);
        });
    }


}

export default ActivitiesApi;
