import { Typography, Grid, Box } from '@mui/material';
import React from 'react';
const Dashboard = () => {
    return (
        <>
            <Typography variant='h1'>
                DASHBOARD PAGE
        </Typography>
            <Grid item xs={12} sm={12} lg={6}>
                <Box
                    style={{
                        backgroundSize: "cover",
                        height: "50vh",
                        minHeight: "500px",
                        backgroundColor: "#C4543B",
                    }}
                >
                
                <h1 className="header"> </h1>
                <h3>Welcome Ms Salah Eddinne Elbakkerri</h3>
                <p>..............................</p>
                </Box>
            </Grid>
            
        </>
    );
};
export default Dashboard;