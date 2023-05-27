import {Button, Card, CardContent, AppBar, CssBaseline, Toolbar, Typography} from "@mui/material";
import useStyles from './styles';
import {Routes, Route, Link, BrowserRouter} from "react-router-dom";
import React, {useState} from "react";
import {PhotoCamera} from "@mui/icons-material"
import MenuRoundedIcon from "@mui/icons-material/MenuRounded";
import GridViewRoundedIcon from "@mui/icons-material/GridViewRounded";
import ReceiptRoundedIcon from "@mui/icons-material/ReceiptRounded";
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
import {Sidebar, Menu, MenuItem, SubMenu, useProSidebar} from "react-pro-sidebar";
import MainSection from "./MainSection";
//------------------------------------------------------------------------------------//
export default function Acceuil() {
    const StylesClasses = useStyles();
    const {collapseSidebar, toggleSidebar, collapsed, toggled, broken, rtl} = useProSidebar();
    const [currentSection, setCurrentSection] = useState('Home');
    const handleSectionClick = (section) => {
        setCurrentSection(section);
    }
    return (
        <>
            <CssBaseline/>
            <AppBar position="relative">
                {/*style={{color: "#F0785F"}}*/}
                <Toolbar>
                    <PhotoCamera className={StylesClasses.icon}/>
                    <Typography variant='h6'>
                        SECA
                    </Typography>
                </Toolbar>
            </AppBar>
            <main>
                <div className={StylesClasses.container}>
                    <div style={{display: "flex", height: "100vh"}}>


                        <Sidebar styles={{background: '#a8d5e5'}}>
                            {/* // component={<Link to="home" className="link"/>}*/}
                            <Menu>
                                <MenuItem


                                    className="menu1"
                                    icon={<MenuRoundedIcon
                                        onClick={() => {
                                            collapseSidebar();
                                        }}/>}
                                >
                                    <h2>QUICKPAY</h2>
                                </MenuItem>
                                {/*component={<Link to="dashboard" className="link"/>}*/}
                                <MenuItem
                                    onClick={() => handleSectionClick("Home")}
                                    icon={<GridViewRoundedIcon/>}

                                >
                                    Dashboard
                                </MenuItem>
                                <MenuItem icon={<ReceiptRoundedIcon/>}> Invoices </MenuItem>
                                <SubMenu label="Charts" icon={<BarChartRoundedIcon/>}>
                                    <MenuItem icon={<TimelineRoundedIcon/>}> Timeline Chart </MenuItem>
                                    <MenuItem icon={<BubbleChartRoundedIcon/>}>Bubble Chart</MenuItem>
                                </SubMenu>
                                <SubMenu label="Wallets" icon={<WalletRoundedIcon/>}>
                                    <MenuItem icon={<AccountBalanceRoundedIcon/>}>
                                        Current Wallet
                                    </MenuItem>
                                    <MenuItem icon={<SavingsRoundedIcon/>}>Savings Wallet</MenuItem>
                                </SubMenu>
                                {/*// component={<Link to="transactions" className="link"/>}*/}
                                {/*component={()=>{handleSectionClick("Home")}}*/}
                                <MenuItem

                                    onClick={() => handleSectionClick("Transactions")}
                                    icon={<MonetizationOnRoundedIcon/>}

                                >
                                    Transactions
                                </MenuItem>
                                <SubMenu label="Settings" icon={<SettingsApplicationsRoundedIcon/>}>
                                    <MenuItem icon={<AccountCircleRoundedIcon/>}> Account </MenuItem>
                                    <MenuItem icon={<ShieldRoundedIcon/>}> Privacy </MenuItem>
                                    <MenuItem icon={<NotificationsRoundedIcon/>}>
                                        Notifications
                                    </MenuItem>
                                </SubMenu>
                                <MenuItem component={<Link to="login" className="link"/>}
                                          icon={<LogoutRoundedIcon/>}
                                > Logout </MenuItem>
                            </Menu>
                        </Sidebar>
                        <section>

                            <Typography variant='h1' align={"left"}>Bienvenu Salah Eddinne Elbakkerri</Typography>
                            <MainSection currentSection={currentSection}/>
                        </section>
                    </div>
                </div>
            </main>

            <footer className={StylesClasses.footer}>
                <Typography variant='h6' align="center" gutterBottom>
                    Footer
                </Typography>
                <Typography variant='subtitle1' align="center" color="textSecondary">
                    Something here to give the footer a purpose!
                </Typography>
            </footer>
        </>
    );
}