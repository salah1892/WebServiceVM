import {
    Typography,
    Grid,
    Box,
    Button,
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    Container
} from '@mui/material';
import ClearIcon from '@mui/icons-material/Clear';
import TextField from "@mui/material/TextField";
import {styled} from '@mui/material';
import React, {useState, useEffect} from 'react';
import Table from '@mui/material/Table';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import TableCell from '@mui/material/TableCell';
import TableBody from '@mui/material/TableBody';
import Paper from '@mui/material/Paper'
import axios from 'axios';
import {GlobaVariable} from "../GlobaVariable.js";
import useStyles from './styles';
import UpdateInterface from "./UpdateInterface";
// import CustomTableCell from '@mui/material/CustomTableCell';
// const CustomTableCell = styled(theme => ({
//     head: {
//         backgroundColor: theme.palette.common.black,
//         color: theme.palette.common.white,
//     },
//     body: {
//         fontSize: 14,
//     },
// }))(TableCell);
const Clients = () => {
        // value={userClicked.firstName}
        const classes = useStyles();
        const [firstname, setFirstName] = useState('');
        const [lastname, setLastName] = useState('');
        const [password, setPassword] = useState('');
        const [email, setMail] = useState('');
        const [mobile, setMobile] = useState('');
        const [gender, setGender] = useState("");
        const handleFirstName = (event) => {
            setFirstName(event.target.value);
        };
        //------------------------------------------------------------------------------//
        const [users, setUsers] = useState([]);
        // const [loginStatus, setLoginStatus] = useState("");
        const getAllUsers = async () => {
            // e.preventDefault();
            await axios.get(GlobaVariable.API_URL + "WebClientController")
                .then((response) => {
                    setUsers(response.data);
                    //console.log(response.data);
                }).catch((err) => {
                    console.log(err)
                });
        }
        useEffect(() => {
            getAllUsers();
        }, []);
        //------------------------------------------------------------------------------//
        const [showForm, setShowForm] = useState(false);

        // const handleOpenForm = () => {
        //     setShowForm(true);
        // };

        const handleCloseForm = () => {
            setShowForm(false);
        };
        const handleOpenForm = () => {
            const formWindow = window.open('/form', '_blank', 'height=600,width=800');
            formWindow.focus();
        };
        const [open, setOpen] = useState(false);

        const handleOpenMessage = () => {
            setOpen(true);
        };

        const handleCloseMessage = () => {
            setOpen(false);
        };
        const [userClicked, setUserClicked] = useState([])
        const handleUserClicked = (id) => {
            console.log("id en debut de f° :" + id);
            users.map(async (e) => {
                    // console.log("e.idWebClient :"+e.idWebClient);
                    if (e.idWebClient === id) {
                        await setUserClicked(e)
                        setFirstName(e.firstname);
                        setLastName(e.lastname);
                        setPassword(e.password);
                        setMail(e.email);
                        setMobile(e.mobile);
                        setGender(e.gender)
                        console.log("userClicked : " + userClicked.idWebClient + " Email : " + userClicked.email)
                    }
                }
                //setUserClicked("")
            );

        };

//------------------------------------------------------------------------------//
        const EditUser = async (user) => {
            //e.preventDefault();
            await axios.put(GlobaVariable.API_URL + `WebClientController/${user.idWebClient}`, null, {
                params: {
                    firstname, lastname, password, email, mobile, gender
                }
            }).then((response) => {

                console.log(response);

            }).catch((err) => {
                console.log(err);
            });
        }
//------------------------------------------------------------------------------//
        const SuppUser = async (id) => {
            //e.preventDefault();
            await axios.delete(GlobaVariable.API_URL + `WebClientController/${id}`, null,)
                .then((response) => {

                    console.log(response);

                }).catch((err) => {
                    console.log(err);
                });
        }
//------------------------------------------------------------------------------//
        const btnUpdateStyle = {
            fontSize: 13,
            fontWeight: 700,
            backgroundColor: 'green',
            '&:hover': {
                backgroundColor: '#F768BA'
            }
        }
        const btnRemoveStyle = {
            fontSize: 13,
            fontWeight: 700,
            margin: '1px 1px 1px 1px',
            backgroundColor: 'red',
            '&:hover': {
                backgroundColor: '#F671AA'
            }
        }
        return (
            <>
                <div>
                    <Typography variant='h1' align="center"
                                className={classes.titleClient}>
                        Clients PAGE
                    </Typography>
                    <Paper>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell align="left">FirstName</TableCell>
                                    <TableCell align="left">LastName </TableCell>
                                    <TableCell align="left">Email </TableCell>
                                    <TableCell align="left">Password </TableCell>
                                    <TableCell align="left">Mobile </TableCell>
                                    {/* <TableCell align="left">Genre </TableCell> */}
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {users.map(user => (
                                    <TableRow className={classes.row} key={user.idWebClient}>
                                        <TableCell component="th" scope="row">{user.firstName}</TableCell>
                                        <TableCell align="left">{user.lastName}</TableCell>
                                        <TableCell align="left">{user.email}</TableCell>
                                        <TableCell align="left">{user.password}</TableCell>
                                        <TableCell align="left">{user.mobile}</TableCell>
                                        {/* <TableCell align="left">{user.genre}</TableCell> */}
                                        <TableCell align="left">
                                            <Button size='large' variant='contained' sx={btnUpdateStyle}
                                                    onClick={() => {
                                                        handleUserClicked(user.idWebClient);
                                                        handleOpenMessage();
                                                    }}
                                            >
                                                Edit
                                            </Button>
                                            {/*<ClearIcon/>*/}
                                            <Button size='large' variant='contained' sx={btnRemoveStyle}
                                                    onClick={() => {
                                                        //handleUserClicked(user.idWebClient);
                                                        SuppUser(user.idWebClient);

                                                    }}
                                            >
                                                Supp
                                            </Button>
                                            <Dialog open={open} onClose={handleCloseMessage}
                                                    PaperProps={{mx: {width: "100%", height: "60%"}}}>

                                                <DialogTitle> UserID : "{userClicked.idWebClient}"</DialogTitle>

                                                <DialogContent>
                                                    <p>Voulez-vous modifier
                                                        l'utilisateur {userClicked.firstName + " " + userClicked.lastName} </p>
                                                    <Table>
                                                        <TableHead>
                                                            <TableRow>
                                                                <TableCell align="left">FirstName</TableCell>
                                                                <TableCell align="left">LastName </TableCell>
                                                                <TableCell align="left">Email </TableCell>
                                                                <TableCell align="left">Password </TableCell>
                                                                <TableCell align="left">Mobile </TableCell>
                                                                {/* <TableCell align="left">Genre </TableCell> */}
                                                            </TableRow>
                                                        </TableHead>

                                                        <TableBody>
                                                            {/*{userClicked.map(item => (*/}
                                                            <TableRow className={classes.row} key={userClicked.idWebClient}>
                                                                <TableCell component="th"
                                                                           scope="row">
                                                                    <TextField
                                                                        size={"medium"}
                                                                        defaultValue={userClicked.firstName}
                                                                        onChange={handleFirstName
                                                                            //(e) => {
                                                                            // setFirstName(e.target.value)
                                                                            // e.target.value
                                                                            // = "" ? setFirstName(userClicked.firstName) :
                                                                            // setFirstName(e.target.value);
                                                                            //}
                                                                        }/>
                                                                </TableCell>
                                                                <TableCell align="left">
                                                                    <TextField
                                                                        size={"medium"}
                                                                        defaultValue={userClicked.lastName}
                                                                        onChange={(e) => {
                                                                            setLastName(e.target.value)
                                                                            // e.target.value = "" ? setLastName(userClicked.lastName) :
                                                                            //     setLastName(e.target.value);
                                                                        }}/></TableCell>
                                                                <TableCell align="left">{userClicked.email}</TableCell>
                                                                <TableCell align="left">{userClicked.password}</TableCell>
                                                                <TableCell align="left" style={{width: "fit-content"}}>
                                                                    <TextField
                                                                        size={"medium"}
                                                                        defaultValue={userClicked.mobile}
                                                                        onChange={(e) => {
                                                                            setMobile(e.target.value);
                                                                        }}/></TableCell>
                                                            </TableRow>
                                                            {/*))}*/}
                                                        </TableBody>
                                                    </Table>
                                                </DialogContent>

                                                <DialogActions>
                                                    <Button onClick={() => {
                                                        EditUser(userClicked);
                                                        handleCloseMessage();
                                                    }} color="primary">
                                                        Modifier
                                                    </Button>
                                                    <Button onClick={handleCloseMessage} color="primary">
                                                        Fermer
                                                    </Button>
                                                </DialogActions>
                                            </Dialog>
                                        </TableCell>

                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </Paper>
                </div>
            </>
        );
    }
;
export default Clients;
// const handleOpenNewWindow = (id) => {
//     // window.open('https://www.facebook.com', '_blank');
//     {
//         console.log("id : " + id);
//     }
//     return (
//         <Box>
//             <Container>
//                 <Typography>salah</Typography>
//             </Container>
//         </Box>)
// };