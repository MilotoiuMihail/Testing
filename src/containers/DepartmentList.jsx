import { Dropdown } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import {Card, ListGroup} from 'react-bootstrap';
import EmployeeList from './EmployeeList';

function DepartmentList(props) {

    const [departmentList, setDepartmentList] = useState([]);

       useEffect(() => {
        fetch("https://localhost:5001/api/Departments")
        .then(reponse => reponse.json())
        .then(data => setDepartmentList(data));
    }, [props.selectedDepartment])

        const listItems = departmentList.map((department) => {
            return <Dropdown.Item onClick={()=>props.onDepartmentChange(department)}>{department.name}</Dropdown.Item>;
    });

    
    if (departmentList.length === 0) {
        return <div>No products :( </div>;
    }

    return (
    <Dropdown>
  <Dropdown.Toggle variant="success" id="dropdown-basic">
    {props.selectedDepartment?props.selectedDepartment.name:'Departments'}
  </Dropdown.Toggle>

  <Dropdown.Menu>
    {listItems}
  </Dropdown.Menu>
</Dropdown>
    )
}

export default DepartmentList;