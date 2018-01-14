import React from "react";
import AppBar from "material-ui/AppBar";
import Toolbar from "material-ui/Toolbar";
import Typography from "material-ui/Typography";
import { withStyles } from "material-ui/styles";
import TextField from "material-ui/TextField";
import { FormGroup, FormControlLabel } from "material-ui/Form";
import Checkbox from "material-ui/Checkbox";
import Paper from "material-ui/Paper";
import Button from "material-ui/Button";
import NavTop from "./DashboardNavTop";

class Login extends React.Component {

    constructor(props) {
        super(props);
        

        this.state = {
            username: "",
            password: ""
        }

        this.onChange = this.onChange.bind(this);
    }
    

    // loginUser(event) {
    //   event.preventDefault();
    //   this.props.actions
    //     .registerUser(this.state.user)
    //     .then(() => this.props.history.push("/registerSuccess"));
    // }

    login(event) {
        event.preventDefault();
        let user = {
            username: this.state.username,
            password: this.state.password
        }

        this.props.actions.loginUser(user).then(() => this.props.history.push("/dashboard"));
    }
  
    onChange(event) {
      const target = event.target;
      const name = target.name;
      const value = target.value;
  
      this.setState({
        [name] : value
      });
    }

    render(){
        return (
            <div>
                <NavTop />
                <Paper>
                    <Typography type="headline" component="h3">
                        Login
                </Typography>
                    <form className={this.props.container}>
                        <TextField
                            id="full-width"
                            label="Email"
                            InputLabelProps={{
                                shrink: true,
                            }}
                            placeholder="Enter your email"
                            fullWidth
                            margin="normal"
                            name = "username"
                        />
                        <TextField
                            id="full-width"
                            label="Password"
                            InputLabelProps={{
                                shrink: true,
                            }}
                            placeholder="Enter your password"
                            fullWidth
                            margin="normal"
                            name = "password"
                        />
                        <Button raised color="primary" className={this.props.button}>
                            Login
                    </Button>
                    </form>
                </Paper>
            </div>

        );
    }
};

export default Login;
