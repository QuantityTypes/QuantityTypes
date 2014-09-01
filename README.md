```
License:       The MIT License (MIT)
Project page:  https://github.com/objorke/QuantityTypes
```

_NASA's Mars Climate Observer crashed in September 1999 because of a serious breakdown in project management. However, that accident
will be best remembered for the simple error that started everything: the value of a thrust parameter was entered into computer systems 
in imperial, rather than SI units. That such a trivial mistake could ultimately bring about a mission failure is astonishing. It begs 
the question of why computers cannot help more when working with physical quantities?_ [Ref. 1]

[![Build status](https://ci.appveyor.com/api/projects/status/0l0beneke0syjt47)](https://ci.appveyor.com/project/objorke/quantitytypes)

### Features

- [Strongly typed](http://en.wikipedia.org/wiki/Strong_typing) arithmetics of [physical quantities](http://en.wikipedia.org/wiki/Physical_quantity)
- Implemented as [value types](http://msdn.microsoft.com/en-us/library/s1ax56ch.aspx)
- Parsing from strings
- Formatting to strings
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
Console.WriteLine(v.ToString("0.00 km/h")); 
Mass m = Mass.Parse("92 kg");
double massInPounds = m.ConvertTo(Mass.Pound);
Temperature temp = 100 * Temperature.Celsius;
double tempInFahrenheit = temp.ConvertTo(Temperature.Fahrenheit);
```

### References

1. B. D. Hall. [Software support for physical quantities](http://mst.irl.cri.nz/Portals/5/enzcon.pdf). 2002.
2. Barton and Nackman. [Dimensional analysis. C++ Report](http://se.ethz.ch/~meyer/publications/OTHERS/scott_meyers/dimensions.pdf)
3. Brown. [Introduction to the SI Library of Unit-Based Computation](http://lss.fnal.gov/archive/1998/conf/Conf-98-328.pdf)
4. Brown. [Applied Template Metaprogramming in SIUNITS](http://www.oonumerics.org/tmpw01/brown.pdf)

### Links

- [Physical quantity](http://en.wikipedia.org/wiki/Physical_quantities)
- [Unit of measurement](http://en.wikipedia.org/wiki/Unit_of_measurement)
- [Conversion of units](http://en.wikipedia.org/wiki/Conversion_of_units)
- [International System of Units](http://en.wikipedia.org/wiki/International_System_of_Units)
- [A Dictionary of Units of Measurement](http://www.unc.edu/~rowlett/units/)
- [The International System of Units (SI)](http://www.bipm.org/utils/common/pdf/si_brochure_8_en.pdf) (Bureau International des Poids et Mesures)
- [Package siunitx: A comprehensive (SI) units package.](http://ctan.org/pkg/siunitx)
- [Writing SI units and symbols](http://www.poynton.com/PDFs/Writing_SI_units_(USL).pdf)

### Other similar libraries

#### .NET

- [NGenericDimensions™](https://ngenericdimensions.codeplex.com/)
- [quantities.net](http://sourceforge.net/projects/quantitiesnet/)
- [unitcon](http://sourceforge.net/projects/unitcon/)
- [units](http://www.gnu.org/software/units/)
- [Measurement Unit Conversion Library](http://www.codeproject.com/Articles/23087/Measurement-Unit-Conversion-Library)
- [Units of Measure Library](http://www.codeproject.com/Articles/404573/Units-of-Measure-Library-for-NET)
- [Units of Measure Validator for C#](http://www.codeproject.com/Articles/413750/Units-of-Measure-Validator-for-Csharp)
- [Working with Units and Amounts](http://www.codeproject.com/Articles/611731/Working-with-Units-and-Amounts)
- [Units.NET](https://github.com/InitialForce/UnitsNet)

#### Java

- [JScience](http://jscience.org/)
- [JConvert](http://sourceforge.net/projects/jconvert/)
- [JSR-108](http://jsr-108.sourceforge.net) 
- [jcp](http://www.jcp.org/en/jsr/detail?id=108)

#### Python

- [sympy](http://sympy.org/en/index.html)
- [unum](http://home.scarlet.be/be052320/Unum.html)
- [quantities](http://packages.python.org/quantities/)
- [numph](http://numpy.scipy.org/)
