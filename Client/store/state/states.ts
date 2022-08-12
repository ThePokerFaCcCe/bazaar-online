import { createSlice } from "@reduxjs/toolkit";

const { actions, reducer } = createSlice({
  name: "states",
  initialState: null,
  reducers: {
    statesReceived: (state, { payload }) => {
      console.log(payload);
      return (state = payload);
    },
  },
});

export const { statesReceived } = actions;
export default reducer;
