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

    constructor(props){
        super(props);
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
