import React, { useState } from 'react';
import { FaCheckSquare } from 'react-icons/fa';
import { Navbar, Nav, Alert, Container } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

import "../styles/dashboard.scss";

const Dashboard = () => {
    
    let time = new Date().toLocaleTimeString();

    const [ctime, setCtime] = useState(time);

    const [show, setShow] = useState(false);

    const UpdateTime = () => {
        time = new Date().toLocaleTimeString();
        setCtime(time);
    }

    const history = useHistory();

    async function Redirect() {
        history.push('/');
    }

    setInterval(UpdateTime, 1000);

    async function PointRegister() {
        setShow(true);

        setTimeout(() => {
            setShow(false)
        }, 3000)
    }

    return (
        <div class="container-dashboard">
            <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand href="#home">Web&Ponto</Navbar.Brand>
                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        <Nav className="me-auto">
                            <Nav.Link href="#appointments">Bater Ponto</Nav.Link>
                            <Nav.Link href="#reports">Relatórios</Nav.Link>
                        </Nav>
                        <Nav>
                            <Nav.Link onClick={Redirect}>Sair</Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
            <div className="container-bater-ponto">
                <div className="itens-bater-ponto">
                    <Alert variant="success" show={show}>
                        Ponto registrado com sucesso! 
                    </Alert>
                    <h1>Hello Matheus!</h1>
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
