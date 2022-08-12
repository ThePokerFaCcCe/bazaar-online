import { configureStore } from "@reduxjs/toolkit";
import reducer from "./reducer";
import categoryApi from "./middleware/categories";
import statesApi from "./middleware/states";

export default configureStore({
  reducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(statesApi, categoryApi),
});
