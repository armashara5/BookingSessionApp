import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import WelcomePage from './components/WelcomePage';
import RegisterPage from './components/RegisterPage';
import LoginPage from './components/LoginPage';
import DashboardPage from './components/DashboardPage';
import BookingSessionPage from './components/BookingSessionPage';
function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/dashboard" element={<DashboardPage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/bookingSession" element={<BookingSessionPage />} />
                <Route path="/" element={<WelcomePage />} />
            </Routes>
        </BrowserRouter>
    )
}

export default App
