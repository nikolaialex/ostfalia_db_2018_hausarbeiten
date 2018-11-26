# 3. Datenmodell

Die Datenspeicherung erfolgt bei dokumentenorientierten Datenbanken in Form von Dokumenten. Gemeint sind hier aber nicht Word- oder Textdateien, sondern strukturierte Datensammlungen im JSON oder XML Format. Beide sind bei Entwicklern sehr beliebt. Document Stores legen z. B. JSON-Dateien zusammen mit einer ID ab. Meist legt die Datenbank nur fest, auf welches Format die ID weist, mehr aber auch nicht. [1]

Die Strukturierung in Dokumenten bieten eine intuitive und natürliche Möglichkeit, Daten zu modellieren, die eng mit der objektorientierten Programmierung (OOP) verbunden ist - jedes Dokument ist praktisch ein Objekt. Dokumente enthalten ein oder mehrere Felder, wobei jedes Feld einen typisierten Wert enthält, wie z.B. Zeichenketten, Kalenderdaten, Binärwerte, Dezimalwerte oder Arrays. Anstatt einen Datensatz über mehrere Spalten und Tabellen zu verteilen, die mit Fremdschlüsseln verbunden sind, wird jeder Datensatz zusammen mit seinen zugehörigen (d.h. verwandten) Daten typischerweise in einem einzigen, hierarchischen Dokument gespeichert. Dieses Modell beschleunigt die Produktivität der Entwickler, vereinfacht den Datenzugriff und erübrigt in vielen Fällen aufwendige JOIN-Operationen und komplexe Transaktionen mit mehreren Datensätzen. [2]

Wie bereits erwähnt sind dokumentenorientierte Datenbanken schemafrei, wobei das Schema als dynamisch angesehen werden kann: Jedes Dokument kann verschiedene Felder enthalten. Diese Flexibilität kann besonders bei der Modellierung unstrukturierter und polymorpher Daten hilfreich sein. Das Schema wird in diesem Sinne mit dem Einfügen eines Dokuments zur Laufzeit erzeugt. Dies erleichtert die Entwicklung einer Anwendung, wie beispielsweise das Hinzufügen neuer Felder, während ihres Lebenszyklus. Darüber hinaus bieten einige dokumentenorientierte Datenbanken Query-Ausdrücke, die Entwickler von relationalen Datenbanken bereits gewohnt sind. Insbesondere können Daten, basierend auf einer beliebigen Kombination von Feldern, in einem Dokument abgefragt werden, wobei umfangreiche Sekundärindizes effiziente Zugriffspfade bieten, die nahezu jedes Abfragemuster unterstützen. [2]

------

[1] Edlich, S. (2011). NoSQL. München: Hanser. <br>
[2] Top 5 Considerations When Evaluating NoSQL Databases. (2018, Juni). Abgerufen 17. November, 2018, von https://www.mongodb.com/collateral/top-5-considerations-when-evaluating-nosql-databases



------

[< Entwicklung und Ursprung](04_Entwicklung-und-Ursprung.md)		|   [Vergleich mit anderen Datenbankmodellen >](06_Vergleich-mit-anderen-Datenbankmodellen.md)
