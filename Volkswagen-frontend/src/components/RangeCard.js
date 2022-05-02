import React, { useState, useEffect } from 'react';

import classes from './RangeCard.module.css';

import FeatureList from './FeaturesList';

const RangeCard = (props) => {
    const [isActive, setIsActive] = useState(false)
    const [isLoading, setIsLoading] = useState(false)
    const [features, setFeatures] = useState([])
    const [value, setValue] = useState(0);
    const handleChange = (e) => setValue(e.target.value);

    useEffect(() => {

        if (isActive === false){
            return;
        }

        setIsLoading(true);
    
        fetch('https://localhost:7167/api/Features/vehicle/' + props.id.toString())
            .then(response => response.json())
            .then(data => {
                setFeatures(data)
                setIsLoading(false);
            })
    }, [props.id, isLoading.props, isActive])

    return (
        <li className={classes.rangeCard}>
            <div>
                <h3>Range name: {props.vehicleName}</h3>
                <h3>Price: R {props.price}</h3>
                <h3>Stock amount: {props.stockAmount}</h3>
                <div className={classes.center}>
                    <p>new stock amount: </p><input type='number' name="stockAmountBox" onChange={handleChange} className={classes.input}/>
                    <button onClick={() => props.UpdateVehicleStock(props.id, value)}>Update stock</button>
                    <br/>
                    <button onClick={() => props.UpdateVehicleStock(props.id, 0)}>Mark car sold</button>
                </div>
            </div>
            <div onClick={() => setIsActive(!isActive)}>
                <h3 className={classes.featureList} >Features {isActive ? "-" : "+"}</h3>
            </div>
            {isActive && <div className="accordion-content"><FeatureList features={features}/></div>}
        </li>
    );
};

export default RangeCard;
