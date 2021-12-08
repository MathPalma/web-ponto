import React, { useState, useEffect } from 'react';
import api from '../../services/api.js';
import { Navbar, Nav, Table, Container } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

import "../styles/dashboard.scss";

const Report = () => {

    const [days, setDays] = useState([]);
    const username = localStorage.getItem('userName');
    const history = useHistory();

    useEffect(() => {
        api.get(`/Relatorio/${username}`)
            .then(response => {
                setDays(response.data)
            })

        console.log(days);
    });

    function Redirect(params) {
        switch (params) {
            case 'home':
                history.push('/dashboard');
                break;
            case 'reports':
                history.push('/reports');
                break;
            default:
                localStorage.clear();
                history.push('/');
                break;
        }
    }

    return (
        <div className="container-dashboard">
            <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand onClick={() => Redirect('home')}>Web&Ponto</Navbar.Brand>
                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        <Nav className="me-auto">
                            <Nav.Link onClick={() => Redirect('home')}>Bater Ponto</Nav.Link>
                            <Nav.Link onClick={() => Redirect('reports')}>Relatórios</Nav.Link>
                        </Nav>
                        <Nav>
                            <Nav.Link onClick={() => Redirect('exit')}>Sair</Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
            <div className="container-bater-ponto">
                <div className="itens-report">
                    <h1>Relatório</h1>
                    <div className="table">
                        <Table striped bordered hover variant="dark">
                            <thead>
                                <tr>
                                    <th>Data Apontada</th>
                                    <th>Hora Entrada</th>
                                    <th>Hora Saída</th>
                                </tr>
                                {days.map((day, i) => (
                                    <tr key={i}>
                                        <th>{Intl.DateTimeFormat('pt-BR').format(new Date(day.dia))}</th>
                                        <th>{Intl.DateTimeFormat('pt-BR', {hour: 'numeric', minute: 'numeric'}).format(new Date(day.entrada))}</th>
                                        <th>{Intl.DateTimeFormat('pt-BR', {hour: 'numeric', minute: 'numeric'}).format(new Date(day.saida))}</th>
                                    </tr>
                                ))
                                }

                            </thead>
                        </Table>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Report
