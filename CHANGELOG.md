# Change Log
All notable changes to this project will be documented in this file.

## 3.0.0
### Changed
- IQuantity depends on IXmlSerializable - changed XML serialization  (#62)
- Xml serialization without units (#66)
- Moved CSV functionality to QuantityTypes.Csv (#67)
- Moved dynamic types to separate project (#71)

### Added
- TimeSpan extension methods (#43)
- Format with conversion, without showing unit (#52)
- Moment type (#11)
- Imperial units

### Fixed
- lb/gal unit (#1)

## 2.0.1
### Changed
- Target netstandard 1.1

## 2.0.0
### Changed
- Target netstandard 1.0

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

### Removed
- 

### Fixed
- Support parsing of "'" units (#20)
