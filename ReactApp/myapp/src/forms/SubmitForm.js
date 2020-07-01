import React from 'react';
import {Card,Form,Button} from 'react-bootstrap';

class SubmitForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            studij:'',//:'Here goes name of Vrste studija',
            trajanje_studija:0
        };
    
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
      }
    
      handleChange(event) {
        if(isNaN(event.target.value))
        {        
            this.setState({studij: event.target.value});
        }
        else
        {
            this.setState({trajanje_studija: event.target.value});
        }
      }
    
      handleSubmit(event) {
        if(this.state.studij !== '' & this.state.trajanje_studija !== 0) {
            alert('Vrsta studija was submitted: ' + this.state.studij + ' with duration of ' + this.state.trajanje_studija + "years.");
            this.refs.form.reset()
            event.preventDefault();
        }
        alert('Field `Studij` or multiple select `Trajanje studija` is not entered correctly ');
        
        
      }

      handleReset() {
        this.refs.form.reset();
      }

    render() {
      return (
        <Card>
            <Card.Body>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="exampleForm.ControlInput1">
                        <Form.Label>Studij</Form.Label>
                        <Form.Control type="vrsta_studija" placeholder="Prediplomski studij Matematike i računarstva" onChange={this.handleChange}/>
                    </Form.Group>
                    <Form.Group controlId="exampleForm.ControlSelect1">
                        <Form.Label>Trajanje studija</Form.Label>
                        <Form.Control as="select" onChange={this.handleChange} placeholder="Number of years">
                            <option>0</option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                        </Form.Control>
                    </Form.Group>
                    
                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </Card.Body>
        </Card>
      );
    }
  }
export default SubmitForm;






