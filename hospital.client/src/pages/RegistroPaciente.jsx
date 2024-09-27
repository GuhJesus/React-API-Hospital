import React, { useState } from 'react';
import { registrarPaciente } from '../services/api';
import '../pages.css'

function RegistroPaciente() {
    const [nome, setNome] = useState('');
    const [telefone, setTelefone] = useState('');
    const [sexo, setSexo] = useState('');
    const [email, setEmail] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        const paciente = { nome, telefone, sexo, email };
        try {
            await registrarPaciente(paciente);
            setNome('');
            setTelefone('');
            setSexo('');
            setEmail('');
            alert('Paciente registrado com sucesso!');
        } catch (error) {
            alert('Erro ao registrar paciente');
        }
    };

    return (
        <div className="container">
            <h2>Cadastro de Paciente</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Nome:</label>
                    <input
                        type="text"
                        value={nome}
                        onChange={(e) => setNome(e.target.value)}
                        required
                        placeholder="Digite o nome do paciente"
                    />
                </div>
                <div>
                    <label>Telefone:</label>
                    <input
                        type="text"
                        value={telefone}
                        onChange={(e) => setTelefone(e.target.value)}
                        required
                        placeholder="Digite o telefone"
                    />
                </div>
                <div>
                    <label>Sexo:</label>
                    <select value={sexo} onChange={(e) => setSexo(e.target.value)} required>
                        <option value="">Selecione</option>
                        <option value="Masculino">Masculino</option>
                        <option value="Feminino">Feminino</option>
                        <option value="Outro">Outro</option>
                    </select>
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                        placeholder="Digite o e-mail"
                    />
                </div>
                <button type="submit">Cadastrar Paciente</button>
            </form>
        </div>
    );
};

export default RegistroPaciente;
