import React from 'react'
import Die from './components/Die'
import {nanoid} from "nanoid"
import Confetti from "react-confetti"
import Stats from "./components/Stats"

function App() {
  const [dice, setDice] = React.useState(allNewDice())
  const [tenzies, setTenzies] = React.useState(false)
  const [rollNumber, setRollNumber] = React.useState(0)
  const [minRollNumber, setMinRollNumber] = React.useState(localStorage.getItem('minRollNumber'))

  React.useEffect(() => {
    let allHeld = dice.every(die => die.isHeld)
    const firstValue = dice[0].value
    const allSameValue = dice.every(die => die.value === firstValue)

    if(allHeld && allSameValue) {
      if(minRollNumber == null || rollNumber < minRollNumber){
        localStorage.setItem('minRollNumber', rollNumber);
        setMinRollNumber(rollNumber)
      }
      setTenzies(true)
    }

  }, [dice])

  function generateNewDie() {
    return {
      value: Math.ceil(Math.random() * 6),
      isHeld: false,
      id: nanoid()
    }
  }

  function allNewDice() {
    let newDice = []
    for(let i = 0; i < 10; i++) {
      newDice.push(generateNewDie())
    }
    return newDice
  }

  function rollDice(){
    setRollNumber(prevValue => prevValue + 1)
    setDice(oldDice => oldDice.map(die => {
      return die.isHeld ? 
        die : 
        generateNewDie()
    }))
  }

  function newGame(){
    setTenzies(false)
    setDice(allNewDice())
    setRollNumber(0)
  }

  function holdDice(id) {
    setDice(prevDice => prevDice.map(die => {
      return die.id === id ? {...die, isHeld: !die.isHeld} : die
    }))
  }

  const diceElements = dice.map(die => <Die value={die.value} key={die.id} isHeld={die.isHeld} holdDice={() => holdDice(die.id)} />)

  return (
    <main>
      {tenzies && <Confetti />}
      <Stats rollNumber={rollNumber} minRollNumber={minRollNumber}/>
      <h1 className="title">Tenzies</h1>
      <p className="instructions">
        Roll until all dice are the same.
      </p>
      <div className="dice-container">
          {diceElements}
      </div>
      
      {tenzies && <button className="roll-dice" onClick={newGame}>New Game</button>}
      {!tenzies && <button className="roll-dice" onClick={rollDice}>Roll</button>}
  </main>
  );
}

export default App;
