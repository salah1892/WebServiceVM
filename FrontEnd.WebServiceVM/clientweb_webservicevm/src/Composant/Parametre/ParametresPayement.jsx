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
//import { GlobaVariable, HubParametre } from "../GlobaVariable.js";
import { GlobaVariable, HubParametre } from "../../GlobaVariable";
import { HubConnectionBuilder } from "@microsoft/signalr";

// const Dashboard = () => {
    const ParametresPayement = () => {
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
          <Grid item xs={12} sm={12} lg={6}>
            <Box
              border={1}
              style={{
                backgroundSize: "cover",
                height: "100vh",
                minHeight: "500px",
                backgroundColor: "#EBD1CB",
              }}
            >
              {/* <h1 className="header"> </h1>
                <h3>Welcome Ms Salah Eddinne Elbakkerri</h3>
                <p>..............................</p> */}
              <div style={{ display: "flex", flexDirection: "row" }}>
                <Typography>Type Parametre</Typography>
                <FormControl sx={{ m: 1, minWidth: 100 }}>
                  <InputLabel id="demo-simple-select-autowidth-label">
                    Parametre
                  </InputLabel>
                  <Select
                    labelId="demo-simple-select-autowidth-label"
                    id="demo-simple-select-autowidth"
                    value={typePayement}
                    onChange={handleChangeTypePayement}
                    autoWidth
                    label="Type Parametre"
                  >
                    <MenuItem value="" />
                    <MenuItem value={1}>1</MenuItem>
                    <MenuItem value={2}>2</MenuItem>
                    <MenuItem value={3}>3</MenuItem>
                  </Select>
                </FormControl>
              </div>
              <div style={{ display: "flex", flexDirection: "row" }}>
                <Typography>DescriptionPayement</Typography>
                <FormControl sx={{ m: 1, minWidth: 100 }}>
                  <InputLabel id="demo-simple-select-autowidth-label">
                    Description Payement
                  </InputLabel>
                  <Select
                    labelId="demo-simple-select-autowidth-label"
                    id="demo-simple-select-autowidth"
                    value={descriptionPayement}
                    onChange={handleChangeDescriptionPayement}
                    autoWidth
                    label="Description Payement"
                  >
                    <MenuItem value="" />
                    <MenuItem value={"Par Slot"}>Par Slot</MenuItem>
                    <MenuItem value={"Par Intervalle"}>Par Intervalle</MenuItem>
                    <MenuItem value={"Par Jour"}>Par Jour</MenuItem>
                  </Select>
                </FormControl>
              </div>
              <Button
                variant="contained"
                endIcon={<SendIcon />}
                size="large"
                onClick={AddParametre}
              >
                Envoyer vers Serveur
              </Button>
            </Box>
          </Grid>
        </>
      );
    };
export default ParametresPayement;