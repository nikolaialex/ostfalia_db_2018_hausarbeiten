# 2 Grundlagen spaltenorientierter Datenbanken - NoSQL

Für das Verständnis der Thematik spaltenorientierter Datenbanken, ist die Einführung
wichtiger Begriffe notwendig. Diese Begriffe und Vorgehensweisen werden in
diesem Kapitel eingeführt. Spaltenorientierte Datenbanken gehören zur Gruppe der
NoSQL Datenbanken. Der Begriff NoSQL ist ein Schlagwort (Buzzword), dass oft mit
Not only SQL (nicht nur SQL) übersetzt wird. Populär wurden NoSQL Datenbanken
Anfang der 2000er Jahre mit dem Siegeszug des Web 2.0 Zeitalters. Das Ziel der Entwicklung
dieser Datenbanken war die Verarbeitung von sehr großen Datenmengen
im Terabyte -und Petabyte-Bereich. NoSQL Datenbanken weisen nach [EFH+11] folgende
Eigenschaften auf:

*		Das zugrundelegende Datenmodell ist nicht relational.
*		Die Systeme sind von Anbeginn an auf eine verteilte und horizontale Skalierbarkeit ausgerichtet.
*		Das NoSQL System ist Open Source.
*		Das System ist schemafrei oder hat nur schwächere Schemarestriktionen.
*		Aufgrund der verteilen Architektur unterstützt das System eine einfache Datenreplikation.
*		Das System bietet eine einfache API.
*		Dem System liegt meistens auch ein anderes Konsistenzmodell zugrunde: Eventually Consistenz und Base, aber nicht ACID.

Eine weitere wichtige Eigenschaft dieser Gruppe von Datenbanken betrifft die horizontale
Skalierbarkeit. Hier sollte es möglich sein Cluster und Datacenter mit Low-
Cost Hardware aufzubauen. Bei relationalen Datenbanken ist der Aufbau eines hochperformanten
Clusters meist nur mit teurer Spezialhardware möglich.

NoSQL Systeme werden wie folgt kategorisiert.

*		 Key-Value Stores
*		 Document Stores
*		 Column Stores (Wide Column Stores/Column Families)
*		 Graphdatenbanken

Key-Value Stores, Document Stores und Column Stores verwenden die Eigenschaften
Eventually Consistent (BASE), verteilte/horizontale Skalierung und Datenreplikation,
aus obiger Liste. Da die genannten Eigenschaften für das Verständnis von NoSQL
Datenbanken, insbesondere für das Thema Column Stores dieser Arbeit, essentiell
sind, wird in den nächsten Abschnitten auf diese Thematik näher eingegangen.

---

[<< Einleitung](einleitung.md) | [2.1 CAP-Theorem und BASE-Modell >>](grundlagen_2_1.md)

---
