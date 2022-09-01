import { createSlice } from "@reduxjs/toolkit";
import { HYDRATE } from "next-redux-wrapper";

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
  // extraReducers: {
  //   [HYDRATE]: (state, action) => {
  //     return {
  //       ...state,
  //       ...action.payload,
  //     };
  //   },
  // },
});

export const { CATEGORY_RECEIVED } = actions;
export default reducer;
