import {User} from "./user";

export interface TodoTask{
    id: number,
    title: string,
    description: string,
    userId: number,
    createdOn: Date,
    user: User
}