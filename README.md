# ValdemoroEn1
<p align="center">
  <img src ="/images/logo.png?raw=true" width="200" />
</p>

Tu agenda de servicios en Valdemoro, toda la información en un mismo lugar.

* **Establecimientos.** Listado de establecimientos como bares y restaurantes, horarios, fotos, carta, teléfono y ubicación. Puedes saber en un click si están abiertos, si envían comida a domicilio y consultar la carta. Llama directamente al establecimiento, haz tu pedido.
* **Cartelera.** Consulta la cartelera de cine en tiempo real y compra tus entradas.
* **Precio de la gasolina.** Consulta el precio de la gasolina en tiempo real y dirígete a la gasolinera mediante GPS.
* **Tiempo y calidad del aire.** Consulta el tiempo y la calidad del aire en tiempo real.
* **Autobuses.** Consulta el horario en tiempo real de autobuses urbanos e interurbanos, localiza el número de parada en la marquesina y consulta el tiempo.
* **Cercanías.** Consulta el horario en tiempo real de los trenes de Valdemoro.

Your services in Valdemoro, all the information in one place.

* **Establishments.** List of establishments such as local restaurants, hours, photos, take-away menu, telephone and location. You can know in a click if they are open, call the establishment directly.
* **Billboard.** Check the movie billing in real time and buy your tickets.
* **Price of gasoline.** Check the price of gasoline in real time and go to the gas station using GPS.
* **Weather and air quality.** Check the weather and air quality in real time.
* **Buses.** Real-time schedule of urban and intercity buses, locate the bus stop number and check the time to your bus.
* **Train.** Check the real-time schedule of Valdemoro trains.

# History
Decido publicar el código fuente de mi aplicación en **[.NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/what-is-maui)** porque creo en el trabajo en comunidad, en que todas las personas aportemos nuestro granito de arena para el avance del código abierto y así aumentar nuestros conocimientos.

**ValdemoroEn1** es un proyecto que empecé con mucha ilusión en el 2015 en **[PhoneGap](https://es.wikipedia.org/wiki/PhoneGap)**, pero en 2017 decidí pasarlo a **[Xamarin Forms](https://learn.microsoft.com/es-es/xamarin/get-started/what-is-xamarin-forms)** y en 2023 a **[.NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/what-is-maui)**

Espero que podáis aprender con el proyecto 👋🏽

I decide to post the source code of my application in **[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui)** because I believe in community work, in which all of us contribute our bit to advance open source and thus increase our knowledge.

**ValdemoroEn1** is a project that I started with great enthusiasm for 2015 at **[PhoneGap](https://en.wikipedia.org/wiki/PhoneGap)**, but in 2017 I decided to move it to **[Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/get-started/what-is-xamarin-forms)** and in 2023 to **[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui)**

I hope you can learn with the project 👋🏽

# Geoportal Gasolineras API
* [Geoportal Gasolineras](https://geoportalgasolineras.es/geoportal-instalaciones/Inicio)
* [API Rest](https://sedeaplicaciones.minetur.gob.es/ServiciosRESTCarburantes/PreciosCarburantes/help)

# IQAir API
* [IQAir](https://www.iqair.com/es/)
* [API](https://api-docs.iqair.com/)

# CRTM API
* [CRTM](https://www.crtm.es/tu-transporte-publico.aspx)

# Google API and Firebase Auth
* [Places](https://developers.google.com/maps/documentation/places/web-service)
* [Auth](https://firebase.google.com/docs/auth)

## Firebase setup
1. Create a Firebase project in the [Firebase Console](https://console.firebase.google.com/), if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Go to the **Authentication** section and press select **Sign-in method**, in the Sign-in provides options, select and enable **Google** and **Email/Password**. 
3. Click **Add Firebase to your *Android* app** and follow the setup steps.
      * To enable Google Sign-In, we will need to provide Google with the package name, the name of the App and a SHA-1 certificate.
      * For the SHA-1 debug key you will need to modify the command below, open a CMD or Terminal.
      * ```keytool -list -v -keystore "PATH\debug.keystore" -alias androiddebugkey -storepass android -keypass android```
4. Put the SHA-1 in Certificate SHA-1 input.         
5. Download and add ```Google-services.json``` to your app project ```Platforms\Android``` and **build action** behaviour to ```GoogleServicesJson``` by Right clicking/Build.

5. Click **Add Firebase to your *iOS* app** and follow the setup steps. (Coming soon)

## Google cloud setup
1. Enable APIS in the [Google cloud](https://developers.google.com/maps/documentation/places/web-service/cloud-setup)
2. Use API keys [Get api key](https://developers.google.com/maps/documentation/places/web-service/get-api-key)
3. Put api key in ```AppSettings ApiKey```

# Tools used
* [MVVM Community Toolkit](https://aka.ms/mvvmtoolkit/docs)
* [NET MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui)
* [Firebase](https://github.com/TobiasBuchholz/Plugin.Firebase)
* [HttpClient](https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/rest)
* [Google Api](https://github.com/vivet/GoogleApi)

# Architecture
The application has a clean and tidy architecture, applying the best practices, MVVM and pattern feature-oriented.

# Features
  * Shell
  * XAML
  * CollectionView
  * SwipeView
  * RefreshView
  * MVVM
  * DI
  * Custom Controls
  * Bindings/Relative
  * Converters
  * Triggers
  * Extensions
  * Font Awesome
  * Global Usings
  * Multi-Language Localization
  
# Platforms
  * Android
  * iOS (coming soon)

# Demo
#### Android

<img src ="/images/menu.png?raw=true" width="200" /> <img src ="/images/list.png?raw=true" width="200" />

# Download
<a href="https://play.google.com/store/apps/details?id=es.valtimoretec.valdemoroenuno" target="_blank">
  <img width="200" src="/images/googleplay.png?raw=true"/>
</a>

# Copyright and license
Copyright 2023 by Ángel Rubén

Code released under the [MIT license](https://en.wikipedia.org/wiki/MIT_License)
