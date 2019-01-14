***

[<< zurück](02_toc.md)

***

# 6. Anwendungsbeispiele
In diesem Abschnitt stellen wir kurz die zwei großen spaltenorientierten Datenbanken vor, die ihre Spalten separat speichern: Cassandra und HBase. Es gibt eine Vielzahl von Open Source Datenbanken, auf die dies nicht zutrifft und deren Performance im Bereich der analytischen Datenarbeit besser ist.   


## 6.1 Cassandra

Cassandra wurde 2007 von P. Malik und A. Lakshman entwickelt, um eine performante Suche mit Hilfe von Indizes zu ermöglichen. Dabei standen Skalierbarkeit und Robustheit im Vordergrund. Das Datenmodell von Cassandra entspricht dem Wide Column Store und ermöglicht nur einfache Anfragen anhand der Schlüssel der Daten und orientiert sich an Google Big Table. Um die Robustheit sicherzustellen werden Replikate von allen Daten angelegt. Die Skalierung ist in Cassandra einfach, da jederzeit weitere Knoten zum System hinzugefügt oder entfernt werden können. Zu erwähnen ist, dass im Gegensatz zu anderen NoSQL-Datenbanken Cassandra eine Art Rückskalierung bereitstellt. Hier kann mit Hilfe eines Managementtools ein Knoten entfernt werden und die für den Knoten bestimmten Informationen neu auf die verbleibenden Knoten verteilt werden.     
Das Konsistenzmodell von Cassandra entspricht dem “eventual consistency” und kann in fünf verschiedenen Leveln eingestellt werden. Diese richten sich nach dem CAP Theorem, bei dem immer nur zwei der drei Eigenschaften (Consistency, Availability und Partition Tolerance) vollständig erfüllt sein können. Wird auf eines mehr Wert gelegt, entfernt man sich zwangsläufig von einem anderen. Die fünf zur Verfügung stehenden Level sind: »Zero«, »Any«, »One«, »Quorum« und »All« . Die Level verschieben die Wichtigkeit der Konsistenz von Null (Zero) zu sehr wichtig (All), wobei die letzte Variante sehr teuer ist und zu Lasten der Verfügbarkeit (Availability) geht.  
Es gibt fünf Hauptbestandteile im Cassandra Datenmodell, die eine sehr große Freiheit in der Datenablage ermöglichen. Wir gehen im folgenden Abschnitt kurz auf die einzelnen Hauptbestandteile ein. [Ga12]

Der **Keyspace**, welcher einer Datenbank in einem relationalem Datenbank Management System entspricht, also die oberste Ebene dastellt. Üblicherweise gibt es nur einen Keyspace, obwohl auch mehrere möglich sind. In ihm werden sogenannte Column Families gespeichert.

Die **Column Families** bestehen aus Rows in denen ein Schlüssel und als Elemente Columns oder Super Columns gespeichert werden. Eine Column Family wird immer in genau einem Keyspace gespeichert und besitzen kein vorgegebenes Schema, an das sie sich halten müssen. Dies stellt einen deutlichen Unterschied zu relationalen Datenbanken dar. Diese Struktur fordert, dass die Interpretation der Daten auf Applikationsebene ablaufen muss. Gespeichert werden sie meistens als Bytes unendlicher Größe und interpretiert als UTF-8 Zeichenketten oder 64bit Integerwerte.

Eine **Row** in einer Column Family setzt sich zusammen aus Columns und Super Column und stellt eine eindeutig identifizierbare Dateneinheit dar.

Um komplexere Datenstrukturen abbilden zu können, gibt es die **Super Columns**. Super Columns sind Columns deren Werte wieder Columns beinhalten.

Der fünfte Bestandteil in Cassandra ist die kleinste Informationseinheit, die **Column**. Sie besteht meistens aus dem Tupel: Name, Wert und Timestamp.


![Cassadnra DatenModell](files/CassandraDatenModell.PNG)

Abbildung 15: Cassadnra Datenmodell aus [KOS-15] </br>


Cassandra wird von Netflix, Twitter und Digg genutzt, sowie bis 2010 von Facebook, die dann zu HBase gewechselt haben. HBase ist eine Technologie die im nächsten Abschnitt vorgestellt wird.

## 6.2 HBase / Hadoop

