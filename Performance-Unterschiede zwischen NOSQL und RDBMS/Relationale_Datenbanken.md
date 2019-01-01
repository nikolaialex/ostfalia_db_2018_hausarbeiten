# 2.1. Relationale Datenbanken

In relationalen Datenbanken werden sämtliche Daten in einzelnen Tabellen gespeichert, die in Beziehung (Relation) zueinander stehen.



**Tabellenstruktur**

Die Tabellen haben durch Namen identifizierte Spalten. Jede Tabelle benötigt wenigstens eine Spalte, die maximale Anzahl an Spalten ist durch das verwendete DBMS vorgegeben. Darüber hinaus bieten die Systeme die Möglichkeit, den Datentyp einer Spalte



**Constraints**

Über Indizes und Fremdschlüssel werden die Beziehungen definiert. Hierüber ist es dem DBMS möglich, die Konsistenz der Daten zu überwachen. Fehlen beim Erstellen eines neuen Datensatzes referenzierte Daten, wird das Persistieren der Daten verhindert. Gleichwohl wird das Löschen vorhandener Datensätze unterbunden, wenn dadurch die Integrität der restlichen Daten zerstört wird.



***

[<< Datenbank-Systeme](Datenbank-Systeme.md) | [NoSQL-Datenbanken >>](NoSQL-Datenbanken.md)