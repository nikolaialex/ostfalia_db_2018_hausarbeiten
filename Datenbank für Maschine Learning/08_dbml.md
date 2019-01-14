***

## Datenbanken für ML


Grundsäzlich ist die Wahl der Datenbank davon abhängig welche Art von Daten für ML verwendet werden. Die meisten Datenbanken unterstüzten von Haus aus kein Machine Learning. Aus diesem Grund werden Bibliotheken oder Frameworks für eine ML Untersützung benötigt. Darüber hinaus gibt es aber auch Datenbanken mit integrierter ML Funktion. Im Folgenden werden hier Bibliotheken für bekannte SQL und NoSQL Datenbanken vorgestellt, sowie Datenbanken die eine integrierte ML Funktionalität anbieten. Die Anforderungen an Datenbanken werden im nächsten Abschnitt (vgl. 09_dbml_requirements) aufgezeigt.


#### Datenbanken mit integrierter ML Funktionalität

**LogicBlox**

Die LogicBlox-Datenbank bietet eine Vielzahl von Abfragen und gleichzeitigen Datenzugriffsmustern für moderne Anwendungen an. Diese bietet eine gleichzeitigen Auswertung und Optimierung von Abfragen sowie grundlegende Analysen mit fortschrittlichen prädiktiven und präskriptiven Methoden.
Quelle: https://developer.logicblox.com/technology/

LogicBlox setzt auf funktionale Programme und ihre funktionale Programmiersprache LogiQL kann mit deklarativer Programmierung kombiniert werden und stellt einen relationalen Abfrageoptimierer dar. Bei der Programmiersprache LogiQL handelt es sich um eine einheitliche und deklarative Sprache, die auf Datalog basiert. LogicBlox unterstützt ML-Methoden in den Kategorien Regression, Clustering, Suche, Dichteabschätzung, Klassifizierung und Dimensionsreduktion.
Quelle: https://developer.logicblox.com/wp-content/uploads/2014/02/mlpack_doc.pdf

Die prädikative Analyse in LogicBlox wird durch eine Sammlung von integrierten maschinellen Lernalgorithmen unterstützt. Dies passiert über prädikative P2P-Regeln, die in zwei Modi angeboten werden. Zum einem in dem Lernmodus, wo ein Modell gelernt wird und dem zum anderen in dem Bewertungsmodus, wo ein Modell angewendet wird, um Vorhersagen zu treffen.
Quelle: http://www.cs.ox.ac.uk/dan.olteanu/papers/logicblox-sigmod15.pdf


**SimSQL**

SimSQL ist ein skalierbares, paralleles, analytisches relationales Datenbanksystem, welches SQL-Abfragen in Java kompiliert, die auf Hadoop laufen.  Dabei verfügt SimSQL über einen voll funktionsfähigen Abfrageoptimierer und verwendet eine Skriptsprache ähnlich zu SQL. Diese nennt sich SimSQL und bietet viele wichtige SQL-Funktionen, sowie verschachtelte Subqueries.

Der datenbankorientierte Ansatz von SimSQL bietet eine Anzahl von Abstraktionen für Bayesian ML. In den meisten ML-Problemen gibt es einige Klassen von Variablen oder Parametern, über die die Inferenz durchgeführt werden soll. Dies können Variablen, oder Modellparameter sein. SimSQL bietet von Haus aus an, dass das groß angelegte Baye'sche maschnielle Lernen eingesetzt werden kann.

Quelle: http://cmj4.web.rice.edu/SimSQL/SimSQL.html

Die Bayes'sche Statistik ist ein mathematisches Verfahren, bei dem angenommen wird, dass ein parametrisierter stochastischer Prozess Daten erzeugt hat. Die Parameter sind nicht eindeutig und das Ziel ist es, frühe Annahmen über die Parameter mit den beobachteten Daten zu kombinieren, um Verteilungseigenschaften der Parameter abzuleiten.

Quelle: https://developer.logicblox.com/wp-content/uploads/2013/10/sigmod13-foula.pdf

