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
const Passager = () => {

    //------------------------------------------------------------------------------//
    const [idTicket, setIdTicke] = useState("");
    const [statut, setStatut] = useState(false);
    const [dateEntree, setDateEntree] = useState("");
    const [dateSortie, setDateSortie] = useState("");
    const [prixTicket, setPrixTicket] = useState(0);
    const handleIdTicke = (event) => {
        setIdTicke(event.target.value)
    }
    const handleStatut = (event) => {
        setStatut(event.target.value)
    }
    const handleDateEntree = (event) => {
        setDateEntree(event.target.value)
    }
    const handleDateSortie = (event) => {
        setDateSortie(event.target.value)
    }
    const handlePrixTicket = (event) => {
        setPrixTicket(event.target.value)
    }
    //------------------------------------------------------------------------------//
    const [tickes, setTickets] = useState([]);

    const getAllTickets = async () => {
        // e.preventDefault();
        await axios.get(GlobaVariable.API_URL + "TicketController")
            .then((response) => {
                setTickets(response.data);
                console.log(response.data);
            }).catch((err) => {
                console.log(err)
            });
    }
    useEffect(() => {
        getAllTickets();
    }, []);
    //------------------------------------------------------------------------------//
    return (
        <div>
            <Typography variant='h1' align="center"
                        className={classes.titleClient}>
                Passager PAGE
            </Typography>
            <Paper>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell align="left">ID Ticket</TableCell>
                            <TableCell align="left">Statut </TableCell>
                            <TableCell align="left">Date Entree </TableCell>
                            <TableCell align="left">Date Sortie </TableCell>
                            <TableCell align="left">Prix Ticket </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {tickes.map(ticket => (
                            <TableRow className={classes.row} key={ticket.idTicket}>
                                <TableCell align="left">{ticket.idTicket}</TableCell>
                                <TableCell align="left">{ticket.statut=true ? "Payé":"Non Payé"}</TableCell>
                                <TableCell align="left">{ticket.dateEntree}</TableCell>
                                <TableCell align="left">{ticket.dateSortie}</TableCell>
                                <TableCell align="left">{ticket.prixTicket}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Paper>
        </div>
    )
}
export default Passager;