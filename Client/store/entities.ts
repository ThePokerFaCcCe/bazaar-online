import { combineReducers } from "@reduxjs/toolkit";
import ui from "./state/ui";
import category from "./state/category";
import states from "./state/states";
import isLoggedIn from "./state/user";
export default combineReducers({
  ui,
  category,
  states,
  isLoggedIn,
});
