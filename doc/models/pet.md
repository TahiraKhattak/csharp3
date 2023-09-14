
# Pet

## Structure

`Pet`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Required | the name lovingly given to the pet |
| `Type` | [`PetTypeEnum?`](../../doc/models/pet-type-enum.md) | Optional | the type of pets allowed |
| `Id` | `long` | Required | a unique identifier for a Pet |

## Example (as JSON)

```json
{
  "name": "Fido",
  "id": 1234,
  "type": "dog"
}
```

