import { Dropdown } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Card, ListGroup, Button } from 'react-bootstrap';

function EmployeeList(props) {

    const [employeeList, setEmployeeList] = useState([]);

    useEffect(() => {
        if (props.selectedDepartment != null)
            fetch(`https://localhost:5001/api/Departments/${props.selectedDepartment.id}/Employees`)
                .then(reponse => reponse.json())
                .then(data => setEmployeeList(data));
    }, [props])

    const listItems = employeeList.map((employee) => {
        return <Dropdown.Item onClick={() => props.onEmployeeChange(employee)}>{employee.name}</Dropdown.Item>;
    });

    return (
        <>
            {
                listItems.length > 0 ? (
                    <Dropdown>
                        <Dropdown.Toggle variant="success" id="dropdown-basic">
                            {props.selectedEmployee ? props.selectedEmployee.name : 'Employees'}
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            {listItems}
                        </Dropdown.Menu>
                    </Dropdown>) : (
                    <Dropdown>
                        <Dropdown.Toggle disabled="true" variant="success" id="dropdown-basic">
                            Employees
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            {listItems}
                        </Dropdown.Menu>
                    </Dropdown>)
            }</>
    )
}

export default EmployeeList;