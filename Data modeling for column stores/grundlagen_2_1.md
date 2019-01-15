#2.1 CAP-Theorem und BASE-Modell

Vor dem Web 2.0 Zeitalter wurden die Architekturen von Datenbanksystemen nach dem ACID-Prinzip (Atomicity, Consistency, Integrity, Durability) entwickelt. Dies bedeutete, dass die Konsistenz der Daten das zentrale Thema waren. Inkonsistenzen
durften insbesondere bei parallelen Zugriffen nicht auftreten. Mit den damals zu bewältigen Datenmengen war das kein Problem. Dies änderte sich allerdings mit dem
Internet-Boom. Die Architekturen relationaler Datenbanksysteme lassen keine
horizontale Skalierung, schnelle Replikation und ab bestimmten Datenmengen keine
schnellen Reaktionszeiten (Zugriffszeiten) zu.

Eric Brewer stellte im Jahr 2000 in seinem Vortrag „Principles of Distributed Computing“
sein CAP-Theorem vor und bewies damit, dass die vollständige Vereinbarkeit
von Konsistenz (Consistency), Verfügbarkeit (Availability) und Ausfalltoleranz (Partition
Tolerance) nicht möglich ist. Die Kernaussage des CAP-Theorems besagt, dass
nur zwei dieser drei Größen erreicht werden können. In [EFH+11] werden die drei
Größen genauer beschrieben. So steht Konsinstenz (Consistency) im CAP-Theorem
dafür, dass die verteilte Datenbank nach Abschluss einer Transaktion einen konsistenten
Zustand erreicht hat, auch wenn der Datenbestand über Knoten verteilt ist.
Eine folgende Leseoperation -über welchen Knoten auch immer- muss den aktuellen,
konsistenten Wert zurückliefern. Das bedeutet aber auch, dass der aktualisierte Wert
über alle Knoten repliziert werden muss. Diese Tatsache ist in sehr großen Clustern
nicht mit schnellen Reaktionszeiten vereinbar.

Verfügbarkeit (Availability) setzt aber genau diese schnellen bzw. akzeptablen Reaktionszeiten
voraus. Mit Ausfalltoleranz ist gemeint, dass der Ausfall eines Knotens
oder einer Kommunikationsverbindung nicht zum Ausfall des gesamten Systems
führt, sondern Anfragen weiter verarbeitet werden.

Da nur zwei der drei Größen nach dem CAP-Theorem bedient werden können, wurden
die Architekturen von NoSQL Datenbanken auf Kosten der Konsistenz entwickelt.
Gerade bei Web-Unternehmen wie Facebook, Google, Amazon oder Netflix
entscheiden Verfügbarkeit und Ausfalltoleranz über Gewinn und Verlust.

Als Konsequenz aus dem CAP-Theorem wurde ein neues Modell entwickelt, dass so
genannte BASE-Modell (Basically, Available, Soft State, Eventually Consistent). Hier
wird Konsistenz der Verfügbarkeit untergeordnet. Die Systeme nach BASE erreichen
auch „irgendwann“ einen konsistenten Status. Es ist aber auch möglich das veraltete,
inkonsistente Daten ausgeliefert werden. In [DHJ+07] wird die Verwendung von „Data Versioning“ bzw. „Version Evolution“ beschrieben, die das Problem inkonsistenter
Daten abschwächt.


[<< 2. Grundlagen spaltenorientierter Datenbanken - NoSQL](grundlagen_2.md) - [2.2 Consistend Hashing >>](grundlagen_2_2.md)