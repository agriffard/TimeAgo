# TimeAgochi

[![NuGet](https://img.shields.io/nuget/v/TimeAgochi.svg)](https://www.nuget.org/packages/TimeAgochi)
[![CI](https://github.com/agriffard/TimeAgochi/actions/workflows/ci.yml/badge.svg)](https://github.com/agriffard/TimeAgochi/actions/workflows/ci.yml)

A self-updating Blazor component that renders human-readable relative time text (for example, "3 minutes ago").

## Installation

```bash
dotnet add package TimeAgochi
```

## Usage

```razor
@using TimeAgochi

<TimeAgo Date="@DateTime.UtcNow.AddMinutes(-3)" />
```
