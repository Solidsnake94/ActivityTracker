import React from 'react';
import NavTop from "./DashboardNavTop";
import Paper from "material-ui/Paper";
import Button from "material-ui/Button"
import Typography from "material-ui/Typography";

const RegisterSuccess = (props) => {

  const login = e => {
    props.history.push("/login");
  };

  return (
    <div>
       <NavTop />
      <Paper>
        <Typography type="headline" component="h3">
              You have been successfully registered
         </Typography>
         <Typography type="headline" component="h3">
              To login please <a onClick={login}>here </a>
         </Typography>

      </Paper>
    </div>
  );
};

export default RegisterSuccess;