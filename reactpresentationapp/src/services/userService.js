import axios from "axios";
import { API_Base_URL } from "./apiConfig";

async function register(username, email, password, userType) {
    const user = {
        username,
        email,
        password,
        userType

    };

    const response = await axios.post(API_Base_URL +'Account/Register', user);

    return response;
}

async function login(username,  password) {
    const user = {
        username,
        password,
    };

    const response = await axios.post(API_Base_URL + 'Account/Login', user);

    return response;
}

export { register, login };
