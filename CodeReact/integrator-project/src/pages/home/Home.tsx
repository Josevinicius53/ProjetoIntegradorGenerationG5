import React from "react";
import { Link } from 'react-router-dom';
import { Typography, Box, Grid, Button, AppBar } from '@material-ui/core';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import "./Home.css";
import MenuSidebar from "../../Components/statics/menuSidebar/MenuSidebar";


function Home() {
    return (
        <>
            <Grid item xs={12} style={{
                background: `url(https://i.imgur.com/9ayuO27.jpg)`,
                backgroundRepeat: 'no-repeat', width: '100%', height: '100vh', backgroundSize: 'cover'
            }}>
<<<<<<< HEAD
                <div className="navbarmenu">
                    <MenuSidebar />
                    <div className="navbarbutton">
                        <Link to='/login'>
                            <button className="distancia">Login</button>
                        </Link>
                    </div>
                    
                        <Link to='/Cadastro'>
                            <button>Cadastre-se</button>
                        </Link>
                    
                </div>
=======
                <AppBar position="sticky" style={{ background: 'transparent', boxShadow: 'none'}}>
                    <div className="navbarmenu">
                        <MenuSidebar />
                        <div className="navbarbutton">
                            <Link to='/login'>
                                <button> Login</button>
                            </Link>
                            <Link to='/Cadastro'>
                                <button>Cadastre-se</button>
                            </Link>
                        </div>
                    </div>
                </AppBar>
>>>>>>> 29657257eb51f1d60ae793a22d01fbcb1a29951d
                <div>
                    <img className="logo" src="https://imgur.com/fqAed38.png" alt="" width="250" />
                </div>
            </Grid>
        </>
    );
}
export default Home;