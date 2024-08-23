# Einrichtung

Um die notwendigen Packages aus dem privaten Package-Manager der co-IT aus GitHub zu laden, wird eine eigene `nuget.config` benötigt.

1. Stelle sicher, dass die [GitHub Cli](https://cli.github.com/) bei dir installiert ist
2. Falls du bisher noch nie eine `nuget.config` anlegen musstest führe `gh auth login --scopes read:packages` aus und verknüpfge deinen GitHub Account
3. Lege eine `nuget.config` Datei mit dem folgenden Inhalt an

```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <clear />
        <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
        <add key="github" value="https://nuget.pkg.github.com/co-IT/index.json" />
    </packageSources>
    <packageSourceCredentials>
        <github>
            <add key="Username" value="{Nutzername}" />
            <add key="ClearTextPassword" value="{Token}" />
        </github>
    </packageSourceCredentials>
</configuration>
```

4. Führe `gh api user -q ".login"` aus und ersetze `{Nutzername}` in der `nuget.config` mit dem Ergebnis
5. Führe `gh auth token` aus und ersetze `{Token}` in der `nuget.config` mit dem Ergebnis

In Zukunft, kannst du diese `nuget.config` auch für andere Tools und Projekte nutzen, die Zugriff auf den co-IT GitHub package manager benötigen und musst nicht mehr den Schritten von oben folgen
