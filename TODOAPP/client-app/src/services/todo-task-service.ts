import axios from "axios";
import {TodoTask} from "../models/todo-task";
import {HttpResult} from "../models/http-result";

export const todoTaskService = {
    getTasks,
    getTask,
    addTask,
    updateTask,
    deleteTask
}

async function getTasks(): Promise<TodoTask[]>{
    let result : HttpResult<TodoTask[]> = (await axios({
        method: 'GET',
        url: '/api/Task',
    })).data;
    
    return result.data;
}

async function getTask(id: number) : Promise<TodoTask>{
    let result : HttpResult<TodoTask> = (await axios({
        method: 'GET',
        url:`/api/Task/${id}`
    })).data;
    
    return result.data;
}

async function addTask(todoTask: TodoTask): Promise<void>{
    await axios({
        method: 'POST',
        url: 'api/Task',
        data: todoTask
    })
}

async function updateTask(todoTask: TodoTask): Promise<void>{
    await axios({
        method: 'PUT',
        url: 'api/Task',
        data: todoTask
    })
}

async function deleteTask(id: number) : Promise<void>{
    await axios({
        method: 'DELETE',
        url: `api/Task/${id}`
    })
}