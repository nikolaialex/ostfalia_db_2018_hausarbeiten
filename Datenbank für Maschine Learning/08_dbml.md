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

RapidMiner formt eine Softwareumgebung, die es ermöglicht industrielle und wissenschaftliche Anwendungen umzusetzen. Dazu zählen ML- und Data Mining-Aufgaben. RapidMiner wurde in Java entwickelt und unterstützt verschiedene Datenbanken. Zu den SQL-Datenbanken zählen beispielsweise <a href="https://www.mysql.com">MySQL</a>, <a href="https://www.postgresql.org">PostgreSQL</a> und <a href="https://www.oracle.com/database/">Oracle</a>. Von den NoSQL-Datenbanken werden unter anderen <a href="http://cassandra.apache.org">Cassandra</a> und <a href="https://www.mongodb.com">MongoDB</a> unterstützt.[809] Prinzipiell können alle Datenbanken verwendet werden, für die JDBC Treiber existieren. Die Bedienung von RapidMiner ist über eine grafische Benutzeroberfläche möglich. Neben Datenbanken können auch verschiedene Cloud Services integriert werden, von denen Daten direkt ausgelesen und gespeichert werden. Das Produkt RapidMiner Studio bietet verschiedenste Funktionen für ML an. Dazu zählen die Funktionen: [810]

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


#### scikit learn

Bei <a href="https://scikit-learn.org">scikit learn</a> handelt es sich um eine Open Source Bibliothek für maschineless Lernen, entwickelt in Python. Diese stellt eine Reihe an einfachen und effizienten Tools für Data Mining und Datenanlysen bereit.

Klassifizierung
- Identifizierung, zu welcher Kategorie ein Objekt gehört

Regression
- Vorhersage eines kontinuierlich bewerteten Attributs, das einem Objekt zugeordnet ist

Clustering
- Automatische Gruppierung ähnlicher Objekte zu Mengen

Reduzierung der Dimensionalität
- Reduzierung der Anzahl der zu berücksichtigenden Zufallsvariablen

Modell Auswahl
- Vergleich, Validierung und Auswahl von Parametern und Modellen

Vorverarbeitung
- Extraktion und -normalisierung von Merkmalen

In der Dokumentation von <a href="https://scikit-learn.org">scikit learn</a> wird explizit erwähnt, dass Nutzer Dateien von einer Datenbank, oder einem Netzwerk-Stream liefern können. Jedoch werden Einzelheiten, wie dies zu erreichen ist nicht in der Dokumentation erläutert. Damit handelt es sich bei diesem Werkzeug nicht direkt um eine ML Bibliothek mit Datenbank unterstützung.

Um Daten aus gängigen Formaten wie CSV, Excel, JSON oder SQL einlesen zu können wird die Python Bibliothek <a href="http://pandas.pydata.org">pandas</a> verwendet. Mit der pandas I/O API können Datenrahmen als Listen von Tupeln aufgbaut werden. Das SQL-Modul der <a href="http://pandas.pydata.org">pandas</a> I/O API bieter eine umfangreiche Sammlung von Query-Wrappern, mit denen Datenabrufe erleichtert und Abhängigkeiten zu DB spezifischen Schnittstellen reduziert werden. <a href="http://pandas.pydata.org">pandas</a> verarbeitet heterogene Daten reibungslos und bietet Werkzeuge zur Manipulation und Umwandlung in ein numerisches Array, das für Scikit-Learning geeignet ist.

Zusätzlich kann das <a href="https://docs.python.org/2/library/pickle.html">pickle</a> Modul von Python verwendet werden, um die ML-Algorithmen zu serialisieren und das serialisierte Format in einer Datei zu speichern. Zum Speichern der Daten kann eine <a href="https://www.postgresql.org">PostgreSQL</a> oder <a href="https://www.mysql.com">MySQL</a> Datenbank verwendet werden. [811]

#### MADlib

Bei dem <a href="http://madlib.apache.org">MADLib</a> Projekt handelt es sich um einen Ansatz immer größer werdene Datenmengen analysieren zu können. Dabei ist das Projekt eine Mischung aus der kommerziellen Praxis, der akademischen Forschung und der Open-Source-Entwicklungsgemeinschaft. Der Vorteil von <a href="http://madlib.apache.org">MADLib</a> ist, dass direkt in einer Datenbank gearbeitet werden kann. Daten müssen nicht zwischen verschiedenen Laufzeitumgebungen verschoben werden. Damit stellt <a href="http://madlib.apache.org">MADLib</a> ein Hybrid dar. Als empfohlene Datenbanken nennt <a href="http://madlib.apache.org">MADLib</a> auf der Internetseite PostgreSQL und <a href="https://greenplum.org">Greenplum</a>. <a href="https://greenplum.org">Greenplum</a> ist darüber hinaus eine Datenbank die vorwiegend für analytische parallele Datenplattformen, ML und KI ausgelegt ist. <a href="http://madlib.apache.org">MADLib</a> bietet folgende ML-Funktionen: [812]

Klassifizierung
- Datensätze korrekt mit der richtigen Klasse für einen Datensatz kennzeichnen

Regression
- Erstellung eines Modells, dass den Ausgabewert vorhersagt

Clustering
- Identifizierung von Datengruppen, so dass Elemente eines Clusters ähnliner zueinander sind

Themenmodellierung (ähnlich Clustering)
- Identifizierung von Clustern aus Dokumenten, die ähnlich zueinadner sind, aber anhand der Hauptthemen

Assoziationsregel Mining
- Versuch zu ermitteln, welche Items häufiger vorkommen, als es der Zufall vermuten lässt

Beschreibende Statistik
- liefert kein Modell und gilt deshalb nicht als Lernmethode
- Hilfreich um Informationen zum Verständnis der zugrunde liegenden Daten zur Verfügung zu stellen

Validierung
- Fehler eines Modells verstehen und das Modell auf Genauigkeit an Testdaten bewerten
- Einsatz der n-fachen Kreuzvalidierung

---


[801] LogicBlox: LogicBlox Platform Technology

[802] LogicBlox: MACHINE LEARNING METHODS IN LOGICBLOX

[803] Aref, Molham und ten Cate, Balder und Green, Todd J. und Kimelfeld, Benny und Olteanu, Dan und Pasalic, Emir und Veldhuizen, Todd L. und Washburn, Geoffrey: Design and Implementation of the LogicBlox System

[804] RICE: SimSQL Overview

[805] Cai, Zhuhua und Vagena, Zografoula und Perez, Luis und Arumugam, Subramanian und Haas, Peter J. und Jermaine, Christopher: Simulation of Database-Valued Markov Chains Using SimSQL

[806] Orenstein, Gary: MemSQL 6 Product Pillars and Machine Learning Approach

[807] SAP: SAP HANA

[808] Jeppesen, David: Machine Learning in the SAP HANA Platform

[809] RapidMiner Studio: Feature List

[810] RapidMiner Studio: How To

[811] scikit-learn: scikit-learn

[812] MADLib: MADLib

---

[< Abgrenzungen](07_ml_dds.md) | [Anforderungen an ein DBMS >](09_dbml_requirements.md)
