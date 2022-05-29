# QuantityTypes

## Features

- [Strongly typed](http://en.wikipedia.org/wiki/Strong_typing) arithmetics of [physical quantities](http://en.wikipedia.org/wiki/Physical_quantity)
- Implemented as [value types](http://msdn.microsoft.com/en-us/library/s1ax56ch.aspx)
- Parsing from strings
- Formatting to strings
- Operators
- Unit conversion
- Extendable (create more quantity types, add units)
- Configurable (set default units for parsing and formatting)
- [NuGet package](https://www.nuget.org/packages/QuantityTypes)

## Examples

``` csharp
Length s = 100 * Length.Metre;
Time t = 9.58 * Time.Second;
Velocity v = s / t;
Console.WriteLine(v); 
Console.WriteLine(v.ToString("0.00[km/h]")); 
Console.WriteLine("Speed: {0:0.00[!km/h] kmph}", v);
Mass m = Mass.Parse("92 kg");
double massInPounds = m / Mass.Pound;
Temperature temp = 100 * Temperature.DegreeCelsius;
double tempInFahrenheit = temp.ConvertTo(Temperature.DegreeFahrenheit);
```
