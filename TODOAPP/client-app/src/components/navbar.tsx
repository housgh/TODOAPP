import React, {useState} from 'react';
import {
    Button,
    Navbar,
    NavbarBrand,
} from 'reactstrap';
import {FaLockOpen} from 'react-icons/fa'
import {authService} from "../services/auth-service";
import {useNavigate} from "react-router-dom";



export function NavBar(){
    let navigate = useNavigate();
    let logout = () => {
        authService.logout();
        navigate("/login");
    }
    return (
        <div>
            <Navbar style={{backgroundColor: "#3b5eec"}} light expand="md">
                <NavbarBrand style={{color: "white"}} href="/">{"TODO APP"}</NavbarBrand>
                <Button style={{backgroundColor: 'inherit', border: 'none'}} end={"true"} onClick={() => logout()}><FaLockOpen/></Button>
            </Navbar>
        </div>
    );
}
