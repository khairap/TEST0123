import React from 'react';
import { render, screen } from '@testing-library/react';
import TodoList from '../components/TodoList';

test('renders list of todos', () => {
  const todos = [
    { id: 1, name: 'Learn React', completed: false },
    { id: 2, name: 'Write Tests', completed: true },
  ];
  const toggleCompletion = jest.fn();

  render(<TodoList todos={todos} toggleCompletion={toggleCompletion} />);

  expect(screen.getByText('Learn React')).toBeInTheDocument();
  expect(screen.getByText('Write Tests')).toBeInTheDocument();
});
