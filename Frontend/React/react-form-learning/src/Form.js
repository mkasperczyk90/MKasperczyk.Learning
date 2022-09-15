import React from "react"
import react from "react"

export default function Form() {
    const [formData, setFormData] = React.useState({
        firstName: "",
        lastName: "",
        email: "",
        comments: "",
        isFriendly: true,
        employment: "",
        favColor: ""
    })


    function handleChange(event) {
        const {name, value, type, checked} = event.target

        setFormData(prevFormData => {
            return { 
                ...prevFormData,
                [name]: type === "checkbox" ? checked : value
            }
        })
    }

    function handleSubmit(event) 
    {
        event.preventDefault()
        console.log(formData);
    }

    return (
        <form onSubmit={handleSubmit}>
            <input type="text"
                placeholder="FirstName"
                onChange={handleChange}
                name="firstName"
                value={formData.firstName}
                /><br />
            <input type="text"
                placeholder="Last Name"
                onChange={handleChange}
                name="lastName"
                value={formData.lastName}
                /><br />
            <input type="text"
                placeholder="Email"
                onChange={handleChange}
                name="email"
                value={formData.email}
                /><br />
            <textarea value={formData.comments} 
                    onChange={handleChange}
                    name="comments"
            /><br />
            <input type="checkbox"
                    id="isFriendly"
                    onChange={handleChange}
                    name="isFriendly"
                    checked={formData.isFriendly} />
            <label htmlFor="isFriendly">Are you friendly?</label><br />

            <fieldset>
                <legend>Current employment status</legend>

                <input  type="radio" id="unemployed" name="employment" value="unemployed" onChange={handleChange} checked={formData.employment === "unemployed"}/>
                <label htmlFor="unemployed">unemployed</label>

                <input  type="radio" id="part-time" name="employment" value="part-time" onChange={handleChange} checked={formData.employment === "part-time"}/>
                <label htmlFor="part-time">Part-time</label>

                <input  type="radio" id="full-time" name="employment" value="full-time" onChange={handleChange} checked={formData.employment === "full-time"}/>
                <label htmlFor="full-time">Full-time</label>
            </fieldset>

            <label htmlFor="favColor">What is your favorit color?</label>
            <br />
            <select id="favColor" value={formData.favColor} onChange={handleChange} name="favColor">    
                <option value="red">Red</option>
                <option value="green">Green</option>
                <option value="blue">Blue</option>
            </select><br /><br />
            <button>Submit</button>
        </form>
    )
}