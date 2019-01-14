# 3. Key Value Stores im Detail
***
[Einleitung](1_Einleitung.md) - [Was ist NoSQL?](2_NoSql.md) - **[Key Value Stores im Detail](3_KV_Detail.md)** - [Key Value Store Datenbanken](4_KV_Datenbanken.md) - [Funktionsweise von KV-Stores](5_KV_Abfragen.md)
***
Im vorigen Kapitel wurden Ansatzweise die gängisten Typen von NoSQL Datenbanken vorgestellt. Darunter auch der Key Value Store, welcher in diesem Kapitel weiter vertieft werden soll. Der Einfachheit halber werden Key Value Stores nachfolgend des öfteren durch KV-Stores abgekürzt.

Wie es bereits in [2.2.1](2_NoSql.md) ersichtlich war, sind KV-Stores ein sehr einfaches System zur Ablage von Informationen, bei dem lediglich ein Schlüssel auf einen beliebigen Wert verweist. Dieser Wert kann zum Beispiel ein String, eine Liste oder Hashes von unterschiedlicher Länge sein und beliebige Daten enthalten.[02]
KV-Stores lassen sich zudem in zwei Arten gleidern, welche nachfolgend beschrieben werden. Wie es dem Namen zu entnehmen ist, bstehen Key Value Stores lediglich aus zwei Spalten.

Da Key Value Datenbanken auf keinem bzw. nur einem sehr schwachen Schema beruhen, können Verbindungen zwischen Datensätzen über die Anwendung selber hergestellt  und somit ein einfaches Datenmodell erzeugt werden.

Das nachfoglende Beispiel zeigt wie ein Eintrag in einem KV-Store aussehen könnte:

| Matrikelnummer (Schlüssel / Key)              | Student (Wert / Value)
| ----------------- | ------------------------------ |
|  123456    | Anton-Müller-Musterstr. 22-12345 Musterhausen-3. Fachsemester-...

In dem Beispiel dient die Matrikelnummer als eindeutiger Identifikator und die Wert-Spalte liefert alle Informationen dazu. Hier könnten bei jeden Eintrag beliebig viele Informationen gespeivhert werden, da es keine weiteren Spalten gibt. Die Anwendung, welche die Daten verarbeiten soll, kann die Einträge anhand des Bindestrichs trennen und einzeiln darstellen. Erfolgen Änderungen an einer Information aus der Wert-Spalte, wird der gesamte String erneut in die Spalte geschrieben und gespeichert.

Die Befehle zum Abfragen oder Ändern von Daten aus einem KV-Store sind, je nach System, sehr übersichtlich gehalten. Für das Einfügen, Ändern, Löschen oder einfach nur Abfragen von Werten genügen folgende drei Befehle [03]:

- put(key, value)
- get(key)
- remove(key)

Mit "put" können neue Einträge erfsst werden oder zusammen mit einem vorhandenen Key geändert werden. Mit dem "get" Befehl können Werte unter Angabe des Schlüssel zurückgegebene werden und per "remove" werden die Einträge unter dem angegebenen Schlüssel gelöscht.

### 3.1 Arten von KV-Stores
- In-Memory: Hierbei werden die Daten im Hauptspeicher des Systems gespeichert. Dadurch wird eine hohe Performanz erreicht, da die Daten nicht erst von einer Festplatte gelesen werden müssen und somit die Zugriffszeiten minimal sind. Der Nachteil hierbei ist das Risiko eines Datenverlusts im Falle eines Server-Fehler, welcher dazu führt, dass der Server ausfällt oder neugestartet werden muss. Demnach bieten sich In-Memory-Datenbanken als Cache-Speichersystem an.

- On-Disk: Anders als bei In-Memory werden die Daten hier direkt auf der Festplatte gespeichert und somit dient diese Variante als Datenspeicher. Der Performanz-Verlust durch die Speicherung auf Festplatten und der dadurch entstehenden Zugriffszeiten geht einher mit einer hohen Sicherheit der Daten. Durch Nutzung von SSD-Speicher kann allerdings wieder ein deutlich höhere Performanz erzielt werden. [01, Abschnitt: "Key-Value-Datenbanken: Redis"]

