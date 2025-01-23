import { configureStore, createSlice } from '@reduxjs/toolkit';
import preferencesReducer from './features/preferencesSlice';
import authReducer from './features/authSlice';
import todosReducer from './features/todosSlice';

const testSlice = createSlice({
  name: 'test',
  initialState: { message: 'Hello from Redux' },
  reducers: {},
});

const store = configureStore({
  reducer: {
    test: testSlice.reducer,
    todos:todosReducer,
    auth:authReducer,
    preferences: preferencesReducer, 
  },
});
console.log('Store:', store);
export default store;
