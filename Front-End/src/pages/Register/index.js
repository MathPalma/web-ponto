import React, { useState } from 'react';
import api from '../../services/api.js';
import { useHistory } from 'react-router-dom';

import '../styles/index.scss';

export default function Register() {
    const [usuario, setUserName] = useState('');
    const [nome, setUserFullName] = useState('');
    const [email, setEmail] = useState('');
    const [telefone, setCellPhone] = useState('');
    const [senha, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const history = useHistory();

    async function Register(e) {
        e.preventDefault();

        const data = {
            usuario,
            nome,
            email,
            senha
        }

        if(senha === confirmPassword)
        {
            try {
                const response = await api.post('/Auth/register', data);
                history.push('/')
            } catch (e) {
                console.log(e);
            }
        }
        else
        {
            alert('Senhas não coincidem. Tente novamente!');
        }
        
    }

    async function Redirect() {
        history.push('/');
    }

    return (
        <div className="container">
            <form onSubmit={Register} className="box" method="post">
                <h1>Web&Ponto</h1>
                <input type="text" value={usuario} onChange={e => setUserName(e.target.value)} placeholder="Usuário" />
                <input type="text" value={nome} onChange={e => setUserFullName(e.target.value)} placeholder="Nome" />
                <input type="email" value={email} onChange={e => setEmail(e.target.value)} placeholder="Email" />
                <input type="text" value={telefone} onChange={e => setCellPhone(e.target.value)} placeholder="Telefone" />
                <input type="password" value={senha} onChange={e => setPassword(e.target.value)} placeholder="Senha" />
                <input type="password" value={confirmPassword} onChange={e => setConfirmPassword(e.target.value)} placeholder="Confirmar Senha" />
                <input type="submit" value="Cadastrar-se" onClick="login()" />
                <div className="forgot" onClick={Redirect}>Logar-se</div>
            </form>
        </div>
    );
}