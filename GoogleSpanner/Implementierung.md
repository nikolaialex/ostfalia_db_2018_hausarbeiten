[<<2. Einleitung](Einleitung.md)

[>>4. True Time API](TrueTimeAPI.md)

***


## 2. Implementierung

Ein Spanner Deployment wird „Universe“ genannt. Dadurch, dass Spanner Daten global managed, wird es nur eine Handvoll „Universen“ geben. Zum Zeitpunkt des Artikels von James C. Corbett 2012 waren es das „Test/Playground Universe“, ein „Development/Production Universe“ und ein „Production-Only Universe“.<sup>14</sup>

Spanner ist als ein Satz von Zonen organisiert. Jede Zone entspricht grob dem Einsatz eines Bigtable-Servers. Der Satz von Zonen ist außerdem der Satz von Locations über die die Daten repliziert werden können. Zonen können hinzugefügt oder entfernt werden aus dem laufenden System, wenn neue Rechenzentren in Betrieb genommen werden und alte Rechenzentren vom Betrieb entfernt werden. Zonen sind auch die Einheiten der physischen Isolation, es kann eine oder mehrere Zonen in einem Rechenzentrum geben, zum Beispiel wenn verschiedene Applikationsdaten auf verschiedenen Servern des gleichen Rechenzentrums partitioniert werden.<sup>15</sup> 

Eine Zone hat einen Zonenmaster und zwischen hundert und tausend *Spanserver*. 

Die Per-Zone Location Proxies werden von den Clients genutzt um die *Spanserver* zu identifizieren, die genutzt werden ihre Daten zu speichern. Der *Universe Master* und der *Placement Driver* sind momentan einzigartig. Der *Universe Master* ist primär eine Konsole, die Status Informationen über alle Zonen für interaktives Debugging enthält. Der *Placement Driver* kommuniziert periodisch mit den *Spanservern* um Daten zu finden, die verschoben werden müssen, entweder um geupdateten Replication Contraints zu entsprechend oder um eine Lastverteilung zu erwirken (Load Balancing).<sup>16</sup>  
