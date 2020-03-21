# APIGatewayRequestSignerWithAPIKeySupport

*NOTE: Make sure to type your json with double quotes. Single quotes does not work while parsing the data*

Program.cs Line 22 to 29 - Edit the below code with your details and you are good to go.
```
_accessKey = "<your_access_key>";
_secretKey = "<your_secret_key>";
_service = "execute-api";
_region = "us-east-2";
_requestUri = new Uri("your_api_gateway_endpoint");
//Make sure to type your json with double quotes. Single quotes does not work while parsing the data
_json = "{\"type\":\"dog\",\"price\":2008}";
_x_api_key = "<api_key_value_if_configured>";
```
