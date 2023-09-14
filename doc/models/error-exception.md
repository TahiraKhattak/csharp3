
# Error Exception

## Structure

`ErrorException`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Code` | `int` | Required | the code associated with the error returned |
| `Message` | `string` | Required | detailed message about the error returned |

## Example (as JSON)

```json
{
  "code": 101010,
  "message": "Invalid pet type, only cat and dogs allowed"
}
```

