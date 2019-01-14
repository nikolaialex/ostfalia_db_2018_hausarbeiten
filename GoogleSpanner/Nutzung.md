[<<4. True Time API](TrueTimeAPI.md)

[>>6. Literaturverzeichnis](Literaturverzeichnis.md)

***


## 5. Nutzung von Spanner ##

Heute wird Spanner häufig als OLTP-Datenbankverwaltung eingesetzt, als System für strukturierte Daten bei Google. Online-Transaction-Processing (OLTP) (deutsch: Online-Transaktionsverarbeitung) bezeichnet ein Benutzungsparadigma von Datenbanksystemen und Geschäftsanwendungen, bei dem die Verarbeitung von Transaktionen direkt und prompt, ohne nennenswerte Zeitverzögerung, stattfindet.

Spanner ist außerdem öffentlich zugänglich in Beta als Cloud Spanner auf der Google Cloud-Plattform (GCP). 2017 liefen in Googles Produktionsinstanzen über 5.000 Datenbanken, die von Teams in vielen Teilen von Google inklusive der Muttergesellschaft selbst verwendet werden. Diese Daten sind die "Quelle der Wahrheit" für eine Vielzahl von geschäftskritischen Google-Datenbanken, inkl. AdWords. Einer unserer großen Nutzer ist die Google Play-Plattform, auf der SQL-Abfragen ausgeführt werden – dort werden Kundeneinkäufe und Konten verwaltet. Spanner dient dutzende Millionen von QPS in allen Datenbanken, die Hunderte von Petabyte von Daten. Replikate der Daten werden von Rechenzentren bereitgestellt auf der ganzen Welt, um verstreuten Kunden eine niedrige Latenz zu bieten. Trotz dieser breite Replikation bietet das System Transaktionskonsistenz und stark konsistente Nachbildungen sowie hohe Verfügbarkeit.

Die Datenbankfunktionen von Spanner sind bei diesem Betrieb massiv machen sie zu einer attraktiven Plattform für Neuentwicklungen insbesondere als Migration von Anwendungen aus vorhandenen Datenspeichern für „große“ Kunden mit vielen Daten und großen Arbeitslasten. Sogar "kleine" Kunden profitieren von den robusten Datenbankfunktionen.   

Zuerst wurde Google Spanner nur von Google selbst genutzt, doch als Cloud Lösung steht Spanner nun weltweit anderen Unternehmen zur Verfügung. Laut einem Artikel von Cade Metz aus dem Jahr 2017, ist Google TrueTime API nach wie vor einzigartig und wurde noch nicht als OpenSource-Version „nachgebaut“.  

Laut Metz gibt es derzeit wenig weltweit operierende Unternehmen, die Spanners komplettes Potential ausnutzen können. Google gibt seinen Kunden aber die Möglichkeit zu expandieren. Im Finanzmarkt könnten die Funktionen von Spanner jetzt schon nützlich sein. Laut Metz führe Google laut eigener Aussage Gespräche mit Interessenten aus diesem Bereich.   


