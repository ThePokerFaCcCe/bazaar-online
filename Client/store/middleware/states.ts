import { createAction } from "@reduxjs/toolkit";
import { STATES_RECEIVED } from "../state/states";
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
        dispatch(STATES_RECEIVED(data));
      } catch (ex) {
        console.log(ex);
      }
    }
  };

export default statesApi;
