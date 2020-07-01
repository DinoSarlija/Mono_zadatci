import React from 'react';
import {Card,Button} from 'react-bootstrap';
import img1 from '../assets/slika1.jpg';
import img2 from '../assets/slika2.jpg';
import img3 from '../assets/slika3.jpg';

class card extends React.Component {
    render() {
      return(
        <div classsName="container-fluid d-flex justify-content-center">
            
            
            <div className="row">

                <div className="col-md-4">
                    <Card style={{ width: '18rem' }}>
                        <Card.Body>
                            <img src={img1} alt={'image1'} className="card-img-top"/>
                            <Card.Title>Studij 1</Card.Title>
                            <Card.Text>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            </Card.Text>
                            <Button variant="primary">Find more</Button>
                        </Card.Body>
                    </Card>
                </div>
                <div className="col-md-4">
                    <Card style={{ width: '18rem' }}>
                        <Card.Body>
                            <img src={img2} alt={'image2'} className="card-img-top"/>
                            <Card.Title>Studij 2</Card.Title>
                            <Card.Text>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            </Card.Text>
                        <Button variant="primary">Find more</Button>
                    </Card.Body>
                    </Card>
                </div>
                <div className="col-md-4">
                    <Card style={{ width: '18rem' }}>
                        <Card.Body>
                        <img src={img3} alt={'image3'} className="card-img-top"/>
                            <Card.Title>Studij 3</Card.Title>
                            <Card.Text>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            </Card.Text>
                        <Button variant="primary">Find more</Button>
                    </Card.Body>
                    </Card>
                </div>
            </div>
            
        </div>
      );
    }
}
export default card;