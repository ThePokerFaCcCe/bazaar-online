import { createSlice } from "@reduxjs/toolkit";
import { Category } from "../../types/type";

const { actions, reducer } = createSlice({
  name: "UI",
  initialState: null,
  reducers: {
    categoryReceived: (state, { payload }) => {
      if (state === null) {
        return (state = payload);
      }
    },
  },
});

export const { categoryReceived } = actions;
export default reducer;
