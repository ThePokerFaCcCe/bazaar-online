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
  },
});

export const {
  signModalToggle,
  cityModalToggle,
  desktopMenuToggle,
  mobileMenuToggle,
} = actions;
export default reducer;
