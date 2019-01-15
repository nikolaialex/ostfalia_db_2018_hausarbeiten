[<- Beipiele](Beispiele.md "Beipiele")

# Praxisbeispiel To-Do-Liste

Im Rahmen einer verteilten Anwendung soll eine gemeinsame To-Do-Liste verwaltet werden. Dabei können Anomalien auftauchen, die aus der gemeinsamen verteilten Bearbeitung resultieren. Beispielsweise kann ein Benutzer einen Eintrag löschen, während ein anderer Nutzer denselben Eintrag bearbeitet hat.

Um einen konsistenten verteilten Datenbestand zu erhalten, ist es nötig, die Verfahren zum Abgleich der verschiedenen Bearbeitungsstände so zu definieren, dass alle Teilnehmer das gleiche Ergebnis erhalten, sofern sie von den gleichen Operationen auf dem Datenbestand Kenntnis erhalten haben. Dies entspricht genau der Definition der strong eventual consistency, weshalb es sich anbietet, die gemeinsamen verteilten Daten, also die To-Do-Liste, als zustandsorientiertes CRDT zu definieren.

Die folgenden an die JSON-Notation angelehnten Daten mögen die Struktur der gemeinsamen Daten für dieses Beispiel illustrieren:

to-do: 	[ Milch kaufen, Blumen gießen ]

Diese Daten sollen in allen Knoten repliziert sein und es soll auf die Reihenfolge der Einträge nicht ankommen. Dann bietet sich die Modellierung als OR-Set an.

Ein Replikat besteht dazu aus zwei Mengen Added und Removed, die getrennt voneinander alle Elemente enthalten, die hinzugefügt bzw. gelöscht werden.

Der Abgleich zwischen zwei Knoten findet statt, indem die eigenen Mengen mit den fremden Mengen vereinigt werden.

Added<sub>neu</sub> = Added &#x222A; Added’, Removed<sub>neu</sub> = Removed &#x222A; Removed’

mit Added und Removed als die eigenen Mengen und Added’ und Removed’ als die Mengen des entfernten Replikats.

Alle Knoten kennen schließlich alle hinzugefügten Einträge. Solche, die von irgendeinem Knoten entfernt wurden, sind damit aus der Gesamtliste entfernt.

Ansonsten arbeitet die To-Do-Liste erwartungsgemäß. Die Identität eines Elements ergibt sich aus seiner Textdarstellung.

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")