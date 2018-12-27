# 3 ACID Eigenschaften und ihre Unterschiede zum CAP-Theorem

Bereits 1983 formulierten Härder und Reuter vier konzeptionelle Eigenschaften
von Datenbank-Systemen [1]. Diese Eigenschaften werden im Englischen mit Atomicity (A), Consistency (C), Isolation (I) und Durability (D) bezeichnet [1].

Die Überschneidungen und Unterschiede der Begriffe *Atomicity* und *Consistency*
von ACID werden den Verwendungen im CAP-Theorem gegenübergestellt.

Die ACID-Taxonomie nach Härder und Reuter definiert *Atomicity* als Eigenschaft
einer Datenbank eine Transaktion von ihrem Anfang bis zu ihrem Ende anzuwenden;
 erfolgt zwischen Anfang und Ende ein Fehler so werden die bis dahin angewendeten
 Teilaktionen der Transaktion rückgängig gemacht [1]. *Consistency* garantiert
 valide Zustände der Datenbank für alle bestehenden Verbindungen zu dieser
 Datenbank-Instanz (bei erfolgreichen Transaktionen) [1].  
Die Eigenschaft *Isolation* isoliert mehrere Transkationen voneinander, so dass
"aus Sicht" einer einzelnen Transaktion weitere Transaktionen entweder vor ihr
oder nach ihr angewendet werden [1]. *Durability* stellt sicher, dass eine
abgeschlossene Transaktion gegen einen Fehlerfall einer Datenbank-Instanz
abgesichert ist, zum Beispiel durch ein *flush*-Kommando auf das unterliegende
Speichersystem [1]. Ein anschauliches Beispiel ist die Sitzplatz Reservierung
auf einem Flug. *Durability* stellt sicher, das der erfolgreich reservierte
Sitzplatz auch nach einem Fehlerfall als reserviert behandelt wird.

Die Ideen von ACID und CAP zielen auf einen jeweils anderen Bezugsbereich ab.
Insbesondere bei der Konsistenz unterscheiden sich die beiden Eigenschaftsmengen.  
ACID bezieht sich bei der Konsistenz auf eine einheitliche Sicht auf die
geänderten über alle bestehenden Datenbank Verbindungen.  
CAP betrachtet hierbei die eventuelle Konsistenz der Daten über alle
Knoten in einem Datenbank-Cluster.



|**Eigenschaft**|**ACID**|**CAP**|**Konflikt**|
|--- |--- |--- |--- |
|Durability|“Once a transaction completes successfully, its changes to the state survive failures.” [D2]|The word and the concept are not used.|Nein|
|Consistenty|Integrity constraints on the data (data types, relations, …)|For CAP, Consistency is a shortcut for “Atomic Consistency”. The atomic consistency is a consistency model. More on this later.|Gleicher Begriff, verschiedene Konzepte|
|Isolation|“Even though transactions execute concurrently, it appears to each Transaction, T, that others executed either before either after T”. [D2]|The word is not used in CAP but the word Isolation as defined in ACID is a consistency model in CAP vocabulary.|Unterschiedliche Begriffe aber gleiches Konzept|
|Atomicity|All changes happen or none happen.|For CAP, Atomic is a consistency model, the one used in the CAP proof.|Gleicher Begriff, verschiedene Konzepte|
|Availability|Concept not often used. If so, the definition can be different than in CAP, i.e. available may not require all the non-failing nodes to respond.|“every request received by a non-failing node in the system must result in a response” [C2]|Gleicher Begriff, gleiches Konzept, unterschiedliche Definitionen|
|Partition(-tolerance)|Concept not often used. If so, the definition is the same as in CAP.|Two sets of nodes are partitioned when all messages between them are lost.|Nein|

Tabelle 1: Übersicht der unterschiedlichen Begriffsbezüge bei ACID und CAP
(aus dem Englischen in Anlehnung an Liochon 2015, [2])

<br />

[1] Haerder, T., & Reuter, A. (1983). Principles of transaction-oriented
  database recovery. *ACM Computing Surveys, 15*(4), 287-317. doi:10.1145/289.291

[2] Liochon, N. (2015). The confusing CAP and ACID wording.
URL: http://blog.thislongrun.com/2015/03/the-confusing-cap-and-acid-wording.html,
letzter Aufruf: 2018-12-11
