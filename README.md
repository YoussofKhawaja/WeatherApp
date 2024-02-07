# WeatherApp DevOps Project

Welcome to the WeatherApp DevOps project repository. This project aims to manage the deployment and CI/CD pipelines for the WeatherApp, which consists of frontend code and utilizes an Arduino project with ESP8266 and DHT11 sensor as a submodule. Additionally, the backend is built with an ASP.NET API and a database.

## Branches

This repository contains two main branches:

- **main**: Production-ready branch, used for stable releases.
- **development**: Branch for ongoing development work.

## Workflows

### Main Workflow

The main workflow is responsible for deploying changes to the production environment.

- **Trigger**: Automatically triggered on pushes to the main branch.
- **Actions**:
  - Build and test frontend code.
  - Deploy frontend changes to the AWS server using Amazon EKS.

### Development Workflow

The development workflow is used for testing changes in a development environment.

- **Trigger**: Automatically triggered on pushes to the development branch.
- **Actions**:
  - Build and test frontend code.
  - Deploy frontend changes to a development environment for testing.

## Server Infrastructure

We are utilizing AWS as our server infrastructure, leveraging Amazon EKS for container orchestration.

## Submodule

The WeatherApp frontend relies on a submodule for the backend, which includes an Arduino project with ESP8266 and DHT11 sensor, as well as an ASP.NET API backend with a database.

## Getting Started

To get started with the project:

1. Clone the repository: `git clone <repository-url>`
2. Ensure you have the necessary dependencies installed.
3. Follow instructions for setting up the submodule.
4. Start contributing to the project!

## Contributing

Contributions to the project are welcome! If you'd like to contribute, please follow the guidelines outlined in the CONTRIBUTING.md file.

## License

This project is licensed under the [MIT License](LICENSE).
