import axios from 'axios';

const API_URL = 'https://localhost:7155/api'; // Substitua pela URL correta do seu backend



// Função para listar pacientes
export const listarPacientes = async () => {
    try {
        const response = await axios.get(`${API_URL}/paciente`);
        return response.data;
    } catch (error) {
        console.error('Erro ao listar pacientes', error);
        throw error;
    }
};

// Função para registrar novo paciente
export const registrarPaciente = async (paciente) => {
    try {
        const response = await axios.post(`${API_URL}/Paciente`, paciente);
        return response.data;
    } catch (error) {
        console.error('Erro ao registrar paciente', error);
        throw error;
    }
};

// Função para listar atendimentos
export const listarAtendimentos = async () => {
    try {
        const response = await axios.get(`${API_URL}/atendimento/ListaAtendimento`);
        return response.data;
    } catch (error) {
        console.error('Erro ao listar atendimentos', error);
        throw error;
    }
};

//Próximo Atendimento
export const proxAtendimento = async () => {
    try {
        const response = await axios.get(`${API_URL}/atendimento/ProximoAtendimento`);
        return response.data;
    } catch (error) {
        console.error('Erro ao listar atendimentos', error);
        throw error;
    }
};

// Função para registrar triagem
export const criarTriagem = async (triagem) => {
    try {
        const response = await axios.post(`${API_URL}/triagem`, triagem);
        return response.data;
    } catch (error) {
        console.error('Erro ao registrar triagem', error);
        throw error;
    }
};

// Função para listar triagens
export const listarTriagens = async () => {
    try {
        const response = await axios.get(`${API_URL}/triagem`);
        return response.data;
    } catch (error) {
        console.error('Erro ao listar atendimentos', error);
        throw error;
    }
};

// Função para listar especialidades
export const listarEspecialidades = async () => {
    try {
        const response = await axios.get(`${API_URL}/especialidade/ListaEspecialidade`);
        return response.data;
    } catch (error) {
        console.error('Erro ao listar especialidades', error);
        throw error;
    }
};
