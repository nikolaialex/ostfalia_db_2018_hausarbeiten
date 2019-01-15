***

[<< zurück](02_toc.md)

***

# 4.2. Technische Aspekte

Viel spaltenorientierte Datenbanken sind inspiriert von dem System Bigtable von Google und bauen darauf auf. [Ma14]. Zu den wichtigsten Komponenten von spaltenorientierten Datenbanken zählt das verteilte Dateisystem (GFS). Ein Vorteil von einem geteilten Datenbanksystem ist, dass die Speicherung von Log-Dateien und Daten getrennt sind. Somit ist die Verfügbarkeit und Vertraulichkeit der Informationen zwischen den Maschinen einfacher bewahrt.[Br12]

Zu den typischen Eigenschaften von Spaltenorientierten Datenbanken zählen
- die hohe Skalierbarkeit
- hohe Ausfallsicherheit
- Redundanz



## 4.2.1 Skalierbarkeit
Die Skalierbarkeit von Daten ist einer der wichtigsten Eigenschaften. Für Firmen ist es sehr wichtig große Mengen von Datensätzen zu speichern. Durch die Verwendung von Commodity Hardware kann einer horizontale Skalierung von Rechnerleistung bei Bedarf einfacher ermöglicht werden. Unter Commodity Hardware versteht man relativ kostengünstige, verbreitete und austauschbare Hardware, die man zusammenschließen und leicht erweitern kann.[WT18] Mit diesem System arbeitet Google bei Bigtable.

## 4.2.2 Ausfallsicherheit
Neben der Skalierbarkeit der Leistungsfähigkeit ist besonders im Online Handel die Verlässlichkeit vor Ausfällen sehr wichtig. Mit dem Datenbanksystem Dynamo hat Amazon einen sehr großen Schwerpunkt auf die Zuverlässigkeit seines Systems gelegt. Die Möglichkeiten für Ausfall sollte so weit es geht eliminiert werden. Dynamo nutzt intensiv die Objektversionierung und setzt auf geteilte Dateisysteme.[DHJ07] Genau dieses Prinzip der verteilte Dateisysteme hat Cassandra aufgenommen. 

Um eine Robustheit des Systems zu gewährleisten, nutzt Cassandra das Prinzip der Distributed Hash Tables. Dieses ist Prinzip einer Speicherung von Daten in einem P2P-System. Die Vorteile sind die hohe Fehlertoleranz, Lastenverteilung, Robustheit und Skalierbarkeit. Die Verteilung der Daten geschieht gleichmäßig über die gegebenen Speicherknoten.[WVH18]
Da der Schlüssel an alle Knoten eines Clusters verteilt werden, so dass eine Unabhängigkeit zu einem bestimmten Masterknoten besteht, wie bei Bigtablet.[Br1]

## 4.2.3 Redundanz/Replikation
Sollte es zu einem Ausfall oder Verlust kommen, macht z.B. Cassandra Replikate, um eine Robustheit des Systems zu gewährleisten. Dabei wird das Replikationsfaktor N für die Anzahl der Replikaten genutzt, die auf unterschiedlichen Knoten bzw. Maschinen gespeichert werden. Diesen Faktor N kann der Nutzer selbst bestimmen.[Ga12]    

## 4.2.4 Systeme

Die bekannten Wide Column Stores, wie Dynamo, Hbase und Cassandra, sind Cross- Plattformen und sind alle in der Programmiersprache Java geschrieben.[MH13] Im Kapitel 6 werden die bekannten Systeme Cassandra und HBase vorgestellt.


***

[<< Datenmodell](06-1_data_model.md) | [Spaltenorientierte Speicherung >>](06-3_storage.md)

***

```
Quellenangabe:

- [Ma14]  V. Manoj, Comparative Study of NoSQL Document, Column Store Databases and Evaluation of Cassandra, 2014, S. 13
- [Br12]  F. Bruckner, Wide Column Stores, 2012, S.5
- [WT18]  https://whatis.techtarget.com/definition/commodity-hardware, abgerufen 26.12.2018
- [DHJ07] G. DeCandia et al, Dynamo: Amazon’s Highly Available Key-value Store, 2007, S. 205
- [WVH18] https://de.wikipedia.org/wiki/Verteilte_Hashtabelle, 26.12.2018
- [Br12]  F. Bruckner, Wide Column Stores, 2012, S.5
- [Ga12]  M. Gassner, Einsatz von (No)SQL-Datenbanken am Beispiel von Facebook, 2012, S.10
- [MH13]  A. B. M. Moniruzzaman und S. A. Hossain, NoSQL Database: New Era of Databases for Big data Analytics - Classification, Characteristics and Comparison, 2013. S. 9

```
***