# Development Plan

This document describes the recommended plan for developing QuantityTypes further, based on
the findings in the [Standards Alignment Review](StandardsAlignment.md)
([issue #107](https://github.com/QuantityTypes/QuantityTypes/issues/107)).

The plan is organized in phases. Non-breaking work (bug fixes, aliases, additions, tooling)
can ship in minor releases; breaking changes (renames, symbol changes, removals) are collected
for the next major release.

## Phase 1 — Correctness fixes (non-breaking)

Fix defects where the current behavior is simply wrong with respect to the standards.

- [x] Fix the `InchOunceForce` conversion factor for `Moment` and `Torque`
      (was off by a factor of 10¹⁰ due to a missing decimal point).
- [x] Fix the `Torque.JoulePerRadian` symbol (`J/m` → `J/rad`), keeping `J/m` as a
      parse-only alias for backwards compatibility.
- [ ] Audit every remaining conversion factor in `Units.csv` against NIST SP 811 Appendix B
      and record the source (and exactness) of each factor as a comment.

## Phase 2 — Standards-conformant additions (non-breaking)

Add missing units and aliases without changing existing behavior.

- [x] Add explicitly named variants for ambiguous units:
  - `MetricHorsePower` / `MechanicalHorsePower` (power)
  - `ImperialGallon` (volume) and corresponding fuel-economy units
  - `CalorieThermochemical` (energy)
  - `ShortTon` / `LongTon` (mass)
- [x] Add standards-conformant symbol aliases (`°C`/`°F` for temperature rate of change,
      `L`-based aliases where lowercase `l` is used, `·` and superscript forms such as `N·m`,
      `m/s²` as parse aliases).
- [x] Add commonly requested SI-prefixed units systematically (e.g. `Gigapascal`,
      `Terahertz`), preferably by teaching the code generator about SI prefixes instead of
      hand-writing each row.
- [x] Add an `InformationQuantity` type per IEC 80000-13 (bit, byte, decimal and binary
      prefixes), separate from the thermodynamic `InformationEntropy`.

## Phase 3 — Tooling: make alignment verifiable

Turn standards alignment into an automatically checked property instead of a one-off review.

- [ ] Extend the `Units.csv` schema (and `CodeGenerator`) with an optional ISQ dimension
      column (exponents of L, M, T, I, Θ, N, J) per quantity type.
- [ ] Add a validation step (unit tests or a CI job) that checks:
  - every quantity's units are dimensionally consistent,
  - cross-quantity operators in the `Operators` folder are dimensionally consistent,
  - unit names/symbols/factors cross-reference cleanly against
    [UnitsDB](https://github.com/unitsml/unitsdb) (`quantities.yaml`, `units.yaml`).
- [ ] Document the provenance of each conversion factor (NIST SP 811 table reference).

## Phase 4 — Breaking changes (next major release)

Collect the renames and default-symbol changes that cannot be done compatibly.

- [ ] Rename `Gallon` → `USGallon` (keeping `Gallon` as an obsolete alias for one release).
- [ ] Make `°C`/`°F` the primary (formatting) symbols for temperature-related quantities.
- [ ] Standardize the litre symbol on `L` in all display symbols.
- [ ] Deprecate/remove `Mass.Kips` (the kip is a unit of force; `Force.KipForce` remains).
- [ ] Review quantity-type names against the ISO 80000 quantity names (e.g. `Flow` vs.
      *volume flow rate*, `Radiation` vs. *activity*) and rename where it improves clarity.

## Phase 5 — Ecosystem and interoperability (longer term)

- [ ] Evaluate generating `Units.csv` (or validating it) directly from UnitsDB, making the
      standards database the single source of truth.
- [ ] Consider optional UCUM code output/parsing for interoperability with healthcare and
      scientific data-exchange systems.
- [ ] Keep target frameworks and CI tooling current (the library targets `netstandard2.0`,
      which remains the right choice for maximum compatibility; test projects should track
      supported .NET versions).

## Working practices

- Every change to `Units.csv` must include the source of the conversion factor in the pull
  request description and, where practical, a unit test asserting the converted value.
- Non-breaking releases follow the existing minor-version cadence; breaking changes are
  batched for major versions and documented in `CHANGELOG.md`.
- New quantity types or units should reference the corresponding ISO 80000 part or
  NIST SP 811 table in their pull request.
