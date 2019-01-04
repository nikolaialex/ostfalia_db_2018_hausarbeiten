## Anforderungen an ein DBMS für ML

### Prozess und Komponenten für ML abbilden

1) Wir beginnen mit einer Datei voller Trainingsdaten, die in einen Trainingsdatensatz geladen wird.
2) Es wird ein Trainingsverfahren durchgeführt, um ein Modell zu erstellen.
3) Das Modell wird verwendet, um eine Bewertungsfunktion zu parametrieren.
4) Diese Bewertungsfunktion ist über einen REST-Endpunkt für Echtzeit-Scoring zugänglich.
5) Die Scoring-Funktion ist auch über eine SQL-Abfrage zugänglich.
6) Ein Batch-Scoring-Verfahren verwendet SQL, um die Scoring-Funktion auf einen unbewerteten Datensatz im Batch anzuwenden und einen Scored Datensatz zu erzeugen.

#### Grob-Anforderungen

1) Datei Import
    2) Dataset
3) ML Algorithmus anwenden
    4) Prozeduren
5) Modell sichern
6) Funktionen
    7) REST Schnittstelle
    8) SQL Schnittstelle
    9) Batchbetrieb

