import React, { useState, useEffect } from 'react';

import classes from './ModelCard.module.css';

import RangeList from './RangeList';

const ModelCard = (props) => {
    const [isActive, setIsActive] = useState(false)
    const [isLoading, setIsLoading] = useState(false)
    const [vehicles, setVehicles] = useState([])

    useEffect(() => {

        if (isActive === false){
            return;
        }

        setIsLoading(true);
    
        fetch('https://localhost:7167/api/Vehicles/byModel/' + props.id.toString())
        .then(response => response.json())
        .then(data => {
            setVehicles(data)
            setIsLoading(false);
        });
      }, [props.id, isLoading.props, isActive])


    function UpdateVehicleStock(id, amount){
        console.log('in UpdateVehicleStock')
        console.log(amount)
        console.log(id)

        if (window.confirm('Are you sure you want to update the vehicle stock?')) {
            fetch('https://localhost:7167/api/Vehicles/stock/' , {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
                body: JSON.stringify({id: props.id, stockNumber: amount})
            })
            .then(response => response.json())
            .then(data => {
                setVehicles(data)
                setIsLoading(false);
                setIsActive(false);
            }).catch(error => {
                window.alert('an error occured')
            });
          } 
    }

  return (
    <React.Fragment>
        <li className={classes.model}>
            <div onClick={() => setIsActive(!isActive)}>
                <h2>{props.modelName}</h2> <br/> <h3 className={classes.accordianText}>{isActive ? "-" : "+"}</h3> 
            </div>
            {!isLoading && isActive && vehicles.length > 0 && <div><RangeList vehicleList={vehicles} UpdateVehicleStock={UpdateVehicleStock}/></div>}
            {isLoading && <p>loading...</p>}
        </li>
    </React.Fragment>
  );
};

export default ModelCard;
