import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import imgSte from "./image/Logo_SECA.png";
import bgimg from "./image/backimg.jpg";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import {ThemeProvider, createTheme} from "@mui/material/styles";
import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
import React, {useState, forwardRef, useEffect} from "react";
import Snackbar from "@mui/material/Snackbar";
import Stack from "@mui/material/Stack";
import MuiAlert from "@mui/material/Alert";
import Slide from "@mui/material/Slide";
import {useNavigate} from "react-router-dom";
import {useForm} from "react-hook-form";
import {GlobaVariable} from "../GlobaVariable";
import axios from 'axios';

const Alert = forwardRef(function Alert(props, ref) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const darkTheme = createTheme({
    palette: {
        mode: "dark",
    },
});

const boxstyle = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: "75%",
    height: "70%",
    bgcolor: "background.paper",
    boxShadow: 24,
};

const center = {
    position: "relative",
    top: "50%",
    left: "37%",
};

export default function Login() {
    const [open, setOpen] = useState(false);
    const [remember, setRemember] = useState(false);
    const vertical = "top";
    const horizontal = "right";
    const navigate = useNavigate();
    // const [firstname, setFirstName] = useState('');
    // const [lastname, setLastName] = useState('');
    const [password, setPassword] = useState('');
    const [email, setMail] = useState('');

//------------------------------------------------------------------------------//

    const [loginStatus, setLoginStatus] = useState("");
    const loginUser = async (e) => {
        e.preventDefault();
        await axios.post(GlobaVariable.API_URL + "login", null, {
            params: {
                email, password
            }
        }).then((response) => {
            navigate("/");
        }).catch((err) => {
            console.log(err);
            navigate("/register");
        });
    }
//------------------------------------------------------------------------------//

    const {
        register,
        handleSubmit,
        watch,
        formState: {errors},
    } = useForm();

    const onSubmit = async (data) => {
        console.log(data);
        setOpen(true);
    };

    const handleClose = (event, reason) => {
        if (reason === "clickaway") {
            return;
        }
        setOpen(false);
    };

    function TransitionLeft(props) {
        return <Slide {...props} direction="left"/>;
    }

    return (
        <>
            <Snackbar
                open={open}
                autoHideDuration={3000}
                onClose={handleClose}
                TransitionComponent={TransitionLeft}
                anchorOrigin={{vertical, horizontal}}
            >
                <Alert onClose={handleClose} severity="success" sx={{width: "100%"}}>
                    Vous vous êtes connecté avec succès! </Alert>
            </Snackbar>
            <div
                style={{
                    backgroundImage: `url(${bgimg})`,
                    backgroundSize: "cover",
                    height: "100vh",
                    color: "#f5f5f5",
                }}
            >
                <Box sx={boxstyle}>
                    <Grid container>
                        <Grid item xs={12} sm={12} lg={6}>
                            <Box
                                style={{
                                    backgroundImage: `url(${imgSte})`,
                                    backgroundSize: "cover",
                                    marginTop: "40px",
                                    marginLeft: "15px",
                                    marginRight: "15px",
                                    height: "63vh",
                                    color: "#f5f5f5",
                                }}
                            ></Box>
                        </Grid>
                        <Grid item xs={12} sm={12} lg={6}>
                            <Box
                                style={{
                                    backgroundSize: "cover",
                                    height: "70vh",
                                    minHeight: "500px",
                                    backgroundColor: "#C4543B",
                                }}
                            >
                                <ThemeProvider theme={darkTheme}>
                                    <Container>
                                        <Box height={35}/>
                                        <Box sx={center}>
                                            <Avatar
                                                sx={{ml: "35px", mb: "4px", bgcolor: "#ffffff"}}
                                            >
                                                <LockOutlinedIcon/>
                                            </Avatar>
                                            <Typography component="h1" variant="h4">
                                                Connexion
                                            </Typography>
                                        </Box>
                                        <Box sx={{mt: 2}}/>
                                        <form onSubmit={loginUser}>

                                            <Grid container spacing={1}>
                                                <Grid item xs={12} sx={{ml: "3em", mr: "3em"}}>
                                                    <TextField
                                                        fullWidth
                                                        id="email"
                                                        label="Email Utilisateur"
                                                        name="email"
                                                        autoComplete="email"
                                                        {...register("email")}
                                                        aria-invalid={errors.email ? "true" : "false"}
                                                        onChange={(e) => {
                                                            setMail(e.target.value)
                                                        }}
                                                    />
                                                    {errors.email && (
                                                        <span
                                                            style={{color: "#f7d643", fontSize: "12px"}}
                                                        >
                                                            Ce champ est obligatoire!
                                                        </span>
                                                    )}
                                                </Grid>
                                                <Grid item xs={12} sx={{ml: "3em", mr: "3em"}}>
                                                    <TextField
                                                        fullWidth
                                                        {...register("password", {required: true})}
                                                        name="password"
                                                        label="Mot de Passe"
                                                        type="password"
                                                        id="password"
                                                        autoComplete="new-password"
                                                        onChange={(e) => {
                                                            setPassword(e.target.value)
                                                        }}
                                                    />
                                                    {/*// value={password} onChange={handlePassword}*/}
                                                    {errors.password && (
                                                        <span
                                                            style={{color: "#f7d643", fontSize: "12px"}}
                                                        >
                                                            Ce champ est obligatoire!
                                                        </span>
                                                    )}
                                                </Grid>
                                                <Grid item xs={12} sx={{ml: "3em", mr: "3em"}}>
                                                    <Stack direction="row" spacing={2}>
                                                        <FormControlLabel
                                                            sx={{width: "60%"}}
                                                            onClick={() => setRemember(!remember)}
                                                            control={<Checkbox checked={remember}/>}
                                                            label="Souvenez-moi !!"
                                                        />
                                                        <Typography
                                                            variant="body1"
                                                            component="span"
                                                            onClick={() => {
                                                                navigate("/reset-password");
                                                            }}
                                                            style={{marginTop: "10px", cursor: "pointer"}}
                                                        >
                                                            Mot de Passe oublié?
                                                        </Typography>
                                                    </Stack>
                                                </Grid>
                                                <Grid item xs={12} sx={{ml: "5em", mr: "5em"}}>
                                                    <Button
                                                        type="submit"
                                                        variant="contained"
                                                        fullWidth={true}
                                                        size="large"
                                                        sx={{
                                                            mt: "10px",
                                                            mr: "20px",
                                                            borderRadius: 28,
                                                            color: "#ffffff",
                                                            minWidth: "170px",
                                                            backgroundColor: "#FF9A01",
                                                        }}

                                                    >
                                                        Se Connecter
                                                    </Button>
                                                </Grid>
                                                <Grid item xs={12} sx={{ml: "3em", mr: "3em"}}>
                                                    <Stack direction="row" spacing={2}>
                                                        <Typography
                                                            variant="body1"
                                                            component="span"
                                                            style={{marginTop: "10px"}}
                                                        >
                                                            Vous n'êtes pas inscrit ?{" "}
                                                            <span
                                                                style={{
                                                                    color: "#beb4fb",
                                                                    cursor: "pointer",
                                                                }}
                                                                onClick={() => {
                                                                    navigate("/register");
                                                                }}
                                                            >
                                                                Créer nouveau compte
                                                            </span>
                                                        </Typography>
                                                    </Stack>
                                                </Grid>
                                            </Grid>
                                        </form>
                                    </Container>
                                </ThemeProvider>
                            </Box>
                        </Grid>
                    </Grid>
                </Box>
            </div>
        </>
    );
}
//const [mobile, setMobile] = useState('');
// var userEmail = document.getElementById("email");
// var userPassword = document.getElementById("password");
// const handleEmail = (event) => {
//     setMail(event.target.value);
//     console.log("email=" + email);
// }
// const handlePassword = (event) => {
//     setPassword(event.target.value);
//     console.log("Password=" + password);
// }
// const handleRegistre = () => {
//     // if (register){
//     setRegistre(!register);
//     // }
// }
//Crud Api----------------------------------------------------------------------//

