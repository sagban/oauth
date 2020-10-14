import React, { Component } from 'react';
import { GoogleLogin, GoogleLogout } from 'react-google-login';


const CLIENT_ID = '167408661522-5k2u0mhcvo9s1r7dgj56na5k9tfpddjg.apps.googleusercontent.com';


class GoogleBtn extends Component {
   constructor(props) {
    super(props);

    this.state = {
      isLogined: false,
      accessToken: ''
    };

    // this.login = this.login.bind(this);
    // this.handleLoginFailure = this.handleLoginFailure.bind(this);
    // this.logout = this.logout.bind(this);
    //  this.handleLogoutFailure = this.handleLogoutFailure.bind(this);
     this.responseGoogle = this.responseGoogle.bind(this);
  }

  login (response) {
    if(response.accessToken){
      this.setState(state => ({
        isLogined: true,
        accessToken: response.accessToken
      }));
    }
  }

  logout (response) {
    this.setState(state => ({
      isLogined: false,
      accessToken: ''
    }));
  }

  responseGoogle(response) {
    console.log(response);
  }

  render() {
    return (
    <div>
      { this.state.isLogined ?
        <GoogleLogout
          clientId={ CLIENT_ID }
          buttonText='Logout'
          onLogoutSuccess={ this.responseGoogle }
          onFailure={ this.responseGoogle}
        >
        </GoogleLogout>: <GoogleLogin
          clientId={ CLIENT_ID }
          buttonText='Login'
          onSuccess={ this.responseGoogle }
          onFailure={ this.responseGoogle }
          cookiePolicy={ 'single_host_origin' }
          responseType='code,token'
        />
      }
      { this.state.accessToken ? <h5>Your Access Token: <br/><br/> { this.state.accessToken }</h5> : null }

    </div>
    )
  }
}

export default GoogleBtn;