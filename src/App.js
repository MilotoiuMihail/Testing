import './App.css';
import Button from 'react-bootstrap/Button';
import Dropdown from 'react-bootstrap/Dropdown';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Nav from 'react-bootstrap/Nav';
import Container from 'react-bootstrap/Container';
import GameList from './containers/GameList';
import 'bootstrap/dist/css/bootstrap.min.css';
import DepartmentList from './containers/DepartmentList';
import EmployeeList from './containers/EmployeeList';
import { useState } from 'react';
import InventoryList from './containers/InventoryList';


function App() {
  const [currentDepartment, setCurrentDepartment] = useState(null)
  const [currentEmployee, setCurrentEmployee] = useState(null)
  const [added, setAdded] = useState(0);
  return (
    <div className="App">
      <GameList selectedDepartment={currentDepartment} selectedEmployee={currentEmployee} onInventoryChange={handleInventoryChange} />
      <DepartmentList selectedDepartment={currentDepartment} onDepartmentChange={handleDepartmentChange} />
      <EmployeeList selectedDepartment={currentDepartment} selectedEmployee={currentEmployee} onEmployeeChange={handleEmployeeChange} />
      <InventoryList added={added} selectedDepartment={currentDepartment} selectedEmployee={currentEmployee} />
    </div>
  );

  function handleDepartmentChange(department) {
    setCurrentDepartment(department);
  }
  function handleEmployeeChange(employee) {
    setCurrentEmployee(employee);
  }
  function handleInventoryChange() {
    setAdded(added+1);
  }
}

export default App;
