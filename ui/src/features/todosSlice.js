import { createSlice } from '@reduxjs/toolkit';

const todosSlice = createSlice({
  name: 'todos',
  initialState: [],
  reducers: {
    addTodo(state, action) {
      state.push(action.payload);
    },
    removeTodo: (state, action) => {
      return state.filter((todo) => todo.id !== action.payload);
    },
    toggleCompletion(state, action) {
      const todo = state.find((t) => t.id === action.payload);
      if (todo) {
        todo.completed = !todo.completed;
      }
    },
    delegateTodo(state, action) {
      const { id, delegateTo } = action.payload;
      const todo = state.find((t) => t.id === id);
      if (todo) {
        todo.delegateTo = delegateTo;
      }
    },
  },
});

export const { addTodo, removeTodo, toggleCompletion, delegateTodo } = todosSlice.actions;
export default todosSlice.reducer;
