import { createSlice } from "@reduxjs/toolkit";

const { actions, reducer } = createSlice({
  name: "userStatus",
  initialState: false,
  reducers: {
    SET_USER_STATUS: (status, { payload }) => {
      if (payload !== status) {
        return (status = payload);
      }
      return status;
    },
  },
});

export const { SET_USER_STATUS } = actions;
export default reducer;
