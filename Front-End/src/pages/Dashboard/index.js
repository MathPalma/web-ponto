import React, { useState } from 'react'
import { FaCheckSquare } from 'react-icons/fa';

import styled from 'styled-components';


import './styles.css';
import { Nav, NavLink, Bars, NavMenu, NavBtnLink, NavBtn } from './NavbarElements';

const Dashboard = () => {
    let time = new Date().toLocaleTimeString();

    const [ctime, setCtime] = useState(time);

    const UpdateTime = () => {
        time = new Date().toLocaleTimeString();
        setCtime(time);
    }

    setInterval(UpdateTime, 1000);

    return (
        <div>
            <Nav>
                <NavMenu>
                    <NavLink to="/Ponto">Bater Ponto</NavLink>
                    <NavLink to="/Relatorios">Relatórios</NavLink>
                </NavMenu>
                <Bars />
                <NavBtn>
                    <NavBtnLink to="/">Sair</NavBtnLink>
                </NavBtn>

            </Nav>
            <h1>Hello Matheus!</h1>
            <h3>Relógio de ponto virutal</h3>
            <div className="container-bater-ponto">
                <div className="itens-bater-ponto">

                    <h1>{time}</h1>
                    Horário do Servidor
                    <button className="btn-registrar-ponto">
                        Registrar Ponto
                        <span className="symbol-btn">
                            <FaCheckSquare></FaCheckSquare>
                        </span>

                    </button>

                </div>
            </div>


        </div>
    )
}

export default Dashboard
