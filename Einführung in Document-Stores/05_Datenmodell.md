# 3. Datenmodell

Die Datenspeicherung erfolgt bei dokumentenorientierten Datenbanken in Form von Dokumenten. Gemeint sind hier aber nicht Word- oder Textdateien, die mit einen Textbearbeitungsprogramm verändert werden, sondern strukturierte Datensammlungen im JSON oder XML Format. Beide sind bei Entwicklern sehr beliebt. Ein Dokument umfasst in diesem Zusammenhang einzelne Einheiten, die aber in sich unterschiedlich strukturiert sein können. Document-Stores legen z. B. JSON-Dateien zusammen mit einem eindeutigen Identifikator, sprich ID, ab. Meist legt die Datenbank nur fest, auf welches Format die ID verweist, mehr aber auch nicht. Mit Hilfe dieser ID kann das Dokument dann immer wieder gefunden werden. [1, 3]

Die Strukturierung in Dokumenten bieten eine intuitive und natürliche Möglichkeit Daten zu modellieren, die eng mit der objektorientierten Programmierung (OOP) verbunden ist - jedes Dokument ist praktisch ein Objekt. Dokumente enthalten ein oder mehrere Felder, wobei jedes Feld einen typisierten Wert enthält, wie z.B. Zeichenketten, Kalenderdaten, Binärwerte, Dezimalwerte oder Arrays. Die Daten werden in Form von Schlüssel-/Wertpaaren gesichert. Das heißt, das Dokument besteht aus einer Reihe mit Namen versehener Schlüsselfelder, denen jeweils ein bestimmter Wert zugeordnet ist. Der Wert kann hier eine beliebige Information sein. Es kann ein String, Text oder auch Liste und Array sein, der wiederum geschachtelte Datentypen enthalten kann. Anstatt einen Datensatz über mehrere Spalten und Tabellen zu verteilen, die mit Fremdschlüsseln verbunden sind, wird jeder Datensatz zusammen mit seinen zugehörigen (d.h. verwandten) Daten typischerweise in einem einzigen, hierarchischen Dokument gespeichert. Dieses Modell beschleunigt die Produktivität der Entwickler, vereinfacht den Datenzugriff und erübrigt in vielen Fällen aufwendige JOIN-Operationen und komplexe Transaktionen mit mehreren Datensätzen. [2]

Wie bereits erwähnt sind dokumentenorientierte Datenbanken schemafrei, wobei das Schema als dynamisch angesehen werden kann: Jedes Dokument kann verschiedene Felder enthalten, also anders aufgebaut sein. Diese Flexibilität kann besonders bei der Modellierung unstrukturierter und polymorpher Daten hilfreich sein. Deswegen eignen sich dokumententorientierte Daten sehr gut für die Speicherung von HTML-Formularen. Das Schema wird in diesem Sinne mit dem Einfügen eines Dokuments zur Laufzeit erzeugt. Dies erleichtert die Entwicklung einer Anwendung, wie beispielsweise das Hinzufügen neuer Felder, während ihres Lebenszyklus. Durch diese Eigenschaft verfügen Document-Stores auch über eine hohe Skalierbarkeit. Im Allgemeinen erfolgt die Abfrage der Daten bei den meisten dokumentorientieren Datenbankmodell mit einem nicht-relationalen Ansatz (No-SQL). Dies bedeutet, es wird nicht auf eine SQL-ähnliche Syntax zurückgegriffen, um Beziehungen zwischen verschiedenen Tabellen und Spalten, wie man es von relationalen Datenbankenbankmodellen kennt, abzufragen. [1, 4]

Darüber hinaus bieten jedoch einige dokumentenorientierte Datenbanken Query-Ausdrücke, die Entwickler von relationalen Datenbanken bereits gewohnt sind. Insbesondere können Daten, basierend auf einer beliebigen Kombination von Feldern, in einem Dokument abgefragt werden, wobei umfangreiche Sekundärindizes effiziente Zugriffspfade bieten, die nahezu jedes Abfragemuster unterstützen. [2]

------

[1] Edlich, S. (2011). NoSQL. München: Hanser.

[2] Top 5 Considerations When Evaluating NoSQL Databases. (2018, Juni). Abgerufen 17. November, 2018, von https://www.mongodb.com/collateral/top-5-considerations-when-evaluating-nosql-databases

[3] Litzel, N., & Lapp, A. (2017, 24. Mai). Big Data, SQL und NoSQL – eine kurze Übersicht. Abgerufen 26. Dezember, 2018, von https://www.bigdata-insider.de/big-data-sql-und-nosql-eine-kurze-uebersicht-a-602249/

[4] Ngoc Ha, T. (2011). Charakteristika und Vergleich von SQL- und NoSQLDatenbanken. Abgerufen 26. Dezember, 2018, von https://dbs.uni-leipzig.de/file/seminar_1112_tran_ausarbeitung.pdf

------

[< Entwicklung und Ursprung](04_Entwicklung-und-Ursprung.md)		|   [Vergleich mit anderen Datenbankmodellen >](06_Vergleich-mit-anderen-Datenbankmodellen.md)
