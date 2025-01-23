import { createSlice } from '@reduxjs/toolkit';

const preferencesSlice = createSlice({
  name: 'preferences',
  initialState: { theme: 'light', layout: 'list' },
  reducers: {
    setTheme(state, action) {
      state.theme = action.payload;
    },
    setLayout(state, action) {
      state.layout = action.payload;
    },
  },
});

export const { setTheme, setLayout } = preferencesSlice.actions;
export default preferencesSlice.reducer;
