import React, { useState } from 'react'
import { FaCheckSquare } from 'react-icons/fa';
import Button from 'react-bootstrap/Button';
import  { Navbar, Container } from 'react-bootstrap';


const Dashboard = () => {
    let time = new Date().toLocaleTimeString();

    const [ctime, setCtime] = useState(time);

    const UpdateTime = () => {
        time = new Date().toLocaleTimeString();
        setCtime(time);
    }

    setInterval(UpdateTime, 1000);

    return (
        // <Navbar bg="dark" variant="dark">
        //     <Container>
        //     <Navbar.Brand href="#home">Navbar</Navbar.Brand>
        //     <Nav className="me-auto">
        //     <Nav.Link href="#home">Home</Nav.Link>
        //     <Nav.Link href="#features">Features</Nav.Link>
        //     <Nav.Link href="#pricing">Pricing</Nav.Link>
        //     </Nav>
        //     </Container>
        // </Navbar>
        
        <div>
            <h1>Hello Matheus!</h1>
            <h3>Aponte suas horas</h3>
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
