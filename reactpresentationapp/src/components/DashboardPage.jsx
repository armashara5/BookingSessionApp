import { useLocation } from 'react-router-dom';
import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

function DashboardPage() {
    const location = useLocation();
    const navigate = useNavigate();
    const [username, setUsername] = useState(null);
    const [userId, setUserId] = useState("");
    useEffect(() => {
        if (location.state) {
            setUsername(location.state.userName);
            setUserId(location.state.userId);
        }
    }, [location.state]);

    const toBookingSession = () => {
        navigate('/bookingSession', { state: { userName: username, userId: userId } });
    }
    return (
        <div className="dashboard-page">
            <h1>Welcome, {username}!</h1>
            <div>
                <button onClick={() => { toBookingSession() }}>Book Session</button>
            </div>
        </div>
    );
}

export default DashboardPage;
