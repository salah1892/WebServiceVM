import { Button, Card, CardContent, AppBar, CssBaseline, Toolbar, Typography } from "@mui/material";
import SensorsIcon from '@mui/icons-material/Sensors';
import useStyles from './styles';
import { Link, } from "react-router-dom";
import React, { useState } from "react";
import { PhotoCamera } from "@mui/icons-material"
import MenuRoundedIcon from "@mui/icons-material/MenuRounded";
import GridViewRoundedIcon from "@mui/icons-material/GridViewRounded";
//import ReceiptRoundedIcon from "@mui/icons-material/ReceiptRounded";
import PersonIcon from "@mui/icons-material/Person";
import BarChartRoundedIcon from "@mui/icons-material/BarChartRounded";
import TimelineRoundedIcon from "@mui/icons-material/TimelineRounded";
import BubbleChartRoundedIcon from "@mui/icons-material/BubbleChartRounded";
import WalletRoundedIcon from "@mui/icons-material/WalletRounded";
import AccountBalanceRoundedIcon from "@mui/icons-material/AccountBalanceRounded";
import SavingsRoundedIcon from "@mui/icons-material/SavingsRounded";
import MonetizationOnRoundedIcon from "@mui/icons-material/MonetizationOnRounded";
import SettingsApplicationsRoundedIcon from "@mui/icons-material/SettingsApplicationsRounded";
import AccountCircleRoundedIcon from "@mui/icons-material/AccountCircleRounded";
import ShieldRoundedIcon from "@mui/icons-material/ShieldRounded";
import NotificationsRoundedIcon from "@mui/icons-material/NotificationsRounded";
import LogoutRoundedIcon from "@mui/icons-material/LogoutRounded";
import { Sidebar, Menu, MenuItem, SubMenu } from "react-pro-sidebar";
import MainSection from "./MainSection";
import Footer from './Footer'
import Notification from "../Notification/Notification";
//------------------------------------------------------------------------------------//
export default function Acceuil() {
    const StylesClasses = useStyles();

    const [currentSection, setCurrentSection] = useState('Home');
    const handleSectionClick = (section) => {
        setCurrentSection(section);
    }
    return (
        <>
            <CssBaseline />
            <AppBar position="relative" style={{ backgroundColor: "#F1836B" }}>

                <Toolbar style={{ justifyContent: 'space-between' }}>
                    {/* <div style={{ display: "flex" }} > */}
                        <PhotoCamera className={StylesClasses.icon} />
                        <Typography variant='h6'>
                            SECA
                        </Typography>
                        {/* </div> */}
                        {/* style={{ position: 'absolute', right: '-10' }} */}
                        <Notification />
                </Toolbar>
            </AppBar>
            {/* <main> */}
            <div className={StylesClasses.container}>
                <div style={{ display: "flex" }}>


                    <Sidebar styles={{ background: '#a8d5e5' }}>
                        {/* // component={<Link to="home" className="link"/>}*/}
                        <Menu>
                            <MenuItem


                                className="menu1"
                                icon={<MenuRoundedIcon />}
                                // onClick={() => {
                                //     collapsedWidth('80px')
                                //     // collapsed(true);
                                //     //  collapseSidebar();
                                // }}
                                style={{ textAlign: "center" }}>
                                <h2>SECA </h2>
                            </MenuItem>
                            {/*component={<Link to="dashboard" className="link"/>}*/}
                            <MenuItem
                                onClick={() => handleSectionClick("Dashboard")}
                                icon={<GridViewRoundedIcon />}

                            >
                                Dashboard
                            </MenuItem>
                            <MenuItem
                                icon={<PersonIcon />}
                                onClick={() => handleSectionClick("Clients")}
                            > Clients </MenuItem>
                            <SubMenu label="Abonnements" icon={<SensorsIcon />}>
                                <MenuItem icon={<TimelineRoundedIcon />}> Abonnée </MenuItem>
                                <MenuItem icon={<BubbleChartRoundedIcon />}>Abonnements</MenuItem>
                            </SubMenu>
                            <MenuItem label="Passager" icon={<WalletRoundedIcon />}>Passager
                                {/*<MenuItem icon={<AccountBalanceRoundedIcon />}>*/}
                                {/*    Current Wallet*/}
                                {/*</MenuItem>*/}
                                {/*<MenuItem icon={<SavingsRoundedIcon />}>Savings Wallet</MenuItem>*/}
                            </MenuItem>
                            {/*// component={<Link to="transactions" className="link"/>}*/}
                            {/*component={()=>{handleSectionClick("Home")}}*/}
                            <MenuItem

                                onClick={() => handleSectionClick("Transactions")}
                                icon={<MonetizationOnRoundedIcon />}

                            >
                                Payements
                            </MenuItem>
                            <SubMenu label="Paramètres " icon={<SettingsApplicationsRoundedIcon />}>
                                <MenuItem icon={<AccountCircleRoundedIcon />}> Compte </MenuItem>
                                <MenuItem icon={<ShieldRoundedIcon />}> Privacy </MenuItem>
                                <MenuItem icon={<NotificationsRoundedIcon />}>
                                    Notifications
                                </MenuItem>
                            </SubMenu>
                            <MenuItem component={<Link to="login" className="link" />}
                                icon={<LogoutRoundedIcon />}
                            > Se Déconnecter </MenuItem>
                        </Menu>
                    </Sidebar>


                    <div className={StylesClasses.content}>
                        <section>

                            {/* <Typography variant='h1' align={"left"}>Bienvenu Salah Eddinne Elbakkerri</Typography> */}
                            <MainSection currentSection={currentSection} />
                        </section>

                    </div>
                </div>
                <Footer />
            </div>
            {/* </main> */}
        </>
    );
}