***

## Datenbanken für ML


Grundsäzlich ist die Wahl der Datenbank davon abhängig welche Art von Daten für ML verwendet werden. Die meisten Datenbanken unterstüzten von Haus aus kein Machine Learning. Aus diesem Grund werden Bibliotheken oder Frameworks für eine ML Untersützung benötigt. Darüber hinaus gibt es aber auch Datenbanken mit integrierter ML Funktion. Im Folgenden werden hier Bibliotheken für bekannte SQL und NoSQL Datenbanken vorgestellt, sowie Datenbanken die eine integrierte ML Funktionalität anbieten. Die Anforderungen an Datenbanken werden im nächsten Abschnitt (vgl. 09_dbml_requirements) aufgezeigt.


#### Datenbanken mit integrierter ML Funktionalität
**LogicBlox**

https://developer.logicblox.com/wp-content/uploads/2014/02/mlpack_doc.pdf

**SimSQL**

http://cmj4.web.rice.edu/SimSQL/SimSQL.html

**MemSQL**

https://www.memsql.com/blog/memsql-6-product-pillars-and-machine-learning-approach/


**SAP HANA**

https://www.prowesscorp.com/machine-learning-on-sap-hana/


#### ML Bibliotheken mit Datenbank-Unterstüztung

**RapidMiner**

Bei RapidMiner handelt es sich um eine Softwareumgebung, die es ermöglicht industrielle und wissenschaftliche Anwendungen umzusetzten. Dazu zählen Machine Learning und Data Mining Aufgaben. RapidMiner wurde in Java entwickelt und unterstützt verschiedene Datenbanken. Zu den SQL Datenbanken zählen beispielsweise MySQL, PostgreSQL und Oracle. Von den NoSQL Datenbanken werden unter anderen Cassandra und MongoDB unterstützt. Prinzipiell werden alle Datenbanken unterstützt, für die es JDBC Treiber gibt. Die Bedienung von RapidMiner ist über eine graphische Benutzeroberfläche möglich. Neben Datenbanken können auch verschiedene Cloud Services integriert werden, von denen Daten direkt ausgelesen und gespeichert werden. Das Produkt RapidMiner Studio bietet verschiedenste Funktionen für Machine Learning, dazu zählen unter anderen folgende Funktionen:

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

**CYBERTEC**
  - https://www.cybertec-postgresql.com/de/produkte/pgneural_de/
- PostgreSQL

**bigML**
- MySQL
  - https://blog.bigml.com/2013/10/30/data-preparation-for-machine-learning-using-mysql/

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
