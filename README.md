
# Getting Started with Petstore

## Introduction

The API enables users to view detailed information about a specific pet store and its available pets. The API can be used by pet owners, pet adoption agencies, and anyone looking for information about pets in a particular area.

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package TahiraTestSDK --version 1.0.4
```

You can also view the package at:
https://www.nuget.org/packages/TahiraTestSDK/1.0.4

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `AccessToken` | `string` | The OAuth 2.0 Access Token to use for API requests. |

The API client can be initialized as follows:

```csharp
Petstore.Standard.PetstoreClient client = new Petstore.Standard.PetstoreClient.Builder()
    .AccessToken("AccessToken")
    .Build();
```

## Authorization

This API uses `OAuth 2 Bearer token`.

## List of APIs

* [Pets](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/controllers/pets.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/http-request.md)
* [HttpResponse](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/http-string-response.md)
* [HttpContext](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/TahiraKhattak/csharp3/tree/1.0.4/doc/api-exception.md)

