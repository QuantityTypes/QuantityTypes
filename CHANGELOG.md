# Change Log

## Next

### Added
- GitHub workflows (#113)
- Publish to GitHub packages (#114)
- Examples with System.Text.Json (#108)

### Changed
- Target netstandard2.0 (#127)

### Removed
- net45 target (#109)

### Fixed
- Removed all usages of regular expressions (#125)

## 4.0.0
### Added
- Imperial units
- NaN, PositiveInfinity and NegativeInfinity quantities (#83)
- LinearMassDensity (#82)
- Scandinavian mile length unit (#88)
- Custom length example (#89)

### Changed
- Target netstandard1.3 and net45 (#97)

### Fixed
- Null reference exception in QuantityJsonConverter (#85)
- Migrate projects to netstandard (#94)
- TryParse of `null` should return `false` (#96)

## 3.0.1
### Changed
- IQuantity depends on IXmlSerializable - changed XML serialization  (#62)
- Xml serialization without units (#66)
- Moved CSV functionality to QuantityTypes.Csv (#67)
- Moved dynamic types to separate project (#71)
- Signing the QuantityTypes assembly (#51)

### Added
- t/m^3 density unit (#80)
- TimeSpan extension methods (#43)
- Format with conversion, without showing unit (#52)
- Moment type (#11)

### Fixed
- lb/gal unit (#1)

## 2.0.1
### Changed
- Target netstandard 1.0

## 2.0.0
### Changed
- Target netstandard 1.1

## 1.1.0
### Added
- Torque units: N*cm, N*mm (#8)
- Use GitHub as source server (#12)
- Unit prefixes and operator overloads for electrical units
- Lighting calculations

### Changed
- Refactor UnitProvider.RegisterUnits to extension methods (#6)
- Rename DegreeKelvin to Kelvin and delete "degK" unit (#30)
- Case sensitive unit prefixes
- Switch PCL project to profile 328

### Fixed
- Support parsing of "'" units (#20)
