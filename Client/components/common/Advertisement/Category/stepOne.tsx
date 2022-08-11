import { Typography, Grid } from "@mui/material";
import { useSelector } from "react-redux";
import { Category, Store, CategoryStepOneProps } from "../../../../types/type";
import styles from "../../../../styles/Advertisement.module.css";

const StepOne = ({
  icons,
  onSelectCategory,
}: CategoryStepOneProps): JSX.Element => {
  // Redux Setup
  const category: Category = useSelector(
    (state: Store) => state.entities.category
  );

  return (
    <>
      {category &&
        category.map((item: any, index: number) => (
          <Grid item key={index}>
            <Grid container direction="row" alignItems="center">
              <Grid item>{icons[index]}</Grid>
              <Grid item>
                <Typography
                  onClick={() => onSelectCategory(item)}
                  className={styles.category__item}
                >
                  {item.title}
                </Typography>
              </Grid>
            </Grid>
          </Grid>
        ))}
    </>
  );
};

export default StepOne;
