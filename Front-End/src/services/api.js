import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:44355',
})

export default api;