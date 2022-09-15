import React from "react"

function Card(props) {
    let badgeText
    if(props.openSpots === 0) {
        badgeText = "SOLD OUT"
    } else if(props.location === "Online"){
        badgeText = "ONLINE"
    }
    return (
        <div className="card">
            {badgeText && <div className="card--badge">{badgeText}</div>} 
            <img src={process.env.PUBLIC_URL + "/images/" + props.img} className="card--image" />
            <div className="card--stats">
                <img src={process.env.PUBLIC_URL + '/images/star.png'} className="card--star" />
                <span>{props.rating}</span>
                <span className="grey">({props.reviewCount}) . </span>
                <span className="grey">{props.country}</span>
            </div>
            <p><span className="card--title">{props.title}</span></p>
            <p><span className="card--price bold">From ${props.price} </span>/ Person</p>
        </div>
    )
}

export default Card;