import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
// import {ProSidebarProvider} from "react-pro-sidebar";
// import { BrowserRouter } from "react-router-dom";
import { ThemeProvider } from '@mui/material/styles';
import { GlobalStyles } from "./Composant/GlobalStyles"
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <ThemeProvider theme={GlobalStyles}>
    <React.StrictMode>
        {/*<BrowserRouter>*/}
            <App/>
        {/*</BrowserRouter>*/}
    </React.StrictMode>
    </ThemeProvider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
