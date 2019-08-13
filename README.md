# Azure Logging and Monitoring Example

## Overview

Example of logging in Azure using [Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)

## Build Status 

Dev Stage
[![Build Status](https://dev.azure.com/slusk/Azure%20Logging%20Demo/_apis/build/status/scottluskcis.azure-logging-monitor?branchName=master)](https://dev.azure.com/slusk/Azure%20Logging%20Demo/_build/latest?definitionId=13&branchName=master)

## Setup for Running this Example

### Provision Azure Resources

1. First you will need to make a copy of the [azure-deploy.parameters.json](Ops/Provision/azure-dpeloy.parameters.json) file and name it `azure-deploy.parameters.local.json`. This will allow you to specify your changes without checking them into source control.
2. Review the newly created file and enter all the appropriate values for the parameters
3. Open a PowerShell Core prompt in the [Provision](Ops/Provision) directory
4. Execute the [azure-deploy.ps1](Ops/Provision/azure-deploy.ps1) script using a command similar to the following, be sure to set the values to match your values:

```powershell
& ./azure-deploy `
  -Subscription "<your subscription name or guid>" `
  -ResourceGroupName "<your resource group name>" `
  -ResourceGroupLocation "<location closest to you>" `
  -TemplatefilePath "azure-deploy.json" `
  -ParametersFilePath "azure-deploy.parameters.local.json"
```

5. Login to [Azure Portal](https://portal.azure.com/) and verify the resource group contains the resources.

### Setup Azure DevOps

* If you are new to Azure Pipelines be sure to read up on the article [Create your first pipeline](https://docs.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=tfs-2018-2) and [Get started with Azure Pipelines](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/overview?view=azure-devops)
* The [azure-pipelines.yml](azure-pipelines.yml) contains most everything necessary for the CI/CD pipelines. 
* You will need to create a [Service Connection](https://docs.microsoft.com/en-us/azure/devops/pipelines/library/connect-to-azure?view=azure-devops). This Service Connection is referenced in the [azure-pipelines.yml](azure-pipelines.yml) file in the `subscription` variable. 
* Additionally you will need to create a pipeline variable named `appServiceName` with the value that corresponds to what was specified in `azure-deploy.parameters.local.json` file
* You may need to also authorize your Service Connection to have access to the Resource Group that contains the [provisioned resources](#provision-azure-resources)

## Simple Example using Logging

The first and simplest example of logging is to use the [LoggingAPI] project which is a really simple example to quickly get a log message into AppInsights.