Hadoop ist ein Framework für skalierbare, verteilt arbeitende Software, mit dem große Datenmengen auf verteilten Rechnersystemen (Hadoop-Cluster) in hoher Geschwindigkeit verarbeitet werden können.[BDI-HD] 

HBase basiert, ähnlich wie Cassandra, auf einer freien Implementierung von Google BigTable und ist eine skalierbare Datenbank. Das vereinfaachte Datenmodell von HBase ist in _Abbildung 16_ zu sehen. Es gibt eine **Table** (Tabelle) in der die **Cells**(Zellen) nach **Column Families** und **Row Keys** organisiert sind. In einer Column Family können zur besseren Organisation der Daten auch noch **Column Qualifiers** vorhanden sein. In der Abbildung sind die Column Qualifiers als _"Colmun Name"_ beschriftet. Innerhalb eines Hadoop-Clusters kann man mit HBase sehr große Datenmengen verwalten. Als 2010 Facebook das Nachrichtensystem geändert hat, hat sich HBase sehr gut geeignet, weil zwar neue Daten oft ergänzt werden, aber die bestehenden Datensätze nicht oft verändert oder aktualisiert werden.[CVHB-19]

![HBase DatenModell](files/HBase.PNG)
Abbildung 16: Datenmodell HBase nach [CVHB-19]

In HBase werden Suchindizes, Textinhalte und Metadaten gespeichert und verwaltet. HBase hat im Gegensatz zu Cassandra eine masterbasierte Architektur und damit einen Single Point of Failure. In HBase wird nach dem Ausfall des Masters eine gewissen Arbeitszeit eingeräumt, da ein HBase-Client nicht direkt mit dem Master kommuniziert, sondern mit dem Slave-Server. HBase hat eine stark konsistente Datenhaltung, ist aber im Gegensatz zu Cassandra nicht immer verfügbar.[CVHB-19]
 
HBase arbeitet mit dem Hadoop Distributed File System (HDFS). HDFS ist ist ein leistungsstarkes Dateisystem zur Speicherung von großen Datenmengen in dem es zwei Arten von Servern, sogenannten Clusternodes gibt, 
den Namenode und den Datanode. HBase speichert Metadaten auf dem NameNode und Datenblöcke werden auf dem DataNode gespeichert. Aus Sicht von Facebook gab es hier den Nachteil, dass bei Ausfall des NameNodes der Cluster nicht mehr erreichbar wäre. Aufgrund dieses Single Point of Failures hat Facebook hier viele eigene Weiterentwicklungen vorangetrieben, die in _[Ga12] (Abschnitt 3.3 Anpassungen,S. 18 ff.)_ nach zu lesen sind.




## 6.3 Weitere Beispiele

#### C-Store / Vertica

C-Store und dessen Erweiterung Vertica ist eine der wenigen echten physischen Column Stores, da die meisten Implementierungen die Daten nur im Arbeitsspeicher spaltenorientiert realisieren.
Es gibt eine vorgelagerte schreiboptimierte Datenbank, in der Änderungen gespeichert werden und dann in regelmäßigen Abständen in den komprimierten Datenbestand synchronisieren.[MG15]


***

[<< Datenstruktur ](07-3_normalized_data_structure.md) | [Datawarehouse und Business Intelligence >>](09_data_warehouse.md)

***

```
Quellenangabe:

[Ga12] - M. Gassner, Einsatz von (No)SQL-Datenbanken am Beispiel von Facebook, Universität Leipzig – Abteilung Datenbanken, 2012, S.6 ff.  
[KOS-15] - F. Eitel, J. Neef, M. Seibold, M. Weber, KOS.content, Ergebnisse der Untersuchungen des bKompetenzzentrum Open Source der DHBW-Stuttgart, Testszenarien für NoSQL-Datenbanksysteme/-dienste aus der Cloud, Paper: https://www.dhbw-stuttgart.de/fileadmin/dateien/KOS/pub_kos.content_1.2015.band2.pdf, Band 2, 2015, S.61
[BDI-HD] - N. Litzel, https://www.bigdata-insider.de/was-ist-hadoop-a-587448/, 01.09.2016, letzter Aufruf 10.01.2019
[CVHB-19] - https://www.scnsoft.de/blog/cassandra-vs-hbase, letzter Aufruf 13.01.2019
[MG15] - Marcel Gladbach, Spaltenorientierte Datenbanken, Hochschule für Technik, Wirtschaft und Kultur Leipzig, Paper, 2015, S.3 ff

```

***