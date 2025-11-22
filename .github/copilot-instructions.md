# Copilot Instructions for Acide.Latesa.Web

## Project Overview

This is a .NET 10.0 Blazor Server application (Acide.Latesa.Web). The project uses modern ASP.NET Core with Blazor components for interactive server-side rendering.

## Technology Stack

- **Framework**: .NET 10.0
- **Project Type**: Blazor Server (Interactive Server Components)
- **Language**: C# with nullable reference types enabled
- **UI Framework**: Blazor Razor Components
- **Formatting Tool**: CSharpier (version 1.2.1)

## Project Structure

```
/Web
├── Acide.Latesa.Web.csproj - Main project file
├── Program.cs - Application entry point
├── Components/ - Blazor components
│   ├── App.razor
│   ├── Routes.razor
│   ├── Layout/ - Layout components
│   └── Pages/ - Page components
├── Properties/ - Project properties
├── wwwroot/ - Static assets
└── appsettings.Example.json - Configuration template
```

## Development Guidelines

### Building and Running

- **Restore dependencies**: `dotnet restore`
- **Build project**: `dotnet build`
- **Run project**: `dotnet run --project Web` or `dotnet watch run --project Web`
- **Clean build artifacts**: `dotnet clean`

### Code Style and Formatting

- Use **CSharpier** for code formatting: `dotnet csharpier format .`
- Always format code before committing changes
- The project uses implicit usings and nullable reference types
- Follow C# and ASP.NET Core naming conventions

### Coding Standards

1. **Nullable Reference Types**: Always handle nullable values properly as the project has `<Nullable>enable</Nullable>`
2. **Implicit Usings**: Common namespaces are imported automatically via implicit usings
3. **Razor Components**: 
   - Place page components in `Components/Pages/`
   - Place layout components in `Components/Layout/`
   - Use `@page` directive for routable pages
   - Prefer interactive server render mode for components
4. **Dependency Injection**: Use constructor injection for services in components and classes
5. **Configuration**: Use `appsettings.json` for configuration, never commit sensitive data

### Blazor-Specific Guidelines

- Use `AddInteractiveServerComponents()` for server-side interactivity
- Components should follow the Blazor component lifecycle
- Use `@inject` for dependency injection in Razor components
- Handle exceptions properly with error boundaries
- Use `app.UseAntiforgery()` for CSRF protection

### Testing

- Write unit tests for business logic
- Test Blazor components using bUnit or similar frameworks
- Ensure tests cover edge cases and error scenarios

### Security

- Always use antiforgery tokens for forms
- Validate user input
- Use HTTPS in production (configured via `app.UseHsts()`)
- Never commit secrets or sensitive configuration to source control
- Use `appsettings.Example.json` as a template for required configuration

### Performance

- Use static asset optimization (`MapStaticAssets()`)
- Consider lazy loading for heavy components
- Optimize render tree updates in Blazor components

### Error Handling

- Development environment shows detailed error pages
- Production uses custom error handler at `/Error` route
- Status code pages redirect to `/not-found` for 404s
- Use `createScopeForErrors: true` for proper DI scope management

## Common Tasks

### Adding a New Page

1. Create a new `.razor` file in `Web/Components/Pages/`
2. Add `@page "/your-route"` directive
3. Define the component markup and code
4. Format with CSharpier before committing

### Adding a New Service

1. Define interface and implementation
2. Register service in `Program.cs` using `builder.Services.Add*`
3. Inject service where needed using constructor injection or `@inject`

### Modifying Configuration

1. Update `appsettings.json` or environment-specific files
2. Update `appsettings.Example.json` to document new settings
3. Never commit sensitive values

## Important Notes

- The project uses .NET 10.0 (cutting edge version)
- Interactive server render mode is the primary rendering mode
- Antiforgery protection is enabled globally
- Static asset optimization is enabled
- The project uses `BlazorDisableThrowNavigationException=true` to suppress navigation exceptions

## Getting Help

- Refer to [ASP.NET Core documentation](https://learn.microsoft.com/aspnet/core/)
- Refer to [Blazor documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- Check .NET 10 release notes for new features and changes
