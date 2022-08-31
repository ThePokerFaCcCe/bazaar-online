import { createAction } from "@reduxjs/toolkit";
import { organaizeCategories } from "../../services/orgCategories";
import { CATEGORY_RECEIVED } from "../state/category";
import { State, Next, Action } from "../../types/type";
import axios from "axios";
import config from "../../config.json";

// Action Creator
export const apiCallBegan = createAction("getCategory/apiCallBegan");

// Reducer
const categoryApi =
  ({ dispatch, getState }: State) =>
  (next: Next) =>
  async (action: Action) => {
    if (action.type !== apiCallBegan.type) next(action);
    if (getState().entities.category === null) {
      try {
        const { data } = await axios.get(`${config.apiEndPoint}/Categories`);
        dispatch(CATEGORY_RECEIVED(organaizeCategories(data)));
      } catch (ex) {
        console.log(ex);
      }
    }
  };

export default categoryApi;
