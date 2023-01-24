import React from "react";
import './LoginForm.css';
import { useRef } from 'react'

const LoginForm = (props) => {
	const name = useRef();
	const password = useRef();

	const handleSubmit = (event) => {
		event.preventDefault();

		if (!name.current.value || !password.current.value) {
			alert('Name and password are both required');
			return;
        }

		props.onSubmit({
			login: name.current.value,
			password: password.current.value,
		});
	}

	return (
		<form className="form">
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" id="name" ref={name} />
			<label htmlFor="password">Password</label>
			<input type="password" id="password" ref={password} />
			<button type="submit" onClick={handleSubmit}>Continue</button>
		</form>
	)
}

export default LoginForm;