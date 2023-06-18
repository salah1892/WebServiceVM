import React, {useEffect, useState} from "react";
import Typography from "@mui/material/Typography";
import axios from "axios";
import {GlobaVariable} from "../GlobaVariable";
import classes from "./styles";
import Paper from "@mui/material/Paper";
import Table from "@mui/material/Table";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import TableCell from "@mui/material/TableCell";
import TableBody from "@mui/material/TableBody";

const Abonnement = () => {
    const [IdAbonnement, setIdAbonnement] = useState("");
    const [dateCreation, setDateCreation] = useState('');
    const [dateActivation, setDateActivation] = useState('');
    const [dateDesActivation, setDateDesActivation] = useState("");

    const handleIdAbonnement = (event) => {
        setIdAbonnement(event.target.value)
    }
    const handleDateCreation = (event) => {
        setDateCreation(event.target.value)
    }
    const handleDateActivation = (event) => {
        setDateActivation(event.target.value)
    }
    const handleDateDesActivation = (event) => {
        setDateDesActivation(event.target.value)
    }
    //------------------------------------------------------------------------------//
    const [abonnements, setAbonnement] = useState([]);

    const getAllAbonnement = async () => {
        // e.preventDefault();
        await axios.get(GlobaVariable.API_URL + "AbonnementController")
            .then((response) => {
                setAbonnement(response.data);
                console.log(response.data);
            }).catch((err) => {
                console.log(err)
            });
    }
    useEffect(() => {
        getAllAbonnement();
    }, [abonnements]);
    //------------------------------------------------------------------------------//
    return (
        <div>
            <Typography variant='h1' align="center"
                        className={classes.titleClient}>
                Abonnement PAGE
            </Typography>
            <Paper>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell align="left">ID Abonnement</TableCell>
                            <TableCell align="left">Date Création </TableCell>
                            <TableCell align="left">Date Activation </TableCell>
                            <TableCell align="left">Date DésActivation</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {abonnements.map(abonnement => (
                            <TableRow className={classes.row} key={abonnement.idAbonnement}>
                                <TableCell align="left">{abonnement.idAbonnement}</TableCell>
                                <TableCell align="left">{abonnement.dateCreation}</TableCell>
                                <TableCell align="left">{abonnement.dateActivation}</TableCell>
                                <TableCell align="left">{abonnement.dateDesActivation}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Paper>
        </div>
    )
}
export default Abonnement;