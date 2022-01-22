import React, {useState} from "react";
import {LoginModel} from "../models/login-model";
import {Button, FormGroup, Input, Label} from "reactstrap";
import {authService} from "../services/auth-service";
import {useNavigate} from "react-router-dom";

export function Login(){
    document.body.style.backgroundColor = '#3b5eec';
    let navigate = useNavigate();
    let [loginModel, setLoginModel] = useState<LoginModel>({ username: "", password: ""} as LoginModel);

    let loginContainer : React.CSSProperties = {
        marginRight: 'auto',
        marginLeft: 'auto',
        width: '350px',
        backgroundColor: 'white',
        marginTop: '10%',
        height: '400px',
        //textAlign: 'center',
        padding: '1rem',
        fontFamily: 'Trebuchet MS'
    };
    
    let submit = async () => {
        await authService.login(loginModel);
        navigate("/home");
    }

    return (
        <>
            <div style={loginContainer}>
                <h1>Login</h1>
                <div style={{marginTop: '20%'}}>
                        <FormGroup>
                            <Label for="description">Username</Label>
                            <Input
                                type="text"
                                id="description"
                                value={loginModel?.username}
                                onChange={(e) => setLoginModel({...loginModel, username: e.target.value})}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label for="description">Password</Label>
                            <Input
                                type="password"
                                id="description"
                                value={loginModel?.password}
                                onChange={(e) => setLoginModel({...loginModel, password: e.target.value})}
                            />
                        </FormGroup>
                        <Button style={{marginTop: "5%", backgroundColor: "#3b5eec"}} onClick={() => submit()}>Login</Button>
                </div>
            </div>
        </>
    )
}