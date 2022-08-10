import { configureStore } from "@reduxjs/toolkit";
import reducer from "./reducer";
import categoryApi from "./middleware/categories";
export default configureStore({
  reducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(categoryApi),
});
