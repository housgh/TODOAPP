import {To, useNavigate} from "react-router-dom"
import React, {useEffect, useState} from "react";
import {NavBar} from "../components/navbar";
import {Badge, Button, Table} from "reactstrap";
import {TodoTask} from "../models/todo-task";
import {TaskStatus} from "../enums/task-status";
import Moment from 'moment'
import { FaPen } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';
import { FaPlus } from 'react-icons/fa';
import {CreateEditModal} from "../components/create-edit-modal";
import {DeleteModal} from "../components/delete-modal";
import {todoTaskService} from "../services/todo-task-service";
import {authService} from "../services/auth-service";
import axios from "axios";

export function Home(){
    let navigate = useNavigate();
    useEffect(() => {
        if(!authService.isLoggedIn()){
            navigate("/login");
        }
        axios.interceptors.request.use(function (config) {
            const token = localStorage.getItem("token");
            if(config && config.headers && token){
                config.headers.Authorization =  `Bearer ${token}`;
            }
            return config;
        });
    }, [])
    document.body.style.backgroundColor = 'white';
    Moment.locale('en');
    let [tasks, setTasks] = useState<TodoTask[]>([]);
    
    useEffect(() => {
        getTasks().catch(console.error);
    }, []);
    
    let getTasks = async (): Promise<void> => {
       let tasks =  await todoTaskService.getTasks();
       setTasks(tasks);
    }
    
    let statusColor: {[key: string] : string} = {
        [TaskStatus.Pending]: "warning",
        [TaskStatus.InProgress]: "primary",
        [TaskStatus.Complete]: "success"
    }
    
    let statusValue : {[key: string] : string} = {
        [TaskStatus.Pending]: "Pending",
        [TaskStatus.InProgress]: "In Progress",
        [TaskStatus.Complete]: "Complete"
    }

    
    let [taskId, setTaskId] = useState(0);
    let [isEditModalOpen, setEditModalOpen] = useState(false);
    let [isDeleteModalOpen, setDeletedModalOpen] = useState(false);

    let deleteTask = async () : Promise<void> => {
        await todoTaskService.deleteTask(taskId);
        toggleDeleteModal(false);
        await getTasks();
    }
    
    let submit = async (task: TodoTask) : Promise<void> => {
        if(!task) return;

        if(taskId){
            await todoTaskService.updateTask(task);
            toggleEditModal(false);
            await getTasks();
            return;
        }
        await todoTaskService.addTask(task);
        toggleEditModal(false);
        await getTasks();
    }
    
    let getTask  = async () : Promise<TodoTask | null>  => {
        if(!taskId) return null;
        return await todoTaskService.getTask(taskId);
    }
    
    function openCreateEditModal(id: number){
        setTaskId(id);
        setEditModalOpen(true);
    }
    
    function openDeleteModal(id: number){
        if(!id) return;
        setTaskId(id);
        setDeletedModalOpen(true);
    }
    
    function toggleEditModal(isOpen: boolean){
        if(!isOpen){
            setTaskId(0);
        }
        setEditModalOpen(isOpen);
    }
    
    function toggleDeleteModal(isOpen: boolean){
        if(!isOpen){
            setTaskId(0);
        }
        setDeletedModalOpen(isOpen);
    }
    
    return (
        <>
            <NavBar/>
            <div style={{padding: "50px"}}>
                <Button 
                    color="success" 
                    style={{fontSize: "10px", float: "right"}} 
                    onClick={() => openCreateEditModal(0)}>
                    <FaPlus/>
                </Button>
                
                <Table>
                    <thead>
                    <tr>
                        <th>#</th>
                        <th>title</th>
                        <th>status</th>
                        <th>created on</th>
                        <th>Actions</th>
                    </tr>
                    </thead>
                    <tbody>
                    {tasks.map((e, key) => {
                        return (
                            <tr key={key}>
                                <td>{e.id}</td>
                                <td>{e.title}</td>
                                <td>
                                    {console.log(e.status && statusColor[TaskStatus[e.status]])}
                                    {console.log(e.status && TaskStatus[e.status])}
                                    {console.log(e.status)}
                                    <Badge 
                                        color={e.status? statusColor[TaskStatus[e.status]]: "warning"}
                                        style={{padding: "10px"}}
                                    >{e.status ? statusValue[TaskStatus[e.status]] : "Pending"}</Badge>
                                </td>
                                <td>{Moment(e.createdOn).format("DD/MM/YYYY")}</td>
                                <td>
                                    <Button 
                                        color={"primary"} 
                                        style={{fontSize: "10px"}} 
                                        onClick={() => openCreateEditModal(e.id??0)}>
                                        <FaPen/>
                                    </Button>{" "}
                                    
                                    <Button 
                                        color={"danger"} 
                                        style={{ fontSize: "10px"}} 
                                        onClick={() => openDeleteModal(e.id??0)}>
                                        <FaTrash/>
                                    </Button>
                                </td>
                            </tr>
                        )
                    })}
                    </tbody>
                </Table>
                {tasks.length === 0 && <h3 style={{marginTop:"5%"}}>No Data Available</h3>}
                <CreateEditModal 
                    isOpen={isEditModalOpen} 
                    toggle={() => toggleEditModal(!isEditModalOpen)} 
                    id={taskId} submit={(task: TodoTask) => submit(task)} 
                    getTask={() => getTask()}
                />
                
                <DeleteModal 
                    isOpen={isDeleteModalOpen} 
                    toggle={() => toggleDeleteModal(!isDeleteModalOpen)} 
                    onDelete={() => deleteTask()} 
                />
            </div>
            
        </>
    )
}