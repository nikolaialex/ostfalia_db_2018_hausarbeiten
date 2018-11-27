## 6.1 CouchDB

<img src="./images/LogoCouchDB.png" alt="Logo Mongo DB" style="width: 300px;"/>

### 6.1.1 Beschreibung

Die Entwicklung von CouchDB wurde im Jahre 2005 vom ehemaligen Senior-Entwickler von Lotus Notes, Damien Katz zunächst auf privater Basis und später als Apache-Projekt begonnen. CouchDB orientiert sich an Google BigTable und stellt auch MapReduce über JavaScript zur Verfügung. Dieser Datenbank liegt außerdem die Apache Lizenz 2.0 zugrunde, wodurch sie als Open Source Software einzuordnen ist.

CouchDB zeichnet sich vor allem dadurch aus, dass es auch mit einfachen Grundkenntnissen im NoSQL-Bereich leicht benutzbar ist. Dieses Prinzip vermittelt auch das Logo, welches eine Couch und den Schriftzug "relax" zeigt. Nutzer, die bereits Erfahrungen im Bereich der Webentwicklung sammeln konnten, werden einen leichten Einstieg in CouchDB finden. Der Fokus wurde auf eine unkomplizierte und einfache Nutzung der Datenbank gelegt. Dieses Prinzip der Einfachheit gilt auch für die Fehlertoleranz, Fehlersuche, Skalierbarkeit und Performance von CouchDB. Entsprechend geht man z. B. auch davon aus, dass nicht immer eine Netzwerkverbindung vorhanden ist und Fehler in verteilten Systemen vorkommen können. Anders als erwartet steht das Akronym CouchDB für "Cluster of unreliable commodity hardware Data Base". Zusammenfassend lassen sich die besonderen Merkmale dieses dokumentorientieren Datenbanksystems folgendermaßen beschreiben:

- JSON-Dokumente als Datenspeicher
- HTTP (per REST) für Anfragen
- Zuverlässigkeit
- Konsistenz der Datenspeicherung. [1, 3, 4]

### 6.1.2 Architektur

Bei CouchDB werden alle Daten als JSON-Datenstrukturen gespeichert. Diese können über eine HTTP API (RESTful JSON API) erstellt, gelesen oder aktualisiert werden. Wie bereits erwähnt, erfolgen die Abfragen über JavaScript und das MapReduce-Verfahren. CouchDB basiert auf der Erlang OTP-Plattform, welche die Parallelisierung von Anwendungen ermöglicht. Diese Programmiersprache wurde mit einem Fokus auf Zuverlässigkeit und Verfügbarkeit entwickelt. Das Datenbanksystem ermöglicht die Replikation der Daten auf mehrere Knoten, somit können Lesevorgänge parallelisiert werden. Durch ein MVCC-Modell (Multiversion Concurrency Control) können konkurrierende Zugriffe stattfinden. Der Nutzer erhält über den gesamten Zeitraum der Leseoperation einen konsistenten Snapshot der Datenbank ohne andere Zugriffe zu blockieren. [1, 3, 5]

### 6.1.3 Datenspeicherung

In CouchDB werden Dokumente in Form von JSON-Datenstrukturen abgelegt. Ähnlich wie bei anderen dokumentorientierten Datenbanken geschieht dies schemafrei. Allerdings gibt das JSON Format eine gewisse Struktur durch die Syntax vor. Die Dokumente werden in Unterdatenbanken gespeichert und durch Dokument-IDs bzw. Revisions-IDs indexiert. Die eindeutige Dokument-ID legt der Nutzer selbst fest, die Revisions-ID wird wiederum von CouchDB verwaltet. Sie gibt an, in welcher Version ein Dokument vorhanden ist. Wird eine Instanz aktualisiert, dann lassen sich die Änderungen später anhand der Revisions-ID nachvollziehen. Die einzelnen Dokumente stellen das Pendant zu den Tupeln der relationalen Datenbanken dar. Jedes JSON-Objekt wird durch eine Liste von Eigenschaften aufgebaut, wobei jede Eigenschaft durch ein Key/Value-Paar beschrieben wird. Jeder Value kann zusätzlich eine neue Eigenschaft darstellen. Dieses System ermöglicht die beliebige Verschachtelung von Key/Value-Paaren und Listen. [1, 3]

