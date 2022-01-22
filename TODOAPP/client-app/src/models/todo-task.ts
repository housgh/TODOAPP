import {User} from "./user";
import {TaskStatus} from "../enums/task-status";

export interface TodoTask{
    id?: number;
    title?: string;
    description?: string;
    userId?: number;
    createdOn?: string;
    user?: User;
    status?: TaskStatus;
}