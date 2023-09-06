const API_Base_URL = "https://localhost:7127/api/";
var Token = "_";

function SetAuthToken(token) {
    Token = token;
}

export { API_Base_URL, Token, SetAuthToken };