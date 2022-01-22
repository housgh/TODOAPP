import React, {useEffect, useState} from 'react'
import {Button, FormGroup, Input, Label, Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";
import {TaskStatus} from "../enums/task-status";
import {TodoTask} from "../models/todo-task";

export function CreateEditModal(props: {isOpen: boolean, toggle: () => void, id: number | null, submit: (todoTask: TodoTask) => void, getTask: () => Promise<TodoTask | null>}){
    useEffect(() => {
        getTask().catch(console.error);
    }, [props.isOpen])
    
    let initialTask : TodoTask = {
        status: TaskStatus.Pending,
        title: "",
        description: ""
    }
    
    let [task, setTask]= useState<TodoTask>(initialTask);
    
    let getTask = async () => {
        setTask(initialTask);
        if(props.id){
            let taskResult = await props.getTask();
            if(!taskResult) return;
            setTask(taskResult);
        }
    }
    
    return (
        <>
            <Modal isOpen={props.isOpen} toggle={props.toggle}>
                <ModalHeader toggle={props.toggle}>{props.id? "Edit" : "Create"} Task {task?.title? "-" : ""} {task?.title}</ModalHeader>
                <ModalBody>
                    <FormGroup>
                        <Label for="title">Title</Label>
                        <Input 
                            type="text"
                            id={"title"}
                            placeholder="Title"
                            value={task?.title}
                            onChange={(e) => setTask({...task, title: e.target.value})}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label for="status">Status</Label>
                        <Input 
                            type="select"
                            id="status"
                            value={task?.status}
                            onChange={(e) => setTask({...task, status: (TaskStatus as any)[e.target.value]})}
                        >
                            <option value={TaskStatus.Pending}>Pending</option>
                            <option value={TaskStatus.InProgress}>In Progress</option>
                            <option value={TaskStatus.Complete}>Complete</option>
                        </Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="description">Description</Label>
                        <Input 
                            type="textarea" 
                            id="description"
                            value={task?.description}
                            onChange={(e) => setTask({...task, description: e.target.value})}
                        />
                    </FormGroup>
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={() => {
                        if(!task) return;
                        props.submit(task)
                    }}>Submit</Button>{' '}
                    <Button color="secondary" onClick={props.toggle}>Cancel</Button>
                </ModalFooter>
            </Modal>
        </>
    )
}