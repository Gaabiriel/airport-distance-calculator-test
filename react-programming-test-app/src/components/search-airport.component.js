import React, { Component } from 'react';
import axios from 'axios';

export default class SearchAirport extends Component {
    constructor(props) {
        super(props);
        this.state = {
            firstAirportIata: '',
            secondAirportIata: '',
            distance: 0
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        var letters = /^[A-Za-z]+$/;
        if (value.match(letters)) {
            this.setState({
                [name]: value.toUpperCase()
            });
        }
        else {
            this.setState({
                [name]: ''
            });
        }
    }

    onSubmit(e) {
        e.preventDefault();

        axios.get("https://localhost:44305/api/airport/calculatedistance?firstIata=" + this.state.firstAirportIata + "&secondIata=" + this.state.secondAirportIata)
            .then(response => {
                console.log(response);
                this.setState({ distance: response.data })
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return (
            <div style={{ marginTop: 20 }}>
                <h3>Search airport</h3>
                <form onSubmit={this.onSubmit}>
                    <div className="form-group">

                        <label>From Airport</label>
                        <input type="text"
                            name="firstAirportIata"
                            className="form-control"
                            value={this.state.firstAirportIata}
                            onChange={this.handleInputChange}
                            maxLength="3"
                            required
                            style={{ width: "80px" }} />

                        <label>To Airport</label>
                        <input type="text"
                            name="secondAirportIata"
                            className="form-control"
                            value={this.state.secondAirportIata}
                            onChange={this.handleInputChange}
                            maxLength="3"
                            required
                            style={{ width: "80px" }} />

                    </div>
                    <div className="form-group">
                        <input type="submit" value="Calculate Distance" className="btn btn-primary" />
                    </div>
                </form>
                <div className="form-group">
                    <h3>The distance between {this.state.firstAirportIata} to {this.state.secondAirportIata} is {this.state.distance.toFixed(2)} miles</h3>
                </div>
            </div>
        )
    }
}