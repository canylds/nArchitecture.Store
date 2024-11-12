<p align="center">
  <a href="https://github.com/kodlamaio-projects/nArchitecture/graphs/contributors"><img src="https://img.shields.io/github/contributors/canylds/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/network/members"><img src="https://img.shields.io/github/forks/canylds/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/stargazers"><img src="https://img.shields.io/github/stars/canylds/nArchitecture.svg?style=for-the-badge"></a>
  <a href="https://github.com/kodlamaio-projects/nArchitecture/issues"><img src="https://img.shields.io/github/issues/canylds/nArchitecture.svg?style=for-the-badge"></a>
</p><br />

## 💻 About The Project

This is an example [nArchitecture](https://github.com/canylds/nArchitecture) project, originally developed by Kodlama.io. Inspired by Clean Architecture, nArchitecture is a monolith project that demonstrates advanced development techniques. The project includes Clean Architecture, CQRS, Advanced Repository, Dynamic Querying, JWT, OTP, Role-Based Management, Distributed Caching (Redis), Logging (Serilog), and much more.

### Built With

[![](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/tr-tr/dotnet/welcome)

## ⚙️ Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 8

### Installation

1. Clone the repo
   ```sh
   git clone --recurse-submodules https://github.com/canylds/nArchitecture.git
   ```
2. Configure `appsettings.json` in WebAPI.
3. Run `Update-Database` command with Package Manager Console in WebAPI to create tables in sql server.

- Run the following command to update submodules
  ```sh
   git submodule update --remote
   ```

## 🚀 Usage

1. Run example WebAPI project `dotnet run --project src\starterProject\WebAPI`

### Analysis

1. If not, Install dotnet tool `dotnet tool restore`.
2. Run anaylsis command `dotnet roslynator analyze`

### Format

1. If not, Install dotnet tool `dotnet tool restore`.
2. Run format command `dotnet csharpier .`

## 🚧 Roadmap

See the [open issues](https://github.com/canylds/nArchitecture/issues) for a list of proposed features (and known issues).

## 📧 Contact

**Project Link:** [https://github.com/kodlamaio-projects/nArchitecture](https://github.com/canylds/nArchitecture)

<!-- ## 🙏 Acknowledgements
- []() -->
