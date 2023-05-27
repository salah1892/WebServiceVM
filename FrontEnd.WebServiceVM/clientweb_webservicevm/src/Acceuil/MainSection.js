import React from 'react';
const Home = () => {
    return (
        <>
            <h1 className="header">WELCOME TO QUICKPAY</h1>
            <h3>Bank of the free</h3>
            <p>Lorem ipsum dolor sit amet...</p>
        </>
    );
};

const Dashboard = () => {
    return (
        <>
            <h1 className="header"> DASHBOARD PAGE</h1>
            <h3>Welcome User</h3>
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
        sectionContent = <Home/>;
    } else if (currentSection === 'Dashboard') {
        sectionContent = <Dashboard/>;
    } else if (currentSection === 'Transactions') {
        sectionContent = <Transactions/>;
    }

    return (
        <div >
            {sectionContent}
        </div>
    );
}

export default MainSection;