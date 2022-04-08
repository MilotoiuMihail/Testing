import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Card, ListGroup } from 'react-bootstrap';

function InventoryList(props) {

    
    const [inventoryList, setInventoryList] = useState([]);
    
    useEffect(() => {
        if (props.selectedDepartment != null && props.selectedEmployee != null)
            fetch(`https://localhost:5001/api/Departments/${props.selectedDepartment.id}/Employees/${props.selectedEmployee.id}/EmployeeGames`)
                .then(reponse => reponse.json())
                .then(data => setInventoryList(data));
    }, [props])

    const listItems = inventoryList.map((inventory, index) => {
        console.log('caca',inventory);
        return <ListGroup.Item key={index}>{inventory.name} {inventory.borrowDate.slice(0, 10)}
            <Button variant="danger" onClick={() => fetch(`https://localhost:5001/api/departments/${props.selectedDepartment.id}/employees/${props.selectedEmployee.id}/EmployeeGames/${inventory.gameId}`, { method: 'DELETE' })
            .then(()=>setInventoryList(inventoryList.filter((i,ind)=> ind!==index)))}>Remove</Button>
        </ListGroup.Item>;
    });


    return (
        <Card style={{ width: '18rem', marginTop: '50px' }}>
            <Card.Header>Game List</Card.Header>
            {inventoryList.length != 0 ? (
                <ListGroup variant="flush">
                    {listItems}
                </ListGroup>) :
                (<ListGroup variant="flush">
                    <ListGroup.Item>Empty</ListGroup.Item>
                </ListGroup>)}
        </Card>
    )
}

export default InventoryList;