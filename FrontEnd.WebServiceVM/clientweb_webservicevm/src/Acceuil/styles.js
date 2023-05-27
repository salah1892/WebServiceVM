// import { makeStyles } from "@mui/styles"
//import { makeStyles } from '@emotion/styled';
import { styled } from "@mui/material";
const useStyles = styled((theme) => ({
    container: {
        backgroundColor: theme.palette.background.paper,
        padding: theme.spacing(8, 0, 6)
    },
    icon: {
        marginRight: '20px',
    },
    buttons: {
        marginTop: '40px'
    },
    cardGrid: {
        padding: '20px 0'
    },
    card: {
        height: '100%',
        display: 'flex',
        flexDirection: 'column'
    },
    cardMedia: {
        paddingTop: '56.25%' //16:9
    }
    ,
    cardContent: {
        flexGrow: 1,
    }, footer: {
        backgroundColor: theme.palette.background.paper,
        padding:'50px 0'
    },
    menu1 :{
    marginBottom: '40px',
    marginTop: '20px',
}
}))
export default useStyles;