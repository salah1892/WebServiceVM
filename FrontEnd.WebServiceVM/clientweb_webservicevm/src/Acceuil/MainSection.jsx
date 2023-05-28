//import { height } from '@mui/system';
import React from 'react';
import Clients from './Clients';
import Dashboard from './Dashboard'
// import { GlobalStyles } from "./Acceuil/GlobalStyles"
const Home = () => {
    return (
        <>
            <h1 className="header">WELCOME TO QUICKPAY</h1>
            <h3>Bank of the free</h3>
            <p>Lorem ipsum dolor sit amet...</p>
        </>
    );
};
const Transactions = () => {
    return (
        <>
            <h1 className="header">KEEP TRACK OF YOUR SPENDINGS</h1>
            <h3>Seamless Transactions</h3>
            <p>Lorem ipsum dolor sit amet...</p>
        </>
    );
};
function MainSection({ currentSection }) {
    
    let sectionContent = null;

    if (currentSection === 'Home') {
        sectionContent = <Home />;
    } else if (currentSection === 'Dashboard') {
        sectionContent = <Dashboard />;
    } else if (currentSection === 'Transactions') {
        sectionContent = <Transactions />;
    } else if (currentSection === 'Clients') {
        sectionContent = <Clients />;
    }
    // style={{flexGrow: 1,
    //     width: 1000,
    //         height: '100vh',
    //             overflow: 'auto'}}
    return (
        <div className='MainSection' style={{
            flexGrow: 1,
            width: 1000,
            height: '100vh',
            overflow: 'auto'
        }}>
            {sectionContent}
        </div>
    );
}

export default MainSection;