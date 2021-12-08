import React, { useState } from 'react';
import api from '../../services/api.js';
import { useHistory } from 'react-router-dom';

import "../styles/index.scss";

export default function Login() {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const history = useHistory();

    async function Login(e) {
        e.preventDefault();
        const data = {
            userName,
            password
        }

        try {
            const response = await api.post('/Auth/signin', data);

            localStorage.setItem('userName', userName);
            localStorage.setItem('accessToken', response.data.accessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);
            localStorage.setItem('fullName', response.data.name);

            history.push('/dashboard')
        } catch (e) {
            console.log(e);
        }
    }

    async function Redirect() {
        history.push('/register');
    }

    return (
        <div className="container">
            <form onSubmit={Login} className="box" method="post">
                <h1>Web&Ponto</h1>
                <input type="text" value={userName} onChange={e => setUserName(e.target.value)} placeholder="Usuário" />
                <input type="password" value={password} onChange={e => setPassword(e.target.value)} placeholder="Senha" />
                <input type="submit" value="Entrar"/>
                <div className="forgot" onClick={Redirect}>Registrar-se</div>
            </form>
        </div>
    );
}