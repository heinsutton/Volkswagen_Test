import React from 'react';

import FeatureCard from './FeatureCard';
import classes from './FeatureList.module.css';

const FeatureList = (props) => {
  return (
    <ul className={classes['feature-list']}>
      {props.features.map((feature) => (
        <FeatureCard
            key={feature.id}
            id={feature.id}
            name={feature.name}
        />
      ))}
    </ul>
  );
};

export default FeatureList;