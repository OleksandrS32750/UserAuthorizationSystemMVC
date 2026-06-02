My implementation description:
	- Local repository to store users in memory
	- Admin class created directly in code inside userService and added directly to repository
	- guid type used for UserId and NoteId

Answers for questions:
1 - to prevent situations,when someone has access to user database (emp or any other person) so they wont be able to login as other users
2 - because it is fast,so it doesen't stop brute-force attacks from hackers
3 - to prevent password duplication,and hide real password by adding unique generated string
4 - pepper is a hidden string stored in .env or other hidden location and added after hashed password
5 - auth - to check if user logined in system , authorization - to check if user allowed to  perform action
6 - 
7 - because if user misstyped password or email,such error will misslead him,thinking he used other credentials for website