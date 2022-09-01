import { configureStore, ThunkAction } from "@reduxjs/toolkit";
import reducer from "./reducer";
import { Action } from "redux";
import categoryApi from "./middleware/categories";
import statesApi from "./middleware/states";
import { createWrapper } from "next-redux-wrapper";

const makeStore = () =>
  configureStore({
    reducer,
  });

export default makeStore;
export type AppStore = ReturnType<typeof makeStore>;
export type AppState = ReturnType<AppStore["getState"]>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  AppState,
  unknown,
  Action
>;
export const wrapper = createWrapper(makeStore);
