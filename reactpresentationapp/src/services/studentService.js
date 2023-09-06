import axios from "axios";
import { API_Base_URL, Token } from "./apiConfig";


async function bookSession(userId, startDate, lengthInMinutes, instructor ) {
    const session = {
        StudentId: userId,
        StartDate: startDate,
        LengthInMinutes: lengthInMinutes,
        InstructorId: instructor
    };
    debugger;
    const response = await axios.post(API_Base_URL + 'Student/BookSession', session, {
        headers: {
            Authorization: `Bearer ${Token}`
        }
    });

    return response;
}


export { bookSession };
