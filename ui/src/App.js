import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { BrowserRouter } from 'react-router-dom';
import Login from './pages/Login';
import Preferences from './pages/Preferences';
import TodoList from './components/TodoList';
import ErrorBoundary from './ErrorBoundary';
import './App.css';

const App = () => {
    console.log('Rendering App.js');
    console.log('React version:', React.version);
  return (
    <Router>
    <nav className="navbar">
      <ul className="navbar-list">
        <li className="navbar-item">
          <Link to="/" className="navbar-link">Login</Link>
        </li>
        <li className="navbar-item">
          <Link to="/preferences" className="navbar-link">Preferences</Link>
        </li>
        <li className="navbar-item">
          <Link to="/todos" className="navbar-link">Todo List</Link>
        </li>
      </ul>
    </nav>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/preferences" element={<Preferences />} />
        <Route path="/todos" element={<TodoList />} />
    </Routes>
    </Router>
  );

};

export default App;
