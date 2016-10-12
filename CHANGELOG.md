# Change Log
All notable changes to this project will be documented in this file.

## Unreleased
### Changed
- IQuantity depends on IXmlSerializable - changed XML serialization  (#62)
- Moved CSV functionality to QuantityTypes.Csv (#67)

### Added
- TimeSpan extension methods (#43)

## 2.0.0
### Changed
- Target netstandard 1.0

## 1.1.0
### Added
- Unit prefixes and operator overloads for electrical units
- Use GitHub as source server (#12)
- Lighting calculations
- Torque units: N*cm, N*mm (#8)

### Changed
- Rename DegreeKelvin to Kelvin and delete "degK" unit (#30)
- Case sensitive unit prefixes
- Switch PCL project to profile 328
- Refactor UnitProvider.RegisterUnits to extension methods (#6)

### Removed
- 

### Fixed
- Support parsing of "'" units (#20)