In JSON werden die folgenden Basistypen definiert: Objekte, Arrays, Zeichenketten, Zahlen, Boolesche Werte und null. Neben der Speicherung wird das kompakte JSON Datenformat auch zur Übertragung der Daten genutzt. Damit entfällt die Umwandlung in andere Formate zur Speicherung in einer Datenbank, was sich durch erhöhte Performance bemerkbar machen kann. [1, 4]

In CouchDB findet außerdem eine Unterscheidung diverser Dokumentarten statt. Die folgenden sind von besonderer Bedeutung:

- Datendokumente
- Virtuelle (nicht persistent) Dokumente
- Design Dokumente


**Datendokumente**

Datendokumente bilden eine geschlossene Einheit von Informationen. Als zusätzliche Metadaten werden die oben angesprochenen Dokument-IDs und Revisions-IDs gespeichert. Wie bereits erwähnt wird die Dokument-ID durch den Benutzer vergeben. Es wird empfohlen dafür einen Universally Unique Identifier (UUID) zu verwenden, aber auch benutzerdefinierte IDs funktionieren. Diese UUIDs kann CouchDB auch mit Hilfe eines speziellen GET-Request selbst generieren. Im folgenden Beispiel ist ein Datendokument zusehen, welches die Dokument-ID bzw. Revisions-ID als Value zu den Keys `"_id"` und `"_rev"` zuordnet. [3]


```
{
	"_id"       :	"00a271787f89c0ef2e10e88a0c00048b", 
	"_rev"      :	"1-60e25d93dc12884676d037400a6fa189", 
	"tutor"     :	"Hans Maier", 
	"lecture"   : 
		{
			"Quantencomputer"   : "Raum 102", 
			"Mathematik 1" 		: "Raum 220", 
			"Web Development"	: "Raum 138",
            "Softwaretechnik"	: "Raum 68" 
		} 
}
```

**Virtuelle Dokumente**

Grundsätzlich werden zwar alle Informationen in einem Dokument gespeichert. Da dies aber auch Nachteile mit sich bringen kann, ist es manchmal notwendig, diese in mehrere logische Dokument-Typen aufzuteilen. Als Beispiel werden oft Blogposts und die dazugehörenden Kommentare genannt. Virtuelle Dokumente werden dazu verwendet, um diese verteilten Informationen als zusammengehörendes Dokument darzustellen. Mit Hilfe einer Abfrage lassen sich diese temporären Views anzeigen, welche auch als Ad-Hoc-Abfragen bezeichnet werden können. [3]

**Design Dokumente**

Design Dokumente werden von CouchDB genau wie Datendokumente gespeichert und behandelt. Bei einer Replikation werden sie beispielsweise genauso auf die Zieldatenbank kopiert. Der entscheidende Unterschied ist jedoch, dass sie Quellcode enthalten, der mit Hilfe des eingebauten JavaScript-Query-Servers ausgeführt werden kann. Um ein Design-Dokument zu kennzeichnen muss dessen ID mit dem Präfix „_design/“ beginnen. Dieser Dokumenttyp kann aus folgenden Komponenten bestehen :

- View-Funktionen
- Show-Funktionen
- List-Funktionen
- Update-Funktionen
- Validierungs-Funktionen [3, 5]

### 6.1.4 Kommunikation

CouchDB greift zur Kommunikation auf das HTTP Protokoll zurück, da dieses bereits standardisiert und vergleichsweise leicht zu verwenden ist. Zur Übermittlung, Abfragung und Manipulation aller relevanten Daten wird das Architekturprinzip REST verwendet. Jede Ressource wird durch eine URI (Uniform Resource Identifier) beschrieben. Auf diese kann jeweils durch die HTTP-Aufrufe GET, POST, PUT, DELETE zugegriffen werden. Durch die Nutzung dieser etablierten Internettechnik gibt es zahlreiche Möglichkeiten dieses Datenbanksystem anzusteuern. [1, 3]

### 6.1.5 Views

