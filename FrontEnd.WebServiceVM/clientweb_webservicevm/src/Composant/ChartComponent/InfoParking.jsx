import React, { useState, useEffect } from "react";
import axios from "axios";
import { GlobaVariable } from "../../GlobaVariable";
import { Line } from "react-chartjs-2";
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from "chart.js";
ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
);
const InfoParking = () => {
    const [parkings, setParkings] = useState({});

    // e.preventDefault();
    useEffect(() => {
        const getAllParkings = async () => {
            await axios
                .get(GlobaVariable.API_URL + "ParkingController")
                .then((response) => {
                    const data =  response.json();
                    console.log(data)
                    const chartLabels = data.map((item) => item.NomParking);
                    const chartValues = data.map((item) => item.IdParking);
                    setParkings({
                      labels: chartLabels,
                      datasets: [
                        {
                          //label: "API Data",
                          label: chartLabels,
                          data: chartValues,
                          backgroundColor: "rgba(75,192,192,0.2)",
                          borderColor: "rgba(75,192,192,1)",
                          borderWidth: 1,
                        },
                      ],
                    });
                })
                .catch((err) => {
                    console.log(err);
                });
        }


        getAllParkings();
    }, []);
    const options = {};
    //------------------------------------------------------------------------------//
    return (
        <>
            <div style={{ width: 500, height: 300 }}>
                <Line options={options} data={parkings}></Line>
                <h1>InfoParking</h1>
            </div>
        </>
    );
};
export default InfoParking;
