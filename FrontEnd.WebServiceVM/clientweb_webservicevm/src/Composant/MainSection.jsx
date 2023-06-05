//import { height } from '@mui/system';
import React from 'react';
import Clients from './Clients';
import Dashboard from './Dashboard'
import Abonnee from "./Abonnee";
import Abonnement from "./Abonnement";
import Passager from "./Passager";
import Payement from "./Payement";
// import { GlobalStyles } from "./Composant/GlobalStyles"
const Home = () => {
    return (
        <>
            <h1 className="header">From Home</h1>
            <h3>From Home</h3>
            <p>From Home.........</p>
        </>
    );
};
// const Payement = () => {
//     return (
//         <>
//             <h1 className="header">Payement</h1>
//             <h3>Payement</h3>
//             <p>Payement..................</p>
//         </>
//     );
// };

function MainSection({currentSection}) {

    let sectionContent = null;

    if (currentSection === 'Home') {
        sectionContent = <Home/>;
    } else if (currentSection === 'Dashboard') {
        sectionContent = <Dashboard/>;
    } else if (currentSection === 'Payement') {
        sectionContent = <Payement/>;
    } else if (currentSection === 'Clients') {
        sectionContent = <Clients/>;
    } else if (currentSection === 'Abonnee') {
        sectionContent = <Abonnee/>;
    } else if (currentSection === 'Abonnement') {
        sectionContent = <Abonnement/>;
    }else if (currentSection === 'Passager') {
        sectionContent = <Passager/>;
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