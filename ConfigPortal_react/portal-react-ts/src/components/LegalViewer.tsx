import { stringify } from 'querystring';
import * as React from 'react';
import { useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
import { Document, Page  } from 'react-pdf'
import { JsxElement } from 'typescript';

interface LegalViewerProps {
    consentGiven: boolean
}
 
interface LegalViewerState {
    consentGiven: boolean
}
 
class LegalViewer extends React.Component<LegalViewerProps, LegalViewerState> {
    constructor(props: LegalViewerProps) {
        super(props);
        this.state = {consentGiven: props.consentGiven };
    };
    render() {
        //let vh = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
        //let vw = Math.max(document.documentElement.clientWidth, window.innerWidth || 0);
        //let staticHeight = (vh*0.8).toString() + "px";
        return (
          <div className="modal align-content-stretch" id="consent-modal" tabIndex={-1} role="dialog" align-content="center"> 
            <div className='' role="document">
              <div className="modal-content d-flex justify-content-center col-md-12" align-content="center">
                <div className="modal-header justify-content-center">
                  <h5 className="modal-title justify-content-center">Terms of service</h5>
                  <button
                    type="button"
                    className="close"
                    data-dismiss="modal"
                    aria-label="Close"
                  >
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div className="modal-body col-md-12 justify-content-center" align-content={"center"} >
                    <object className="col-md-12 justify-content-center" align-content={"center"} data='https://www.fleetster.net/legal/standard-terms-and-conditions.pdf' type='application/pdf'>
                        <iframe src="https://docs.google.com/viewer?https://www.fleetster.net/legal/standard-terms-and-conditions.pdf&embedded=true"/>
                    </object>
                </div>
                <div className="modal-footer">
                  <button
                    type="button"
                    className="btn btn-primary"
                    data-dismiss="modal"
                    onClick={() => {
                      let checkbox = document.getElementById("register-consent");
                      if (!(checkbox as HTMLInputElement)?.checked) {
                        checkbox?.click();
                      }
                    }}
                  >
                    I Agree
                  </button>
                </div>
              </div>
            </div>
          </div>
        );
    }
}
 
export default LegalViewer;