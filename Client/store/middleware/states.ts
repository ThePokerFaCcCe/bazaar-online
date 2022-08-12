import { createAction } from "@reduxjs/toolkit";
import { statesReceived } from "../state/states";
import { State, Next, Action } from "../../types/type";
import axios from "axios";
import config from "../../config.json";
// Action Creator

export const statesApiCallBegan = createAction("getStates/apiCallBegan");

// Reducer
const statesApi =
  ({ dispatch, getState }: State) =>
  (next: Next) =>
  async (action: Action) => {
    if (action.type !== statesApiCallBegan.type) next(action);
    if (getState().entities.states === null) {
      try {
        const { data } = await axios.get(
          `${config.apiEndPoint}/Locations/Cities`
        );
        dispatch(statesReceived(data));
      } catch (ex) {
        console.log(ex);
      }
    }
  };

export default statesApi;
