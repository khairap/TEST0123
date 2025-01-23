import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import FilterBar from '../components/FilterBar';

test('calls setFilter when filter buttons are clicked', () => {
  const setFilter = jest.fn();
  const addTodo = jest.fn();

  render(<FilterBar setFilter={setFilter} addTodo={addTodo} />);

  fireEvent.click(screen.getByText(/All/i));
  fireEvent.click(screen.getByText(/Completed/i));
  fireEvent.click(screen.getByText(/Pending/i));

  expect(setFilter).toHaveBeenCalledTimes(3);
  expect(setFilter).toHaveBeenNthCalledWith(1, 'all');
  expect(setFilter).toHaveBeenNthCalledWith(2, 'completed');
  expect(setFilter).toHaveBeenNthCalledWith(3, 'pending');
});

test('calls addTodo when new task is added', () => {
  const setFilter = jest.fn();
  const addTodo = jest.fn();

  render(<FilterBar setFilter={setFilter} addTodo={addTodo} />);
  const input = screen.getByPlaceholderText('Add a new task');
  const button = screen.getByText('Add');

  fireEvent.change(input, { target: { value: 'New Task' } });
  fireEvent.click(button);

  expect(addTodo).toHaveBeenCalledWith('New Task');
});
