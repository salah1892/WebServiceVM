import { Toolbar, Typography } from "@mui/material";
import useStyles from './styles';
const Footer = () => {
    const StylesClasses = useStyles();
    return (
        // className = { StylesClasses.footer }
        <Toolbar style={{ flexDirection:'column', direction: 'flex', position: 'static', backgroundColor:'#F1836B' ,height:'10vh' ,color:'white'}}>
            {/* <div style={{ direction: 'flex', align:"center" ,width:}}> */}
                <Typography variant='h6' align="center" gutterBottom style={{ align:'center'}}>
                Footer
            </Typography>
            <Typography variant='subtitle1' align="center" color="textSecondary">
                Something here to give the footer a purpose!
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