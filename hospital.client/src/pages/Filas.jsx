import React, { useState, useEffect } from 'react';
import { listarPacientes, listarAtendimentos, listarTriagens } from '../services/api';
import '../pages.css'

const FilaVisualizacao = () => {
    const [pacientes, setPacientes] = useState([]);
    const [atendimentos, setAtendimentos] = useState([]);
    const [triagens, setTriagens] = useState([]);
    const [activeTab, setActiveTab] = useState('pacientes'); // Controla a aba ativa

    useEffect(() => {
        const fetchData = async () => {
            try {
                const pacientesData = await listarPacientes();
                const atendimentosData = await listarAtendimentos();
                const triagensData = await listarTriagens();
                setPacientes(pacientesData);
                setAtendimentos(atendimentosData);
                setTriagens(triagensData);
            } catch (error) {
                console.error("Erro ao carregar dados", error);
            }
        };
        fetchData();
    }, []);

    const renderPacientes = () => (
        <div>
            <h3>Lista de Pacientes</h3>
            <ul>
                {pacientes.map(paciente => (
                    <li key={paciente.id}>{paciente.nome}</li>
                ))}
            </ul>
        </div>
    );

    const renderAtendimentos = () => (
        <div>
            <h3>Lista de Atendimentos</h3>
            <ul>
                {atendimentos.map(atendimento => (
                    <li key={atendimento.id}>Número Sequencial= {atendimento.numeroSequencial}  |  Status: {atendimento.status}</li>
                ))}
            </ul>
        </div>
    );

    const renderTriagens = () => (
        <div>
            <h3>Lista de Triagens</h3>
            <ul>
                {triagens.map(triagem => (
                    <li key={triagem.id}>Atendimento ID: {triagem.atendimentoId} - Especialidade: {triagem.especialidadeId}</li>
                ))}
            </ul>
        </div>
    );

    return (
        <div>
            <h2>Filas de Atendimento</h2>
            <div className="divFilasCenter">
                <button className="btnFilasCenter" onClick={() => setActiveTab('pacientes')}>Pacientes</button>
                <button className="btnFilasCenter" onClick={() => setActiveTab('atendimentos')}>Atendimentos</button>
                <button className="btnFilasCenter" onClick={() => setActiveTab('triagens')}>Triagens</button>
            </div>

            <div className="divFilasCenter">
                {activeTab === 'pacientes' && renderPacientes()}
                {activeTab === 'atendimentos' && renderAtendimentos()}
                {activeTab === 'triagens' && renderTriagens()}
            </div>
        </div>
    );
};

export default FilaVisualizacao;
