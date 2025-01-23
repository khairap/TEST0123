import React, { useMemo } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { setTheme, setLayout } from '../features/preferencesSlice';

const Preferences = () => {
  const { theme, layout } = useSelector((state) => state.preferences);
  const dispatch = useDispatch();

  return (
    <div className="container mt-5">
      <h1>Preferences</h1>
      <div className="form-group">
        <label>Theme</label>
        <select
          className="form-control"
          value={theme}
          onChange={(e) => dispatch(setTheme(e.target.value))}
        >
          <option value="light">Light</option>
          <option value="dark">Dark</option>
        </select>
      </div>
      <div className="form-group mt-3">
        <label>Layout</label>
        <select
          className="form-control"
          value={layout}
          onChange={(e) => dispatch(setLayout(e.target.value))}
        >
          <option value="list">List</option>
          <option value="grid">Grid</option>
        </select>
      </div>
    </div>
  );
};

export default Preferences;
