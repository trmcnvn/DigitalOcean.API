# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [5.2.0]

### Added

- Added ContainerRegistry client. (@JoshClose)

## [5.1.0]

### Added

- Managed Databases: Firewall and SQL Mode Management (@Nicholi)
- Kubernetes node_pools now contain a user-defined labels object (@Nicholi)
- New prop for DatabaseUsers, mysql_settings, used to specify auth_plugin (@Nicholi)
- New VPC Endpoint (@Nicholi)

### Changed

- Droplet neighbors endpoint deprecated (@Nicholi)

## [5.0.1]

### Fixed

- Updated function signatures for `int` -> `long` changes (@azakhi)

## [5.0.0]

### Fixed

- Breaking: Updated `Id` types across Response models to be a `long` type rather than `int` (Thanks @azakhi)

## [4.1.1]

### Fixed

- Updated RateLimit header tags to match actual response. (@azakhi)

## [4.1.0]

### Added

- Support for Balance API. (@podobaas)

### Fixed

- Typo on Address property of SourceLocation. (@podobaas)

### Changed

- Updated RestSharp to 106.9

## [4.0.1]

### Fixed

- Fixed the `Source` and `Destination` fields of the Firewall Inbound/Outbound rules to be in the expected format. (@azakhi)

## [4.0.0]

### Added

- Support for Databases, Kubernetes, Block Storage, Firewalls, Floating IPs.
- Missing features for already supported API:
  - Create multiple droplets
  - List neighbors for a droplet
  - List all droplet neighbors
  - Enable backups on a droplet
  - Acting on droplets via a tag
  - Creating a custom image
  - Listing images via a tag
  - Listing all actions for an image
  - Converting an image to a snapshot
- This package is now also available via GitHub's new package registry.

### Changed

- Dependency Updates
  - RestSharp 106.2.1 -> 106.6.10
  - Newtonsoft.Json 10.0.3 -> 12.0.2
- A number of fields and models were changed to make the codebase more consistent with itself and the API.
  - `RegionSlug`, `SizeSlug`, `ImageIdOrSlug`, `SshIdsOrFingerprints` were renamed to `Region`, `Size`, `Image`, `SshKeys` to match the API.

### Fixed

- Load Balancer functions now correctly take a string rather than an int for their ID fields.

### Removed

- `Droplets.GetUpgrades` was removed.

## [3.1.0] - 2019-08-07

### Added

- Support for Account API (@Nicholi)
- Support for Projects API (@Nicholi)
- Support for Snapshots API (@Nicholi)

## [3.0.0] - 2019-08-02

### Changed

- Changed DomainRecord's `TTL` property to `Ttl`.
- Changed UpdateCdnEndpoint's `TTL` property to `Ttl`.

## [2.4.0] - 2019-08-02

### Added

- Added CDN Endpoint and Certificate support (@Nicholi)

## [2.3.0] - 2019-08-01

### Added

- Added Project Resources API Support (@Nicholi)

## [2.2.0] - 2019-04-30

### Added

- Add monitoring property to Droplet (@Nicholi)

## [2.1.1] - 2019-04-26

### Fixed

- Fixed issue with serialization of Load Balancer (@AlisterGreg)

[unreleased]: https://github.com/trmcnvn/DigitalOcean.API/compare/v3.1.0...HEAD
[3.1.0]: https://github.com/trmcnvn/DigitalOcean.API/compare/v3.0.0...v3.1.0
[3.0.0]: https://github.com/trmcnvn/DigitalOcean.API/compare/v2.4.0...v3.0.0
[2.4.0]: https://github.com/trmcnvn/DigitalOcean.API/compare/v2.3.0...v2.4.0
[2.3.0]: https://github.com/trmcnvn/DigitalOcean.API/compare/v2.2.0...v2.3.0
[2.2.0]: https://github.com/trmcnvn/DigitalOcean.API/compare/v2.1.1...v2.2.0
[2.1.1]: https://github.com/trmcnvn/DigitalOcean.API/releases/tag/v2.1.1
