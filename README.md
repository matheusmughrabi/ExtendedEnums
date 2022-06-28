# ExtendedEnums

ExtendedEnums is a tool to help working with enums.

## Installation
#### .NET CLI
```
dotnet add package ExtendedEnums
```

## Basic usage
```csharp
public enum CountriesEnum
{
    [System.ComponentModel.Description("Brazil")]
    Brazil = 1,
    [System.ComponentModel.Description("United States of America")]
    UnitedStates = 2,
    Canada = 3
}
```

#### Description of a value
```csharp
var unitedStates = CountriesEnum.UnitedStates;

var unitedStatesDescription = unitedStates.ToDescription();

Console.WriteLine(unitedStatesDescription)

// Output: United States of America
```

#### Retrieve all values of an enum
```csharp
var values = EnumsExtensions.GetValues<CountriesEnum>();

Console.WriteLine(unitedStatesDescription)

// Output:
// [0] Brazil
// [1] UnitedStates
// [2] Canada
```

#### Check if a value is defined within an enum
```csharp
var value = CountriesEnum.Canada;
var isDefined = canada.IsDefined();

Console.WriteLine(isDefined )

// Output: true
```

```csharp
 var value = (CountriesEnum)3;
 var isDefined = value.IsDefined();

Console.WriteLine(isDefined)

// Output: true
```

```csharp
 var value = (CountriesEnum)4;
 var isDefined = value.IsDefined();

Console.WriteLine(isDefined)

// Output: false
```

#### Convert to EnumResult (strongly typed class)
```
public class EnumResult
    {
        public EnumResult()
        {
        }

        public EnumResult(long value, string description)
        {
            Value = value;
            Description = description;
        }

        public long Value { get; set; }
        public string Description { get; set; }
    }
```

```csharp
 var value = CountriesEnum.UnitedStates;
 var enumResult = value.ConvertToEnumResult();

Console.WriteLine(enumResult.Value); // Output: 2
Console.WriteLine(enumResult.Description ); // Output: United States of America
```

#### Retrieve all values of an enum as IEnumerable\<EnumResult>
```
var allValues = EnumsExtensions.GetValuesAsEnumResult<CountriesEnum>();

// Output:
[0]: Value = 1
     Description = "Brazil"
[1]: Value = 2
    Description = "United States of America"
[2]: Value = 3
     Description = "Canada"
``` 

