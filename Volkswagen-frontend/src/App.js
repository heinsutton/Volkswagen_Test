import React, {useState, useEffect} from 'react';

import './App.css';
import ModelList from './components/ModelList';

function App() {
  const [models, setModels] = useState([]);
  const [isLoading, setIsLoading] = useState(false);


  useEffect(() => {
    setIsLoading(true);

    fetch('https://localhost:7167/api/Models')
      .then(response => response.json())
      .then(data => {
        setModels(data)
        setIsLoading(false);
      });
  }, [isLoading.prop])

  return (
    <React.Fragment>
      <section>
        {!isLoading && models.length > 0 && <ModelList models={models} />}
        {!isLoading && models.length === 0 && <p>Found no models</p>}
        {isLoading && <p>loading...</p>}
      </section>
    </React.Fragment>
  );
}

export default App;



// return (
//   <React.Fragment>
//     <section>
//       <button onClick={fetchMoviesHandler}>Fetch Movies</button>
//     </section>
//     <section>
//       {!isLoading && movies.length > 0 && <MoviesList movies={movies} />}
//       {!isLoading && movies.length === 0 && <p>Found no movies</p>}
//       {isLoading && <p>loading...</p>}
//     </section>
//   </React.Fragment>
// );
