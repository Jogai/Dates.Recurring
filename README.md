
[![n](https://img.shields.io/nuget/v/Scott.Dates.Recurring)](https://www.nuget.org/packages/Scott.Dates.Recurring/) | ![l](https://img.shields.io/github/license/jogai/Dates.Recurring) | ![d](https://img.shields.io/nuget/dt/Scott.Dates.Recurring) | ![c](https://circleci.com/gh/circleci/circleci-docs.svg?style=shield) | ![p](https://github.com/Jogai/Dates.Recurring/workflows/Scott%20Dates%20Recurring%20-%20Deploy/badge.svg)

# Scott.Dates.Recurring

Library for working with recurring dates in a fluent syntax

## Installation

Install from nuget

```bash
dotnet add package Scott.Dates.Recurring
```

```powershell
Install-Package Scott.Dates.Recurring
```

## Usage

You can see the usage in the tests, simple example

```csharp
using Scott.Dates.Recurring;

var weekly = RuleBuilder
                .Every(2)
                .Weeks()
                .Starting(new DateTime(2016, 10, 2))
                .Ending(new DateTime(2016, 10, 31))
                .Build();
            Assert.AreEqual(16, weekly.Sequence.Count);
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
