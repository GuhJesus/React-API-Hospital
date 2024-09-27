import React, { useState, useEffect } from 'react';
import { proxAtendimento, criarTriagem, listarEspecialidades } from '../services/api';
import '../pages.css'

const FilaAtendimento = () => {
    const [atendimento, setAtendimento] = useState(null);
    const [sintomas, setSintomas] = useState('');
    const [pressaoArterial, setPressaoArterial] = useState('');
    const [peso, setPeso] = useState('');
    const [altura, setAltura] = useState('');
    const [especialidadeId, setEspecialidadeId] = useState('');
    const [especialidadeDescricao, setEspecialidadeDescricao] = useState(''); // Novo estado para a descrição
    const [especialidades, setEspecialidades] = useState([]);

    useEffect(() => {
        const fetchEspecialidades = async () => {
            try {
                const response = await listarEspecialidades();
                setEspecialidades(response);
            } catch (error) {
                console.error('Erro ao carregar especialidades', error);
            }
        };

        fetchEspecialidades();
    }, []);

    const handleChamarAtendimento = async () => {
        try {
            const response = await proxAtendimento();
            setAtendimento(response);
            setSintomas('');
            setPressaoArterial('');
            setPeso('');
            setAltura('');
            setEspecialidadeId('');
            setEspecialidadeDescricao('');
        } catch (error) {
            console.error(error);
            alert('Erro ao chamar atendimento');
        }
    };

    const handleCriarTriagem = async () => {
        try {
            const triagemData = {
                atendimentoId: atendimento.id,
                sintomas: sintomas,
                pressaoArterial: pressaoArterial,
                peso: parseFloat(peso),
                altura: parseFloat(altura),
                especialidadeId: parseInt(especialidadeId),
                especialidadeDescricao: especialidadeDescricao,
            };

            const response = await criarTriagem(triagemData);
            setSintomas('');
            setPressaoArterial('');
            setPeso('');
            setAltura('');
            setEspecialidadeId('');
            alert('Triagem criada com sucesso!');
        } catch (error) {
            console.error(error);
            alert('Erro ao criar triagem');
        }
    };

    return (
        <div className="container">
            <h2>Fila de Atendimento</h2>
            <button className="btnCenter"
                onClick={handleChamarAtendimento}>Chamar Próximo Atendimento</button>
            {atendimento && (
                <div>
                    <h3>Atendimento Chamado:</h3>
                    <p>ID do Paciente: {atendimento.pacienteId}</p>
                    <p>Número Sequencial: {atendimento.numeroSequencial}</p>
                    <p>Status: {atendimento.status}</p>

                    <label>Sintomas:</label>
                    <textarea
                        value={sintomas}
                        onChange={(e) => setSintomas(e.target.value)}
                        placeholder="Digite os sintomas"
                    />
                    <label>Pressão Arterial:</label>
                    <input
                        type="text"
                        value={pressaoArterial}
                        onChange={(e) => setPressaoArterial(e.target.value)}
                        placeholder="Ex: 120/80"
                    />
                    <label>Peso (kg):</label>
                    <input
                        type="number"
                        value={peso}
                        onChange={(e) => setPeso(e.target.value)}
                        placeholder="Digite o peso"
                    />
                    <label>Altura (m):</label>
                    <input
                        type="number"
                        value={altura}
                        onChange={(e) => setAltura(e.target.value)}
                        placeholder="Digite a altura"
                    />
                    <label>Especialidade:</label>
                    <select
                        value={especialidadeId}
                        onChange={(e) => setEspecialidadeId(e.target.value)}
                    >
                        <option value="">Selecione a Especialidade</option>
                        {especialidades.map((especialidade) => (
                            <option key={especialidade.id} value={especialidade.id}>
                                {especialidade.descricao}
                            </option>
                        ))}
                    </select>
                    <button onClick={handleCriarTriagem}>Iniciar Triagem</button>
                </div>
            )}
        </div>
    );
};

export default FilaAtendimento;
