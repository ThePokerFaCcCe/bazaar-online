import { combineReducers } from "@reduxjs/toolkit";
import ui from "./state/ui";
import category from "./state/category";
export default combineReducers({
  ui,
  category,
});
