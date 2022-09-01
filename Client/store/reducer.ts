import { combineReducers } from "redux";
import entitiesReducer from "./entities";

const reducer = combineReducers({
  entities: entitiesReducer,
});

export type RootState = ReturnType<typeof reducer>;
export default reducer;
