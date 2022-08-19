import { createSlice } from "@reduxjs/toolkit";

const { actions, reducer } = createSlice({
  name: "userStatus",
  initialState: false,
  reducers: {
    setUserStatus: (status, { payload }) => {
      if (payload !== status) {
        return (status = payload);
      }
    },
  },
});

export const { setUserStatus } = actions;
export default reducer;
