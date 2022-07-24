import {
  Box,
  Typography,
  Grid,
  Divider,
  Switch,
  CardActions,
  CardContent,
  Button,
} from "@mui/material";
import styles from "../styles/Advertisement.module.css";
import { Input, Collapse } from "antd";
import Category from "../components/common/Advertisement/category";
import Card from "../components/common/Advertisement/card";
const Advertisement = (): JSX.Element => {
  return (
    <>
      <div className="row mt-2">
        <div
          className="col-xs-5 col-sm-4"
          style={{ borderLeft: "1px solid #cfcfcf" }}
        >
          <Category />
        </div>
        <div className="col-xs-7 col-sm-8">
          <div className="row gx-1 gy-3 flex-wrap">
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
            <div className="col">
              <Card title="ماشین" />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Advertisement;
