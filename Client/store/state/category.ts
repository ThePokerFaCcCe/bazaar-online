import { createSlice } from "@reduxjs/toolkit";
import { Category } from "../../types/type";

const { actions, reducer } = createSlice({
  name: "UI",
  initialState: null,
  reducers: {
    CATEGORY_RECEIVED: (state, { payload }) => {
      if (state === null) {
        return (state = payload);
      }
      return state;
    },
  },
});

export const { CATEGORY_RECEIVED } = actions;
export default reducer;
