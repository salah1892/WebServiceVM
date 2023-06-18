// import { makeStyles } from "@mui/styles"
//import { makeStyles } from '@emotion/styled';
import { styled,withStyles } from "@mui/material";
const useStyles = styled((theme) => ({
  container: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(8, 0, 6),
    display: "flex",
    flexDirection: "column",
    minHeight: "100vh",
    overflow: "hidden",
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(2),
  },
  icon: {
    marginRight: "20px",
    color: "#0D0B0A",
  },
  buttons: {
    marginTop: "40px",
  },
  cardGrid: {
    padding: "20px 0",
  },
  card: {
    height: "100%",
    display: "flex",
    flexDirection: "column",
  },
  cardMedia: {
    paddingTop: "56.25%", //16:9
  },
  cardContent: {
    flexGrow: 1,
  },
  footer: {
    padding: "50px 0",
    color: " #fc86aa",
  },
  menu1: {
    marginBottom: "40px",
    marginTop: "20px",
  },
  row: {
    "&:nth-of-type(odd)": {
      backgroundColor: theme.palette.background.default,
    },
  },
  titleClient: {
    background: "#00022E",
    color: "#fc86aa",
  },
}));
export default useStyles;