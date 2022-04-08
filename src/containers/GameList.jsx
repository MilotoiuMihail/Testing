import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Card, ListGroup } from 'react-bootstrap';

function GameList(props) {
    const [gameList, setGameList] = useState([]);

    useEffect(() => {
        fetch("https://localhost:5001/api/Games")
            .then(reponse => reponse.json())
            .then(data => setGameList(data));
    }, [props])

    const listItems = gameList.map((game, index) => {
        if (props.selectedEmployee != null) {
            var requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    employeeId: props.selectedEmployee.id,
                    gameId: game.id,
                    borrowDate: new Date()
                })
            };
        }
        return <ListGroup.Item key={index}>{game.name} - Release date: <strong>{game.releaseDate.slice(0, 10)}</strong>
            <Button variant="success"
                onClick={() => fetch(`https://localhost:5001/api/departments/${props.selectedDepartment.id}/employees/${props.selectedEmployee.id}/EmployeeGames`
                    , requestOptions)
                    .then(() => props.onInventoryChange())
                }>Rent</Button>
        </ListGroup.Item>;
    });

    if (gameList.length === 0) {
        return <div>No products :( </div>;
    }

    return (
        <Card style={{ width: '18rem', marginTop: '50px' }}>
            <Card.Header>Game List</Card.Header>
            <ListGroup variant="flush">
                {listItems}
            </ListGroup>
        </Card>
    )
}

export default GameList;