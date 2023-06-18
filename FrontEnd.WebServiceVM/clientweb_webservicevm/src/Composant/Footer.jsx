import { Toolbar, Typography } from "@mui/material";
import AccountCircleRoundedIcon from "@mui/icons-material/AccountCircleRounded";
import useStyles from './styles';
const Footer = () => {
    const StylesClasses = useStyles();
    return (
      // className = { StylesClasses.footer }
      <Toolbar
        style={{
          flexDirection: "column",
          direction: "flex",
          position: "static",
          backgroundColor: "#F1836B",
          height: "10vh",
          color: "white",
          borderStyle: "groove",
        }}
      >
        {/* <div style={{ direction: 'flex', align:"center" ,width:}}> */}
        <Typography
          variant="h6"
          align="center"
          gutterBottom
          style={{ align: "center", color: "#0D0B0A" }}
        >
          Seca Serrure
        </Typography>
        {/* <AccountCircleRoundedIcon /> */}
        <Typography
          //   icon={<AccountCircleRoundedIcon />}
          variant="subtitle1"
          align="center"
          color="textSecondary"
        >
          36 bis route de Tunis - 4011 Hammam Sousse - TUNISIE , CP : 4011
          HAMMAM SOUSSE - Sousse
        </Typography>
        {/* </div> */}
        {/* <ul>
                <li>
                    <a href="https://github.com/Ahmed-Abdul-Aziz/" target="_blank" rel="noreferrer">
                        github
                    </a>
                </li>
                <li>
                    <a href="https://www.linkedin.com/in/ahmed-abdul-aziz-a0a0b0b8/" target="_blank" rel="noreferrer">
                        linkedin
                    </a>
                </li>
            </ul> */}
      </Toolbar>
    );
};
export default Footer;