[![Build status](https://img.shields.io/appveyor/ci/objorke/quantitytypes/master.svg)](https://ci.appveyor.com/project/objorke/quantitytypes) 
[![Gitter](https://img.shields.io/gitter/room/objorke/quantitytypes.svg)](https://gitter.im/objorke/QuantityTypes?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet](https://img.shields.io/nuget/v/quantitytypes.svg)](https://www.nuget.org/packages/QuantityTypes/)
[![Issues](https://img.shields.io/github/issues/objorke/quantitytypes.svg)](https://github.com/objorke/QuantityTypes/issues)

```
License:       The MIT License (MIT)
Project page:  https://github.com/objorke/QuantityTypes
```

### Features

- [Strongly typed](http://en.wikipedia.org/wiki/Strong_typing) arithmetics of [physical quantities](http://en.wikipedia.org/wiki/Physical_quantity)
- Implemented as [value types](http://msdn.microsoft.com/en-us/library/s1ax56ch.aspx)
- Parsing from strings
- Formatting to strings
- Operators
- Unit conversion
- Extendable (create more quantity types, add units)
- Configurable (set default units for parsing and formatting)
- [NuGet package](https://www.nuget.org/packages/QuantityTypes)

### Examples

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
