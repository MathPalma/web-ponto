import styled from 'styled-components'
import { NavLink as NLink } from 'react-router-dom'
import { FaBars } from 'react-icons/fa'

export const Nav = styled.nav`
    background: purple;
    height: 80px;
    display: flex;
    justify-content: space-between;
    padding: 0.5rem calc((100vw - 1000px) / 2);
    z-index: 10;
    `

    export const NavLink = styled(NLink)`
        color: #fff;
        display: flex;
        align-items: center;
        text-decoration: none;
        padding: 0 1rem;
        height: 100%;
        cursor: pointer;
        
        &:active {
            color: #04BF58;
        }
    `

    export const Bars = styled(FaBars)`
        display: none;
        color: #fff;

        @media screen and (max-width: 768px) {
            display: block;
            position: absolute;
            top: 0;
            right: 0;
            transform: translate(-100%, 75%);
            font-size: 1.8rem;
            cursor: pointer;
        }
    `

    export const NavMenu = styled.div`
        display: flex;
        align-items: center;
        margin-right: -24px;

        @media screen and (max-width: 768px) {
            display: none;
        }
    `

    export const NavBtn = styled.nav`
        display: flex;
        align-items: center;
        margin-right: 24px;

        @media screen and (max-width: 768px) {
            display: none;
        }
    `

    export const NavBtnLink = styled(NLink)`
        border-radius: 4px;
        background-color: #04D361;
        align-items: center;
        width: 150px;
        padding: 10px 55px;
        color: #fff;
        border: none;
        outline: none;
        cursor: pointer;
        transition: all 0.2s ease-in-out;
        text-decoration: none;

        &:hover {
            transition: all 0.2s ease-in-out;
            background-color: #04BF58;
        }
    `