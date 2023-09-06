import axios from "axios";
import { API_Base_URL, Token } from "./apiConfig";


async function getInstuctors() {
    const response = await axios.get(API_Base_URL + 'Instructor/GetInstuctors', {
        headers: {
            Authorization: `Bearer ${Token}`
        }
    });
    return response;
}


export { getInstuctors };
