import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Category } from "../../types/type";

const { actions, reducer } = createSlice({
  name: "UI",
  initialState: [{}],
  reducers: {
    categoryReceived: (state, { payload }) => {
      return (state = payload);
    },
  },
});

export const { categoryReceived } = actions;
export default reducer;
