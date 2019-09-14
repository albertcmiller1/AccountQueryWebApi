import React, { Component } from "react";
import {
    Dropdown,
    DropdownToggle,
    DropdownMenu,
    DropdownItem,
    InputGroup,
    InputGroupText,
    InputGroupAddon,
    Input,
    Label,
    FormGroup,
    Button,
    Table
} from "reactstrap";

export class Home extends Component {
    constructor(props) {
        super(props);

        this.state = {
            dropdownOpen: false,
            GotData: [],
            SentData: [],
            TypeUI: "",
            FromDateUI: "",
            ToDateUI: "",
            DescriptionUI: "",
            FromCheckUI: "",
            ToCheckUI: "",
            FromAmountUI: "",
            ToAmountUI: ""
        };

        fetch("api/PUT/sendToFilter", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(d => {
                return d.json();
            })
            .then(data => {
                this.setState({ GotData: data });
                console.log("initial Data: ", data);
            })
            .catch(function () {
                console.log("error");
            });

        this.toggle = this.toggle.bind(this);
        this.TypeSubmit = this.TypeSubmit.bind(this);
        this.FromDateSubmit = this.FromDateSubmit.bind(this);
        this.ToDateSubmit = this.ToDateSubmit.bind(this);
        this.DescriptionSubmit = this.DescriptionSubmit.bind(this);
        this.FromCheckSubmit = this.FromCheckSubmit.bind(this);
        this.ToCheckSubmit = this.ToCheckSubmit.bind(this);
        this.FromAmountSubmit = this.FromAmountSubmit.bind(this);
        this.ToAmountSubmit = this.ToAmountSubmit.bind(this);
        this.postInstructions = this.postInstructions.bind(this);
        this.clearSubmit = this.clearSubmit.bind(this);
    }

    TypeSubmit(e) {
        this.setState({ TypeUI: e });
    }

    FromDateSubmit(e) {
        console.log("from date: ", e.target.value);
        this.setState({ FromDateUI: e.target.value });
    }

    ToDateSubmit(e) {
        console.log("to date: ", e.target.value);
        this.setState({ ToDateUI: e.target.value });
    }

    DescriptionSubmit(e) {
        this.setState({ DescriptionUI: e.target.value });
    }

    FromCheckSubmit(e) {
        this.setState({ FromCheckUI: e.target.value });
    }

    ToCheckSubmit(e) {
        this.setState({ ToCheckUI: e.target.value });
    }

    FromAmountSubmit(e) {
        this.setState({ FromAmountUI: e.target.value });
    }

    ToAmountSubmit(e) {
        this.setState({ ToAmountUI: e.target.value });
    }

    //FromAmountSubmit(field, e) {
    //    this.setState({ [field]: e.target.value });
    //}

    clearSubmit() {
        this.setState({
            TypeUI: "",
            FromDateUI: "",
            ToDateUI: "",
            DescriptionUI: "",
            FromCheckUI: "",
            ToCheckUI: "",
            FromAmountUI: "",
            ToAmountUI: ""
        });
        this.postInstructions();
        console.log("poop");
    }

    postInstructions() {
        const PutURL = "api/PUT/sendToFilter";

        fetch(PutURL, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                ToDate: this.state.ToDateUI,
                Description: this.state.DescriptionUI,
                TransactionType: this.state.TypeUI,
                FromDate: this.state.FromDateUI,
                FromCheckNumber: this.state.FromCheckUI,
                ToCheckNumber: this.state.ToCheckUI,
                FromAmount: this.state.FromAmountUI,
                ToAmount: this.state.ToAmountUI
            })
        })
            .then(r => {
                return r.json();
            })
            .then(r2 => {
                this.setState({ GotData: r2 });
                console.log("Data sent back from APi: ", r2);
            })
            .catch(function () {
                console.log("error");
            });
    }

    toggle() {
        this.setState(prevState => ({
            dropdownOpen: !prevState.dropdownOpen
        }));
    }

    TypeOptions = ["Card", "Check", "Payment", "Reimbursement", "Transfer"];

    render() {
        return (
            <div>
                <h1>Filter Transactions</h1>
                <h3>Select Transaction Type</h3>
                <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggle}>
                    <DropdownToggle caret>Transaction Type</DropdownToggle>
                    <DropdownMenu>
                        {this.TypeOptions.map(p => (
                            <DropdownItem key={p} onClick={() => this.TypeSubmit(p)}>
                                {p}
                            </DropdownItem>
                        ))}
                    </DropdownMenu>
                </Dropdown>
                <br />
                <h3>Select Time Period</h3>
                <FormGroup>
                    <Label for="exampleDate">From Date</Label>
                    <Input
                        type="date"
                        name="date"
                        id="exampleDate"
                        placeholder="date placeholder"
                        onChange={this.FromDateSubmit}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="exampleDate">To Date</Label>
                    <Input
                        type="date"
                        name="date"
                        id="exampleDate"
                        placeholder="date placeholder"
                        onChange={this.ToDateSubmit}
                    />
                </FormGroup>
                <br />
                <h3>Search by Key Words</h3>
                <InputGroup>
                    <InputGroupAddon addonType="prepend">
                        <InputGroupText>Enter Description</InputGroupText>
                    </InputGroupAddon>
                    <Input onChange={this.DescriptionSubmit} />
                </InputGroup>
                <br />
                <h3>Search by Range of Check Numbers</h3>
                <div>
                    From Check Number
          <InputGroup>
                        <InputGroupAddon addonType="prepend">
                            <InputGroupText>Enter</InputGroupText>
                        </InputGroupAddon>
                        <Input onChange={this.FromCheckSubmit} />
                    </InputGroup>
                    To Check Number
          <InputGroup>
                        <InputGroupAddon addonType="prepend">
                            <InputGroupText>Enter</InputGroupText>
                        </InputGroupAddon>
                        <Input onChange={this.ToCheckSubmit} />
                    </InputGroup>
                </div>
                <br />
                <h3>Search by Range of Amounts</h3>
                <div>
                    From Amount (most negative first)
          <InputGroup>
                        <InputGroupAddon addonType="prepend">
                            <InputGroupText>Enter</InputGroupText>
                        </InputGroupAddon>
                        <Input onChange={this.FromAmountSubmit} />
                    </InputGroup>
                    To Amount
          <InputGroup>
                        <InputGroupAddon addonType="prepend">
                            <InputGroupText>Enter</InputGroupText>
                        </InputGroupAddon>
                        <Input onChange={this.ToAmountSubmit} />
                    </InputGroup>
                </div>
                <br />
                <Button
                    outline
                    color="success"
                    size="lg"
                    onClick={this.postInstructions.bind(this)}
                >
                    Submit
        </Button>
                <Button
                    outline
                    color="danger"
                    size="lg"
                    onClick={this.clearSubmit.bind(this)}
                >
                    Clear
        </Button>
                <br />
                <br />
                <h2>Transactions</h2>

                <Table striped>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Description</th>
                            <th>Check Number</th>
                            <th>Amount</th>
                            <th>Balance</th>
                            <th>Transaction Type</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.GotData.map(transaction => (
                            <tr key={transaction.balance}>
                                <td>{transaction.date}</td>
                                <td>{transaction.description}</td>
                                <td>{transaction.checkNumber}</td>
                                <td>{transaction.amount}</td>
                                <td>{transaction.balance}</td>
                                <td>{transaction.transactionType}</td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
                <br />
                <br />
                <br />
                <br />
            </div>
        );
    }
}