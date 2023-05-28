import './App.css';
import React, { useState } from "react";
import {Routes, Route, BrowserRouter} from "react-router-dom";
import Acceuil from './Acceuil/Acceuil';
import Register from './LoginPages/Register';
import Login from './LoginPages/Login';
import ForgotPassword from './LoginPages/ForgotPassword';
//import { ProSidebarProvider } from 'react-pro-sidebar';
function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    {/* <React.Fragment>
                    <ProSidebarProvider> */}
                    <Route path="/" exact element={<Acceuil/>}></Route>
                    {/* </ProSidebarProvider>
                        </React.Fragment> */}
                    <Route path="/login" exact element={<Login/>}></Route>
                    <Route path="/register" exact element={<Register/>}></Route>
                    <Route path="/reset-password" exact element={<ForgotPassword/>}></Route>
                </Routes>
            </BrowserRouter>
        </>
    );
}
export default App;
