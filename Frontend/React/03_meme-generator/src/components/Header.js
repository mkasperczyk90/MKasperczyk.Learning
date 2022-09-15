import React from "react"

function Header(){
    return(
        <header className="header">
            <img className="header--image" src={process.env.PUBLIC_URL + '/images/trollface.png'} />
            <h2 className="header--title">Meme Generator</h2>
            <h4 className="header--project">React Course Project 3</h4>
        </header>
    )
}

export default Header