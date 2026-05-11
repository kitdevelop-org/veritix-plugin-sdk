# Veritix Plugin SDK

Official Software Development Kit for extending the **Veritix ERP** ecosystem.

## Overview

The Veritix SDK provides the foundational abstractions and services required to build modern, multi-tenant, and modular plugins for Veritix ERP. It standardizes fiscal compliance, performance monitoring, logging, and multi-dialect localization.

## Installation

Install the SDK via NuGet:

```bash
dotnet add package Veritix.Plugin.SDK --source https://nuget.pkg.github.com/kitdevelop-org/index.json
```

## Key Capabilities

- **`IVtxLocalizer`**: Advanced localization engine supporting tenant-level overrides and regional dialects.
- **`IFiscalDocumentEngine`**: Unified interface for issuing fiscal documents (NCF, CUFE, CFDI) across multiple countries.
- **`IVtxMetricsService`**: Enterprise-grade business intelligence and performance tracking with historical persistence.
- **`IAppLogger`**: Standardized logging for plugins without core dependencies.
- **`PluginBase`**: The foundational class for plugin discovery and lifecycle management.

## Creating a Plugin

1. Inherit from `PluginBase`.
2. Configure your services in `ConfigureServices`.
3. Define your frontend manifest in the `Frontend` property.
4. Run `dotnet publish` to generate your `.vtx` package.

## Development

To build the SDK locally:

```bash
dotnet build Veritix.Plugin.SDK.sln
```

## License

Proprietary - KitDevelop S.R.L.
