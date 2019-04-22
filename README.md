## ![](http://i.imgur.com/llqIpX6.png) DigitalOcean API

[![Build status](https://ci.appveyor.com/api/projects/status/kowp84s9j95138r6/branch/master?svg=true)](https://ci.appveyor.com/project/vevix/digitalocean-api-p6bv8/branch/master)
[![NuGet version](https://img.shields.io/nuget/v/DigitalOcean.API.svg)](https://www.nuget.org/packages/DigitalOcean.API)

Implementation of the DigitalOcean API (v2) for .NET.

[![NuGet](http://i.imgur.com/M4DTYI4.png)](https://www.nuget.org/packages/DigitalOcean.API)

## Usage Examples

```csharp
var client = new DigitalOceanClient("api_token");
```

You can generate your API token from your [DigitalOcean Control Panel](https://cloud.digitalocean.com/settings/tokens/new)

```csharp
// Retrieving all Droplets
var droplets = await client.Droplets.GetAll();
// => IReadOnlyList<Droplet>
```

```csharp
// Retrieving all Domain Records
var records = await client.DomainRecords.GetAll();
// => IReadOnlyList<DomainRecord>
```

```csharp
// Rebooting a Droplet
var action = await client.DropletActions.Reboot(9001);
// => Action
```

```csharp
// Creating a new Droplet
var newDroplet = new Droplet {
  // ...
};
var droplet = await client.Droplets.Create(newDroplet);
// => Droplet
```

## Documentation

Check out the [DigitalOcean API](https://developers.digitalocean.com/) for in-depth details.

## License

Copyright (c) 2016 Thomas McNiven (vevix)

MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
