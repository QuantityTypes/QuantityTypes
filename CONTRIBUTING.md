# Contributing to QuantityTypes

Thank you for your interest in contributing to QuantityTypes! We welcome contributions from the community.

## Code of Conduct

By participating in this project, you are expected to uphold a respectful and collaborative environment for all contributors.

## How to Contribute

### Reporting Issues

If you find a bug or have a suggestion for improvement:

1. Check if the issue already exists in the [issue tracker](https://github.com/QuantityTypes/QuantityTypes/issues)
2. If not, create a new issue with a clear title and description
3. Include relevant details such as:
   - Steps to reproduce (for bugs)
   - Expected vs. actual behavior
   - Environment details (.NET version, OS, etc.)
   - Code samples or test cases when applicable

### Submitting Pull Requests

1. Fork the repository
2. Create a new branch for your changes (`git checkout -b feature/your-feature-name`)
3. Make your changes following the guidelines below
4. Test your changes thoroughly
5. Commit your changes with clear, descriptive commit messages
6. Push to your fork (`git push origin feature/your-feature-name`)
7. Open a pull request against the `main` branch

## Development Setup

### Prerequisites

- [.NET SDK 7.0](https://dotnet.microsoft.com/download) or later
- A code editor (Visual Studio, VS Code, or Rider recommended)

### Building the Project

```bash
cd Source
dotnet restore
dotnet run --project CodeGenerator/CodeGenerator.csproj --configuration Release --framework net7.0 -- QuantityTypes/Units.csv QuantityTypes/Quantities
dotnet build --configuration Release
```

### Running Tests

```bash
cd Source
dotnet test --configuration Release
```

## Coding Guidelines

- Follow the existing code style and conventions used in the project
- Write clear, self-documenting code
- Add XML documentation comments for public APIs
- Ensure your code compiles without warnings
- Keep changes focused and atomic

## Testing

- Add unit tests for new functionality
- Ensure all existing tests pass before submitting a pull request
- Aim for good test coverage of your changes

## Adding New Quantity Types or Units

When adding new quantity types or units:

1. Update the `Units.csv` file in the `Source/QuantityTypes` directory
2. Run the code generator to regenerate the quantity type classes
3. Add appropriate tests for the new types or units
4. Update documentation as needed

## Documentation

- Update relevant documentation for your changes
- Keep the README.md up to date with new features
- Add examples for significant new functionality

## Contributor Agreement

By submitting a contribution, you agree to license your work under the same license as this project (see [LICENSE](LICENSE) file). Please add your name and email to the [CONTRIBUTORS](CONTRIBUTORS) file with your first contribution.

## Questions?

If you have questions about contributing, feel free to:

- Open an issue with your question
- Contact the maintainers (see [CONTRIBUTORS](CONTRIBUTORS) file)

Thank you for contributing to QuantityTypes!
