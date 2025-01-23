import React, {useState} from 'react';
import { addTodo, toggleCompletion } from '../features/todosSlice';
import TodoItem from './TodoItem';
import { useSelector, useDispatch } from 'react-redux';


function TodoList({ toggleCompletion}) {

    const todos = useSelector((state) => state.todos || []);
    const isLoading = useSelector((state) => state.isLoading);
    const [todoText, setTodoText] = useState('');
   const dispatch = useDispatch();

  const handleAddTodo = (e) => {
    e.preventDefault();
    if (todoText.trim()) {
      dispatch(addTodo({ id: Date.now(), text: todoText, completed: false }));
      setTodoText('');
    }
  };

  const handleToggleCompletion = (id) => {
    dispatch(toggleCompletion(id));
  };
    if (isLoading) {
      return <p>Loading...</p>;
    }
  

    return (
        <div>
          <h1>Todo List</h1>
          <form onSubmit={handleAddTodo}>
            <input
              type="text"
              value={todoText}
              onChange={(e) => setTodoText(e.target.value)}
              placeholder="Enter a new todo"
              className="form-control"              
            />
            <button type="submit"  className="btn btn-primary mt-2">Add Todo</button>
          </form>
    
          {todos.length === 0 ? (
            <p>No todos available</p>
          ) : (
            <ul className="list-group mt-3">
              {todos.map((todo) => (
          <TodoItem
          key={todo.id}
          todo={todo}
          toggleCompletion={() => handleToggleCompletion(todo.id)}
        />
              ))}
            </ul>
          )}
        </div>
      );
}

export default TodoList;
