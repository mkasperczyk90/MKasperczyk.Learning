import React from "react"

function Meme() {

    const [allMemes, setAllMemes] = React.useState([]);

    const [meme, setMeme] = React.useState({
        topText: "",
        bottomText: "",
        randomImage: "https://i.imgflip.com/23ls.jpg"
    })

    React.useEffect(() => {
        async function getMemes() {
            const res = await fetch("https://api.imgflip.com/get_memes")
            const data = await res.json()
            setAllMemes(data.data.memes)
        }
        getMemes()
    }, [])

    function getMemeImage() {
        const randomNumber = Math.floor(Math.random() * allMemes.length)
        const url = allMemes[randomNumber].url
        setMeme(prevMeme => ({
            ...prevMeme,
            randomImage: url
        }))
    }

    function handleChange(event) {
        const {name, value} = event.target

        setMeme(prevMeme => ({
            ...prevMeme,
            [name]: value
        }))
    }

    return (
        <main >
            <div className="form">
                <input className="form--inputs" 
                        placeholder="Test"
                        type="text"
                        name="topText"
                        value={meme.topText}
                        onChange={handleChange}
                        />
                <input className="form--inputs" 
                        placeholder="Test"
                        type="text"
                        name="bottomText"
                        value={meme.bottomText}
                        onChange={handleChange}/>
                <button className="form--button" onClick={getMemeImage}>Get a new meme image </button>
            </div>
            <div className="meme">
                <img src= {meme.randomImage} className="meme--image" />
                <h2 className="meme--text top">{meme.topText}</h2>
                <h2 className="meme--text bottom">{meme.bottomText}</h2>
            </div>
        </main>
    )
}

export default Meme