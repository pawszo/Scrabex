import React from 'react';
import "./Toggle";
import { Navbar, Nav, NavItem, NavProps, Button } from 'react-bootstrap';
import useToggle from './Toggle';

interface ToolBoxProps {
    id: number,
    login: string
}
 
interface ToolBoxState {
    expanded: boolean
}
 
class ToolBox extends React.Component<ToolBoxProps, ToolBoxState> {
    constructor(props: ToolBoxProps)
    {
        super(props);
    };

    state : ToolBoxState = {
        expanded: false
    };

    onClick = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>): void => {
        let newExpanded = !this.state.expanded;
        this.setState({ expanded: newExpanded});
      };

    render() {
        return (
          <div id="toolbox">
            <div className="pos-f-t">
              <div
                className={this.state.expanded ? "expanded" : "collapse"}
                id="navbarToggleExternalContent"
              >
                <div className="container-fluid">
                  <div className='row align-items-center' data-toggle="buttons">
                    <div className="col-4 align-items-center">
                      <div
                        className="btn-group btn-group-toggle mt-1 mb-1"
                        data-toggle="buttons"
                      >
                        <label className="btn btn-secondary active">
                          <input
                            type="radio"
                            name="options"
                            id="option1"
                            autoComplete="off"
                            checked
                          />{" "}
                          Account
                        </label>
                        <label className="btn btn-secondary">
                          <input
                            type="radio"
                            name="options"
                            id="option2"
                            autoComplete="off"
                          />{" "}
                          Scenarios
                        </label>
                        <label className="btn btn-secondary">
                          <input
                            type="radio"
                            name="options"
                            id="option3"
                            autoComplete="off"
                          />{" "}
                          Stats
                        </label>
                      </div>
                    </div>
                    <div className="col-7">
                        
                    </div>
                    <div className="col-1">
                      <button type="button" className="btn btn-outline-primary">
                        Log out
                      </button>
                    </div>
                  </div>
                </div>
              </div>

              <nav className="navbar navbar-dark bg-dark">
                <button
                  className="navbar-toggler"
                  type="button"
                  aria-expanded={this.state.expanded}
                  onClick={this.onClick}
                >
                  <span className="navbar-toggler-icon"></span>
                </button>
              </nav>
            </div>
          </div>
        );
    }
}
 
export default ToolBox;