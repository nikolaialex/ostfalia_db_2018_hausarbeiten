
# 5.2 Amazon DynamoDB



## 5.2.? Kritik

DynamoDB hat kein öffentliches Service Level Agreement, worunter die Kontrollmöglichkeit für den Nutzer leidet. Zudem besitzt es zwar ein flexibles Schema und arbeitet mit komplexen Datentypen wie JSON-Dokumenten, aber SQL wird als Abfragesprache nicht unterstützt. Zwar sind die JSON-Anfragen nicht nennenswert umfangreicher als die SQL-Anfragen, aber die Lesbarkeit und die Qualität der Anfrage ist bei SQL höher. Außerdem unterstützt DynamoDB keine Gruppierung (GROUP BY), Aggregationsfunktionen oder Verbindungen (JOIN). [*]

DynamoDB repliziert die Daten über drei Standorte in einer Region, um eine hohe Verfügbarkeit zu gewähren. Im Falle einer grenzübergreifenden Replikation bietet DynamoDB allerdings keine Lösung an. Es wird hingegen eine Replikationsbibliothek und ein Kommandozeilenprogramm angeboten, die mit zusätzlichen Kosten verbunden sind. [*]


***

[*] Chaves, W. (2017, November 27). Current State of the NewSQL/NoSQL Cloud Arena. Retrieved January 12, 2019, from https://www.red-gate.com/simple-talk/cloud/cloud-data/current-state-newsqlnosql-cloud-arena/ 

***

[<< 5.1 Google Spanner](5_1_Spanner.md) | [5.3 Ein Vergleich zwischen Google Spanner und Amazon DynamoDB >>](5_3_Ein_Vergleich_zwischen_Google_Spanner_und_Amazon_DynamoDB.md)

***
