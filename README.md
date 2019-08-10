## ![](http://i.imgur.com/llqIpX6.png) DigitalOcean API

[![GitHub Actions](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Ftrmcnvn%2FDigitalOcean.API%2Fbadge&label=build&logo=none)](https://actions-badge.atrox.dev/trmcnvn/DigitalOcean.API/goto)
[![NuGet version](https://img.shields.io/nuget/v/DigitalOcean.API.svg)](https://www.nuget.org/packages/DigitalOcean.API)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ftrmcnvn%2FDigitalOcean.API.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Ftrmcnvn%2FDigitalOcean.API?ref=badge_shield)

Implementation of the DigitalOcean API for .NET.

## Install

DigitalOcean.API is available from NuGet and GitHub Packages.

<details>
<summary>NuGet</summary>

```
dotnet add package DigitalOcean.API
```

</details>
<details>
<summary>GitHub</summary>

Make sure that you have followed these [steps](https://help.github.com/en/articles/configuring-nuget-for-use-with-github-package-registry#installing-a-package) to setup GitHub Packages.

```
dotnet add package DigitalOcean.API -s https://nuget.pkg.github.com/trmcnvn/index.json
```

</details>

## Examples / Documentation

<details>
  <summary>Account</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#account)

#### Get User Information

```csharp
var account = await client.Account.Get();
// => Models.Responses.Account
```

</details>
<details>
  <summary>Actions</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#actions)

#### List all Actions

```csharp
var actions = await client.Actions.GetAll();
// => IReadOnlyList<Models.Responses.Action>
```

#### Retreive an existing Action

```csharp
var action = await client.Actions.Get(36804636);
// => Models.Responses.Action
```

</details>
<details>
<summary>Block Storage</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/documentation/v2/#block-storage)

#### List all volumes

```csharp
var volumes = await client.Volumes.GetAll();
// => IReadOnlyList<Models.Responses.Volume>
```

#### Create a new volume

```csharp
var newVolume = new Models.Requests.Volume {
  SizeGigabytes = 10,
  Name = "example",
  Description = "Block store for examples",
  Region = "nyc1"
};
var volume = await client.Volumes.Create(newVolume);
// => Models.Responses.Volume
```

#### Retreive an existing volume

```csharp
var volume = await client.Volumes.Get("7724db7c-e098-11e5-b522-000f53304e51");
// => Models.Responses.Volume
```

#### Retreive an existing volume by name

```csharp
var volumes = await client.Volumes.GetByName("example", "nyc1");
// => IReadOnlyList<Models.Responses.Volume>
```

#### List snapshots for a volume

```csharp
var snapshots = await client.Volumes.GetSnapshots("7724db7c-e098-11e5-b522-000f53304e51");
// => IReadOnlyList<Models.Responses.Snapshot>
```

#### Create a snapshot from a volume

```csharp
var newSnapshot = new Models.Requests.VolumeSnapshot {
  Name = "big-data-snapshot"
};
var snapshot = await client.Volumes.CreateSnapshot("7724db7c-e098-11e5-b522-000f53304e51", newSnapshot);
// => Models.Responses.Snapshot
```

#### Delete a volume

```csharp
await client.Volumes.Delete("7724db7c-e098-11e5-b522-000f53304e51");
```

#### Delete a volume by name

```csharp
await client.Volumes.Delete("example", "nyc1");
```

#### Delete a volume by snapshot

```csharp
await client.Snapshots.Delete("12345");
```

</details>
<details>
<summary>Block Storage Actions</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/documentation/v2/#block-storage-actions)

#### Attach a volume to a Droplet

```csharp
var action = await client.VolumeActions.Attach("7724db7c-e098-11e5-b522-000f53304e51", 123456, "nyc1");
// => Models.Responses.Action
```

#### Attach a volume to a Droplet by name

```csharp
var action = await client.VolumeActions.AttachByName("example", 123456, "nyc1");
// => Models.Responses.Action
```

#### Remove a volume from a Droplet

```csharp
var action = await client.VolumeActions.Detach("7724db7c-e098-11e5-b522-000f53304e51", 123456, "nyc1");
// => Models.Responses.Action
```

#### Remove a volume from a Droplet by name

```csharp
var action = await client.VolumeActions.DetachByName("example", 123456, "nyc1");
// => Models.Responses.Action
```

#### Resize a volume

```csharp
var action = await client.VolumeActions.Resize("7724db7c-e098-11e5-b522-000f53304e51", 100, "nyc1");
// => Models.Responses.Action
```

#### List all actions for a volume

```csharp
var actions = await client.VolumeActions.GetActions("7724db7c-e098-11e5-b522-000f53304e51");
// => IReadOnlyList<Models.Responses.Action>
```

#### Retreive an existing volume action

```csharp
var action = await client.VolumeActions.GetAction("7724db7c-e098-11e5-b522-000f53304e51", 12345);
// => Models.Responses.Action
```

</details>
<details>
  <summary>CDN Endpoints</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#cdn-endpoints)

#### Create a new CDN endpoint

```csharp
var newEndpoint = new Models.Requests.CdnEndpoint {
  Origin = "static-images.nyc3.digitaloceanspaces.com",
  CertificateId = "892071a0-bb95-49bc-8021-3afd67a210bf",
  CustomDomain = "static.example.com",
  Ttl = 3600,
};
var endpoint = await client.CdnEndpoints.Create(newEndpoint);
// => Models.Responses.CdnEndpoint
```

#### Retreive an existing CDN endpoint

```csharp
var endpoint = await client.CdnEndpoints.Get("19f06b6a-3ace-4315-b086-499a0e521b76");
// => Models.Responses.CdnEndpoint
```

#### List all CDN endpoints

```csharp
var endpoints = await client.CdnEndpoints.GetAll();
// => IReadOnlyList<Models.Responses.CdnEndpoint>
```

#### Update an exisiting CDN endpoint

```csharp
var updatedEndpoint = new Models.Requests.CdnEndpoint {
  Ttl = 1800,
};
var endpoint = await client.CdnEndpoints.Update("19f06b6a-3ace-4315-b086-499a0e521b76", updatedEndpoint);
// => Models.Responses.CdnEndpoint
```

#### Delete a CDN endpoint

```csharp
await client.CdnEndpoints.Delete("19f06b6a-3ace-4315-b086-499a0e521b76");
```

#### Purge the cache for an existing CDN endpoint

```csharp
var files = new Models.Requests.PurgeCdnFiles {
  Files = new List<string> {
    "assets/img/hero.png",
    "assets/css/*",
  },
};
await client.CdnEndpoints.PurgeCache("19f06b6a-3ace-4315-b086-499a0e521b76", files);
```

</details>
<details>
<summary>Certificates</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#certificates)

#### Create a new custom Certificate

```csharp
var newCertificate = new Models.Requests.Certificate {
  Name = "web-cert-01",
  Type = "custom",
  PrivateKey = "-----BEGIN PRIVATE KEY-----",
  LeafCertificate = "-----BEGIN CERTIFICATE-----",
  CertificateChain = "-----BEGIN CERTIFICATE-----",
};
var certificate = await client.Certificates.Create(newCertificate);
// => IReadOnlyList<Models.Responses.Certificate>
```

#### Create a new Let's Encrypt Certificate

```csharp
var newCertificate = new Models.Requests.Certificate {
  Name = "le-cert-01",
  Type = "lets_encrypt",
  DnsNames = new List<string> {
    "www.example.com",
    "example.com",
  },
};
var certificate = await client.Certificates.Create(newCertificate);
// => IReadOnlyList<Models.Responses.Certificate>
```

#### Retreive an exisiting Certificate

```csharp
var certificate = await client.Certificates.Get("892071a0-bb95-49bc-8021-3afd67a210bf");
// => Models.Responses.Certificate
```

#### List all Certificates

```csharp
var certificates = await client.Certificates.GetAll();
// => IReadOnlyList<Models.Requests.Certificate>
```

#### Delete a Certificate

```csharp
await client.Certificates.Delete("892071a0-bb95-49bc-8021-3afd67a210bf");
```

</details>

<details>
<summary>Domains</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#domains)

#### List all Domains

```csharp
var domains = await client.Domains.GetAll();
// => IReadOnlyList<Models.Responses.Domain>
```

#### Create a new Domain

```csharp
var newDomain = new Models.Requests.Domain {
  Name = "example.com",
  IpAddress = "1.2.3.4",
};
var domain = await client.Domains.Create(newDomain);
// => Models.Responses.Domain
```

#### Retreive an existing Domain

```csharp
var domain = await client.Domains.Get("example.com");
// => Models.Responses.Domain
```

#### Delete a Domain

```csharp
await client.Domains.Delete("example.com");
```

</details>
<details>
<summary>Domain Records</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#domain-records)

#### List all Domain Records

```csharp
var records = await client.DomainRecords.GetAll();
// => IReadOnlyList<Models.Responses.DomainRecord>
```

#### Create a new Domain Record

```csharp
var newRecord = new Models.Requests.DomainRecord {
  Type = "A",
  Name = "www",
  Data = "162.10.66.0",
  Ttl = 1800,
};
var record = await client.DomainRecords.Create(newRecord);
// => Models.Responses.DomainRecord
```

#### Retreive an existing Domain Record

```csharp
var record = await client.DomainRecords.Get(3352896);
// => Models.Responses.DomainRecord
```

#### Update a Domain Record

```csharp
var updateRecord = new Models.Requests.UpdateDomainRecord {
  Name = "blog",
};
var record = await client.DomainRecords.Update(3352896, updateRecord);
// => Models.Responses.DomainRecord
```

#### Delete a Domain Record

```csharp
await client.DomainRecords.Delete();
```

</details>
<details>
  <summary>Droplets</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#droplets)

#### Create a new Droplet

```csharp
var newDroplet = new Models.Requests.Droplet {
  Name = "example.com",
  Region = "nyc3",
  Size = "s-lvcpu-1gb",
  Image = "ubuntu-16-04-x64",
  SshIdsOrFingerprints = new List<int> { 107149 },
  Backups = false,
  Ipv6 = true,
  Tags = new List<string> { "web" },
};
var droplet = await client.Droplets.Create(newDroplet);
// => Models.Responses.Droplet
```

#### Retreive an existing Droplet by id

```csharp
var droplet = await client.Droplets.Get(3164494);
// => Models.Responses.Droplet
```

#### List all Droplets

```csharp
var droplets = await client.Droplets.GetAll();
// => IReadOnlyList<Models.Responses.Droplet>
```

#### Listing Droplets by Tag

```csharp
var droplets = await client.Droplets.GetAllByTag("awesome");
// => IReadOnlyList<Models.Responses.Droplet>
```

#### List all available Kernels for a Droplet

```csharp
var kernels = await client.Droplets.GetKernels(3164494);
// => IReadOnlyList<Models.Responses.Kernel>
```

#### List snapshots for a Droplet

```csharp
var snapshots = await client.Droplets.GetSnapshots(3164494);
// => IReadOnlyList<Models.Responses.Image>
```

#### List backups for a Droplet

```csharp
var backups = await client.Droplets.GetBackups(3164494);
// => IReadOnlyList<Models.Responses.Image>
```

#### List actions for a Droplet

```csharp
var actions = await client.Droplets.GetActions(3164494);
// => IReadOnlyList<Models.Responses.Action>
```

#### Delete a Droplet

```csharp
await client.Droplets.Delete(3164494);
```

#### Deleting Droplets by Tag

```csharp
await client.Droplets.DeleteByTag("awesome");
```

</details>
<details>
<summary>Droplet Actions</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#droplet-actions)

#### Disable Backups

```csharp
var action = await client.DropletActions.DisableBackups(3164450);
// => Models.Responses.Action
```

#### Reboot a Droplet

```csharp
var action = await client.DropletActions.Reboot(3164450);
// => Models.Responses.Action
```

#### Power Cycle a Droplet

```csharp
var action = await client.DropletActions.PowerCycle(3164450);
// => Models.Responses.Action
```

#### Shutdown a Droplet

```csharp
var action = await client.DropletActions.Shutdown(3164450);
// => Models.Responses.Action
```

#### Power Off a Droplet

```csharp
var action = await client.DropletActions.PowerOff(3164450);
// => Models.Responses.Action
```

#### Power On a Droplet

```csharp
var action = await client.DropletActions.PowerOn(3164450);
// => Models.Responses.Action
```

#### Restore a Droplet

```csharp
var action = await client.DropletActions.Restore(3164450, 12389723);
// => Models.Responses.Action
```

#### Password Reset a Droplet

```csharp
var action = await client.DropletActions.ResetPassword(3164450);
// => Models.Responses.Action
```

#### Resize a Droplet

```csharp
var action = await client.DropletActions.Resize(3164450, "1gb");
// => Models.Responses.Action
```

#### Rebuild a Droplet

```csharp
var action = await client.DropletActions.Rebuild(3164450, "ubuntu-16-04-x64");
// => Models.Responses.Action
```

#### Rename a Droplet

```csharp
var action = await client.DropletActions.Rename(3164450, "nifty-new-name");
// => Models.Responses.Action
```

#### Change the Kernel

```csharp
var action = await client.DropletActions.ChangeKernel(3164450, 991);
// => Models.Responses.Action
```

#### Enable IPv6

```csharp
var action = await client.DropletActions.EnableIpv6(3164450);
// => Models.Responses.Action
```

#### Enable Private Networking

```csharp
var action = await client.DropletActions.EnablePrivateNetworking(3164450);
// => Models.Responses.Action
```

#### Snapshot a Droplet

```csharp
var action = await client.DropletActions.Snapshot(3164450, "Nifty New Snapshot");
// => Models.Responses.Action
```

#### Retreive a Droplet Action

```csharp
var action = await client.DropletActions.GetDropletAction(3164444, 36804807);
// => Models.Responses.Action
```

</details>
<details>
<summary>Floating IPs</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#floating-ips)

#### List all Floating IPs

```csharp
var ips = await client.FloatingIps.GetAll();
// => IReadOnlyList<Models.Responses.FloatingIp>
```

#### Create a new Floating IP assigned to a Droplet

```csharp
var newIp = new Models.Requests.FloatingIp {
  DropletId = 123456
};
var ip = await client.FloatingIps.Create(newIp);
// => Models.Responses.FloatingIp
```

#### Create a new Floating IP assigned to a Region

```csharp
var newIp = new Models.Requests.FloatingIp {
  Region = "nyc3"
};
var ip = await client.FloatingIps.Create(newIp);
// => Models.Responses.FloatingIp
```

#### Retreive an existing Floating IP

```csharp
var ip = await client.FloatingIps.Get("1.2.3.4");
// => Models.Responses.FloatingIp
```

#### Delete a Floating IP

```csharp
await client.FloatingIps.Delete("1.2.3.4");
```

</details>
<details>
<summary>Floating IP Actions</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#floating-ip-actions)

#### Assign a Floating IP to a Droplet

```csharp
var action = await client.FloatingIpActions.Assign("1.2.3.4", 123456);
// => Models.Responses.Action
```

#### Unassign a Floating IP

```csharp
var action = await client.FloatingIpActions.Unassign("1.2.3.4");
// => Models.Responses.Action
```

#### List all actions for a Floating IP

```csharp
var actions = await client.FloatingIpActions.GetActions("1.2.3.4");
// => IReadOnlyList<Models.Responses.Action>
```

#### Retreive an existing Floating IP Action

```csharp
var action = await client.FloatingIpActions.GetAction("1.2.3.4", 123456);
// => Models.Responses.Action
```

</details>
<details>
<summary>Firewall</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/documentation/v2/#firewalls)

#### Create a new Firewall

```csharp
var newFirewall = new Models.Requests.Firewall {
  Name = "firewall",
  InboundRules = new List<Models.Requests.InboundRule> {
    new Models.Requests.InboundRule {
      Protocol = "tcp",
      Ports = "80",
      Sources = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          LoadBalancerUids = new List<string> { "123456" }
        }
      }
    }
  },
  OutboundRules = new List<Models.Requests.OutboundRule> {
    new Models.Requests.OutboundRule {
      Protocol = "tcp",
      Ports = "80",
      Destinations = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          Addressess = new List<string> { "0.0.0.0/0", "::/0" }
        }
      }
    }
  },
  DropletIds = new List<int> { 123456 }
};
var firewall = await client.Firewalls.Create(newFirewall);
// => Models.Responses.Firewall
```

#### Retreive an existing Firewall

```csharp
var firewall = await client.Firewalls.Get("bb4b2611-3d72-467b-8602-280330ecd65c");
// => Models.Responses.Firewall
```

#### List all Firewalls

```csharp
var firewalls = await client.Firewalls.GetAll();
// => IReadOnlyList<Models.Responses.Firewall>
```

#### Update a Firewall

```csharp
var updateFirewall = new Models.Requests.Firewall {
  Name = "firewall",
  InboundRules = new List<Models.Requests.InboundRule> {
    new Models.Requests.InboundRule {
      Protocol = "tcp",
      Ports = "80",
      Sources = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          LoadBalancerUids = new List<string> { "123456" }
        }
      }
    }
  },
  OutboundRules = new List<Models.Requests.OutboundRule> {
    new Models.Requests.OutboundRule {
      Protocol = "tcp",
      Ports = "80",
      Destinations = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          Addressess = new List<string> { "0.0.0.0/0", "::/0" }
        }
      }
    }
  },
  DropletIds = new List<int> { 123456 }
};
var firewall = await client.Firewalls.Update("bb4b2611-3d72-467b-8602-280330ecd65c", updateFirewall);
// => Models.Responses.Firewall
```

#### Delete a Firewall

```csharp
await client.Firewalls.Delete("bb4b2611-3d72-467b-8602-280330ecd65c");
```

#### Add Droplets to a Firewall

```csharp
var droplets = new Models.Requests.FirewallDroplets {
  DropletIds = new List<int> { 123456 }
};
await client.Firewalls.AddDroplets("bb4b2611-3d72-467b-8602-280330ecd65c", droplets);
```

#### Remove Droplets from a Firewall

```csharp
var droplets = new Models.Requests.FirewallDroplets {
  DropletIds = new List<int> { 123456 }
};
await client.Firewalls.RemoveDroplets("bb4b2611-3d72-467b-8602-280330ecd65c", droplets);
```

#### Add Tags to a Firewall

```csharp
var tags = new Models.Requests.FirewallTags {
  Tags = new List<string> { "awesome" }
};
await client.Firewalls.AddTags("bb4b2611-3d72-467b-8602-280330ecd65c", tags);
```

#### Remove Tags from a Firewall

```csharp
var tags = new Models.Requests.FirewallTags {
  Tags = new List<string> { "awesome" }
};
await client.Firewalls.RemoveTags("bb4b2611-3d72-467b-8602-280330ecd65c", tags);
```

#### Add rules to a Firewall

```csharp
var rules = new Models.Requests.FirewallRules {
  InboundRules = new List<Models.Requests.InboundRule> {
    new Models.Requests.InboundRule {
      Protocol = "tcp",
      Ports = "80",
      Sources = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          LoadBalancerUids = new List<string> { "123456" }
        }
      }
    }
  },
  OutboundRules = new List<Models.Requests.OutboundRule> {
    new Models.Requests.OutboundRule {
      Protocol = "tcp",
      Ports = "80",
      Destinations = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          Addressess = new List<string> { "0.0.0.0/0", "::/0" }
        }
      }
    }
  },
};
await client.Firewalls.AddRules("bb4b2611-3d72-467b-8602-280330ecd65c", rules);
```

#### Remove rules from a Firewall

```csharp
var rules = new Models.Requests.FirewallRules {
  InboundRules = new List<Models.Requests.InboundRule> {
    new Models.Requests.InboundRule {
      Protocol = "tcp",
      Ports = "80",
      Sources = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          LoadBalancerUids = new List<string> { "123456" }
        }
      }
    }
  },
  OutboundRules = new List<Models.Requests.OutboundRule> {
    new Models.Requests.OutboundRule {
      Protocol = "tcp",
      Ports = "80",
      Destinations = new List<Models.Requests.SourceLocation> {
        new Models.Requests.SourceLocation {
          Addressess = new List<string> { "0.0.0.0/0", "::/0" }
        }
      }
    }
  },
};
await client.Firewalls.RemoveRules("bb4b2611-3d72-467b-8602-280330ecd65c", rules);
```

</details>
<details>
<summary>Images</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#images)

#### List all Images

```csharp
var images = await client.Images.GetAll();
// => IReadOnlyList<Models.Responses.Image>
```

#### List all Distrubution Images

```csharp
var images = await client.Images.GetAll(Models.Requests.ImageType.Distrubution);
// => IReadOnlyList<Models.Responses.Image>
```

#### List all Application Images

```csharp
var images = await client.Images.GetAll(Models.Requests.ImageType.Application);
// => IReadOnlyList<Models.Responses.Image>
```

#### List a User's Images

```csharp
var images = await client.Images.GetAll(Models.Requests.ImageType.Private);
// => IReadOnlyList<Models.Responses.Image>
```

#### Retreive an existing Image by id

```csharp
var image = await client.Images.Get(7555620);
// => Models.Responses.Image
```

#### Retreive an existing Image by slug

```csharp
var image = await client.Images.Get("ubuntu-16-04-x64");
// => Models.Responses.Image
```

#### Update an Image

```csharp
var updateImage = new Models.Requests.UpdateImage {
  Name = "new-image-name",
};
var image = await client.Images.Update(7555620, updateImage);
// => Models.Responses.Image
```

#### Delete an Image

```csharp
await client.Images.Delete(7555620);
```

</details>
<details>
<summary>Image Actions</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#image-actions)

#### Transfer an Image

```csharp
var action = await client.ImageActions.Transfer(7938269, "nyc2");
// => Models.Responses.Action
```

#### Retreive an existing Image Action

```csharp
var action = await client.ImageActions.GetAction(7938269, 36805527);
// => Models.Responses.Action
```

</details>
<details>
<summary>Load Balancers</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#load-balancers)

#### Create a new Load Balancer

```csharp
var newBalancer = new Models.Requests.LoadBalancer {
  Name = "example-lb-01",
  Region = "nyc3",
  ForwardingRules = new List<Models.Requests.ForwardingRule> {
    new Models.Requests.ForwardingRule {
      EntryProtocol = "http",
      EntryPort = 80,
      TargetProtocol = "http",
      TargetPort = 80,
      CertificateId = "",
      TlsPassthrough = false,
    },
  },
  HealthCheck = new Models.Requests.HealthCheck {
    Protocol = "http",
    Port = 80,
    Path = "/",
    CheckIntervalSeconds = 10,
    ResponseTimeoutInSeconds = 5,
    HealthyThreshold = 5,
    UnhealthyThreshold = 3,
  },
  StickySessions = new Models.Requests.StickySessions {
    Type = "none",
  },
  DropletIds = new List<int> { 3164444, 3164445 },
};
var balancer = await client.LoadBalancers.Create(newBalancer);
// => Models.Responses.LoadBalancer
```

#### Create a new Load Balancer with Droplet Tag

```csharp
var newBalancer = new Models.Requests.LoadBalancer {
  Name = "example-lb-01",
  Region = "nyc3",
  ForwardingRules = new List<Models.Requests.ForwardingRule> {
    new Models.Requests.ForwardingRule {
      EntryProtocol = "http",
      EntryPort = 80,
      TargetProtocol = "http",
      TargetPort = 80,
      CertificateId = "",
      TlsPassthrough = false,
    }
  },
  HealthCheck = new Models.Requests.HealthCheck {
    Protocol = "http",
    Port = 80,
    Path = "/",
    CheckIntervalSeconds = 10,
    ResponseTimeoutInSeconds = 5,
    HealthyThreshold = 5,
    UnhealthyThreshold = 3,
  },
  StickySessions = new Models.Requests.StickySessions {
    Type = "none",
  },
  Tag = "web:prod",
};
var balancer = await client.LoadBalancers.Create(newBalancer);
// => Models.Responses.LoadBalancer
```

#### Retreive an existing Load Balancer

```csharp
var balancer = await client.LoadBalancers.Get("4de7ac8b-495b-4884-9a69-1050c6793cd6");
// => Models.Responses.LoadBalancer
```

#### List all Load Balancers

```csharp
var balancers = await client.LoadBalancers.GetAll();
// => IReadOnlyList<Models.Responses.LoadBalancer>
```

#### Update a Load Balancer

```csharp
var updateBalancer = new Models.Requests.LoadBalancer {
  Name = "example-lb-01",
  Region = "nyc3",
  Algorithm = "least_connections",
  ForwardingRules = new List<Models.Requests.ForwardingRule> {
    new Models.Requests.ForwardingRule {
      EntryProtocol = "http",
      EntryPort = 80,
      TargetProtocol = "http",
      TargetPort = 80,
    }
  },
  HealthCheck = new Models.Requests.HealthCheck {
    Protocol = "http",
    Port = 80,
    Path = "/",
    CheckIntervalInSeconds = 10,
    ResponseTimeoutInSeconds = 5,
    HealthyThreshold = 5,
    UnhealthyThreshold = 3,
  },
  StickySessions = new Models.Requests.StickySessions {
    Type = "cookies",
    CookieName = "DO_LB",
    CookieTtlInSeconds = 300,
  },
  DropletIds = new List<int> { 3164444, 3164445 },
};
var balancer = await client.LoadBalancers.Update("4de7ac8b-495b-4884-9a69-1050c6793cd6", updateBalancer);
// => Models.Responses.LoadBalancer
```

#### Delete a Load Balancer

```csharp
await client.LoadBalancers.Delete("4de7ac8b-495b-4884-9a69-1050c6793cd6");
```

#### Add Droplets to a Load Balancer

```csharp
var droplets = new Models.Requests.LoadBalancerDroplets {
  DropletIds = new List<int> { 3164446, 3164447 },
};
await client.LoadBalancers.AddDroplets("4de7ac8b-495b-4884-9a69-1050c6793cd6", droplets);
```

#### Remove Droplets from a Load Balancer

```csharp
var droplets = new Models.Requests.LoadBalancerDroplets {
  DropletIds = new List<int> { 3164446, 3164447 },
};
await client.LoadBalancers.RemoveDroplets("4de7ac8b-495b-4884-9a69-1050c6793cd6", droplets);
```

#### Add forwarding rules to a Load Balancer

```csharp
var rules = new Models.Requests.ForwardingRulesList {
  ForwardingRules = new List<Models.Requests.ForwardingRule> {
    EntryProtocol = "tcp",
    EntryPort = 3306,
    TargetProtocol = "tcp",
    TargetPort = 3306,
  },
};
await client.LoadBalancers.AddForwardingRules("4de7ac8b-495b-4884-9a69-1050c6793cd6", rules);
```

#### Remove forwarding rules from a Load Balancer

```csharp
var rules = new Models.Requests.ForwardingRulesList {
  ForwardingRules = new List<Models.Requests.ForwardingRule> {
    EntryProtocol = "tcp",
    EntryPort = 3306,
    TargetProtocol = "tcp",
    TargetPort = 3306,
  },
};
await client.LoadBalancers.RemoveForwardingRules("4de7ac8b-495b-4884-9a69-1050c6793cd6", rules);
```

</details>
<details>
<summary>Projects</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#projects)

#### Create a Project

```csharp
var newProject = new Models.Requests.Project {
  Name = "my-web-api",
  Description = "My Website API",
  Purpose = Models.Requests.Project.Purposes.ServiceOrApi,
  Environment = Models.Requests.Project.Environments.Production,
};
var project = await client.Projects.Create(newProject);
// => Models.Responses.Project
```

#### List All Projects

```csharp
var projects = await client.Projects.GetAll();
// => IReadOnlyList<Models.Responses.Project>
```

#### Update a Project

```csharp
var updateProject = new Models.Requests.UpdateProject {
  Name = "my-web-api",
  Description = "My Website API",
  Purpose = Models.Requests.Project.Purposes.ServiceOrApi,
  Environment = Models.Requests.Project.Environments.Staging,
  IsDefault = false,
};
var project = await client.Projects.Update("4e1bfbc3-dc3e-41f2-a18f-1b4d7ba71679", updateProject);
// => Models.Responses.Project
```

#### Patch a Project

```csharp
var patchProject = new Models.Requests.PatchProject {
  Environment = Models.Requests.Project.Environments.Staging,
};
var project = await client.Projects.Patch("4e1bfbc3-dc3e-41f2-a18f-1b4d7ba71679", patchProject);
// => Models.Responses.Project
```

#### Retreive an existing Project

```csharp
var project = await client.Projects.Get("4e1bfbc3-dc3e-41f2-a18f-1b4d7ba71679");
// => Models.Responses.Project
```

#### Retreive the Default Project

```csharp
var project = await client.Projects.GetDefault();
// => Models.Responses.Project
```

#### Update the Default Project

```csharp
var updateProject = new Models.Requests.UpdateProject {
  Name = "my-web-api",
  Description = "My Website API",
  Purpose = Models.Requests.Project.Purposes.ServiceOrApi,
  Environment = Models.Requests.Project.Environments.Staging,
  IsDefault = false,
};
var project = await client.Projects.UpdateDefault(updateProject);
// => Models.Responses.Project
```

#### Patch the Default Project

```csharp
var updateProject = new Models.Requests.PatchProject {
  Environment = Models.Requests.Project.Environments.Staging,
};
var project = await client.Projects.PatchDefault(updateProject);
// => Models.Responses.Project
```

</details>
<details>
<summary>Project Resources</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#project-resources)

#### List all Resources

```csharp
var resources = await client.ProjectResources.GetResources("4e1bfbc3-dc3e-41f2-a18f-1b4d7ba71679");
// => IReadOnlyList<Models.Responses.ProjectResource>
```

#### Assign Resources

```csharp
var newResources = new Models.Requests.AssignResourcesNames {
  Resources = new List<string> { "do:droplet:1", "do:floatingip:192.168.99.100", },
};
var resources = await client.ProjectResources.AssignResources("4e1bfbc3-dc3e-41f2-a18f-1b4d7ba71679", newResources);
// => IReadOnlyList<Models.Responses.ProjectResource>
```

#### List Default Project Resources

```csharp
var resources = await client.ProjectResources.GetDefaultResources();
// => IReadOnlyList<Models.Responses.ProjectResource>
```

#### Assign Default Project Resources

```csharp
var newResources = new Models.Requests.AssignResourcesNames {
  Resources = new List<string> { "do:droplet:1", "do:floatingip:192.168.99.100", },
};
var resources = await client.ProjectResources.AssignDefaultResources("4e1bfbc3-dc3e-41f2-a18f-1b4d7ba71679", newResources);
// => IReadOnlyList<Models.Responses.ProjectResource>
```

</details>
<details>
<summary>Regions</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#regions)

#### List all Regions

```csharp
var regions = await client.Regions.GetAll();
// => IReadOnlyList<Models.Responses.Region>
```

</details>
<details>
<summary>Sizes</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#sizes)

#### List all Sizes

```csharp
var sizes = await client.Sizes.GetAll();
// => IReadOnlyList<Models.Responses.Sizes>
```

</details>
<details>
<summary>Snapshots</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#snapshots)

#### List all snapshots

```csharp
var snapshots = await client.Snapshots.GetAll();
// => IReadOnlyList<Models.Responses.Snapshot>
```

#### List all Droplet snapshots

```csharp
var snapshots = await client.Snapshots.GetAll(Models.Requests.Snapshot.SnapshotType.Droplet);
// => IReadOnlyList<Models.Responses.Snapshot>
```

#### List all volume snapshots

```csharp
var snapshots = await client.Snapshots.GetAll(Models.Requests.Snapshot.SnapshotType.Volume);
// => IReadOnlyList<Models.Responses.Snapshot>
```

#### Retreive an existing snapshot by id

```csharp
var snapshot = await client.Snapshots.Get("fbe805e8-866b-11e6-96bf-000f53315a41");
// => Models.Responses.Snapshot
```

#### Delete a snapshot

```csharp
await client.Snapshots.Delete("fbe805e8-866b-11e6-96bf-000f53315a41");
```

</details>
<details>
<summary>SSH Keys</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#ssh-keys)

#### List all Keys

```csharp
var keys = await client.Keys.GetAll();
// => IReadOnlyList<Models.Responses.Key>
```

#### Create a new Key

```csharp
var newKey = new Models.Requests.Key {
  Name = "My SSH Public Key",
  PublicKey = "ssh-rsa AAAAB3NzaC1yc....",
};
var key = await client.Keys.Create(newKey);
// => Models.Responses.Key
```

#### Retreive an existing Key

```csharp
var key = await client.Keys.Get(512190);
// => Models.Responses.Key
```

```csharp
var key = await client.Keys.Get("3b:16:bf:e4:8b:00:8b:b8:59:8c:a9:d3:f0:19:45:fa");
// => Models.Responses.Key
```

#### Update a Key

```csharp
var updateKey = new Models.Requests.Key {
  Name = "Renamed SSH Key",
};
var key = await client.Keys.Update(512190, updateKey);
```

```csharp
var updateKey = new Models.Requests.UpdateKey {
  Name = "Renamed SSH Key",
};
var key = await client.Keys.Update("3b:16:bf:e4:8b:00:8b:b8:59:8c:a9:d3:f0:19:45:fa", updateKey);
```

#### Delete a Key

```csharp
await client.Keys.Delete(512190);
```

```csharp
await client.Keys.Delete("3b:16:bf:e4:8b:00:8b:b8:59:8c:a9:d3:f0:19:45:fa");
```

</details>
<details>
<summary>Tags</summary>

[DigitalOcean Documentation](https://developers.digitalocean.com/Documentation/v2/#tags)

#### Create a new Tag

```csharp
var newTag = new Models.Requests.Tag {
  Name = "awesome",
};
var tag = await client.Tags.Create(newTag);
// => Models.Responses.Tag
```

#### Retreive a Tag

```csharp
var tag = await client.Tags.Get("awesome");
// => Models.Responses.Tag
```

#### List all Tags

```csharp
var tags = await client.Tags.GetAll();
// => IReadOnlyList<Models.Responses.Tag>
```

#### Tag a Resource

```csharp
var resources = new Models.Requests.TagResources {
  Resources = new List<Models.Requests.Tag> {
    new Models.Requests.Tag {
      Id = "9569411",
      Type = "droplet",
    },
    New Models.Requests.Tag {
      Id = "7555620",
      Type = "image",
    },
  }
};
await client.Tags.Tag("awesome", resources);
```

#### Untag a Resource

```csharp
var resources = new Models.Requests.TagResources {
  Resources = new List<Models.Requests.Tag> {
    new Models.Requests.Tag {
      Id = "9569411",
      Type = "droplet",
    },
    New Models.Requests.Tag {
      Id = "7555620",
      Type = "image",
    },
  }
};
await client.Tags.Untag("awesome", resources);
```

#### Delete a Tag

```csharp
await client.Tags.Delete("awesome");
```

</details>
