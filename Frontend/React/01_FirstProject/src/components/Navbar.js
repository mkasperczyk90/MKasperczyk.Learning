import React from "react"
import logo from "../images/logo-triathlon.png"
function Navbar() {
    return (
        <nav>
            <img className="nav--icon" src={logo} alt="logo"/>
            <h3 className="nav--logo_text">Triathlon Facts</h3>
            <h4 className="nav--title">Triathlon Competition 1</h4>
        </nav>
    )
}

export default Navbar;