## Praktisches Beispiel

Die lokale Installation und Ausführung von MLDB ist möglich. Nichtsdestotrotz muss hierbei beachtet werden, dass das Bauen mittels der Quelldateien je nach Performance der Maschine dauern kann. Laut eigener Angaben soll eine 32-Kern-Maschine mit 244 GB RAM etwa 5 Minuten für das Bauen brauchen<sup>[11](#11)</sup>. Da diese Hardware nicht gegeben ist, wird im Rahmen dieses Abschnittes auf die integrierte Juptyer Notebook-Schnittstelle zurückgegriffen. Das Jupyter Notebook ist eine Open-Source-Webanwendung, mit der Dokumente erstellt und freigeben werden können, die Live-Code, Gleichungen, Visualisierungen und narrativen Text enthalten<sup>[11](#11)</sup>. Nützliche Pakete wie Numpy, Pandas oder Matplotlib stehen von vornherein zur Verfügung. Außerdem ist die hauseigene `pymldb`-Bibliothek bereits vorinstalliert, wodurch das Arbeiten mit der REST-API vereinfacht wird.<sup>[11](#11)</sup>

Im folgenden soll geprüft werden, ob MLDB den im Abschnitt [_Anforderungen an ein DBMS für ML_](09_dbml_requirements.md) beschriebenen Anforderungen an eine ML-Datenbank genügen. Hierfür werden alle Anforderungen sukzessiv mit Beispielen geprüft. Die Möglichkeit besteht, dass bestimmte Beispiele aufeinander aufbauen. Man wird darauf hingewiesen, dass die gezeigten Beispiele in Zukunft gegebenen falls nicht mehr aktuell sind.

Wie zuvor beschrieben, erfolgen die Interaktionen mit MLDB über eine REST-API. Diese Interaktionen werden durch die `pymldb`-Bibliothek abstrahiert und stehen im  Jupyter Notebook zur Verfügung. Bevor HTTP-Anfragen gesendet werden können, muss zuvor eine Verbindung zur REST-API erzeugt werden. Dies geschieht mittels der Klasse Connection. Aus diesem Grund müssen sämtliche Beispiele mit diesen Anweisungen starten:

```python
from pymldb import Connection
mldb = Connection()
```

Damit die Beispiele so kurz wie möglich sind, wird auf die Anzeige der beiden Anweisungen verzichtet. Dementsprechend kann davon ausgegangen werden, dass bei allen gezeigten Beispielen eine Verbindung schon existiert.

### Import

MLDB verfügt über fünf Prozeduren, die das Importieren von Datensätzen ermöglichen. Alle zur Verfügung stehenden Prozeduren werden in der folgenden Tabelle kurz beschrieben:

| Prozedur              | Beschreibung                                                                                                                                                                            |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `import.git`          | Diese Prozedur ermöglicht das Importieren von Commit-Metadaten aus einem lokalen Git-Repository<sup>[11](#11)</sup> .                                                                   |
| `import.json`         | Diese Prozedur ermöglicht das Importieren einer Textdatei, die pro Zeile eine JSON enthält<sup>[11](#11)</sup> .                                                                        |
| `import.sentiwordnet` | Diese Prozedur ermöglicht das Laden von Wörtern und Ausdrücken aus der lexikalischen Ressource SentiWordNet in die MLDB<sup>[11](#11)</sup>.                                            |
| `import.text`         | Mit dieser Prozedur werden Daten aus Textdateien importiert, wobei jede Zeile in der Datei einer Zeile im Datensatz entspricht. Geeignet für Dateien im CSV-Format.<sup>[11](#11)</sup> |
| `import.word2vec`     | Diese Prozedur ermöglicht das Laden von Wörtern und Ausdrücken aus dem Word2Vec-Tool in die MLDB<sup>[11](#11)</sup>.                                                                   |

Im folgenen wird nun mithilfe der Prozedur `import.text` der [Iris-Datensatz](https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data) aus dem [Machine Learning Repository](https://archive.ics.uci.edu/ml/index.php) der UCI importiert. Der Datensatz steht im CSV-Format zur Verfügung und enthält drei Klassen mit jeweils 50 Instanzen, wobei sich jede Klasse auf einen Irispflanzen-Typ bezieht. Mithilfe von Parametern, die [hier](https://docs.mldb.ai/doc/#builtin/procedures/importtextprocedure.md.html) näher beschrieben werden, kann das Importieren spezifiziert werden. Erwähnenswert ist, dass intern eine `PUT`-Anfrage an den REST-Endpunkt `/v1/procedures/{procedureName}` gesendet wird. Folglich dient die Anfrage ursprünglich nur der Erzeugung der Prozedur. Damit der Datensatz im Anschluss importiert und über eine SQL-Abfrage ausgespielt werden kann, muss der Parameter `runOnCreation` auf `True` gesetzt werden. Dank des Parameters wird die Prozedur direkt nach der Erzeugung ausgeführt. Nach dem der Datensatz erfolgreich importiert wurde, ist die Anzeige der Daten über eine SQL-Abfrage möglich (siehe Zeile 10).

```python
mldb.put('/v1/procedures/import_iris', {
    "type":"import.text",
    "params": {
        "dataFileUrl":"https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data",
        "headers": [ "sepal length", "sepal width", "petal length", "petal width", "class" ],
        "outputDataset": "iris",
        "runOnCreation": True
    }
})
mldb.query("SELECT * FROM iris LIMIT 5")
```

![Die ersten fünf Einträge des Iris-Datensatzes](./statics/11_mldb/examples/import.png)

#### Datenaufruf via Schnittstellen (REST, QL)

#### Dataset (CSV, Erstellung, Vorlagen)

#### Klassische Bearbeitung (Filter, Rules)

### ML Algorithmus anwenden

#### Performance

#### Aufruf via Schnittstellen (REST, QL)

#### Prozeduren

#### Auto-Verallgemeinerung

#### Auto-Zusammenfassung

#### Auto-Charakterisierung

### Modell (Ändern,Sichern)

### Funktionen

#### Funktionsaufruf via Schnittstellen (REST, QL)

#### Batchbetrieb

### Export (REST, QL)

## Fazit

---

<a name="11"><sup>11</sup></a> _Building and running the MLDB Community Edition Docker image_ (2019). URL: [https://github.com/mldbai/mldb/blob/master/Building.md](https://github.com/mldbai/mldb/blob/master/Building.md) (besucht am 11.01.2019).

<a name="11"><sup>11</sup></a> _The Jupyter Notebook_ (2019). URL: [https://jupyter.org/](https://jupyter.org/) (besucht am 11.01.2019).

<a name="11"><sup>11</sup></a> _Notebooks and pymldb_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Notebooks.md.html](https://docs.mldb.ai/doc/#builtin/Notebooks.md.html) (besucht am 11.01.2019).

<a name="11"><sup>11</sup></a> _Git importer procedure_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/procedures/GitImporter.md.html](https://docs.mldb.ai/doc/#builtin/procedures/GitImporter.md.html) (besucht am 12.01.2019).

<a name="11"><sup>11</sup></a> _JSON Import Procedure_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/procedures/JSONImporter.md.html](https://docs.mldb.ai/doc/#builtin/procedures/JSONImporter.md.html) (besucht am 12.01.2019).

<a name="11"><sup>11</sup></a> _SentiWordNet Importer Procedure_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/procedures/SentiWordNetImporter.md.html](https://docs.mldb.ai/doc/#builtin/procedures/SentiWordNetImporter.md.html) (besucht am 12.01.2019).

<a name="11"><sup>11</sup></a> _Importing Text_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/procedures/importtextprocedure.md.html](https://docs.mldb.ai/doc/#builtin/procedures/importtextprocedure.md.html) (besucht am 12.01.2019).

<a name="11"><sup>11</sup></a> _Word2Vec importer procedure_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/procedures/Word2VecImporter.md.html](https://docs.mldb.ai/doc/#builtin/procedures/Word2VecImporter.md.html) (besucht am 12.01.2019).

---

[< MLDB Merkmale](13_mldb_features.md) | [Conclusion >](15_conclusion.md)
