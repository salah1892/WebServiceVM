import './App.css';
import { Routes, Route, BrowserRouter } from "react-router-dom";
import Acceuil from './Acceuil/Acceuil';
import Register from './LoginPages/Register';
import Login from './LoginPages/Login';
import ForgotPassword from './LoginPages/ForgotPassword';
function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" exact element={<Login />}></Route>
          <Route path="/register" exact element={<Register />}></Route>
          <Route path="/reset-password" exact element={<ForgotPassword />}></Route>
          <Route path="/Acceuil" exact element={<Acceuil />}></Route>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
