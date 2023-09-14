# Pets

the pet grouping

```csharp
PetsController petsController = client.PetsController;
```

## Class Name

`PetsController`

## Methods

* [Create Pets](../../doc/controllers/pets.md#create-pets)
* [List Pets](../../doc/controllers/pets.md#list-pets)
* [Show Pet by Id](../../doc/controllers/pets.md#show-pet-by-id)


# Create Pets

Create a pet and key characteristics

```csharp
CreatePetsAsync(
    Models.Pet body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Pet`](../../doc/models/pet.md) | Body, Required | A single Pet object used to create a new Pet |

## Response Type

`Task`

## Example Usage

```csharp
Pet body = new Pet
{
    Name = "Indiana",
    Id = 12345L,
};

try
{
    await petsController.CreatePetsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| Default | unexpected error | [`ErrorException`](../../doc/models/error-exception.md) |


# List Pets

List all pets

```csharp
ListPetsAsync(
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | How many items to return at one time (max 100)<br>**Constraints**: `<= 100` |

## Response Type

[`Task<List<Models.Pet>>`](../../doc/models/pet.md)

## Example Usage

```csharp
int? limit = 10;
try
{
    List<Pet> result = await petsController.ListPetsAsync(limit);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
[
  {
    "id": 12345,
    "name": "Indiana",
    "petType": "dog"
  },
  {
    "id": 56789,
    "name": "Shadow",
    "petType": "cat"
  }
]
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| Default | unexpected error | [`ErrorException`](../../doc/models/error-exception.md) |


# Show Pet by Id

Info for a specific pet

```csharp
ShowPetByIdAsync(
    string petId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `string` | Template, Required | The id of the pet to retrieve |

## Response Type

[`Task<Models.Pet>`](../../doc/models/pet.md)

## Example Usage

```csharp
string petId = "33918";
try
{
    Pet result = await petsController.ShowPetByIdAsync(petId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response *(as JSON)*

```json
{
  "id": 12345,
  "name": "Cody",
  "petType": "dog"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| Default | unexpected error | [`ErrorException`](../../doc/models/error-exception.md) |

