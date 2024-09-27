import React, { useState, useEffect } from 'react';
import Home from './components/Home.jsx'
//import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
//import RegistroPaciente from './pages/RegistroPaciente'
//import FilaAtendimento from './pages/FilaAtendimento';

//function App() {
//    return (
//        <Router>
//            <Routes>
//                <Route path="/" element={<RegistroPaciente />} />
//                <Route path="/atendimento" element={<FilaAtendimento />} />
//            </Routes>
//        </Router>
//    );
//}

function App() {

    return (
        <div>
            <Home />
        </div>
    );
}

export default App;
