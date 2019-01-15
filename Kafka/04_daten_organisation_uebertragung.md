# Organisation und Übertragung von Daten
In diesem Kapitel wird die Organisation und Übertragung von Daten im Kafka-Konstrukt dargestellt.

## Messages
Die Messages, auch Record genannt, werden zwischen Produzent und Apache Kafka sowie Kafka und Konsument ausgetauscht und stellen die zentrale Einheit der Kommunikation zwischen diesen Komponenten dar (Narkhede et al., 2017, S. 4). In Messages werden gemäß Narkhede et al. (2017, S. 4) die Nutzdaten übertragen, welche als Schlüssel ("Key"), Wert ("Value") und Header-Informationen organisiert sind, wobei es sich bei einem Key und bei den Informationen des Headers um optionale Angaben handelt. Während der Inhalt der Message demnach den Payload darstellt, erfolgt über den Schlüssel das Routing zu einem Topic sowie einer Partition.

Für den optimalen Einsatz von Kafka eignen sich kleine Messages, die im besten Fall mit Kilobyte bemessen sind und ein Megabyte nicht überschreiten (Cloudera, 2018). Die Speicherung von Messages erfolgt in Kafka als Byte-Array, sodass der Payload der Nachrichten für Kafka grundlegend nicht zugänglich ist und damit eine Verarbeitung der Informationen in Kafka ausgeschlossen ist (Narkhede et al., 2017, S. 4). Kafka schreibt Messages in ein Log, in welchem die einzelnen Nachrichten anhand ihrer eindeutigen Zuordnung einer Offset-Number identifizierbar sind  (Bejeck & Narkhede, 2018, S. 26 ff.). Sobald eine Message ins Log geschrieben wurde, kann sie nicht mehr modifiziert werden. Grundlegend stehen Nachrichten auch nach der Auslieferung an einen Konsumenten zur Verfügung, wodurch eine Message mehrmals, gegebenenfalls durch mehrere Konsumenten, entgegengenommen werden kann ("Write Once Read Many").

### Speicherung von Messages
Für die persistente Speicherung von Messages kommt ein Logfile zum Einsatz (Narkhede et al., 2017, S. 5). Neue Messages werden hierbei am Ende an diese Datenstruktur angehängt, um gespeichert zu werden und damit unveränderbar zu sein (Bejeck & Narkhede, 2018, S. 28). Ein Log bzw. Logfile lässt sich laut den Autoren Bejeck und Narkhede (2018, S. 28) in mehrere Segmente unterteilen, von denen ein oder mehrere Segmente genutzt werden, um Messages einer Partition zu speichern. Die Anzahl der Segmente eines Logs erhöht sich beispielsweise, wenn ein Größenlimit oder ein Zeitlimit überschritten wird. Innerhalb eines Segments werden Messages, wie oben bereits erwähnt, als Byte-Array gespeichert. Während es grundsätzlich unmöglich ist, mit Apache Kafka einzelne Messages zu löschen, erfolgt eine regelmäßige Prüfung, ob ein gesamtes Segment, welches momentan nicht für den Schreibzugriff geöffnet ist, entfernt werden kann (Bejeck & Narkhede, 2018, S. 37).

## Topics
Für die Datenübertragung mit Kafka kommen Topics zum Einsatz (Apache Software Foundation, 2017), bei denen es sich um logische Kategorien bzw. Container handelt. In Topics werden Messages für einen identischen oder ähnlichen Zweck, beispielsweise bezogen auf Nutzungsszenario, Datenformat oder Modul, zusammengefasst (Narkhede et al., 2017, S. 5; Bhole, Chapte & Karve, 2018, S. 2). Während sich automatisch generierte Topics für den Testbetrieb eignen, sollten sie für den produktiven Einsatz nach einem frei definierbaren Namensschema Bezeichnungen erhalten (Narkhede et al., 2017, S. 24). Für die Anzahl der Topics existiert keine Beschränkung, eine Umbenennung des Topics ist jedoch nicht vorgesehen. Eine "Umbenennung" ist nur (noch) möglich, indem ein Topic gelöscht und neu angelegt wird. Narkhede et al. (2017, S. 182) beschreibt, dass Topic-Bezeichnungen zu Beginn mit ``__`` gekennzeichnet sind.

Über die Kommandozeile lässt sich ein neues Topic mit der Bezeichnung ``dbtech``, vier Partitionen und einem Replikationsfaktor ``4`` mit folgendem Befehl anlegen:

```bash
/bin/kafka-topics.sh --create --zookeeper zookeeper.local:2181 --replication-factor 4 --partitions 4 --topic dbtech
```

