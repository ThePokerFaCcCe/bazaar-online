import { Box } from "@mui/material";
import { Card } from "../../types/type";
import styles from "../../styles/Advertisement.module.css";

const Card = ({ title, minuets, city }: Card): JSX.Element => (
  <div className="card mx-auto card__size">
    <div className="card-body overflow-hidden">
      <div className="d-flex justify-content-between">
        <div className="d-flex flex-column justify-content-between">
          <h5 className="card-title mb-2">{title}</h5>
          <p className="card-text" style={{ margin: 0 }}>
            <span>{minuets}</span>
            <span>{city}</span>
          </p>
        </div>
        <Box sx={{ width: "129px", height: "129px" }}>
          <img
            src="https://s100.divarcdn.com/static/thumbnails/1658667482/gYOL8HKE.jpg"
            className={styles.ad__img}
          />
        </Box>
      </div>
    </div>
  </div>
);

export default Card;