### 3.2 Replikation und Konsistenz
Anders als von relationalen Datenbanken gewohnt, setzen NoSQL Datenbanken im allgemeinen nicht auf ACID (siehe [2.1](2_NoSql.md)). Im Falle von KV-Stores wird auf eher auf eine hohe Verfügbarkeit gesetzt und im Falle eines Updates auf einem Knoten innerhalb eines verteilten Systems, welcher ein Replikat der Master-Datenbank darstellt, wird davon ausgegangen, dass das Replikat irgenwann konsistent zum Master ist. Das beschriebene Verfahren, welches als BASE-System bekannt ist, wird wie folgt definiert:

- BA: Basically Available
- S:  Soft State
- E:  Eventually Consistency

Somit sind KV-Stores auf eine grundsätzliche Verfügbarkeit (Basically available) bei der Daten periodisch abgespeichert werden (soft state). Durch Änderungen verursachte Inkonsistenzen werden irgendwann abgeglichen, um wieder eine Konsistenz zu erhalten (eventually consistency) [03, S.26 ff]. Demnach steht eine hohe Verfügbarkeit sowie eine sehr gute Performanz im Vordergrund und geht einher mit einer nicht ständigen Konsistenz. Demnach ist abzuwägen, ob KV-Stores für ein geplntes Szenario verwendet werden sollten. Bei sicherheitskritischen Anwendungen, bei denen es auf eine hohe Konsistenz ankommt, ist die Verwendung KV-Stores beispielsweise nicht in Betracht zu ziehen. (Finanzen, Gesundheitswesen, ...).

### 3.3 Vor- und Nachteile von KV-Stores
Zu den Vorteilen gehört die schnelle Verarbeitung der Daten, welche durch das sehr einfache Schema des Datenmodells erreicht wird. Auch die gute Skalierbarkeit fällt positiv auf.
Der KV-Store übernimmt auch einen Teil der Verantwortung des Schemas und versioniert das Datenmodell im Falle einer Änderungen. Somit können dem Modell auch zur Laufzeit neue Felder hinzugefügt werden, ohne dass die Datenbank für eine gewisse Zeit nicht erreichbar ist. Die Konvertierung der Daten geschieht unbemerkt vom Anwender im Hintergrund, welcher selber noch auf der vorigen Version des Modells arbeitet.[02]

Die Tatsache, dass KV-Stores lediglich über den Schlüssel abgefragt werden können, schränkt die Komplexität der Abfragen sehr stark ein. Hier muss das eingesetzte Datenbanksystem eine entsprechend umfangreiche API bieten, um ansatzweise komplexe Abfragen zu erstellen. Weiterhin gibt es keine Indizes sowie keine umfangreiche Suchalgorithmen. [02]

***
[<< Was ist NoSQL?](2_NoSql.md) - [Key Value Store Datenbanken >>](4_KV_Datenbanken.md)

#### Quellenangaben
```
[03] - Lie, Tabara, Schierschlicht, Simon, Dimitriadis, Lüning; Datenbanktechnologie (VFHDBT.pdf), Jahr 2018 (Stand: 13.02.2018)

Medienverweise:

[01] - NoSQL im Überblick
(Quelle: https://www.heise.de/ct/artikel/NoSQL-im-Ueberblick-1012483.html Zugriff am 08.01.2019)

[02] - Key/Value-Datenbanksysteme
(Quelle: http://www.datenbanken-verstehen.de/lexikon/key-value-datenbanksysteme/
 Zugriff am 08.01.2019)

 [03] - NoSQL Teil 2: Key-Value Stores am Beispiel von Redis
 (Quelle: https://www.zweitag.de/blog/nosql-teil-2-key-value-stores-am-beispiel-von-redis, Zugriff am 14.01.2018)


```
