## MLDB Merkmale

[![Grundlegender Machine Learning-Fluss](./statics/11_mldb/BasicMLFlow.png)](https://docs.mldb.ai/doc/builtin/img/BasicMLFlow.svg)

In MLDB werden ML-Modelle mithilfe von Funktionen angewendet, die durch die Ausgabe von Prozeduren, die über Datensätze mit Trainingsdaten laufen, parametrisiert werden. Interessant ist, dass Funktionen auch für SQL-Abfragen und als REST-Endpunkte zur Verfügung stehen.<sup>[1](#1301)</sup>

### Funktionen

[![Abhängigkeiten einer Funktionen in MLDB](./statics/11_mldb/Functions.png)](https://docs.mldb.ai/doc/builtin/img/Functions.svg)

Funktionen (_eng. "functions"_) sind benannte, wiederverwendbare Programme, die zum Implementieren von Streaming-Berechnungen verwendet werden, die Argumente akzeptieren und Funktionswerte zurückgeben können. Funktionen werden verwendet, um:

- SQL-Ausdrücke einzukapseln.

- ML-Modelle anzuwenden, die durch die Ausgabe einer Trainingsprozedur parametrisiert werden.

Alle MLDB-Funktionen sind automatisch als REST-Endpunkte (_eng. "REST Endpoints"_) verfügbar, mit denen ML-Modelle in einem Streaming-Prozess angewendet werden können. Darüber hinaus können Funktionen innerhalb von SQL-Abfragen (_eng. "SQL queries"_) aufgerufen werden, um ML-Modelle auf Daten in einem Batch-Prozess anzuwenden. MLDB stellt eine Reihe von integrierten Funktionsarten für verschiedene Anwendungsfälle zur Verfügung.<sup>[2](#1302)</sup> Beispielsweise können Funktionen der integrierten Art `classifier` erzeugt werden, um einen trainierten Klassifikator auf neue Daten anzuwenden<sup>[3](#1303)</sup>.

### Prozeduren

[![Abhängigkeiten einer Prozedur in MLDB](./statics/11_mldb/Procedures.png)](https://docs.mldb.ai/doc/builtin/img/Procedures.svg)

Prozeduren (_eng. "procedures"_) sind benannte, wiederverwendbare Programme, die verwendet werden, um lange laufende Batch-Operationen ohne Rückgabewerte zu implementieren. Prozeduren laufen im Allgemeinen über Datensätze und können über SQL-Ausdrücke konfiguriert werden. Die Ausgaben einer Prozedur können Datensätze und Dateien enthalten. Prozeduren werden verwendet um:

- Daten zu transformieren oder zu bereinigen.

- ML-Modelle zu trainieren.

- ML-Modelle im Batch-Modus anzuwenden.

MLDB stellt eine Reihe von integrierten Prozedurtypen für verschiedene Anwendungsfälle zur Verfügung.<sup>[4](#1304)</sup> Beispielsweise können Prozeduren der integrierten Art `classifier.train` erzeugt werden, um einen überwachten Klassifikator (_eng. "supervised classifier"_) zu trainieren.<sup>[5](#1305)</sup>.

### Datensätze

[![Abhängigkeiten eines Datensatzes in MLDB](./statics/11_mldb/Datasets.png)](https://docs.mldb.ai/doc/builtin/img/Datasets.svg)

Datensätze (_eng. "datasets"_) verkörpern schemalose, nur anhängende (_eng. "append-only"_) benannte Mengen von Datenpunkten, wobei jeder Datenpunkt als Tupel (Zeile, Spalte, Zeitstempel, Wert) dargestellt werden kann.<sup>[6](#1306)</sup> Datensätze können Milliarden von Datenpunkten enthalten, die in Millionen von Zeilen mit Millionen von Spalten angeordnet sind. Datensätze können aus Dateien geladen oder in Dateien persistiert werden. Zusätzlich können Datensätze als Eingabeparameter für Prozeduren dienen und von diesen erstellt werden. Ferner ist die Abfrage von Datensätzen über SQL-Abfragen möglich.<sup>[7](#1307)</sup> Datensätze können als dreidimensionale Matrizen betrachtet werden, wobei die Zeile, die Spalte und der Zeitstempel die Dimensionen verkörpern. Folglich wird pro Zeitstempel eine bestimmte Version der Daten persistiert. Die folgende Abbildung zeigt wie Datensätze innerhalb von MLDB strukturiert sind:<sup>[8](#1308)</sup>

[![Struktur von Datensätzen innerhalb von MLDB](./statics/11_mldb/SlicedDataset.png)](https://docs.mldb.ai/doc/builtin/img/SlicedDataset.svg)

### Zuordnung von SQL zu HTTP

Die folgende Tabelle beschreibt die Zuordnung von SQL-Kommandos zu HTTP-Methoden, die im Rahmen von MLDB eine Rolle spielen:<sup>[9](#1309)</sup>

| **SQL-Kommando** | **HTTP-Methode** |
| ---------------- | ---------------- |
| CREATE           | PUT              |
| DROP             | DELETE           |
| INSERT           | POST             |
| SELECT           | GET              |

------

<a name="1301"><sup>1</sup></a> _MLDB Overview_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Overview.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 09.01.2018).

<a name="1302"><sup>2</sup></a> Ebd.

<a name="1303"><sup>3</sup></a> _Intro to Functions_ (2019). URL: [https://docs.mldb.ai/doc/builtin/functions/Functions.md.html](https://docs.mldb.ai/doc/builtin/functions/Functions.md.html) (besucht am 09.01.2018).

<a name="1304"><sup>4</sup></a> _MLDB Overview_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Overview.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 09.01.2018).

<a name="1305"><sup>5</sup></a> _Intro to Procedures_ (2019). URL: [https://docs.mldb.ai/doc/builtin/procedures/Procedures.md.html](https://docs.mldb.ai/doc/builtin/procedures/Procedures.md.html) (besucht am 09.01.2018).

<a name="1306"><sup>6</sup></a> _Intro to Datasets_ (2019). URL: [https://docs.mldb.ai/doc/builtin/datasets/Datasets.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 09.01.2018).

<a name="1307"><sup>7</sup></a> _MLDB Overview_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Overview.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 09.01.2018).

<a name="1308"><sup>8</sup></a> _Intro to Datasets_ (2019). URL: [https://docs.mldb.ai/doc/builtin/datasets/Datasets.md.html](https://docs.mldb.ai/doc/#builtin/Overview.md.html) (besucht am 09.01.2018).

<a name="1309"><sup>9</sup></a> _IBIG 2016: The Machine Learning Database_ (2019). URL: [https://www.youtube.com/watch?v=D2qWqBgsqIU](https://www.youtube.com/watch?v=D2qWqBgsqIU) (besucht am 09.01.2018).

------

[< MLDB Einführung](11_mldb_intro.md) | [MLDB Praktisches Beispiel >](13_mldb_example.md)
