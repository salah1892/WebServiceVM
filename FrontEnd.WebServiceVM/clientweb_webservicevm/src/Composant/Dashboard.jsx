import { Typography, Grid, Box, TextField } from "@mui/material";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import React, { useState, useEffect } from "react";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import Button from "@mui/material/Button";
//import DeleteIcon from '@mui/icons-material/Delete';
import SendIcon from "@mui/icons-material/Send";
import axios from "axios";
import { GlobaVariable, HubParametre } from "../GlobaVariable.js";
import { HubConnectionBuilder } from "@microsoft/signalr";
import EtatParking from "./ChartComponent/EtatParking"
import InfoParking from "./ChartComponent/InfoParking";
const Dashboard = () => {
    const [connection, setConnection] = useState(null);
    const [typePayement, setTypePayement] = useState("");
    const [descriptionPayement, setDescriptionPayement] = useState("");
    //--------------------------------------------------------------------------------//
    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl(GlobaVariable.HubParametre)
            // .configureLogging("trace")
            // .configureLogging("debug")
            .configureLogging("information")
            //.withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);
    useEffect(() => {
        if (connection) {
            // setConnection(connection);
            connection
                .start()
                .then((result) => {
                    console.log("Connected!");
                    // console.log(JSON.stringify(result));
                    // connection.on("ReceivePayementMsg", (message) => {
                    //     setMessage(message);
                    //   console.log("From Serveur :", message);
                    // });
                })
                .catch((e) => console.log("Connection Failed: ", e));
        }
    }, [connection]);
    //--------------------------------------------------------------------------------//
    const handleChangeTypePayement = (event) => {
        setTypePayement(event.target.value);
    };

    const handleChangeDescriptionPayement = (event) => {
        setDescriptionPayement(event.target.value);
    };
    //------------------------------------------------------------------------------//
    const AddParametre = async (user) => {
        //e.preventDefault();
        await axios
            .post(GlobaVariable.API_URL + `ParametreController`, null, {
                params: {
                    typePayement,
                    descriptionPayement,
                },
            })
            .then((response) => {
                console.log(response);
            })
            .catch((err) => {
                console.log(err);
            });
    };
    //------------------------------------------------------------------------------//
    return (
      <>
        {/* <Typography variant="h1">DASHBOARD PAGE</Typography> */}
        {/* <Grid item xs={12} sm={12} lg={6}> */}
        <Grid
          // item xs={12} sm={12} lg={6}
          //   border={1}
          style={{
            backgroundSize: "cover",
            height: "100vh",
            minHeight: "500px",
            backgroundColor: "#EBD1CB",
          }}
        >
          {/* <Box> */}
          <Box sx={{ display: "flex", height: "50%" }}>
            <Box
              border={1}
              sx={{
                width: "50%",
                margin: "1px 1px 1px 1px",
                p: 2,
                //bgcolor: "primary.main",
                
              }}
            >
             <EtatParking/>
            </Box>
            <Box
              border={1}
              sx={{
                // border={1},
                width: "50%",
                margin: "1px 1px 1px 1px",
                p: 2,
                // bgcolor: "secondary.main",
              }}
            >
            {/* <InfoParking/> */}
              Box 2
            </Box>
          </Box>
          <Box sx={{ display: "flex", height: "50%" }}>
            <Box
              border={1}
              sx={{
                width: "50%",
                margin: "1px 1px 1px 1px",
                p: 2,
                // bgcolor: "error.main",
              }}
            >
              Box 3
            </Box>
            <Box
              border={1}
              sx={{
                width: "50%",
                margin: "1px 1px 1px 1px",
                p: 2,
                // bgcolor: "info.main",
              }}
            >
              Box 4
            </Box>
          </Box>
          {/* </Box> */}
        </Grid>
        {/* </Grid> */}
      </>
    );
};
export default Dashboard;
