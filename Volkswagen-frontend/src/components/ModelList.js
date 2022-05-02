import React from 'react';

import ModelCard from './ModelCard';
import classes from './ModelList.module.css';

const ModelList = (props) => {
  return (
    <ul className={classes['model-list']}>
      {props.models.map((model) => (
        <ModelCard
            key={model.id}
            id={model.id}
            modelName={model.name}
        />
      ))}
    </ul>
  );
};

export default ModelList;