import React from "react"

export default function Stats(props) {
    return (
        <div className="stats">
            <div>
                <span className="stats--howMany">Roll count: {props.rollNumber}</span>
            </div>
            <div className="stats">
                <span className="stats--howMany">Best roll count: {props.minRollNumber != null ? props.minRollNumber : 0}</span>
            </div>
        </div>
    )
}