import * as React from 'react'
import Browser from './Browser';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';
import { Document } from 'react-pdf'

interface WorkSpaceProps {
    accessLevel: number,
    content: string
}
 
interface WorkSpaceState {
    accessLevel: number,
    content: string
}
 
class WorkSpace extends React.Component<WorkSpaceProps,WorkSpaceState> {
    constructor(props : WorkSpaceProps)
    {
        super(props);
    }
    state : WorkSpaceState = {
        accessLevel: this.props.accessLevel,
        content : this.props.content
    }

    renderSwitch() {
        switch (this.props.content) {
          case "login":
            return (
                <div className='d-grid' id='workspace'>
                    <LoginForm />
                </div>
            )

          case "register":
            return (
                <div className='container-fluid flex-fill' id='workspace'>
                    <RegisterForm />
                </div>
            )

          case "browser":
            if(this.props.accessLevel < 2)
            {
                return (
                    <div className='container-fluid flex-fill' id='workspace'>
                        <LoginForm />
                    </div>
                )
            }
            else return (
                <div className='container-fluid flex-fill' id='workspace'>
                    <Browser />
                </div>
            )

            case "legal":
                return (
                  <div className="container-fluid flex-fill" id="workspace">
                    <Document file={'https://drive.google.com/file/d/154KurjMq6AWFqbjxID1xBnrXTK6jTlVl/view?usp=sharing'} />
                  </div>
                );

          default:
            return (
              <div className="container-fluid flex-fill" id="workspace">
                <div className="modal" tabIndex={-1} role="dialog">
                  <div className="modal-dialog" role="document">
                    <div className="modal-content">
                      <div className="modal-header">
                        <h5 className="modal-title">Modal title</h5>
                        <button
                          type="button"
                          className="close"
                          data-dismiss="modal"
                          aria-label="Close"
                        >
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div className="modal-body">
                        <p>Modal body text goes here.</p>
                      </div>
                      <div className="modal-footer">
                        <button type="button" className="btn btn-primary">
                          Save changes
                        </button>
                        <button
                          type="button"
                          className="btn btn-secondary"
                          data-dismiss="modal"
                        >
                          Close
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              
            );
        }
    }

    render() { 
        return this.renderSwitch();
    }
}
 
export default WorkSpace;