import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import TodoItem from '../components/TodoItem';

test('renders todo item with correct text', () => {
  const todo = { id: 1, name: 'Learn React', completed: false };
  const toggleCompletion = jest.fn();

  render(<TodoItem todo={todo} toggleCompletion={toggleCompletion} />);

  expect(screen.getByText('Learn React')).toBeInTheDocument();
});

test('calls toggleCompletion when button is clicked', () => {
  const todo = { id: 1, name: 'Learn React', completed: false };
  const toggleCompletion = jest.fn();

  render(<TodoItem todo={todo} toggleCompletion={toggleCompletion} />);
  const button = screen.getByRole('button', { name: /Mark as Completed/i });

  fireEvent.click(button);

  expect(toggleCompletion).toHaveBeenCalledWith(todo.id);
});
