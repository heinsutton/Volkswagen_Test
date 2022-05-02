import React from 'react';

import RangeCard from './RangeCard';
import classes from './RangeList.module.css';

const RangeList = (props) => {

  console.log('rangelist props')
  console.log(props)

  return (
    <ul className={classes['range-list']}>
      {props.vehicleList.map((vehicle) => (
        <RangeCard
            key={vehicle.id}
            id={vehicle.id}
            vehicleName={vehicle.rangeName}
            stockAmount={vehicle.stockAmount}
            price={vehicle.price}
            UpdateVehicleStock={props.UpdateVehicleStock}
        />
      ))}
    </ul>
  );
};

export default RangeList;