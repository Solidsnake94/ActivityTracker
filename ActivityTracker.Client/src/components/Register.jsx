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

const Register = props => {
    return (
        <div>
            <NavTop />
            <Paper>
                <Typography type="headline" component="h3">
                    Register Form
                </Typography>
                <form className={props.container}>
                    <TextField
                        id="full-width"
                        label="Name"
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder="Enter name"
                        fullWidth
                        margin="normal"
                    />
                    <TextField
                        id="full-width"
                        label="Last Name"
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder="Enter last name"
                        fullWidth
                        margin="normal"
                    />
                    <TextField
                        id="full-width"
                        label="Date of Birth"
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder="dd/mm/yyyy"
                        fullWidth
                        margin="normal"
                    />
                    <TextField
                        id="full-width"
                        label="Email"
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder="Email"
                        fullWidth
                        margin="normal"
                    />
                    <TextField
                        id="full-width"
                        label="Password"
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder="Enter password"
                        type="password"
                        fullWidth
                        margin="normal"
                    />
                    <Button raised color="primary" className={props.button}>
                        Register
                    </Button>
                </form>
            </Paper>
        </div >

    );
};

export default Register;
