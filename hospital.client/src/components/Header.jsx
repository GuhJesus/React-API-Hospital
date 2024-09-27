import React, { useState, useEffect } from 'react';
import '../Header.css'


function Header({ setPage }) {

    return (
        <nav className="navbar">
            <button onClick={() => setPage('Paciente')}>Cadastro de Pacientes</button>
            <button onClick={() => setPage('Atendimento')}>Atendimentos</button>
            <button onClick={() => setPage('Fila')}>Filas</button>
        </nav>
    );
}

export default Header;