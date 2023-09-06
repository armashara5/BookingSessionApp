import React, { useState } from "react";
import { register } from "../services/userService"; // import the service file
import { Navigate } from "react-router-dom";
import { SetAuthToken } from "../services/apiConfig";
import './RegisterPage.css';

function RegisterPage() {
    // define the state variables for the input fields
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errors, setErrors] = useState({}); // define the state variable for the validation errors
    const [token, setToken] = useState();
    const [userId, setUserId] = useState();
    const [selectedRole, setSelectedRole] = useState(2);
    // define the state variable for the redirection status
    const [redirectToDashboard, setRedirectToDashboard] = useState(false);

    // define the handler functions for the input changes
    function handleUsernameChange(e) {
        setUsername(e.target.value);
    }

    function handleEmailChange(e) {
        setEmail(e.target.value);
    }

    function handlePasswordChange(e) {
        setPassword(e.target.value);
    }

    function handleRoleChange(e) {
        setSelectedRole(e.target.value);
    }
    // define the handler function for the form submission
    async function handleSubmit(e) {
        e.preventDefault(); // prevent the default behavior of the form
        try {
            const response = await register(username, email, password, selectedRole); // call the service function to register a new user
            if (response.status === 200) {
                setToken(response.data.token);
                setUserId(response.data.userId);
                SetAuthToken(response.data.token);
                setRedirectToDashboard(true);
            }
        } catch (ex) {
            // if there is an error, set the errors state variable with the error message
            if (ex.response && ex.response.status === 400) {
                setErrors(ex.response.data);
            }
        }
    }

    return (
        <div className="register-page">
            <h1 className="register-title">Register</h1>
            {/* check if redirectToDashboard is true */}
            {redirectToDashboard && <Navigate to="/dashboard" replace state={{ userName: username, userId: userId }} />}

            <form onSubmit={handleSubmit} className="register-form">
                <div className="form-group">
                    <label htmlFor="username" className="form-label">Username</label>
                    <input
                        type="text"
                        id="username"
                        name="username"
                        value={username}
                        onChange={handleUsernameChange}
                        className="form-input"
                    />
                    {errors.username && <p className="error">{errors.username}</p>}
                </div>
                <div className="form-group">
                    <label htmlFor="email" className="form-label">Email</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={email}
                        onChange={handleEmailChange}
                        className="form-input"
                    />
                    {errors.email && <p className="error">{errors.email}</p>}
                </div>
                <div className="form-group">
                    <label htmlFor="password" className="form-label">Password</label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={password}
                        onChange={handlePasswordChange}
                        className="form-input"
                    />
                    {errors.password && <p className="error">{errors.password}</p>}
                </div>

                {/* Add the select role form group */}
                <div className="form-group">
                    <label htmlFor="selectedRole" className="form-label">Select Role</label>
                    <select
                        id="selectedRole"
                        name="selectedRole"
                        value={selectedRole ? selectedRole : 2}
                        onChange={handleRoleChange}
                        className="form-select"
                    >
                        <option key={1} value={1}>
                            Instructor
                        </option>
                        <option key={2} value={2}>
                            Student
                        </option>

                    </select>
                </div>

                {/* Style the register button with some color, padding, border-radius and cursor */}
                <button type="submit" className="register-button">Register</button>
            </form>
        </div>
    );


}

export default RegisterPage;
