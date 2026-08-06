# Standards Alignment Review

This document reviews QuantityTypes against the relevant international standards and industry
best practices for quantities and units, assesses the current state of the library, and makes
concrete recommendations. It was created in response to
[issue #107 – Align with standards](https://github.com/QuantityTypes/QuantityTypes/issues/107).

A phased plan for acting on these recommendations is maintained in the
[Development Plan](DevelopmentPlan.md).

## 1. Relevant standards and references

### 1.1 ISO/IEC 80000 — Quantities and units

[ISO 80000-1:2022](https://www.iso.org/standard/76921.html) (and the other parts of
[ISO/IEC 80000](https://en.wikipedia.org/wiki/ISO/IEC_80000)) is the authoritative
international standard for quantities, systems of quantities, units, and quantity and unit
symbols. Key concepts that apply to this library:

- **International System of Quantities (ISQ)** — quantities are organized in a coherent system
  built on seven base quantities: length, mass, time, electric current, thermodynamic
  temperature, amount of substance, and luminous intensity.
- **Quantity dimensions** — every quantity has a dimension expressed as a product of powers of
  the base dimensions (e.g. force has dimension `L·M·T⁻²`).
- **Coherent units** — every quantity has one coherent SI unit (e.g. the newton for force);
  all other units relate to it by a conversion factor (and, for temperature, an offset).
- **Naming and symbols** — the standard defines canonical names and symbols for quantities and
  units, including case sensitivity (e.g. `L` or `l` for litre, `°C` not `C`).

### 1.2 The SI Brochure (BIPM)

The [SI Brochure, 9th edition](https://www.bipm.org/en/publications/si-brochure) is the
definitive description of the International System of Units, including the 2019 redefinition
of the base units in terms of exact values of physical constants, SI prefixes (including the
2022 additions ronna/quetta and ronto/quecto), and rules for writing unit symbols.

### 1.3 NIST SP 811 — Guide for the Use of the International System of Units

[NIST SP 811](https://www.nist.gov/pml/special-publication-811) is the US guide for using the
SI. It is especially valuable for this library because of:

- **Appendix B** — authoritative conversion factors between non-SI units (mostly US customary
  and imperial units) and SI units, given to full precision with an indication of which factors
  are exact.
- **Chapter 6–9** — rules for unit symbols, formatting of quantity values (e.g. a space between
  the number and the unit symbol), and rounding/significant digits.

### 1.4 UnitsML / UnitsDB

[UnitsDB](https://github.com/unitsml/unitsdb) is a machine-readable, curated database of
quantities (`quantities.yaml`), units, prefixes, and dimensions maintained by the UnitsML
project. It cross-references ISO 80000 and NIST SP 811 and is a good candidate as a *source of
truth* for validating (or even generating) the definitions in `Units.csv`.

### 1.5 Other ecosystem references

- [UCUM — Unified Code for Units of Measure](https://ucum.org/) — case-sensitive unambiguous
  codes for units, widely used in healthcare and scientific data exchange.
- [QUDT](https://qudt.org/) — ontology of quantities, units, dimensions and types.
- The SciDataCon session on units interoperability
  ([session 449](https://www.scidatacon.org/IDW-2022/sessions/449/),
  [recording](https://vimeo.com/743474785)) discusses interoperability between these systems.

## 2. Current state of QuantityTypes

QuantityTypes generates strongly typed quantity structs from a single source file,
[`Source/QuantityTypes/Units.csv`](../Source/QuantityTypes/Units.csv), via the `CodeGenerator`
tool. Each line defines a quantity type, a unit name, its symbol(s), and the conversion factor
to the coherent (base) unit of that quantity.

### 2.1 What is already well aligned

- **Coherent-unit model** — each quantity stores its value internally in the coherent SI unit
  (factor `1`), exactly matching the ISO 80000 coherent-unit concept.
- **SI spellings** — unit names use the international spellings (`Metre`, `Litre`) used by the
  SI Brochure and ISO 80000.
- **Symbols** — most symbols follow the SI/NIST rules, including case (`kg`, `Pa`, `Hz`, `L`
  for litre) and Unicode symbols (`µ`, `Ω`, `Å`, `°`) with ASCII fallbacks (`u`, `deg`).
- **Temperature as a special case** — `Temperature` (with offset) is kept separate from
  `TemperatureDifference`, which matches the distinction ISO 80000-5 makes between
  thermodynamic temperature and temperature intervals.
- **Exact conversion factors** — most customary-unit factors match NIST SP 811 Appendix B
  exactly (e.g. `yd = 0.9144 m`, `lb = 0.45359237 kg`, `atm = 101325 Pa`).

### 2.2 Gaps and non-conformances found in this review

The following issues were found by checking `Units.csv` against NIST SP 811 Appendix B and
ISO 80000. Items marked *(fixed)* were corrected as part of this review; the remaining items
are recommendations because fixing them changes public API or default formatting and should be
scheduled deliberately (see the [Development Plan](DevelopmentPlan.md)).

| # | Item | Standard | Status |
|---|------|----------|--------|
| 1 | `InchOunceForce` factor was `0.0254 * 0283495231 * 9.80665` (missing decimal point, off by 10¹⁰) for both `Moment` and `Torque` | NIST SP 811 B.8 | **Fixed** — now `0.0254 * 0.0283495231 * 9.80665` |
| 2 | `Torque.JoulePerRadian` symbol was `J/m` | ISO 80000-4 | **Fixed** — now `J/rad`, with `J/m` kept as a parse-only alias for backwards compatibility |
| 3 | `HorsePower` (`hp`, 735.49875 W) is the *metric* horsepower; NIST defines several horsepower units (550 ft·lbf/s ≈ 745.6999 W being the most common in US usage) | NIST SP 811 B.8 | Recommendation: document the current meaning; add explicitly named variants (`MetricHorsePower`, `MechanicalHorsePower`) |
| 4 | `Gallon` (3.785411784 L) is the US gallon only; the imperial gallon (4.54609 L) is not distinguished by name | NIST SP 811 B.8 | Recommendation: add `ImperialGallon`; consider renaming to `USGallon` with an alias in a major release |
| 5 | `Calorie` (4.1868 J) is the *International Table* calorie; NIST also defines the thermochemical calorie (4.184 J) | NIST SP 811 B.8 | Recommendation: document; add `CalorieThermochemical` |
| 6 | `Mass.Ton` (1016.0469088 kg) is the *long* ton; the short ton (907.18474 kg) is missing | NIST SP 811 B.8 | Recommendation: add `ShortTon`/`LongTon` with explicit names |
| 7 | Litre symbol is inconsistent: `L` for `Volume`/`Density`/`Flow` but lowercase `l` in `FuelConsumption` (`l/100km`) and `FuelEconomy` (`km/l`) | SI Brochure §5.3 (both allowed, but consistency preferred; NIST prefers `L`) | Recommendation: standardize on `L`, keep `l` variants as parse aliases |
| 8 | `TemperatureDifference` / `TemperatureRateOfChange` use bare `C` and `F` (with `°C`/`°F` alternates only for `TemperatureDifference`) | ISO 80000-5, NIST SP 811 §6 | Recommendation: make `°C`/`°F` the primary symbols, keep `C`/`F` as parse aliases |
| 9 | `Kips` is defined as a *mass* (453.59237 kg = 1000 lb); the kip is conventionally a unit of *force* (`KipForce` exists and is correct) | NIST SP 811 B.8 | Recommendation: document; consider deprecating `Mass.Kips` |
| 10 | Missing SI prefixed units in several quantities (e.g. no `Micropascal`, `Gigapascal`; no `Terahertz`) and no support for the 2022 prefixes | SI Brochure ch. 3 | Recommendation: generate prefixed units systematically (see plan) |
| 11 | `InformationEntropy.Byte` mixes information units into a thermodynamic quantity via the Boltzmann constant | IEC 80000-13 | Recommendation: introduce a separate `InformationQuantity` (bit, byte, with binary prefixes per IEC 80000-13) |
| 12 | No machine-readable dimension (ISQ exponents) is recorded per quantity, so dimensional consistency of `Units.csv` and of the operator definitions cannot be verified automatically | ISO 80000-1 §5 | Recommendation: add dimensions to the code-generator input and validate against UnitsDB |

### 2.3 Formatting and parsing

- The default formatting (`value + " " + symbol`, e.g. `"1 N*m"`) follows the NIST SP 811 rule
  of a space between the number and the unit symbol.
- The compound-unit notation uses `*` and `^` (e.g. `N*m`, `m/s^2`) rather than the
  ISO 80000-1 typographical forms (`N·m`, `m/s²`). This is a pragmatic ASCII choice; the
  recommendation is to *additionally* accept (and optionally emit) the `·` and superscript
  forms as symbol aliases, not to break the existing notation.
- Parsing already accepts multiple symbols per unit (the `|`-separated alias mechanism in
  `Units.csv`), which is the right mechanism for adding standards-conformant symbols without
  breaking existing consumers.

## 3. Recommendations (summary)

1. **Treat NIST SP 811 Appendix B as the source of truth for conversion factors.** Every
   factor in `Units.csv` should be traceable to it (or to the SI Brochure/ISO 80000 for SI
   units). Document exactness where NIST marks factors as exact.
2. **Validate `Units.csv` against UnitsDB.** Add an automated check (unit test or CI step)
   that cross-references unit names, symbols, and factors with
   [`unitsml/unitsdb`](https://github.com/unitsml/unitsdb). This turns standards alignment
   from a one-off review into a regression-tested property.
3. **Add ISQ dimensions to the code-generator input** so that dimensional consistency of
   quantities and cross-quantity operators can be verified automatically.
4. **Disambiguate ambiguous units** (horsepower, gallon, calorie, ton) with explicitly named
   variants, keeping the existing names as documented aliases until the next major release.
5. **Prefer standards-conformant primary symbols** (`°C`, `J/rad`, `L`) while keeping legacy
   symbols as parse-only aliases, so no existing parsing code breaks.
6. **Track breaking renames for the next major version** and document them in the changelog,
   per the existing semantic-versioning practice of this project.

## 4. References

- NIST SP 811: <https://www.nist.gov/pml/special-publication-811>
- ISO 80000-1:2022: <https://www.iso.org/standard/76921.html>
- ISO/IEC 80000 overview: <https://en.wikipedia.org/wiki/ISO/IEC_80000>
- SI Brochure (9th ed.): <https://www.bipm.org/en/publications/si-brochure>
- UnitsDB quantities: <https://github.com/unitsml/unitsdb/blob/main/quantities.yaml>
- UCUM: <https://ucum.org/>
- QUDT: <https://qudt.org/>
- SciDataCon IDW-2022 session 449: <https://www.scidatacon.org/IDW-2022/sessions/449/>
  ([recording](https://vimeo.com/743474785))
