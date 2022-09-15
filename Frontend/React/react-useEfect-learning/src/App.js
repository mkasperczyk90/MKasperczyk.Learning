import React from "react"
import './styles.css';

function App() {
  const [starWarsData, setStarWarsData] = React.useState({})
  const [count, setCount] = React.useState(1)

  React.useEffect(function() {
    fetch("https://swapi.dev/api/people/" + count)
      .then(res => res.json())
      .then(data => setStarWarsData(data))
  }, [count])

  function handleClick() {
    setCount(prevCount => ++prevCount)
  }

  return (
    <div className="App">
      <button onClick={handleClick}>Get Next Character</button>
      <pre>{JSON.stringify(starWarsData, null, 2)}</pre>
    </div>
  );
}

export default App;
