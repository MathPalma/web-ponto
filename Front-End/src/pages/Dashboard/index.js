import React, { useState } from 'react';
import api from '../../services/api.js';
import { FaCheckSquare } from 'react-icons/fa';
import { Navbar, Nav, Alert, Container } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

import "../styles/dashboard.scss";

const Dashboard = () => {

    const username = localStorage.getItem('userName');
    const fullName = localStorage.getItem('fullName');


    let time = new Date().toLocaleTimeString();

    const [ctime, setCtime] = useState(time);

    const [show, setShow] = useState(false);

    const UpdateTime = () => {
        time = new Date().toLocaleTimeString();
        setCtime(time);
    }

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
                localStorage.clear();
                break;
        }
    }

    setInterval(UpdateTime, 1000);

    async function PointRegister() {
        try {
            const data = {
                username
            }
            const response = await api.post('/Ponto/marcar', data)

            setShow(true);

            setTimeout(() => {
                setShow(false)
            }, 3000)
        } catch (error) {
            console.log(error);
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
                <div className="itens-bater-ponto">
                    <Alert variant="success" show={show}>
                        Ponto registrado com sucesso!
                    </Alert>
                    <h1>Hello {fullName}!</h1>
                    <h1>{time}</h1>
                    Horário do Servidor
                    <button className="btn-registrar-ponto" onClick={PointRegister}>
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
