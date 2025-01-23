import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { BrowserRouter } from 'react-router-dom';
import Login from './pages/Login';
import Preferences from './pages/Preferences';
import TodoList from './components/TodoList';
import ErrorBoundary from './ErrorBoundary';

const App = () => {
    console.log('Rendering App.js');
    console.log('React version:', React.version);
  return (
    <Router>
      <nav>
        <ul>
          <li><Link to="/">Login</Link></li>
          <li><Link to="/preferences">Preferences</Link></li>
          <li><Link to="/todos">Todo List</Link></li>
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