Die Relationen zwischen Produzent und Topic sowie Topic und Konsument lassen sich als n-zu-m-Beziehung verstehen. Ein einzelner Produzent oder eine Vielzahl von Produzenten kann Messages zu einem Topic oder diversen Topics senden (Narkhede et al., 2017, S. 6). Auch können laut den Autoren (S. 6) Messages eines Topics oder mehrerer Topics von einem oder einer größeren Menge Konsumenten empfangen werden. Für die Speicherung dieser Daten verwendet Apache Kafka - wie oben bereits ausführlicher erklärt - intern Topics.

Ist es gewünscht oder notwendig, sich Informationen bzw. Details zu einem existierenden Topic zu verschaffen, ist dies über die Kommandozeile ebenso möglich:

```bash
/bin/kafka-topics.sh --describe --zookeeper zookeeper.local:2181 --entity-type topics --entity-name dbtech
```

## Partitionen
Ein Topic umfasst laut der Apache Software Foundation (2017) mindestens eine Partition, wobei es sich im Regelfall um mehrere Partitionen handelt. In einer Partition wird eine Teilmenge aller Messages zu einem Topic zusammengefasst, wodurch es sich bei einer Partition um eine geordnete Sequenz von Messages handelt, welche nach erfolgter Persistierung unveränderlich ist. Die Möglichkeit, innerhalb eines Kafka-Clusters mehrere Komponenten, beispielsweise Broker und Konsumenten, mehrfach und verteilt zu betreiben, erlaubt eine parallele Abarbeitung. Konkret bedeutet dies, dass für jedes Topic jeweils nur eine Partition auf einem Broker abgespeichert wird und durch die Verteilung der Partitionen mehrere Produzenten zeitgleich in mehrere Partitionen schreiben können. Analog dazu können auch mehrere Konsumenten von unterschiedlichen Partitionen auf den verteilten Brokern Lesevorgänge durchführen (Shree et al., 2017, S. 2). Durch die lose Kopplung und den redundanten, verteilten Aufbau der Komponenten lässt sich dadurch ein Load Balancing betreiben.

Die Zuordnung einer Message zum Speicherort, also zur Partition, wird durch den Produzenten vorgenommen (Narkhede et al., 2017, S. 59). Das genaue Verfahren der Zuordnung ist den Autoren nach davon abhängig, ob für die Erstellung der Message ein Schlüssel bzw. Key zum Einsatz kam oder nicht. Liegt kein Key vor, so erfolgt die Zuordnung bzw. Verteilung gemäß eines "Round Robin"-Algorithmus und die Partitionen werden dabei jeweils abwechselnd durchlaufen. Im Falle eines vorhandenen Keys kommt dieser für die Zuordnung zum Einsatz.

### Replikation von Partitionen
Apache Kafka bietet die Möglichkeit, Partitionen eines Topics auf weitere Broker replizieren zu können und damit Kopien auf mehreren Brokern vorzuhalten (Narkhede et al., 2017, S. 8). Die Replikation und die damit einhergehende Redundanz zielt darauf ab, eine Ausfallsicherheit zu bieten. Die Anzahl der Broker, auf welchen eine bestimmte Partition gespeichert werden soll, wird mit dem sogenannten Replikationsfaktor bemessen, welcher in den Einstellungen des Brokers für alle Topics festgelegt werden kann. Hierbei gilt, dass ``Replikationsfaktor - 1`` Broker ausfallen können, ohne den Betrieb zu stören oder einen Datenverlust zu bewirken (Apache Software Foundation, 2017; Narkhede et al., 2017, S. 118). Anders ausgedrückt muss der Replikationsfaktor so gewählt werden, dass mindestens ein Broker permanent zur Verfügung steht, um den Betrieb zu gewährleisten (Narkhede et al., 2017, S. 118 f.). Beim Erstellen eines Topics ist es möglich, den vordefinierten Faktor zu überschreiben.

Werden Partitionen repliziert, so besteht die Herausforderung, mit Messages verschiedener Produzenten umzugehen, ohne den konsistenten Zustand zu verlassen. In Apache Kafka erfolgt gemäß Narkhede et al. (2017, S. 97) die Lösung durch die Deklarierung einer Partition eines Topics als Leader, während alle anderen Partitionen Follower darstellen. Die Kommunikation zwischen Produzent und Broker sowie Broker und Konsument verläuft ausschließlich über die Leader.

---

| [<< Architektur von Apache Kafka](03_kafka_architektur.md) | Organisation und Übertragung von Daten | [Einfaches Beispiel zum Streaming mit Apache Kafka >>](05_beispielimplementierung_streaming.md) |
|------------------------------------------------------------|----------------------------------------|-------------------------------------------------------------------------------------------------|
