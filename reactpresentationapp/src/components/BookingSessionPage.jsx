import React, { useState, useEffect } from "react";
import DateTimePicker from 'react-datetime-picker';
import { useLocation } from 'react-router-dom';
import { Navigate, useNavigate } from "react-router-dom";
import { getInstuctors } from "../Services/instructorService";
import { bookSession } from "../Services/studentService";
import 'react-datetime-picker/dist/DateTimePicker.css';
import 'react-calendar/dist/Calendar.css';
import 'react-clock/dist/Clock.css';
import './BookingSessionPage.css';

function BookingSessionPage() {

    const location = useLocation();
    const navigate = useNavigate();
    // define the state variable for the instructor objects
    const [instructors, setInstructors] = useState([]);
    // define the state variable for the selected instructor object
    const [selectedInstructor, setSelectedInstructor] = useState(null);
    // define the state variable for the selected start date for the session
    const [startDate, setStartDate] = useState(new Date());
    // define the state variable for the input value for the length of the session in minutes
    const [lengthInMinutes, setLengthInMinutes] = useState(1);

    const [username, setUsername] = useState(null);
    const [userId, setUserId] = useState("");

    const offset = new Date().getTimezoneOffset();
    useEffect(() => {
        if (location.state) {
            setUsername(location.state.userName);
            setUserId(location.state.userId);
        }
    }, [location.state]);

    // use the useEffect hook to fetch the instructors from getInstructorsEndpoint when the component mounts
    useEffect(() => {
        // define an async function to fetch the instructors
        async function fetchInstructors() {
            try {
                // use axios to send an HTTP GET request to getInstructorsEndpoint
                const response = await getInstuctors();
                //if the response status is 200, get the instructors array from the response data and set it to the instructors state variable
                if (response.status === 200) {
                    setInstructors(response.data);
                    if (response.data.length > 0)
                        setSelectedInstructor(response.data[0]);
                }
            } catch (ex) {
                // handle any errors here
            }
        }

        // call the fetchInstructors function
        fetchInstructors();
    }, []); // pass an empty dependency array to run only once when the component mounts


    // define the handler function for the input changes
    function handleChange(e) {
        const { name, value } = e.target;
        if (name === "selectedInstructor") {
            // find and set the instructor object that matches with value
            const instructor = instructors.find(
                (instructor) => instructor.id == value
            );
            setSelectedInstructor(instructor);
        } else if (name === "lengthInMinutes") {
            // parse and set length in minutes as a number
            const length = parseInt(value, 10);
            setLengthInMinutes(length);
        }
    }
    async function handleSubmit(e) {
        // prevent default behavior of form
        e.preventDefault();
        try {
            // Get the current time in local time zone offset in minutes
            startDate.setTime(startDate.getTime() - startDate.getTimezoneOffset() * 60000);

            const response = await bookSession(userId, startDate.toISOString(), lengthInMinutes, selectedInstructor.id);
            // if the response status is 200, redirect the user to the dashboard page
            if (response.status === 200) {
                alert("Session booked successfully");
                navigate('/dashboard', { state: { userName: username, userId: userId } });
            }
        } catch (ex) {
            alert(ex.message);
            // handle any errors here
        }
    }

        return (
            <div className="booking-session-page">
                <h1 className="booking-title">Book a session</h1>
                <form onSubmit={handleSubmit} className="booking-form">
                    <div className="form-group">
                        <label htmlFor="selectedInstructor" className="form-label">Select an instructor</label>
                        <select
                            id="selectedInstructor"
                            name="selectedInstructor"
                            value={selectedInstructor ? selectedInstructor.id : ""}
                            onChange={handleChange}
                            utcOffset={-offset}
                            className="form-select"
                        >
                            {/* map the instructors array to option elements */}
                            {instructors?.map((instructor) =>
                            (
                                <option key={instructor.id} value={instructor.id}>
                                    {instructor.name}
                                </option>
                            )

                            )}
                        </select>
                    </div>
                    <div className="form-group">
                        <label htmlFor="startDate" className="form-label">Select a start date</label>
                        <DateTimePicker
                            id="startDate"
                            name="startDate"
                            onChange={setStartDate}
                            value={startDate}
                            className="form-datetime"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="lengthInMinutes" className="form-label">Enter the length of the session in minutes</label>
                        <input
                            type="number"
                            id="lengthInMinutes"
                            name="lengthInMinutes"
                            value={lengthInMinutes}
                            onChange={handleChange}
                            className="form-input"
                        />
                    </div>

                    {/* Style the book button with some color, padding, border-radius and cursor */}
                    <button type="submit" className="book-button">Book</button>
                </form>
            </div>
        );
    


}

export default BookingSessionPage;