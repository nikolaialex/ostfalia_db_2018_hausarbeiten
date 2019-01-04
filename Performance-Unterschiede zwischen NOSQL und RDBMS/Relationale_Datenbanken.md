# Relationale Datenbanken

In relationalen Datenbanken werden sämtliche Daten in einzelnen Tabellen gespeichert, die in Beziehung (Relation) zueinander stehen. Bekannte Branchengrößen wie PostgreSQL, MySQL und Oracle sind relationale Datenbank-Systeme.

Die Tabellen der Datenbank haben durch Namen identifizierte Spalten. Jede Tabelle benötigt wenigstens eine Spalte mit jeweils einem Datentyp und die maximale Länge. Die maximale Anzahl an Spalten in einer Tabelle ist durch das verwendete DBMS eingeschränkt. Abhängig vom Datentyp ist die Angabe der Länge optional oder nach oben beschränkt. Da das DBMS den Typ einer Spalte kennt, kann es die Validität des jeweiligen Inhalts sicherstellen. So würde etwa der Versuch, Text in eine Spalte zu schreiben, die als Zahl definiert ist, direkt abgewiesen werden. Außerdem kann bei der Spaltendefinition direkt angegeben werden, ob eine Spalte auch *null*-Werte enthalten darf.



## Foreign Key

Über Indizes und Fremdschlüssel werden die Beziehungen definiert. Hierüber ist es dem DBMS möglich, die Konsistenz der Daten zu überwachen. Fehlen beim Erstellen eines neuen Datensatzes referenzierte Daten, wird das Persistieren der Daten verhindert. Gleichwohl wird das Löschen vorhandener Datensätze unterbunden, wenn dadurch die Integrität der restlichen Daten zerstört wird.



## Daten-Änderungen

Durch die Vorgabe der Datentypen und der jeweiligen Länge weiß das DBMS, welchen Speicherplatz es auf der Festplatte für einen Datensatz (unabhängig vom tatsächlichen Inhalt) reservieren muss. Für die Änderung vorhandener Daten muss durch das DBMS auf dem Laufwerk lediglich der Bereich des entsprechenden Datensatzes ermittelt und überschrieben werden. Sind mehrere Tabellen von einer Änderung betroffen, müssen entsprechend auch mehrere Abschnitte auf der Festplatte modifiziert werden. Der Vorteil besteht hierbei darin, dass je strenger nach der Normalisierung gearbeitet wurde, desto weniger Tabellen bzw. Datensätze müssen tatsächlich verändert werden.



## Strukturelle Änderungen

Die strukturellen Vorgaben einer Tabelle beziehen sich auf alle jeweils enthaltenen Datensätze. Soll etwa der Datentyp einer Spalte verändert werden, erfolgt die Konvertierung (bzw. der Versuch) für alle enthaltenen Datensätze. Ebenso müssen beim Hinzufügen von Constraints sämtliche Referenzen überprüft werden. Es handelt sich bei Migrationen also um entsprechend teure Aufrufe.



## Skalierung





***

[<< Datenbank-Systeme](Datenbank-Systeme.md) | [Document Stores >>](Document_Stores.md)