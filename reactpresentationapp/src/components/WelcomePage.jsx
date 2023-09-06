import React from "react";
import { Link } from "react-router-dom";
import './WelcomePage.css';
function WelcomePage() {

    return (
        <div className="welcome-page">
            <h1 className="welcome-text">Welcome to Booking Session App</h1>
            <p className="welcome-text">Please login or register to continue</p>
            <div className="button-container">
                <Link to="/login" className="button-link">
                    <button type="button" className="button-style">
                        Login
                    </button>
                </Link>
                <Link to="/register" className="button-link">
                    <button type="button" className="button-style">
                        Register
                    </button>
                </Link>
            </div>
        </div>
    );
}


export default WelcomePage;
