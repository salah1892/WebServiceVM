import React, {useEffect, useState} from "react";
import Typography from "@mui/material/Typography";
import classes from "./styles";
import Paper from "@mui/material/Paper";
import Table from "@mui/material/Table";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import TableCell from "@mui/material/TableCell";
import TableBody from "@mui/material/TableBody";
import axios from "axios";
import {GlobaVariable} from "../GlobaVariable";

const Payement=()=>{
    //------------------------------------------------------------------------------//
    const [idPayement, setIdPayement] = useState("");
    const [datePayement, setDatePayement] = useState("");
    const handleIdPayement = (event) => {
        setIdPayement(event.target.value)
    }
    const handleDatePayement = (event) => {
        setDatePayement(event.target.value)
    }
    //------------------------------------------------------------------------------//
    const [payements, setPayements] = useState([]);

    const getAllPayements = async () => {
        // e.preventDefault();
        await axios.get(GlobaVariable.API_URL + "PayementController")
            .then((response) => {
                setPayements(response.data);
                console.log(response.data);
            }).catch((err) => {
                console.log(err)
            });
    }
    useEffect(() => {
        getAllPayements();
    }, []);
    //------------------------------------------------------------------------------//
    return(
        <div>
            <Typography variant='h1' align="center"
                        className={classes.titleClient}>
                Payement PAGE
            </Typography>
            <Paper>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell align="left">ID Payement</TableCell>
                            <TableCell align="left">Date Payement </TableCell>
                            {/*<TableCell align="left">Date Entree </TableCell>*/}
                            {/*<TableCell align="left">Date Sortie </TableCell>*/}
                            {/*<TableCell align="left">Prix Ticket </TableCell>*/}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {payements.map(payement => (
                            <TableRow className={classes.row} key={payements.idTicket}>
                                <TableCell align="left">{payements.idTicket}</TableCell>
                                <TableCell align="left">{payements.datePayement}</TableCell>
                                {/*<TableCell align="left">{payements.dateEntree}</TableCell>*/}
                                {/*<TableCell align="left">{payements.dateSortie}</TableCell>*/}
                                {/*<TableCell align="left">{payements.prixTicket}</TableCell>*/}
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Paper>
        </div>
    )
}
export default Payement;