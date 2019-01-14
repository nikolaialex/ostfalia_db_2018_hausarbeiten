## Datenbanken für ML

Grundsätzlich ist die Wahl der Datenbank davon abhängig welche Art von Daten für ML verwendet werden. Die meisten Datenbanken unterstützen von Haus aus kein ML. Aus diesem Grund werden Bibliotheken oder Frameworks für eine ML Untersützung benötigt. Darüber hinaus sind außerdem Datenbanken mit integrierter ML-Funktion vorhanden. Im Folgenden werden hier Bibliotheken für bekannte SQL und NoSQL Datenbanken vorgestellt, sowie Datenbanken die eine integrierte ML-Funktionalität anbieten. Die Anforderungen an Datenbanken werden im nächsten Abschnitt (siehe Abschnitt "[Anforderungen an ein DBMS für ML](#09_dbml_requirements)") aufgezeigt.

### Datenbanken mit integrierter ML-Funktionalität

#### LogicBlox

Die LogicBlox-Datenbank bietet eine Vielzahl von Abfragen und gleichzeitigen Datenzugriffsmustern für moderne Anwendungen an. Diese stellt eine gleichzeitige Auswertung und Optimierung von Abfragen, sowie grundlegende Analysen mit fortschrittlichen prädiktiven und präskriptiven Methoden zur Verfügung.[801]

LogicBlox setzt auf funktionale Programme und ihre funktionale Programmiersprache LogiQL kann mit deklarativer Programmierung kombiniert werden und stellt einen relationalen Abfrageoptimierer dar. Bei der Programmiersprache LogiQL handelt es sich um eine einheitliche und deklarative Sprache, die auf Datalog basiert. LogicBlox unterstützt ML-Methoden in den Kategorien Regression, Clustering, Suche, Dichteabschätzung, Klassifizierung und Dimensionsreduktion.[802]

Die prädikative Analyse in LogicBlox wird durch eine Sammlung von integrierten maschinellen Lernalgorithmen unterstützt. Dies geschieht über prädikative P2P-Regeln, die in zwei Modi angeboten werden. Zum einem in dem Lernmodus, wo ein Modell gelernt wird und zum anderen in dem Bewertungsmodus, wo ein Modell angewendet wird, um Vorhersagen zu treffen.[803]

#### SimSQL

SimSQL ist ein skalierbares, paralleles, analytisches relationales Datenbanksystem, das SQL-Abfragen in Java kompiliert, die auf Hadoop laufen. Dabei verfügt SimSQL über einen voll funktionsfähigen Abfrageoptimierer und verwendet eine Skriptsprache ähnlich zu SQL. Diese nennt sich SimSQL und bietet viele wichtige SQL-Funktionen, sowie verschachtelte Subqueries.

Der datenbankorientierte Ansatz von SimSQL bietet eine Anzahl von Abstraktionen für Bayesian ML. In den meisten ML-Problemen existieren einige Klassen von Variablen oder Parametern, über die die Inferenz durchgeführt werden soll. Dies können Variablen oder Modellparameter sein. SimSQL bietet von Haus aus die Möglichkeit an, dass das groß angelegte Baye'sche maschnielle Lernen eingesetzt werden kann.[804]

Die Bayes'sche Statistik ist ein mathematisches Verfahren, bei dem angenommen wird, dass ein parametrisierter stochastischer Prozess Daten erzeugt hat. Die Parameter sind nicht eindeutig und das Ziel ist verkörpert durch frühe Annahmen über die Parameter mit den beobachteten Daten zu kombinieren, um Verteilungseigenschaften der Parameter abzuleiten.[805]

Wie eine SimSQL-Anwendung auf das Bayes'sche maschinelle Lernen angewendet werden kann, ist umfangreich in dem Paper [Simulation of Database-Valued Markov Chains Using SimSQL](https://developer.logicblox.com/wp-content/uploads/2013/10/sigmod13-foula.pdf) beschrieben.

#### MemSQL

MemSQL ist eine Datenbank, mit intergrierter ML-Funktion, die moderne Anwendungen und Analysesysteme mit einer hoch skalierbaren Architektur für maximale Aufnahme- und Abfrageleistung bei höchster Parallelität unterstützt. Außerdem ist ein Echtzeit Scoring für ML möglich.

Seit der Version 6 enthält MemSQL neue ML-Funktionen wie DOT_PRODUCT. Diese bietet die Möglichkeit Anwendungen umzusetzen, die einen Vergleich von zwei Vektoren erfordern. Dazu zählt beispielsweise die Echtzeit-Bilderkennung. Mit MemSQL kann dies in der verteilten SQL-Datenabnk realisiert werden und ermöglicht außerdem eine hohe Leistung und Skalierbarkeit.[806]

#### SAP HANA

SAP HANA kombiniert eine ACID-kompatible Datenbank mit Anwendungsservices, Hochgeschwindigkeitsanalysen und flexiblen Werkzeugen für die Datenerfassung auf einer einheitlichen In-Memory-Plattform. In der In-Memory-Datenbank von SAP HANA werden in Anwendungen verwendete Daten gespeichert und abgerufen. Die Datenbank dient zudem als modernes Data Warehouse, das Daten aus einer Vielzahl von Quellen mit Live-Transaktionsdaten integriert und so Einblicke ermöglicht, die immer auf dem aktuellsten Stand sind.[807]

