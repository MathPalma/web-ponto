import React, { useEffect, useState } from 'react';

import {FaLock, FaUserAlt} from 'react-icons/fa';
import { useHistory } from 'react-router-dom';

import './styles.css';

export default function Login() {

    const [user, setUser] = useState('');
    const[password, setPassword] = useState('');

    const history = useHistory();

    async function Login(e) {
        e.preventDefault();
    }
    return (
        <body>
            <div className="limiter">
                <div className="container-login100">
                    <div className="wrap-login100">
                        <form action="" className="login100-form validate-form">
                            <span className="login100-form-title">
                                WebPonto Login
                            </span>

                            <div className="wrap-input100 validate-input">
                                <input type="text" className="input" />
                                <span className="symbol-input100">
                                    <FaUserAlt/>
                                </span>
                            </div>

                            <div className="wrap-input100 validate-input">
                                <input type="password" className="input" />
                                <span className="symbol-input100">
                                    <FaLock/>
                                </span>
                            </div>

                            <div className="container-login100-form-btn">
                                <button className="login100-form-btn">Login</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </body>
    );

}