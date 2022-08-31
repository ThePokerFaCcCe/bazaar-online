import { createSlice } from "@reduxjs/toolkit";

const { actions, reducer } = createSlice({
  name: "states",
  initialState: null,
  reducers: {
    STATES_RECEIVED: (state, { payload }) => {
      if (state === null) {
        return (state = payload);
      }
      return state;
    },
  },
});

export const { STATES_RECEIVED } = actions;
export default reducer;