Wie eine SimSQL Anwendung auf das Bayes'sche maschinelle Lernen angwendet werden kann ist umfangreich in dem Paper  <a href="https://developer.logicblox.com/wp-content/uploads/2013/10/sigmod13-foula.pdf">Simulation of Database-Valued Markov Chains Using SimSQL</a> beschrieben.


**MemSQL**

MemSQL ist eine Datenbank, mit intergrierter ML-Funktion, die moderne Anwendungen und Analysesysteme mit einer hoch skalierbaren Architektur für maximale Aufnahme- und Abfrageleistung bei höchster Parallelität unterstützt.
Außerdem ist ein Echtzeit Scoring für ML möglich.

Seit der Version 6 enthählt MemSQL neue ML-Funktionen wie DOT_PRODUCT. Diese bietet die Möglichkeit Anwendungen umzusetzen, die einen Vergleich von zwei Vektoren erfordern. Dazu zählt beispielsweise die Echtzeit-Bilderkennung. Mit MemSQL kann dies in der verteilten SQL-Datenabnk realisiert werden und ermöglicht außerdem eine hohe Leistung und Skalierbarkeit.

Quelle: https://www.memsql.com/blog/memsql-6-product-pillars-and-machine-learning-approach/


**SAP HANA**

>SAP HANA kombiniert eine ACID-kompatible Datenbank mit Anwendungsservices, Hochgeschwindigkeitsanalysen und flexiblen Werkzeugen für die Datenerfassung auf einer einheitlichen In-Memory-Plattform. In der In-Memory-Datenbank von SAP HANA werden in Anwendungen verwendete Daten gespeichert und abgerufen. Die Datenbank dient zudem als modernes Data Warehouse, das Daten aus einer Vielzahl von Quellen mit Live-Transaktionsdaten integriert und so Einblicke ermöglicht, die immer auf dem aktuellsten Stand sind.

Quelle: https://www.sap.com/germany/products/hana.html

SAP HANA bietet eine Reihe an eingebauten ML-Algorithmen:
- Klassifizierung
- Regression
- Clustering
- Empfehlungen
- Link-Analyse

Des Weiteren wird eine Integration von Modellen, die in gängigen ML-Bibliotheken, oder Frameworks erstellt wurden ermöglicht. Benutzer können Modelle aus einer SQL-basierten Anwedung aufrufen und zudem auch Code, der beispielsweise in Python implementiert wurde. Wenn diese Anwendungen dann auf ML-Anwendungen, die auf dem HANA XS Advanced Applikationsserver entwickelt wurden können die Modelle dann nutzen.
https://www.prowesscorp.com/machine-learning-on-sap-hana/


#### ML Bibliotheken mit Datenbank-Unterstüztung

**RapidMiner**

Bei RapidMiner handelt es sich um eine Softwareumgebung, die es ermöglicht industrielle und wissenschaftliche Anwendungen umzusetzten. Dazu zählen ML- und Data Mining-Aufgaben. RapidMiner wurde in Java entwickelt und unterstützt verschiedene Datenbanken. Zu den SQL Datenbanken zählen beispielsweise MySQL, PostgreSQL und Oracle. Von den NoSQL Datenbanken werden unter anderen Cassandra und MongoDB unterstützt. Prinzipiell können alle Datenbanken verwendet werden, für die es JDBC Treiber gibt. Die Bedienung von RapidMiner ist über eine grafische Benutzeroberfläche möglich. Neben Datenbanken können auch verschiedene Cloud Services integriert werden, von denen Daten direkt ausgelesen und gespeichert werden. Das Produkt RapidMiner Studio bietet verschiedenste Funktionen für Machine Learning, dazu zählen die Funktionen:

- Erstellen von Modelllen
  - Berechnung der Ähnlichkeit
  - Clustering (k-Means, k-Medoid)
  - Klassifizierung
  - Regression

- Vorverarbeitung / Datenreinigung
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

**scikit learn**
- MongoDB
- Python Schnittstelle notwenidg

**MADlib**
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
----

[< Abgrenzungen](07_ml_dds.md)	|	[Anforderungen an ein DBMS >](09_dbml_requirements.md)
