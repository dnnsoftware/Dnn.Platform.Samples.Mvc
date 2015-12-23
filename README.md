Sample projects to create MVC and SPA modules using DNN Platform 8.0


## Solution Structure
Dnn.ContactList.Api - The data repository for the Contact object

Dnn.ContactList.Mvc - A sample module showcasing MVC support

Dnn.ContactList.Spa - A sample module showcasing SPA support

Dnn.ContactList.Tests - Unit test project for the APIs defined in Dnn.ContactList.Api 

## Public Nuget Server
The solution depends on following DNN Platform 8.0 nuget packages

DotNetNuke.Core

DotNetNuke.Web

DotNetNuke.Web.Mvc

The nuget packages can be downloaded from our public Nuget server (no credentials needed)

https://build.dnnsoftware.com/guestAuth/app/nuget/v1/FeedService.svc/

## Install Package Location
Once compiled in RELEASE mode, the installable packages can be obtained from [SOURCE_FOLDER]\Website\Install\Module folder

Following packages are created:

1. DNN_ContactList_Mvc_01.00.01_Install.zip

2. DNN_ContactList_SPA_01.00.00_Install.zip

## Download Intall Packages without Compiling

You may download both the MVC and SPA install-packages without compiling from:

The zip file can be downloaded by clicking the link to zip files individually and then clicking the Raw button to download

https://github.com/dnnsoftware/Dnn.Platform.Samples.Mvc/tree/master/Website/Install/Module

## Download latest version of DNN Platform

You may download the latest version of DNN Platform by either

1. Going directly to the DNN's Team City build server. Login as Guest and go into Packaging step. Download the DNN_Platform_XXXX_Install.zip file from Artifact area. 

https://build.dnnsoftware.com

2. Get from nightly build 

http://www.dnnsoftware.com/platform/build/nightly-builds

DNN's build server (1 above) will get you the latest version of the installation package of DNN Platform.

## Fork
The original code is forked from https://github.com/cnurse/DnnConnect.Demo



