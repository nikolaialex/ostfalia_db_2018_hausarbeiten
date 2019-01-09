***

## Anforderungen an ein DBMS für ML

### Prozess und Komponenten für ML abbilden

1) Wir beginnen mit einer Datei voller Trainingsdaten, die in einen Trainingsdatensatz geladen wird.
2) Es wird ein Trainingsverfahren durchgeführt, um ein Modell zu erstellen.
3) Das Modell wird verwendet, um eine Bewertungsfunktion zu parametrieren.
4) Diese Bewertungsfunktion ist über einen REST-Endpunkt für Echtzeit-Scoring zugänglich.
5) Die Scoring-Funktion ist auch über eine SQL-Abfrage zugänglich.
6) Ein Batch-Scoring-Verfahren verwendet SQL, um die Scoring-Funktion auf einen unbewerteten Datensatz im Batch anzuwenden und einen Scored Datensatz zu erzeugen.

#### Anforderungen Data Mining

1) Verarbeitung unterschiedlichster Daten
2) Effizienz und Skalierbarkeit
3) Nützlichkeit, Sicherheit und Ausdruckskraft der Ergebnissen
4) Interaktives Mining in verschiedenen Abstraktionsebenen

#### Anforderungen ML-DB

1. Import
   2. Aufruf via Schnittstellen (REST,QL)
   3. Dataset (CSV,Erstellung,Vorlagen)
   4. Klassische Bearbeitung (Filter,Rules)
5. ML Algorithmus anwenden
   6. Performance
   7. Aufruf via Schnittstellen (REST,QL)
   8. Prozeduren
   9. Auto-Verallgemeinerung
   10. Auto-Zusammenfassung
   11. Auto-Charakterisierung
12. Modell (Ändern,Sichern)
13. Funktionen
   14. Aufruf via Schnittstellen (REST,QL)
   15. Batchbetrieb
16. Export (REST,QL)


[901]: Russell Jurney, 2017 - Agile Data Science 2.0

----

[< Datenbanken für ML](08_dbml.md)	|	[Vergleich von Datenbanken >](10_dbml_comparsion.md)
