# 3. Key Value Stores im Detail
***
[Einleitung](1_Einleitung.md) - [Was ist NoSQL?](2_NoSql.md) - **[Key Value Stores im Detail](3_KV_Detail.md)** - [Key Value Store Datenbanken](4_KV_Datenbanken.md) - [Funktionsweise von KV-Stores](5_KV_Abfragen.md) - [Fazit](6_Fazit.md)
***
Im vorigen Kapitel wurden Ansatzweise die gängisten Typen von NoSQL Datenbanken vorgestellt. Darunter auch der Key Value Store, welcher in diesem Kapitel weiter vertieft werden soll. Der Einfachheit halber werden Key Value Stores nachfolgend des öfteren durch KV-Stores abgekürzt.

Wie es bereits in [2.2.1](2_NoSql.md) ersichtlich war, sind KV-Stores ein sehr einfaches System zur Ablage von Informationen, bei dem lediglich ein Schlüssel auf einen beliebigen Wert verweist. Dieser Wert kann zum Beispiel ein String, eine Liste oder Hashes von unterschiedlicher Länge sein und beliebige Daten enthalten.[02]
KV-Stores lassen sich zudem in zwei Arten gleidern, welche nachfolgend beschrieben werden.

### 3.1 Arten von KV-Stores
- In-Memory: Hierbei werden die Daten im Hauptspeicher des Systems gespeichert. Dadurch wird eine hohe Performanz erreicht, da die Daten nicht erst von einer Festplatte gelesen werden müssen und somit die Zugriffszeiten minimal sind. Der Nachteil hierbei ist das Risiko eines Datenverlusts im Falle eines Server-Fehler, welcher dazu führt, dass der Server ausfällt oder neugestartet werden muss. Demnach bieten sich In-Memory-Datenbanken als Cache-Speichersystem an.

- On-Disk: Anders als bei In-Memory werden die Daten hier direkt auf der Festplatte gespeichert und somit dient diese Variante als Datenspeicher. Der Performanz-Verlust durch die Speicherung auf Festplatten und der dadurch entstehenden Zugriffszeiten geht einher mit einer hohen Sicherheit der Daten. Durch Nutzung von SSD-Speicher kann allerdings wieder ein deutlich höhere Performanz erzielt werden. [01, Abschnitt: "Key-Value-Datenbanken: Redis"]

### 3.2 Konsistenz
Die Konsistenz ist schwach und

### 3.3 Vor- und Nachteile von KV-Stores
Zu den Vorteilen gehört die schnelle Verarbeitung der Daten, welche durch das sehr einfache Schema des Datenmodells erreicht wird. Auch die gute Skalierbarkeit fällt positiv auf.
Der KV-Store übernimmt auch einen Teil der Verantwortung des Schemas und versioniert das Datenmodell im Falle einer Änderungen. Somit können dem Modell neue Felder hinzugefügt werden, ohne dass die Datenbank für eine gewisse Zeit nicht erreichbar ist. Die Konvertierung der Daten geschieht unbemerkt vom Anwender im Hintergrund, welcher selber noch auf der vorigen Version des Modells arbeitet.[02]

Die Tatsache, dass KV-Stores lediglich über den Schlüssel abgefragt werden können, schränkt die Komplexität der Abfragen sehr stark ein. Hier muss das eingesetzte Datenbanksystem eine entsprechend umfangreiche API bieten, um ansatzweise komplexe Abfragen zu erstellen. Weiterhin gibt es keine Indizes sowie umfangreiche Suchalgorithmen. [02]

***
[<< Was ist NoSQL?](2_NoSql.md) - [Key Value Store Datenbanken >>](4_KV_Datenbanken.md)

#### Quellenangaben
```
Medienverweise:

[01] - NoSQL im Überblick
(Quelle: https://www.heise.de/ct/artikel/NoSQL-im-Ueberblick-1012483.html Zugriff am 08.01.2019)

[02] - Key/Value-Datenbanksysteme
(Quelle: http://www.datenbanken-verstehen.de/lexikon/key-value-datenbanksysteme/
 Zugriff am 08.01.2019)


```
