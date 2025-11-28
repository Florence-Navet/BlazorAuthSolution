# BlazorAuthSolution  
To put microsoft authentication in WASM, we need in the packages web :  
```
Microsoft.AspNetCore.Authorization (9.0.10)
Microsoft.AspNetCore.Components.WebAssembly (9.0.10)
Microsoft.AspNetCore.Components.WebAssembly.Authenfication (9.0.10)
Microsoft.AspNetCore.Components.WebAssembly.DevServer (9.0.9)
Microsoft.Authentication.WebAssembly.Msal (9.0.10)
Microsoft.Extentions.Http(9.0.10)
```

To put microsoft authentification in MAui, we need the packages :   
```
Microsoft.AspNetCore.Components.WebView.Maui (9.0.82)
Microsoft.Extension.Logging.Debugg(9.0.5)
Microsoft.Identity.Client(4.77.1)
Microsoft.Maui.Controls (9.0.82)
```

and probably  

```
MSAL
```
Créer un singleton IPublicClientApplication avec la configuration appropriée.  
1.	Déclencher la connexion  
Utiliser AcquireTokenInteractive pour lancer le flux d’authentification.  
2.	Gérer le callback et le stockage du token  
Utiliser le token pour vos appels API.    


