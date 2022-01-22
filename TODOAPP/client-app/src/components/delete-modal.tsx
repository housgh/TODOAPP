import React from "react";
import {Button, Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";

export function DeleteModal(props: {isOpen: boolean,toggle: () => void,onDelete: () => void}){
    return(
       <>
           <Modal isOpen={props.isOpen} toggle={props.toggle}>
               <ModalHeader toggle={props.toggle}>Delete?</ModalHeader>
               <ModalBody>
                   Are you sure you want to delete it?
               </ModalBody>
               <ModalFooter>
                   <Button color="danger" onClick={() => props.onDelete()}>Delete</Button>{' '}
                   <Button color="secondary" onClick={props.toggle}>Cancel</Button>
               </ModalFooter>
           </Modal>
       </> 
    );
}