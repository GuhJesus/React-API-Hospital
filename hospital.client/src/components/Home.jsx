import React, { useState, useEffect } from 'react';
import Header from '../components/Header.jsx'
//import ItemForm from '../pages/FilaAtendimento.jsx';
//import ItemList from '../pages/RegistroPaciente.jsx';
import FilaAtendimento from '../pages/FilaAtendimento.jsx';
import RegistroPaciente from '../pages/RegistroPaciente.jsx';
import FilaVisualizacao from '../pages/Filas.jsx';


function Home() {

    const [page, setPage] = useState();


    const renderComponent = () => {
        switch (page) {
            case 'Paciente': return <RegistroPaciente />;
            case 'Atendimento': return <FilaAtendimento />;
            case 'Fila': return <FilaVisualizacao />;
            default: return;
        }

    }

    return (
        <div>
            <header>
                <Header setPage={setPage} />
            </header>
            <main>
                {page ? renderComponent() : (
                    <h1> Olá, Bem vindo ao Hospital.NET</h1>
                )}
            </main>
        </div>
    );
}

export default Home;