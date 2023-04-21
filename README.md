# ValdemoroEn1
<p align="center">
  <img src ="/images/logo.png?raw=true" width="200" />
</p>

Tu agenda de servicios en Valdemoro, toda la información en un mismo lugar.

Si eres un amante del teatro, consulta la selección de obras y compra tus entradas con facilidad.

¿Prefieres el cine? No te pierdas la cartelera en tiempo real y asegúrate de conseguir tus entradas a tiempo.

Si necesitas llenar el depósito de tu coche, consulta el precio de la gasolina en tiempo real y encuentra la gasolinera más cercana gracias a la navegación GPS.

¿Te preocupa el clima y la calidad del aire? Obtén información actualizada al instante para que puedas planificar tus actividades con confianza.

Además, si necesitas utilizar transporte público, conoce el horario en tiempo real de los autobuses urbanos e interurbanos, localiza tu parada en la marquesina y consulta el tiempo de espera estimado. Si necesitas información sobre cercanías, también puedes consultar los horarios de los trenes en tiempo real.

# History
Decido publicar el código fuente de mi aplicación en **[.NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/what-is-maui)** porque creo en el trabajo en comunidad, en que todas las personas aportemos nuestro granito de arena para el avance del código abierto y así aumentar nuestros conocimientos.

**ValdemoroEn1** es un proyecto que empecé con mucha ilusión en el 2015 en **[PhoneGap](https://es.wikipedia.org/wiki/PhoneGap)**, pero en 2017 decidí pasarlo a **[Xamarin Forms](https://learn.microsoft.com/es-es/xamarin/get-started/what-is-xamarin-forms)** y en 2023 a **[.NET MAUI](https://learn.microsoft.com/es-es/dotnet/maui/what-is-maui)**

Espero que podáis aprender con el proyecto 👋🏽

# Geoportal Gasolineras API
* [Geoportal Gasolineras](https://geoportalgasolineras.es/geoportal-instalaciones/Inicio)
* [API Rest](https://sedeaplicaciones.minetur.gob.es/ServiciosRESTCarburantes/PreciosCarburantes/help)

# IQAir API
* [IQAir](https://www.iqair.com/es/)
* [API](https://api-docs.iqair.com/)

# CRTM API
* [CRTM](https://www.crtm.es/tu-transporte-publico.aspx)

# Firebase
* [Auth](https://firebase.google.com/docs/auth)
* [Cloud Messaging](https://firebase.google.com/docs/cloud-messaging)

# Google Places API
* [Places](https://developers.google.com/maps/documentation/places/web-service)

# Tools used
* [.NET MAUI](https://github.com/dotnet/maui)
* [.NET MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui)
* [MVVM Community Toolkit](https://aka.ms/mvvmtoolkit/docs)
* [Plugin.Firebase](https://github.com/TobiasBuchholz/Plugin.Firebase)
* [Google Api](https://github.com/vivet/GoogleApi)
* [HttpClient](https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/rest)

# Firebase basic setup
1. Create a Firebase project in the [Firebase Console](https://console.firebase.google.com/), if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click Add Firebase to your **[iOS|Android]** app and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just download the config file.
3. Add **[GoogleService-Info.plist|google-services.json]** file to your app project.
4. Set **[GoogleService-Info.plist|google-services.json]** build action behaviour to **[Bundle Resource|GoogleServicesJson]** by Right clicking/Build Action.
5. Auth setup [Auth](https://github.com/TobiasBuchholz/Plugin.Firebase/blob/development/docs/auth.md)
6. Cloud Messaging setup [Cloud Messaging](https://github.com/TobiasBuchholz/Plugin.Firebase/blob/development/docs/cloud_messaging.md)

## Google cloud setup
1. Enable APIS in the [Google cloud](https://developers.google.com/maps/documentation/places/web-service/cloud-setup)
2. Use API keys [Get api key](https://developers.google.com/maps/documentation/places/web-service/get-api-key)

# Api Keys Setup, create a class
```
public class AppKeys
{
    //IQAir
    public const string IQAirApiKey = "API KEY";

    //Google
    public const string GooglePlacesKey = "API KEY";
}
```

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
  * Visual states
  * Extensions
  * Font Awesome
  * Global Usings
  * Multi-Language Localization
  
# Platforms
  * Android
  * iOS

# Demo
 
# Download
<a href="https://play.google.com/store/apps/details?id=es.valtimoretec.valdemoroenuno" target="_blank">
  <img width="200" src="/images/googleplay.png?raw=true"/>
</a>

<a href="https://apps.apple.com/es/app/valdemoroen1/id6447635266" target="_blank">
  <img width="200" src="/images/applestore.jpg?raw=true"/>
</a>

# Copyright and license
Copyright 2023 by Ángel Rubén

Code released under the [MIT license](https://en.wikipedia.org/wiki/MIT_License)
