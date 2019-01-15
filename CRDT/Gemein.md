[<- Kommunikation in Verteilten Systemen](Kom.md "Kommunikation in Verteilten Systemen")

# Gemeinsamer Datenbestand

Die gemeinsame Datenhaltung einer verteilten Anwendung besteht entweder aus einer einzelnen Datenbank, die von allen Komponenten gemeinsam genutzt wird oder aus einem Replikat des Datenbestands in jedem Knoten.

Ein verteilter Datenbestand ist oft wünschenswert, da er mehrere Vorteile hat

* Erfordert keine durchgehende Netzverbindung
* Lässt lokales Arbeiten zu, ohne auf Antwort aus dem Netz zu warten
* Vermeidet Zentralen Ausfall (single point of failure)

Die weiter oben illustrierten Probleme können im zentralen wie im verteilten Fall auftreten. CRDTs konzentrieren sich dabei auf den Fall replizierter Datenbestände, wobei insbesondere folgende Aspekte adressiert werden:

* Konsistenz replizierter Datenbestände (durch Konvergenz unabhängiger Aktualisierungen)
* Konflikte zwischen Datenaktualisierungen
    * Vertauschte Reihenfolge von Operationen
    * Mehrfachauslieferung
* Performanz
    * Zeitaufwand zur Konfliktbewältigung
    * Lese- und Schreibleistung
* Anwendbarkeit
* Nutzungskonzept mit geringem Lernaufwand

[Konsistenzmodelle ->](Konsistenzmodelle.md "Konsistenzmodelle")

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")