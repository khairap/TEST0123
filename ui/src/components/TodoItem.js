import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { toggleCompletion, delegateTodo } from '../features/todosSlice';
import './TodoItem.css';

const TodoItem = ({ todo }) => {
  const [delegateTo, setDelegateTo] = useState('');
  const dispatch = useDispatch();

  console.log("todo id"  + todo.id +", value="+todo.text);
  return (

<li key={todo.id} className="list-group-item">

      <span
        style={{
          textDecoration: todo.completed ? 'line-through' : 'none',
        }}
      >
         {todo.text}
      </span>
      <button
        className="btn btn-sm btn-primary ms-2"
        onClick={() => dispatch(toggleCompletion(todo.id))}
      >
        {todo.completed ? 'Undo' : 'Complete'}
      </button>
      <input
        type="text"
        className="form-control d-inline-block w-auto ms-2"
        placeholder="Delegate to"
        value={delegateTo}
        onChange={(e) => setDelegateTo(e.target.value)}
      />
      <button
        className="btn btn-sm btn-secondary ms-2"
        onClick={() =>
          delegateTo.trim() && dispatch(delegateTodo({ id: todo.id, delegateTo }))
        }
      >
        Delegate
      </button>
    </li>
  );
};

export default TodoItem;
