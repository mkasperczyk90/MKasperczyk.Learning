import React from "react"

function Hero() {
    return (
        <selection className="hero">
            <img className="hero--photo" src={process.env.PUBLIC_URL + '/images/photo-grid.png'} />
            <h1 className="hero--header">Online Experiences</h1>
            <p className="hero--text">Join unique interactive activities led by one-of-a-kind hosts-all without leaving home.</p>
        </selection>
    )
}

export default Hero;