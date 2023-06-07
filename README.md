# dotnet-nrm
.NET tool of NPM registry manager.

<br/>

## Install

- **.NET CLI**

   ```powershell
   dotnet tool install dotnet-nrm -g
   ```

<br/>

## How to use

Just use this command to choose which registry to use:

```powershell
dotnet nrm
```

List all registries with this command:

```powershell
dotnet ls
```

Use this command to display response times for all registries:

```powershell
dotnet nrm ping
```

Use this command to set directly to use a registry:

```powershell
dotnet nrm use taobao
```

