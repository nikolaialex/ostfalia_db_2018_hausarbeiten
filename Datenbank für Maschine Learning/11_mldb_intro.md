## MLDB Einführung

[![Logo von MLDB](./statics/10_mldb/mldbai_logo.png)](./statics/10_mldb/mldbai_logo.png)

MLDB ist eine Open-Source-Datenbank, die von Element AI für ML entwickelt wurde. Die Datenbank ermöglicht dem Nutzer, Befehle über eine REST-API zu senden, um Daten zu speichern, sie mithilfe von SQL zu untersuchen, ML-Modelle zu trainieren und sie als APIs bereitzustellen.[1101] Allgemein weist MLDB folgende Eigenschaften auf:

- Eine SQL-Datenbank, die in C++ und für ML geschrieben wurde
- Open-Source
- Web nativ, wobei die primäre API JSON zurückliefert und über REST bzw. HTTP zugänglich ist
- Eine Ende-zu-Ende-Lösung, Datenaufnahme, Modelltraining, Modellbereitstellung
- Arbeiten mit Big Data möglich, kann Modelle auf Milliarden von Datenpunkten trainieren
- Kostengünstig - Schnelles Training auf einem einzelnen Knoten möglich, kein Cluster erforderlich

### Traditionelle Datenbank vs. Datenbank für ML

Das folgende Beispiel zeigt den Unterschied zwischen einer traditionellen Datenbank und einer Datenbank für ML. Gegeben sind zwei SQL-Abfragen, die auf die Weblog-Daten von einem bestimmten Nutzer zugreifen. Der Unterschied zwischen beiden Abfragen ist der, dass die zweite Abfrage in der Lage ist, basierend auf den Weblog-Daten des Nutzers, eine Empfehlung zu geben, wie das Verhalten des Nutzers zukünfitg aussehen könnte.[1102]

```sql
--Traditional
SELECT browsing_report() FROM web_logs WHERE user_id = "134567";

--ML
SELECT content_recommendation() FROM web_logs WHERE user_id = "134567";
```

Zusätzlich ermöglicht MLDB die SQL-Abfrage über HTTP, sodass die Empfehlungsfunktion Plattformunabhängig aufgerufen werden kann.[1102]

```http
GET /v1/functions/content_recommendation/application?input={user_id}
```

---

[1101] MLDB is the Machine Learning Database

[1102] BIG 2016: The Machine Learning Database

---

[< MLDB](10_mldb.md) | [MLDB Merkmale >](12_mldb_features.md)
