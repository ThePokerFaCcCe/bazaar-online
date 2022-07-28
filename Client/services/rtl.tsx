import { ConfigProvider } from "antd";
import { RTLProps } from "../type/allTypes";

const RTL = (props: RTLProps) => (
  <ConfigProvider direction="rtl">{props.children}</ConfigProvider>
);

export default RTL;
