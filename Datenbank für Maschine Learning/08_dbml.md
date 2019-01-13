***

## Datenbanken für ML


Grundsäzlich ist die Wahl der Datenbank bzw. der DBMS davon abhängig welche Art von Daten für ML verwendet werden.
Die Anforderungen an Datenbanken wird im nächsten Abschnitt (vgl. 09_dbml_requirements) aufgezeigt.

Die meisten Datenbanken bzw. DBMS unterstüzten von Haus aus kein Machine Learning. Aus diesem Grund werden 3rd Party Frameworks bzw. Bibliotheken benötigt. Diese werden hier für Datenbanken vorgestellt, die keine ML Unterstützung anbieten.

- Built-in machine learning
- Real-time machine learning
- Machine learning in SQL with extensibility


RapidMiner
-MySQL
-PostgreSQL

Greenplum
- laut Seite für ML optimiert, aber nicht ohne Lib möglich
- MADlib

MLDB

MySQL
- RapidMiner
- bigML
-- https://blog.bigml.com/2013/10/30/data-preparation-for-machine-learning-using-mysql/

PostgreSQL
- CYBERTEC
-- https://www.cybertec-postgresql.com/de/produkte/pgneural_de/
- MADlib
- RapidMiner

MongoDB
- ist keine ML Engine
- nur als Datenspeicher
- um ML Models zu bauen
- scikit learn
--- software bibliothekt zum maschinellen lernen für python.


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

LogicBlox

SimSQL

MemSQL

----

[< Abgrenzungen](07_ml_dds.md)	|	[Anforderungen an ein DBMS >](09_dbml_requirements.md)
