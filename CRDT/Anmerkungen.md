# Anmerkungen

* In einem laufenden System wird ein Zustand umfassender Synchronisation ggf. niemals erreicht. CRDTs zielen stattdessen darauf ab, dass ein System, in dem sie eingesetzt werden, nach dem Ende aller Aktualisierungsoperationen schließlich, zu einem beliebig späteren Zeitpunkt, synchronisiert sein wird.

* Für alle CRDTs wird vorausgesetzt, dass das zugrundeliegende Netzwerk alle Nachrichten nach endlicher Zeitspanne zustellt und dafür auch Störungen angemessen ausgleicht, zB indem die Paketzustellung wiederholt wird.

* CRDTs treten der Problematik entgegen, die im CAP-Theorem adressiert wird, indem sie Strong Eventual Consistency für das “C” anbieten.

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")