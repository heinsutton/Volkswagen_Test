import React, { useState} from 'react';

import classes from './FeatureCard.module.css';

const FeatureCard = (props) => {
  return (
    <li className={classes.featureCard}>    
        <div>
          <h3>{props.name}</h3>
        </div>
    </li>
  );
};

export default FeatureCard;