In CouchDB werden zur Aggregation und Darstellung der Daten Views verwendet. Diese greifen nur lesend auf die jeweiligen Dokumente zu und werden dynamisch erzeugt, sobald sie benötigt werden. Außerdem können verschiedene Views erstellt werden, die auf den gleichen Daten basieren. Views werden in den bereits bekannten Design Dokumenten definiert. Zur Erstellung werden MapReduce-Funktionen in der JavaScript-Programmiersprache verwendet. Diese aggregieren die gewünschten Daten, um sie anschließend in der View anzeigen zu können. Weitere Nutzungsmöglichkeiten sind beispielsweise die Filterung von Dokumenten oder die Extraktion und Aufbereitung von Informationen aus Dokumenten. Ebenso kann damit nach Informationen oder Strukturen gesucht und Berechnungen durchgeführt werden. [1, 3]

**MapReduce-Funktion**

Die Views werden automatisch von CouchDB erzeugt, wenn diese vom Anwender abgerufen werden. In diesem Fall wendet das Datenbanksystem die Map-Funktion auf alle Dokumente an. Das Resultat dieser Funktion bezeichnet man als View-Ergebnismenge bzw. View-Rows. Die View-Ergebnismenge kann beliebig viele Einträge in Form von Key/Value-Paaren enthalten. Das folgende Beispiel zeigt eine Map-Funktion.

```
function(doc) {
	if (doc.tutor && doc.lecture) {
		emit([ doc.tutor, doc.lecture ], 1);
	}
}
```

Im Beispiel bekommt die Map-Funktion ein Dokument als Parameter "doc" übergeben. Da die Map-Funktion auf alle Dokumente angewendet wird, muss anschließend geprüft werden, ob das übergebene Dokument die Schlüssel "tutor" und "lecture" enthält, um die entsprechenden Dokumente herauszufiltern. Im Anschluss trägt die emit-Funktion ein Key/Value-Paar in die Ergebnismenge ein. Sind mehrere Einträge gewünscht, dann kann die emit-Funktion auch mehrere Male aufgerufen werden. Im Beispiel wird eine Kombination aus den beiden Eigenschaften "tutor" bzw. "lecture" in einem Array als Schlüssel zurückgegeben.

Das folgende Beispiel zeigt eine einfache Reduce-Funktion .

```
function(keys, values, rereduce) {
   return sum(values);
}
```

Zur Betrachtung der Reduce-Funktion ist es wichtig zu wissen, dass die Ergebnismenge der Map-Funktion als B+-Baum verwaltet wird. Die Reduce-Funktion durchläuft jeden Knoten des Baums, sofern keine Filterung stattfindet. In den ersten beiden Parametern werden Keys und Values übergeben. Diese werden zwischengespeichert. Der dritte Parameter bestimmt, ob ein Blätter-Knoten oder ein innerer Knoten durchlaufen wird. Da bei B+-Bäumen die Nutzdaten nur in den Blättern gespeichert werden, ist eine derartige Unterscheidung notwendig. Auf einzelne Einträge aus der Ergebnismenge der Map-Funktion können bei den Blättern Operationen ausgeführt werden. Bei den inneren Knoten wiederum kann mit den gespeicherten Zwischenergebnissen weitergearbeitet werden. [3]

### 6.1.6 Replikation

Das Replizieren, also das Übertragen von Daten auf andere Knoten, ist bei CouchDB ein inkrementeller Prozess. Dieser kann sowohl kontinuierlich stattfinden, als auch von der Anwendung selbst ausgelöst werden. CouchDB unterstützt bidirektionale Konflikterkennung und bidirektionales Konfliktmanagement, was eine Parallelisierung der Lesezugriffe ermöglicht. Dokumente werden einzeln bei der Replikation auf verschiedene CouchDB-Knoten verteilt, die sich an verschiedenen Orten befinden können. Dadurch können bessere Zugriffszeiten erreicht werden. Ein weiterer Vorteil ist das Fortsetzen der Übertragung bei Abbruch der Kommunikation. In diesem Fall muss das System nicht neugestartet werden und die Kommunikation kann beim letzten übertragenen Dokument fortgesetzt werden. Dieses Datenbanksystem geht davon aus, dass nicht immer eine Verbindung zwischen den einzelnen Datenbank-Knoten besteht, man spricht auch von "offline by default". Die Synchronisation erfolgt wie geplant, sobald die entsprechenden Knoten wieder verbunden sind. Üblicherweise entstehen dabei jedoch Konflikte, die allerdings von CouchDB markiert und im Anschluss gelöst werden können.