SAP HANA bietet eine Reihe an eingebauten ML-Algorithmen:

- Klassifizierung
- Regression
- Clustering
- Empfehlungen
- Link-Analyse

Des Weiteren wird eine Integration von Modellen, die in gängigen ML-Bibliotheken oder Frameworks erstellt wurden, ermöglicht. Benutzer können Modelle aus einer SQL-basierten Anwendung und Programmiercode aufrufen, der beispielsweise in Python implementiert wurde. Wenn diese Anwendungen dann auf ML-Anwendungen, die auf dem HANA XS Advanced Applikationsserver entwickelt wurden, können die Modelle dann nutzen.[808]

### ML Bibliotheken mit Datenbank-Unterstüztung

#### RapidMiner

RapidMiner formt eine Softwareumgebung, die es ermöglicht industrielle und wissenschaftliche Anwendungen umzusetzen. Dazu zählen ML- und Data Mining-Aufgaben. RapidMiner wurde in Java entwickelt und unterstützt verschiedene Datenbanken. Zu den SQL-Datenbanken zählen beispielsweise MySQL, PostgreSQL und Oracle. Von den NoSQL-Datenbanken werden unter anderen Cassandra und MongoDB unterstützt. Prinzipiell können alle Datenbanken verwendet werden, für die JDBC Treiber existieren. Die Bedienung von RapidMiner ist über eine grafische Benutzeroberfläche möglich. Neben Datenbanken können auch verschiedene Cloud Services integriert werden, von denen Daten direkt ausgelesen und gespeichert werden. Das Produkt RapidMiner Studio bietet verschiedenste Funktionen für ML an. Dazu zählen die Funktionen:

- Erstellen von Modellen

  - Berechnung der Ähnlichkeit
  - Clustering (k-Means, k-Medoid)
  - Klassifizierung
  - Regression

- Vorverarbeitung/Datenreinigung

  - Transformation
  - Normalisierung und Standardisierung
  - Attributgenerierung
  - Gewichtung und Auswahl

- Validierung des Modells

- Datenexploration
  - Univariate Statistiken und Diagramme
  - Verteilungsdiagramme
  - Mittelwertabweichungsdiagramme

<!--
https://rapidminer.com/products/studio/feature-list
https://docs.rapidminer.com/latest/studio/how-to/

RapidMiner https://docs.rapidminer.com
Cassandra http://cassandra.apache.org
MongoDB https://www.mongodb.com
MySQL https://www.mysql.com
PostgreSQL https://www.postgresql.org
Oracle https://www.oracle.com/database/
-->

#### scikit learn

- MongoDB
- Python Schnittstelle notwenidg

#### MADlib

- Greenplum
  - laut Seite für ML optimiert, aber nicht ohne Lib möglich
- PostgreSQL

<!--
**CYBERTEC**
  - https://www.cybertec-postgresql.com/de/produkte/pgneural_de/
- PostgreSQL

**bigML**
- MySQL
  - https://blog.bigml.com/2013/10/30/data-preparation-for-machine-learning-using-mysql/
-->

---

[801] LogicBlox: LogicBlox Platform Technology

[802] LogicBlox: MACHINE LEARNING METHODS IN LOGICBLOX

[803] Aref, Molham und ten Cate, Balder und Green, Todd J. und Kimelfeld, Benny und Olteanu, Dan und Pasalic, Emir und Veldhuizen, Todd L. und Washburn, Geoffrey: Design and Implementation of the LogicBlox System

[804] RICE: SimSQL Overview

[805] Cai, Zhuhua und Vagena, Zografoula und Perez, Luis und Arumugam, Subramanian und Haas, Peter J. und Jermaine, Christopher: Simulation of Database-Valued Markov Chains Using SimSQL

[806] Orenstein, Gary: MemSQL 6 Product Pillars and Machine Learning Approach

[807] SAP: SAP HANA

[808] Jeppesen, David: Machine Learning in the SAP HANA Platform

-Mierswa, I., & Klinkenberg, R. (2018). RapidMiner Studio (9.1) [Data science, machine learning, predictive analytics]. Retrieved from https://rapidminer.com/

<!--

TensorFlow
- https://opensourceforu.com/2017/01/best-open-source-machine-learning-frameworks/

Apache Spark MLlib
- https://opensourceforu.com/2017/01/best-open-source-machine-learning-frameworks/

Flink

SAP HANA
- https://www.prowesscorp.com/machine-learning-on-sap-hana/

Spark
- https://data-science-blog.com/blog/2016/08/03/was-ist-eigentlich-apache-spark/
- https://spark.apache.org/
- https://spark.apache.org/mllib/
- Hadoop HDFS

-->

---

[< Abgrenzungen](07_ml_dds.md) | [Anforderungen an ein DBMS >](09_dbml_requirements.md)
