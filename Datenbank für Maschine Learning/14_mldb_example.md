## Praktisches Beispiel

Die lokale Installation und Ausführung von MLDB ist möglich. Nichtsdestotrotz muss hierbei beachtet werden, dass das Bauen mittels der Quelldateien je nach Performance der Maschine dauern kann. Laut eigener Angaben soll eine 32-Kern-Maschine mit 244 GB RAM etwa 5 Minuten für das Bauen brauchen<sup>[11](#11)</sup>. Da diese Hardware nicht gegeben ist, wird im Rahmen dieses Abschnittes auf die integrierte Juptyer Notebook-Schnittstelle zurückgegriffen. Das Jupyter Notebook ist eine Open-Source-Webanwendung, mit der Dokumente erstellt und freigeben werden können, die Live-Code, Gleichungen, Visualisierungen und narrativen Text enthalten<sup>[11](#11)</sup>. Nützliche Pakete wie Numpy, Pandas oder Matplotlib stehen von vornherein zur Verfügung. Außerdem ist die hauseigene `pymldb`-Bibliothek bereits vorinstalliert, wodurch das Arbeiten mit der REST-API vereinfacht wird.<sup>[11](#11)</sup>

Im folgenden soll geprüft werden, ob MLDB den im Abschnitt [_Anforderungen an ein DBMS für ML_](09_dbml_requirements.md) beschriebenen Anforderungen an eine ML-Datenbank genügen. Hierfür werden alle Anforderungen sukzessiv mit Beispielen geprüft. Die Möglichkeit besteht, dass bestimmte Beispiele aufeinander aufbauen. Man beachte, dass die gezeigten MLDB-Funktionalität in Zukunft gegebenen falls nicht mehr aktuell sind.

### Import

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

---

<a name="11"><sup>11</sup></a> _Building and running the MLDB Community Edition Docker image_ (2019). URL: [https://github.com/mldbai/mldb/blob/master/Building.md](https://github.com/mldbai/mldb/blob/master/Building.md) (besucht am 11.01.2019).

<a name="11"><sup>11</sup></a> _The Jupyter Notebook_ (2019). URL: [https://jupyter.org/](https://jupyter.org/) (besucht am 11.01.2019).

<a name="11"><sup>11</sup></a> _Notebooks and pymldb_ (2019). URL: [https://docs.mldb.ai/doc/#builtin/Notebooks.md.html](https://docs.mldb.ai/doc/#builtin/Notebooks.md.html) (besucht am 11.01.2019).

---

[< MLDB Merkmale](13_mldb_features.md) | [Conclusion >](15_conclusion.md)
