import React, { useState, useEffect } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import { login } from "../services/userService"; // import the service file
import { SetAuthToken } from "../services/apiConfig";
import './LoginPage.css';

function LoginPage() {

    // define the state variable for the redirection status
    const [redirectToDashboard, setRedirectToDashboard] = useState(false);
    const [token, setToken] = useState();
    const [userId, setUserId] = useState();
    // define the state variable for the username input value
    const [username, setUsername] = useState("");
    // define the state variable for the password input value
    const [password, setPassword] = useState("");

    function handleChange(e) {
        // get the name and value of the input element from the event object
        const { name, value } = e.target;
        // update the username or password state variables with the new value for the input name
        if (name === "username") {
            setUsername(value);
        } else if (name === "password") {
            setPassword(value);
        }
    }
    // define an async handler function for the form submission
    async function handleSubmit(e) {
        // prevent the default behavior of the form
        e.preventDefault();

        try {
            const response = await login(username, password);
            // if the response status is 200, get the token from the response data and set it to the token state variable
            if (response.status === 200) {
                setToken(response.data.token);
                setUserId(response.data.userId);
                SetAuthToken(response.data.token);
                setRedirectToDashboard(true);
            }
        } catch (ex) {
            // handle any errors here
        }
    }

    const navigate = useNavigate();

    // use useEffect hook to redirect to another page after getting a valid token
    useEffect(() => {
        // define an anonymous function to perform redirection
        function performRedirection() {
            // if there is a valid token, redirect to another page with some logic here
            if (token) {
                <Navigate to="/dashboard" replace state={{ userName: username, userId: userId }} />
            }
        }
        // call performRedirection function
        performRedirection();
    }, [token]);

        return (
            <div className="login-page">
                <h1 className="login-title">Login</h1>
                {/* check if redirectToDashboard is true */}
                {redirectToDashboard && <Navigate to="/dashboard" replace state={{ userName: username, userId: userId }} />}
                <form onSubmit={handleSubmit} className="login-form">
                    <div className="form-group">
                        <label htmlFor="username" className="form-label">Username</label>
                        <input
                            type="text"
                            id="username"
                            name="username"
                            value={username}
                            onChange={handleChange}
                            className="form-input"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password" className="form-label">Password</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            value={password}
                            onChange={handleChange}
                            className="form-input"
                        />
                    </div>

                    <button type="submit" onClick={handleSubmit} className="login-button">Login</button>
                </form>
            </div>
        );
    }




export default LoginPage;