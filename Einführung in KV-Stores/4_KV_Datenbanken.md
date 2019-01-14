  # 4. Key Value Store Datenbanken
***
[Einleitung](1_Einleitung.md) - [Was ist NoSQL?](2_NoSql.md) - [Key Value Stores im Detail](3_KV_Detail.md) - **[Key Value Store Datenbanken](4_KV_Datenbanken.md)** - [Funktionsweise von KV-Stores](5_KV_Abfragen.md)
***

In diesem Kapitel werden einige KV-Store Datenbanksysteme namentlich genannt und knapp vorgestellt. Eine der vorgestellten Systeme wird im Anschluss daran etwas genauer betrachtet und dient im nachfolgendem Kapitel als Grundlage für die Beispiele.

### 4.1 Überblick KV-Stores
In der nachfolgendenden Tabelle werden die mitunter bekanntesten KV-Stores genannt.

| Name              | Kurzbeschreibung | URL |
| ----------------- | -----------------|------------------------------|
|  Redis           |Open Source, umfangreiche API, Verschiedene Datentypen für Werte, gut Skalierbar, schnell |https://redis.io/  |
|  Arango DB       | Kombination aus Graphendatenbank, JSON Dokumenten und KV-Store, eigene Abfrage-Sprache|https://www.arangodb.com/ |
|  HBase           |Gut skalierbare verteilte Datenbank mit strukturiertem Datenspeicher für große Tabellen. Ideal für Big Data |https://hbase.apache.org/ |
|  Couchbase       |Open Source, verteilte Dokumenten-orientierte Datenbank. Schneller KV-Store, Indizes, Engine für SQL Abfragen, ideal für mobile Anwendungen oder IoT|https://www.couchbase.com/de |
|  Memcached       |Hochperformante verteilte Datenbank|http://memcached.org/ |

### 4.2 REDIS
Redis ist bekannt als eine nicht relationale In-Memory remote Datenbank, welche eine hohe Performanz, Replikation und ein einzigartiges Datenmodell bietet. Zudem können diverse verschiedene Datentypen auf einen Schlüssel verweisen.
Nun haben wir zuvor gelesen, dass In-Memory KV-Stores als Cache dienen und somit ihren sehr guten Geschwindigkeitsvorteil bieten. Gleichzeitig aber geht das auf Kosten der Datensicherheit. Hierfür bietet Redis zwei Persistenz-Formen an. Zum einen die schnelle Cache-Variante, welche im Hauptspeicher ausgeführt wird und zum anderen die Variante in der die Daten auf der Festplatte gespeichert werden. Zu der zweiten Methode gibt es außerdem verschiedene Synchronisations-Optionen, um festzulegen, wann und wie oft die Daten gespeichert werden sollen. [01, S.3 ff]

Folgende Datentypen werden von Redis unterstützt [02]:
- Strings
- Listen (Sammlung von Strings. Sortiert wie eingefügt)
- Sets (Unsortiert, unique Strings)
- sorted sets (wie set nur mit sog. Score-Wert für jeden Wert)
- Hashes
- bit arrays/ Bitmaps
- HyperLogLogs
- Streams

Die Redis API bietet eine umfangreiche Liste an Befehlen, welche unter anderem auf die unterschiedlichen Datentypen zugeschnitten sind aber auch die Möglichkeit bieten um bspw. Werte von Schlüsseln aus einem Bestimmten Wertebereich zu erhalten. Außerdem können Transaktionen sowie die Verbindung selber über die API gesteuert werden. Neben den bereits in "[Key Value Stores im Detail](3_KV_Detail.md)" genannten Befehlen, gibt es darauf basierend erweiterte Befehle, um zum Beispiel mehrere Schlüssel/Wert-Paare anzulegen. Der Befehl "remove" existiert allerdings bei Redis nicht. Hierfür gibt es den Befehl "del".

***
[<< Key Value Stores im Detail](3_KV_Detail.md) - [Funktionsweise von KV-Stores >>](5_KV_Abfragen.md)

#### Quellenangaben
```

[01] - Carlson Redis in Action, 2013

Medienverweise:

[02] - An introduction to Redis data types and abstractions
(Quelle: https://redis.io/topics/data-types-intro, Zugriff am 14.01.2019)
[03] - NoSQL Teil 2: Key-Value Stores am Beispiel von Redis
(Quelle: https://www.zweitag.de/blog/nosql-teil-2-key-value-stores-am-beispiel-von-redis, Zugriff am 14.01.2018)

```
