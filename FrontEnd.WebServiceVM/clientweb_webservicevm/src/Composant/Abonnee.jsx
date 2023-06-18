import React, {useEffect, useState} from "react";
import Typography from "@mui/material/Typography";
import axios from "axios";
import {GlobaVariable} from "../GlobaVariable";
import Table from "@mui/material/Table";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import TableCell from "@mui/material/TableCell";
import TableBody from "@mui/material/TableBody";
import Paper from "@mui/material/Paper";
import classes from "./styles";

const Abonnee = () => {
    const [firstname, setFirstName] = useState('');
    const [lastname, setLastName] = useState('');
    const [idAbonnee, setIdAbonnee] = useState("");
    const [numCarte, setNumCarte] = useState("");
    const handleFirstName = (event) => {
        setFirstName(event.target.value)
    }
    const handleLastName = (event) => {
        setLastName(event.target.value)
    }
    const handleIdAbonnee = (event) => {
        setIdAbonnee(event.target.value)
    }
    const handleNumCarte = (event) => {
        setNumCarte(event.target.value)
    }
    //------------------------------------------------------------------------------//
    const [abonnees, setAbonnees] = useState([]);

    const getAllAbonnees = async () => {
        // e.preventDefault();
        await axios.get(GlobaVariable.API_URL + "AbonneeController")
            .then((response) => {
                setAbonnees(response.data);
                console.log(response.data);
            }).catch((err) => {
                console.log(err)
            });
    }
    useEffect(() => {
        getAllAbonnees();
    }, [abonnees]);
    //------------------------------------------------------------------------------//
//-------------------------------------------------------//
    return (
        <div>
            <Typography variant='h1' align="center"
                        className={classes.titleClient}>
                Abonnee PAGE
            </Typography>
            <Paper>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell align="left">ID Abonnee</TableCell>
                            <TableCell align="left">Nom </TableCell>
                            <TableCell align="left">Prénom </TableCell>
                            <TableCell align="left">N° Carte </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {abonnees.map(abonnee => (
                            <TableRow className={classes.row} key={abonnee.idAbonnee}>
                                <TableCell align="left">{abonnee.idAbonnee}</TableCell>
                                <TableCell align="left">{abonnee.nom}</TableCell>
                                <TableCell align="left">{abonnee.prenom}</TableCell>
                                <TableCell align="left">{abonnee.numCarte}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Paper>
            </div>
)};
export default Abonnee;