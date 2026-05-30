# TimeAgo

[![NuGet](https://img.shields.io/nuget/v/TimeAgo.svg)](https://www.nuget.org/packages/TimeAgo)
[![CI](https://github.com/agriffard/TimeAgo/actions/workflows/ci.yml/badge.svg)](https://github.com/agriffard/TimeAgo/actions/workflows/ci.yml)

A self-updating Blazor component that renders human-readable relative time text (for example, "3 minutes ago").

## Installation

```bash
dotnet add package TimeAgo
```

## Usage

```razor
@using TimeAgo

<TimeAgoComponent Date="@DateTime.UtcNow.AddMinutes(-3)" />
```
