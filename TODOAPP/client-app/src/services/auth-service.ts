import axios from 'axios';
import {LoginModel} from '../models/login-model';
import {HttpResult} from "../models/http-result";
import {LoginResult} from "../models/login-result";

//import {Jwt} from 'jsonwebtoken'

export const authService = {
    login,
    isLoggedIn,
    logout
};

async function login(model: LoginModel): Promise<boolean>{
    let result : HttpResult<LoginResult> = (await axios({
        method: 'POST',
        url: '/api/Auth',
        data: model
    })).data;
    if(!result || !result.data || !result.data.token){
        return false;
    }
    console.log(result.data.token)
    localStorage.setItem("token", result.data.token);
    return true;
}

function isLoggedIn(): boolean{
    let token = localStorage.getItem("token");
    return !!token;
    
}

function logout(): void{
    localStorage.clear();
}
