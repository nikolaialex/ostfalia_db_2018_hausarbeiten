# 3 ACID Eigenschaften und ihre Unterschiede zum CAP-Theorem

Bereits 1983 formulierten Härder und Reuter vier konzeptionelle Eigenschaften
von Datenbank-Systemen [1]. Diese Eigenschaften werden im Englischen mit Atomicity (A), Consistency (C), Isolation (I) und Durability (D) bezeichnet [1].

Die Überschneidungen und Unterschiede der Begriffe *Atomicity* und *Consistency*
von ACID werden den Verwendungen im CAP-Theorem gegenübergestellt.

Die ACID-Taxonomie nach Härder und Reuter definiert *Atomicity* als Eigenschaft
einer Datenbank eine Transaktion von ihrem Anfang bis zu ihrem Ende anzuwenden;
 erfolgt zwischen Anfang und Ende ein Fehler, so werden die bis dahin angewendeten
 Teilaktionen der Transaktion rückgängig gemacht [1]. *Consistency* garantiert
 valide Zustände der Datenbank für alle bestehenden Verbindungen zu dieser
 Datenbankinstanz (bei erfolgreichen Transaktionen) [1].  
Die Eigenschaft *Isolation* isoliert mehrere Transkationen voneinander, so dass
"aus Sicht" einer einzelnen Transaktion weitere Transaktionen entweder vor ihr
oder nach ihr angewendet werden [1]. *Durability* stellt sicher, dass eine
abgeschlossene Transaktion gegen einen Fehlerfall einer Datenbankinstanz
abgesichert ist, zum Beispiel durch ein *flush*-Kommando auf das unterliegende
Speichersystem [1]. Ein anschauliches Beispiel ist die Sitzplatz Reservierung
auf einem Flug. *Durability* stellt sicher, das der erfolgreich reservierte
Sitzplatz auch nach einem Fehlerfall als reserviert behandelt wird.

Die Ideen von ACID und CAP zielen auf einen jeweils anderen Bezugsbereich ab.
Insbesondere bei der Konsistenz unterscheiden sich die beiden Eigenschaftsmengen.  
In der Praxis bedeutet Konsistenz bei ACID, dass die Sicht auf die Daten
einheitlich über alle Datenbank-Verbindungen ist. Also sehen zwei Client-Systeme
nach einer Anfrage denselben Stand und nicht etwa unterschiedliche.
CAP betrachtet hierbei die eventuelle Konsistenz der Daten über alle
Knoten in einem Datenbank-Cluster.



|**Eigenschaft**|**ACID**|**CAP**|**Konflikt**|
|--- |--- |--- |--- |
|Durability|“Ist eine Transaktion erfolgreich abgeschlossen, so bleibt der geänderte Zustand auch im Fehlerfall erhalten.” [D2]|Wort und Konzept werden nicht benutzt.|Nein|
|Consistenty|Integritaetsbeschränkungen auf die Daten (Datentypen, Relationen, ...)|Für CAP ist Consistency ein Kürzel für “Atomic Consistency”. Dabei ist atomic consistency ein Konsistenzmodell.|Gleicher Begriff, verschiedene Konzepte|
|Isolation|“Obwohl Transaktionen gleichzeitig ausgeführt werden, ist es aus Sicht einer Transaktion T so, das andere Transaktionen entweder vor oder nach ihr ausgeführt werden.” [D2]|Wort wird nicht benutzt. Es tritt aber als Konsistenzmodell auf.|Unterschiedliche Begriffe aber gleiches Konzept|
|Atomicity|Alle Änderungen werden angewendet oder keine.|Für CAP bedeutet Atomic ein Konsistenzmodell, welches im Beweis genutzt wird.|Gleicher Begriff, verschiedene Konzepte|
|Availability|Das Konzept wird nicht oft genutzt. Wenn, dann kann die Definition zu CAP verschieden sein, z. B. ist es nicht zwingend erforderlich das alle fehlerfreien Knoten antworten.|“Jede Anfrage, die von einem fehlerfreien Knoten im Gesamtsystem angenommen wird, muss zu einer Antwort führen.” [C2]|Gleicher Begriff, gleiches Konzept, unterschiedliche Definitionen|
|Partition(-tolerance)|Das Konzept wird so nicht oft genutzt. Wenn, dann ist die Definition gleich zu CAP.|Zwei Mengen von Knoten sind dann partitioniert, wenn alle Nachrichten zwischen diesen Knoten verloren gehen.|Nein|

Tabelle 1: Übersicht der unterschiedlichen Begriffsbezüge bei ACID und CAP
(aus dem Englischen in Anlehnung an Liochon 2015, [2])

<br />

[1] Haerder, T., & Reuter, A. (1983). Principles of transaction-oriented
  database recovery. *ACM Computing Surveys, 15*(4), 287-317. doi:10.1145/289.291

[2] Liochon, N. (2015). The confusing CAP and ACID wording.
URL: http://blog.thislongrun.com/2015/03/the-confusing-cap-and-acid-wording.html,
letzter Aufruf: 2018-12-11


***

[Zwei verteilte Datenbanken setzen CAP praxisorientiert um >>](4_0_Zwei_verteilte_Datenbanken_setzen_CAP_praxisorientiert_um.md)

***
