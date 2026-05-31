# TimeAgo

[![NuGet](https://img.shields.io/nuget/v/TimeAgo.svg)](https://www.nuget.org/packages/TimeAgo)
[![CI](https://github.com/agriffard/TimeAgo/actions/workflows/ci.yml/badge.svg)](https://github.com/agriffard/TimeAgo/actions/workflows/ci.yml)

A self-updating Blazor component that renders human-readable relative time text (for example, "3 minutes ago").

## Automation

- `ci.yml` restores, builds, and packs the library and sample app on pushes to `main`, pull requests, and manual runs.
- `nuget-package.yml` publishes the `TimeAgo` package to NuGet on release publication or a manual run. Configure the `NUGET_API_KEY` repository secret before using it.
- `github-pages.yml` publishes the sample Blazor WebAssembly app to GitHub Pages from `main`. It defaults to `/<repository-name>/` and can be overridden with a `PAGES_BASE_PATH` repository variable.

## Installation

```bash
dotnet add package TimeAgo
```

## Usage

```razor
@using TimeAgo

<TimeAgoComponent Date="@DateTime.UtcNow.AddMinutes(-3)" />
```
