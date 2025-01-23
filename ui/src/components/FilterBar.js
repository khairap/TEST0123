import React, { useState } from 'react';

function FilterBar({ setFilter, addTodo }) {
    const [newTodo, setNewTodo] = useState('');

    const handleAddTodo = () => {
        if (newTodo.trim()) {
            addTodo(newTodo);
            setNewTodo('');
        }
    };

    return (
        <div className="d-flex flex-column flex-md-row justify-content-between align-items-center mt-3">
            <div className="btn-group">
                <button
                    className="btn btn-outline-primary"
                    onClick={() => setFilter('all')}
                >
                    All
                </button>
                <button
                    className="btn btn-outline-success"
                    onClick={() => setFilter('completed')}
                >
                    Completed
                </button>
                <button
                    className="btn btn-outline-warning"
                    onClick={() => setFilter('pending')}
                >
                    Pending
                </button>
            </div>
            <div className="input-group mt-3 mt-md-0">
                <input
                    type="text"
                    className="form-control"
                    placeholder="Add a new task"
                    value={newTodo}
                    onChange={(e) => setNewTodo(e.target.value)}
                />
                <button
                    className="btn btn-primary"
                    onClick={handleAddTodo}
                >
                    Add
                </button>
            </div>
        </div>
    );
}

export default FilterBar;
