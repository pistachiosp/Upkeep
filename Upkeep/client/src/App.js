import React, { useEffect, useState } from "react";
import { BrowserRouter as Router } from "react-router-dom";
import { Spinner } from "reactstrap";
import { onLoginStatusChange, getUserDetails } from "./modules/authManager";
import firebase from "firebase";
import Header from "./components/user/Header";
import ApplicationViews from "./components/user/ApplicationViews";


function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(null),
    [role, setRole] = useState("");

  useEffect(() => {
    onLoginStatusChange(setIsLoggedIn);
  }, []);

  useEffect(() => {
    if (isLoggedIn) {
      // firebase.auth().currentUser.uid grabs the firebaseUID -- firebase has many helpers like this
      getUserDetails(firebase.auth().currentUser.uid).then((userObject) => {
        setRole(userObject.userType.name);
      });
    } else {
      setRole("");
    }
  }, [isLoggedIn]);

  if (isLoggedIn === null) {
    return <Spinner className="app-spinner dark" />;
  }

  return (
    <Router>
      <Header isLoggedIn={isLoggedIn} role={role} />
      <ApplicationViews isLoggedIn={isLoggedIn} role={role} />
    </Router>
  );
}

export default App;