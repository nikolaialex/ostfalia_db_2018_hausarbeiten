## Anforderungen an ein DBMS für ML

Die wichtigste Voraussetzung nach [902] für ML in einer Datenbank ist die Erweiterbarkeit, die Nutzung von Stored Procedures (PLSQL), benutzerdefinierten Funktionen und Aggregationen. Diese Funktionen ermöglichen Anpassungen, die Elemente einer ML-Pipeline schnell und einfach ausführen zu können.

### Prozess und Komponenten für ML abbilden

1. Wir beginnen mit einer Datei voller Trainingsdaten, die in einen Trainingsdatensatz geladen wird.
2. Es wird ein Trainingsverfahren durchgeführt, um ein Modell zu erstellen.
3. Das Modell wird verwendet, um eine Bewertungsfunktion zu parametrieren.
4. Diese Bewertungsfunktion ist über einen REST-Endpunkt für Echtzeit-Scoring zugänglich.
5. Die Scoring-Funktion ist auch über eine SQL-Abfrage zugänglich.
6. Ein Batch-Scoring-Verfahren verwendet SQL, um die Scoring-Funktion auf einen unbewerteten Datensatz im Batch anzuwenden und einen Scored Datensatz zu erzeugen.

#### Anforderungen Data Mining

1. Verarbeitung unterschiedlichster Daten
2. Effizienz und Skalierbarkeit
3. Nützlichkeit, Sicherheit und Ausdruckskraft der Ergebnissen
4. Interaktives Mining in verschiedenen Abstraktionsebenen

#### Anforderungen ML-DB

1. Import
   1. Aufruf via Schnittstellen
   2. Dataset
   3. Klassische Bearbeitung
2. ML-Algorithmus anwenden
   1. Performance
   2. Aufruf via Schnittstellen
   3. Prozeduren
   4. Auto-Verallgemeinerung
   5. Auto-Zusammenfassung
   6. Auto-Charakterisierung
3. Modell
4. Funktionen
   1. Aufruf via Schnittstellen
   2. Batchbetrieb
5. Export

---

[901] Jurney, Russell: Agile Data Science 2.0

[902] Orenstein, Gary: Matching Modern Databases with ML and AI

---

[< Datenbanken für ML](08_dbml.md) | [MLDB >](10_mldb.md)
