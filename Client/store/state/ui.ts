import { createSlice } from "@reduxjs/toolkit";

const { actions, reducer } = createSlice({
  name: "UI",
  initialState: {
    modals: {
      signModalVisible: false,
      cityModalVisible: false,
    },
    navbar: {
      desktopMenuVisible: false,
      mobileMenuVisible: false,
      megaMenuVisible: false,
    },
  },
  reducers: {
    signModalToggle: ({ modals }) => {
      modals.signModalVisible = !modals.signModalVisible;
    },
    cityModalToggle: ({ modals }) => {
      modals.cityModalVisible = !modals.cityModalVisible;
    },
    desktopMenuToggle: ({ navbar }) => {
      navbar.desktopMenuVisible = !navbar.desktopMenuVisible;
    },
    mobileMenuToggle: ({ navbar }) => {
      navbar.mobileMenuVisible = !navbar.mobileMenuVisible;
    },
    megaMenuToggle: ({ navbar }) => {
      navbar.megaMenuVisible = !navbar.megaMenuVisible;
    },
  },
});

export const {
  signModalToggle,
  cityModalToggle,
  desktopMenuToggle,
  mobileMenuToggle,
  megaMenuToggle,
} = actions;
export default reducer;
