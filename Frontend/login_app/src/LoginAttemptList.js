import React, { useState } from "react";
import "./LoginAttemptList.css";

//const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

function AttemptListFilter(props) {
	const [filter, setFilter] = useState('');

	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input type="input" id="filter" name="filter" placeholder="Filter..." value={filter}
				onChange={event => setFilter(event.target.value)} />
			<ul className="Attempt-List">
				{/*<LoginAttempt>*/}
				{props.attempts.filter(function (attempt) {
					if (filter === '' || (attempt.login.toLowerCase() + ' ' + attempt.password.toLowerCase()).includes(filter.toLowerCase())) { return attempt; } else { return null; }
				}).map((filteredAttempt, index) =>
					<li key={index}>{filteredAttempt.login} {filteredAttempt.password} </li>
					)}
				{/*</LoginAttempt>*/}
			</ul>
		</div>
	);
}

const LoginAttemptList = (props) => (

	AttemptListFilter(props)

);

export default LoginAttemptList;