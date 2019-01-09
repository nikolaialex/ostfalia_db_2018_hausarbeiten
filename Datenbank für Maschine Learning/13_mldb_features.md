## MLDB Merkmale

In MLDB werden ML-Modelle mithilfe von Funktionen angewendet, die durch die Ausgabe von Prozeduren, die über Datensätze mit Trainingsdaten laufen, parametrisiert werden. Interessant ist, dass Funktionen auch für SQL-Abfragen und als REST-Endpunkte zur Verfügung stehen.<sup>[11](#11)</sup>

### Funktionen

[![Abhängigkeiten einer Funktionen in MLDB](./statics/11_mldb/Functions.png)](https://docs.mldb.ai/doc/builtin/img/Functions.svg)

Funktionen (_eng. "functions"_) sind benannte, wiederverwendbare Programme, die zum Implementieren von Streaming-Berechnungen verwendet werden, die Argumente akzeptieren und Funktionswerte zurückgeben können. Funktionen werden verwendet, um:

- SQL-Ausdrücke einzukapseln.

- ML-Modelle anzuwenden, die durch die Ausgabe einer Trainingsprozedur parametrisiert werden.

Alle MLDB-Funktionen sind automatisch als REST-Endpunkte (_eng. "REST Endpoints"_) verfügbar, mit denen ML-Modelle in einem Streaming-Prozess angewendet werden können. Darüber hinaus können Funktionen innerhalb von SQL-Abfragen (_eng. "SQL queries"_) aufgerufen werden, um ML-Modelle auf Daten in einem Batch-Prozess anzuwenden. MLDB stellt eine Reihe von integrierten Funktionsarten für verschiedene Anwendungsfälle zur Verfügung.<sup>[11](#11)</sup> Beispielsweise können Funktionen der integrierten Art `classifier` erzeugt werden, um einen trainierten Klassifikator auf neue Daten anzuwenden<sup>[11](#11)</sup>.

### Prozeduren

[![Abhängigkeiten einer Prozedur in MLDB](./statics/11_mldb/Procedures.png)](https://docs.mldb.ai/doc/builtin/img/Procedures.svg)

Prozeduren sind benannte, wiederverwendbare Programme, die verwendet werden, um lange laufende Stapeloperationen ohne Rückgabewerte zu implementieren. Prozeduren laufen im Allgemeinen über Datensätze und können über SQL-Ausdrücke konfiguriert werden. Die Ausgaben einer Prozedur können Datensätze und Dateien enthalten. Prozeduren werden verwendet um:

- Daten zu transformieren oder zu reinigen.

- ML-Modelle zu trainieren.

- ML-Modelle im Batch-Modus anzuwenden.

MLDB stellt eine Reihe von integrierten Prozedurtypen für verschiedene Anwendungsfälle zur Verfügung.<sup>[11](#11)</sup>

### Datensätze

[![Abhängigkeiten eines Datensatzes in MLDB](./statics/11_mldb/Datasets.png)](https://docs.mldb.ai/doc/builtin/img/Datasets.svg)

Datensätze sind benannte Mengen von Datenpunkten, die aus Tupeln (Zeile, Spalte, Zeitstempel, Wert) bestehen. Datensätze können Millionen benannter Spalten und Zeilen enthalten, und Datenpunkte können mehrere Zeitstempelwerte annehmen, bei denen es sich um Zahlen oder Strings handeln kann.

<a name="11"><sup>11</sup></a> _MLDB Overview_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Overview.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 16.12.2018).

<a name="11"><sup>11</sup></a>Ebd.

<a name="11"><sup>11</sup></a> _Intro to Functions_ (2019). URL: [https://docs.mldb.ai/doc/builtin/functions/Functions.md.html](https://docs.mldb.ai/doc/builtin/functions/Functions.md.html) (besucht am 16.12.2018).

<a name="11"><sup>11</sup></a> _MLDB Overview_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Overview.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 16.12.2018).

---

[< MLDB Einführung](12_mldb_intro.md) | [MLDB Praktisches Beispiel >](14_mldb_example.md)
