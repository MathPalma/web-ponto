import React from 'react';
import { Navbar, Nav, Table, Container } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

import "../styles/dashboard.scss";

const Report = () => {

    const history = useHistory();

    function Redirect(params) {
        switch (params) {
            case 'home':
                history.push('/dashboard');
                break;
            case 'reports':
                history.push('/reports');
                break;
            default:
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
                            </thead>
                            <tbody>
                                <tr>
                                    <td>07/12/2021</td>
                                    <td>08:00</td>
                                    <td>13:00</td>
                                </tr>
                                <tr>
                                    <td>07/12/2021</td>
                                    <td>14:00</td>
                                    <td>17:00</td>
                                </tr>
                                <tr>
                                    <td>08/12/2021</td>
                                    <td>08:00</td>
                                    <td>13:00</td>
                                </tr>
                                <tr>
                                    <td>08/12/2021</td>
                                    <td>14:00</td>
                                    <td>17:00</td>
                                </tr>
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Report
