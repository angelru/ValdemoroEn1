# ValdemoroEn1
<p align="center">
  <img src ="/images/logo.png?raw=true" width="200" />
</p>

Tu agenda de servicios en Valdemoro, toda la información en un mismo lugar.

* **Restauración.** Listado de bares y restaurantes, horarios, fotos, carta, teléfono y ubicación. Puedes saber en un click si están abiertos, si envían comida a domicilio y consultar la carta. Llama directamente al establecimiento, haz tu pedido.
* **Autobuses.** Consulta el horario en tiempo real de autobuses urbanos e interurbanos, localiza el número de parada en la marquesina y consulta el tiempo.
* **Cercanías.** Consulta el horario en tiempo real de los trenes de Valdemoro.

Your services in Valdemoro, all the information in one place.

* **Restaurants.** Local restaurants, hours, photos, take-away menu, telephone and location. You can know in a click if they are open, call the establishment directly.
* **Buses.** Real-time schedule of urban and intercity buses, locate the bus stop number and check the time to your bus.
* **Train.** Check the real-time schedule of Valdemoro trains.

# History
Decido publicar el código fuente de mi aplicación en **[.NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/what-is-maui)** porque creo en el trabajo en comunidad, en que todas las personas aportemos nuestro granito de arena para el avance del código abierto y así aumentar nuestros conocimientos.

**ValdemoroEn1** es un proyecto que empecé con mucha ilusión por el 2015 en **[PhoneGap](https://es.wikipedia.org/wiki/PhoneGap)**, pero en 2017 decidí pasarlo a **[Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/get-started/what-is-xamarin-forms)**, y ahora en 2022 a **[.NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/what-is-maui)**

Espero que podáis aprender con el proyecto 👋🏽

I decide to post the source code of my application in **[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui)** because I believe in community work, in which all of us contribute our bit to advance open source and thus increase our knowledge.

**ValdemoroEn1** is a project that I started with great enthusiasm for 2015 at **[PhoneGap](https://en.wikipedia.org/wiki/PhoneGap)**, but in 2017 I decided to move it to **[Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/get-started/what-is-xamarin-forms)**, and now in 2022 to **[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui)**

I hope you can learn with the project 👋🏽

# CRTM API
* [CRTM](https://www.crtm.es/tu-transporte-publico.aspx)

# Google API and Firebase Auth
* [Places](https://developers.google.com/maps/documentation/places/web-service)
* [Auth](https://firebase.google.com/docs/auth)

## Firebase setup
1. Create a Firebase project in the [Firebase Console](https://console.firebase.google.com/), if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your *[iOS|Android]* app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just download the config file.
3. Add ```[GoogleService-Info.plist|google-services.json]``` file to your app project.
4. Set ```[GoogleService-Info.plist|google-services.json]``` **build action** behaviour to ```[Bundle Resource|GoogleServicesJson]``` by Right clicking/Build Action.

## Google cloud setup
1. Create project and enable APIS in the [Google cloud](https://developers.google.com/maps/documentation/places/web-service/cloud-setup)
2. Use API keys [Get api key](https://developers.google.com/maps/documentation/places/web-service/get-api-key)
3. Put api key in (AppSetings)https://github.com/angelru/ValdemoroEn1/blob/6aa476d162472de061400c0643dbec2ca70154b6/src/ValdemoroEn1/Utils/AppSettings.cs#L19

# Tools used
* [MVVM Community Toolkit](https://github.com/CommunityToolkit/dotnet)
* [NET MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui)
* [Firebase](https://github.com/TobiasBuchholz/Plugin.Firebase)
* [Google Api](https://github.com/vivet/GoogleApi)

# Architecture
The application has a clean and tidy architecture, applying the best practices and MVVM.

# Features
  * XAML
  * Bindings
  * Converters
  * MVVM
  * DI
  * Custom Controls
  * Extensions
  * Font Awesome
  * Global Usings
  * Multi-Language Localization
  * Shell

# Demo
#### Android

<img src ="/images/menu.png?raw=true" width="200" /> <img src ="/images/list.png?raw=true" width="200" />

# Download
<a href="https://play.google.com/store/apps/details?id=es.valtimoretec.valdemoroenuno" target="_blank">
  <img width="200" src="/images/googleplay.png?raw=true"/>
</a>

# Copyright and license
Copyright 2022 by Ángel Rubén

Code released under the [MIT license](https://en.wikipedia.org/wiki/MIT_License)
