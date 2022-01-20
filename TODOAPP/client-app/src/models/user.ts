import {Role} from "../enums/role";

export interface User{
    id: number;
    username: string;
    email: string;
    role: Role
}