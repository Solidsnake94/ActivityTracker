import React from 'react';
import { Switch, Route, Redirect, Link } from "react-router-dom";


const WelcomeDashboard = props => {
    return (
        <div>
            <h2>
                Welcome to your dashboard "TestUser"
                <br/>
                <Link to="/dashboard/activities"> activities</Link>
            </h2>
        </div>
    )
}

export default WelcomeDashboard;