//     const [posts, setPosts] = useState([]);
//     const [resStatus, setResStatus] = useState(0);
//     const [registre, setRegistre] = useState(true);
// //--------------------Post Methode------------------------------//
//     const handlePostMethodeClient = (e) => {
//         e.preventDefault();
//         axios.post(GlobaVariable.API_URL + "WebClientController"
//             , null, {
//                 params: {firstname, lastname, password, email, mobile}
//             })
//             .then((response) => {
//                 setResStatus(response.status);
//                 console.log(response.status + "all hamd lileh");
//             }).catch((err) => {
//             console.log(err)
//         });
//     }
//---------------------------------------------------------------//
//     function getData() {
//         axios.get(GlobaVariable.API_URL + "WebClientController")
//             // ,{
//             //   method: 'GET',
//             //   mode: 'no-cors',
//             //  headers: {
//             //    'Access-Control-Allow-Origin': '*',
//             //   'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
//             // }
//             // withCredentials: true,
//             // credentials: 'same-origin',
//             // })
//             .then((response) => {
//                 setPosts(response.data);
//                 console.log(posts);
//             }).catch((err) => {
//             console.log(err)
//         });
//     }
//-----------------------------------

//import * as yup from "yup";
// const schema = yup
//     .object({
//
//         email: yup.string().email().required(),
//         password: yup.string().min(3).required(),
//     })
//     .required();
//-----------------------------------
//-----------------------------------