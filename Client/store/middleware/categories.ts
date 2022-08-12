import { createAction } from "@reduxjs/toolkit";
import { organaizeCategories } from "../../services/orgCategories";
import { categoryReceived } from "../state/category";
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
    console.log(getState());
    if (getState().entities.category === null) {
      try {
        const { data } = await axios.get(`${config.apiEndPoint}/Categories`);
        dispatch(categoryReceived(organaizeCategories(data)));
      } catch (ex) {
        console.log(ex);
      }
    }
  };

export default categoryApi;
