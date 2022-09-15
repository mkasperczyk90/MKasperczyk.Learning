import React from "react"

function Navbar() {
    return(
        <nav>
            <img className="navbar--logo" src={process.env.PUBLIC_URL + '/images/airbnb.png'}></img>
        </nav>
    )
}

export default Navbar;