Findet gerade eine Replikation statt, dann sind die Dokumente nicht für den Zugriff gesperrt und trotzdem weiterhin verfügbar. Da jedes Dokument eine Revisions-ID besitzt, kann die Konsistenz trotzdem gewährleistet werden, da eventuelle Änderungen anhand dieser ID nachvollzogen werden können.

CouchDB erlaubt die bidirektionale Übertragung aller Dokumente über Replikationen, wodurch Datenbankanwendungen in ihrer Gesamtheit, einschließlich Anwendungsdesign, Logik und Daten, repliziert werden können. [1, 3]

### 6.1.7 Sicherheit

CouchDB bietet für die Zugriffskontrolle ein einfaches Modell, welches zwischen Administrator Access, Reader Access und Update Validation unterscheidet.

**Administrator Access**

Administratoren dürfen neue Accounts anlegen. Sie besitzen weiterhin den Zugriff auf die Design Dokumente, welche die View-Funktionen bereitstellen.

**Reader Access**

Für die Dokumente können Nutzerlisten erstellt werden, mit Hilfe derer sich die Leseberechtigungen einschränken lassen.

**Update Validation**

Die Schreibrechte werden im Hintergrund dynamisch durch JavaScript-Funktionen validiert. [1, 3]

### 6.1.8 Bewertung

CouchDB setzt auf einen webanwendungsnahen Aufbau und ist deshalb auch besonders für solche Anwendungen gut geeignet. Weiterhin ist die Datenbank so für zukünftige Entwicklungen im Internet gewappnet. Wenn es vornehmlich um die Eingabe und Speicherung von Daten geht, ist dieses Datenbanksystem eine gute Wahl. Werden Daten häufig bearbeitet oder komplexe Abfragen durchgeführt, dann eignen sich dafür herkömmliche relationale Datenbanken mehr. SQL beispielsweise stellt derartige Funktionen von Haus aus bereit, während in CouchDB das meiste selbst programmiert werden muss. Auf der anderen Seite kann es auch als Vorteil gesehen werden, wenn der Anwender so wenig wie möglich eingeschränkt wird und man ihm freie Hand lässt. Zwar ist JavaScript als Standard Programmiersprache implementiert, theoretisch kann aber jede beliebige Sprache, die über die Standardkonsole kommuniziert, eingesetzt werden.

CouchDB möchte kein Konkurrent zu relationalen Datenbanksystemen sein, es wurde ganz einfach für einen anderen Anwendungsfall vorgesehen. Durch die "offline by default" Mentalität und die entsprechende Konflikterkennung und -bewältigung kann dieses System als Bindeglied zwischen online und offline Anwendungen gesehen werden.

Aus diesem Grund wird CouchDB besonders häufig in mobilen bzw. Office-Anwendungen im Web eingesetzt. Derzeit findet es Anwendung bei der BBC, Meebo, Assay Depot und Engine Yard. Außerdem ist es integraler Bestandteil des Ubuntu-Betriebyssystems. [1, 2, 3]

------

[1] Edlich, S. (2011). NoSQL. München: Hanser. <br>
[2] Kurowski, O. (2012). NoSQL Einführung. Frankfurt am Main: entwickler.press.  <br>
[3] Datenbanken Online Lexikon | Datenbanken / Apache CouchDB. (o.D.). Abgerufen 14. November, 2018, von http://wikis.gm.fh-koeln.de/wiki_db/index.php?n=Datenbanken.CouchDB <br>
[4] CouchDB: The Definitive Guide. (o.D.). Abgerufen 15. November, 2018, von http://guide.couchdb.org/ <br>
[5] Overview — Apache CouchDB 2.2 Documentation. (o.D.). Abgerufen 18. November, 2018, von http://docs.couchdb.org/en/stable/ <br>

------

[< Übersicht wichtiger dokumentorientierter Datenbanken](08_Übersicht-wichtiger-dokumentorientierter-Datenbanken.md)		|   [MongoDB >](10_MongoDB.md)
