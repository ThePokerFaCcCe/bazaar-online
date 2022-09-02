import { createSlice } from "@reduxjs/toolkit";
import { HYDRATE } from "next-redux-wrapper";
import { Store } from "../../types/type";

const { actions, reducer } = createSlice({
  name: "dashboard",
  initialState: {
    users: [],
    roles: [],
    ads: [],
    categories: [],
    permissions: [],
  },
  reducers: {
    SET_ROLES: (store, { payload }) => {
      store.roles = payload;
      return store;
    },
    SET_USERS: (store, { payload }) => {
      store.users = payload;
      return store;
    },
    SET_ADS: (store, { payload }) => {
      store.ads = payload;
      return store;
    },
    SET_CATEGORIES: (store, { payload }) => {
      store.categories = payload;
      return store;
    },
    SET_PERMISSIONS: (store, { payload }) => {
      store.permissions = payload;
      return store;
    },
  },
  extraReducers: {
    [HYDRATE]: (state, action) => {
      return {
        ...state,
        ...action.payload.entities.dashboard,
      };
    },
  },
});

// Selector

export const selectDashboard = (store: Store) => store.entities.dashboard;

export const {
  SET_ROLES,
  SET_ADS,
  SET_USERS,
  SET_CATEGORIES,
  SET_PERMISSIONS,
} = actions;
export default reducer;
