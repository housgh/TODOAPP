import axios from 'axios';
import {LoginModel} from '../models/login-model';
import {HttpResult} from "../models/http-result";
import {LoginResult} from "../models/login-result";

//import {Jwt} from 'jsonwebtoken'

export async function Login(model: LoginModel): Promise<boolean>{
    let result : HttpResult<LoginResult> = await axios({
        method: 'POST',
        url: '/Auth',
        data: model
    });
    
    if(!result || !result.data || !result.data.token){
        return false;
    }
    
    localStorage.setItem("token", result.data.token);
    return true;
}

export function isLoggedIn(): boolean{
    return localStorage.getItem("token") === null;
}
