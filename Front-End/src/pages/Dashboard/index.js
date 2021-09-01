import React from 'react'

import styled from 'styled-components';


import './styles.css';
import { Nav, NavLink, Bars, NavMenu, NavBtnLink, NavBtn } from './NavbarElements';

const Dashboard = () => {
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
        </div>
    )
}

export default Dashboard
