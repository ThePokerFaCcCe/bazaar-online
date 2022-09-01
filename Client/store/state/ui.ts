import { createSlice } from "@reduxjs/toolkit";
import { Store } from "../../types/type";

const { actions, reducer } = createSlice({
  name: "UI",
  initialState: {
    modals: {
      signModalVisible: false,
      cityModalVisible: false,
      deleteReasonModalVisible: false,
      rejectReasonModalVisible: false,
    },
    navbar: {
      desktopMenuVisible: false,
      mobileMenuVisible: false,
      megaMenuVisible: false,
    },
  },
  reducers: {
    SIGN_MODAL_OPEN: ({ modals }) => {
      modals.signModalVisible = true;
    },
    SIGN_MODAL_CLOSED: ({ modals }) => {
      modals.signModalVisible = false;
    },
    CITY_MODAL_OPEN: ({ modals }) => {
      modals.cityModalVisible = true;
    },
    CITY_MODAL_CLOSED: ({ modals }) => {
      modals.cityModalVisible = false;
    },
    DESKTOP_MENU_OPEN: ({ navbar }) => {
      navbar.desktopMenuVisible = true;
    },
    DESKTOP_MENU_CLOSED: ({ navbar }) => {
      navbar.desktopMenuVisible = false;
    },
    MOBILE_MENU_OPEN: ({ navbar }) => {
      navbar.mobileMenuVisible = true;
    },
    MOBILE_MENU_CLOSED: ({ navbar }) => {
      navbar.mobileMenuVisible = false;
    },
    MEGA_MENU_OPEN: ({ navbar }) => {
      navbar.megaMenuVisible = true;
    },
    MEGA_MENU_CLOSED: ({ navbar }) => {
      navbar.megaMenuVisible = false;
    },
    DELETE_REASON_MODAL_OPEN: ({ modals }) => {
      modals.deleteReasonModalVisible = true;
    },
    DELETE_REASON_MODAL_CLOSED: ({ modals }) => {
      modals.deleteReasonModalVisible = false;
    },
    REJECT_REASON_MODAL_OPEN: ({ modals }) => {
      modals.rejectReasonModalVisible = true;
    },
    REJECT_REASON_MODAL_CLOSED: ({ modals }) => {
      modals.rejectReasonModalVisible = false;
    },
  },
});

// Selector

export const selectModals = (state: Store) => state.entities.ui.modals;
export const selectNavBar = (state: Store) => state.entities.ui.navbar;
export const selectStore = (state: Store) => state.entities;

export const {
  SIGN_MODAL_OPEN,
  SIGN_MODAL_CLOSED,
  CITY_MODAL_OPEN,
  CITY_MODAL_CLOSED,
  DESKTOP_MENU_OPEN,
  DESKTOP_MENU_CLOSED,
  MOBILE_MENU_OPEN,
  MOBILE_MENU_CLOSED,
  MEGA_MENU_OPEN,
  MEGA_MENU_CLOSED,
  REJECT_REASON_MODAL_OPEN,
  REJECT_REASON_MODAL_CLOSED,
  DELETE_REASON_MODAL_OPEN,
  DELETE_REASON_MODAL_CLOSED,
} = actions;

export default reducer;
