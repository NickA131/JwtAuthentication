# JwtAuthentication
Authentication of ASP.Net Core Web API with JSON Web Tokens

Demonstrates authentication against a username and password to produce a token 
that then allows access to secured resources. 
To authenticate, make a POST to /api/authenticate with credentials as a JSON object in the body.

Role based authorization is also demonstrated. There are two users, one standard, 
and the other administrator.

All users, once authenticated, will be able to make GET requests to /api/authentication.

Only nick user will be able to make GET requests to /api/admin.

For users of Postman, 'Postman_Endpoints.json' has full configuration settings. In Visual Studio run using 'kestrel' web server. If using IIS port numbers will need to be changed.


# Credits
Thanks to the following tutorials that were referenced in the writing of this code.

- Gary Woodfine
https://garywoodfine.com/asp-net-core-2-2-jwt-authentication-tutorial/

- Jason Watmore
https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api

