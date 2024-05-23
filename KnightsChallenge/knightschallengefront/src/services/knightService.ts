import axios from 'axios';
import type { Knight } from '@/types/Knight';

const API_URL = 'http://localhost:8080/api/Knights';

export default {
    async getKnights(): Promise<Knight[]> {
        const response = await axios.get(API_URL);
        return response.data;
    },

    async getKnight(id: string): Promise<Knight> {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    },

    async getHeroes(): Promise<Knight[]> {
        const response = await axios.get(`${API_URL}/heroes`);
        return response.data;
    },

    async createKnight(knight: Knight): Promise<Knight> {
        const response = await axios.post(API_URL, knight);
        return response.data;
    },

    async updateKnight(id: string, knight: Knight): Promise<Knight> {
        const response = await axios.patch(`${API_URL}/${id}`, knight);
        return response.data;
    },

    async deleteKnight(id: string): Promise<void> {
        await axios.delete(`${API_URL}/${id}`);
    },
};
