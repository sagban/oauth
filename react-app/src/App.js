import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import GoogleLogin from 'react-google-login';
import FacebookLogin from 'react-facebook-login';

function App() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");

  const responseGoogle = response => {
    setName(response.profileObj.name);
    setEmail(response.profileObj.email);
    console.log(response);
  };
  const responseFacebook = (response) => {
    console.log(response);
    setEmail(response.email);
    setName(response.name);

  };
  const componentClicked = (data) => {

  };

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <div>
          <h1>User Details</h1>
          <h2>Welcome:{name}</h2>
          <h2>Email:{email}</h2>
          <GoogleLogin
            clientId="855429780668-oam01lrboj6ga6qm8ra1ccv632nimfd9.apps.googleusercontent.com"
            buttonText="Login"
            onSuccess={responseGoogle}
            onFailure={responseGoogle}
            cookiePolicy={'single_host_origin'}
          />
          <FacebookLogin
            appId="340051157443008"
            autoLoad={true}
            fields="name,email,picture"
            onClick={componentClicked}
            callback={responseFacebook}

          />

        </div>

      </header>

    </div>
  );
}

export default App;
