## 3. Architektur
Auf der technischen Ebene besteht die Lambda-Architektur aus den drei Schichten: Batch Layer, Speed Layer und Serving Layer. Abbildung x zeigt deren Zusammenspiel.  

![Alt-Text](/images/Lambda-Architektur.png)[2]  

Die eingehenden Daten werden sowohl zum Batch Layer als auch zum Speed Layer geschickt. Im Batch Layer werden diese Daten an den Master-Dataset angehängt, gespeichert und verarbeitet. Nachdem die Berechnungen durchgeführt wurden, werden aus den Ergebnissen Batch Views erstellt und an den Serving Layer weitergeleitet, wo sie indiziert werden und so mit niedriger Latenz abgefragt werden können.
Der Speed Layer behandelt nur die neuesten Daten und berechnet anhand derer Real Time Views. Eingehende Anfragen werden beantwortet, indem die Ergebnisse aus den Batch Views und den Real Time Views zusammengeführt werden. [3]

Im Folgenden werden die genauen Funktionsweisen der einzelnen Schichten beschrieben.

### 3.1 Batch Layer
Im Batch Layer werden alle eingehenden Rohdaten permanent und in redundanter Ausführung in Computerclustern gespeichert. Bei Aktualisierungen werden neue zusätzliche Daten an den entsprechenden Master-Datensatz angehängt und beim nächsten Durchlauf berücksichtigt.  

Berechnungen können uneingeschränkt stattfinden und sind idempotent, können allerdings aufgrund der großen Datenmenge sehr lange dauern, was sich negativ auf die Latenz auswirkt. Aus diesem Grund kann bei den produzierten Views, die im Serving Layer landen, keine Aktualität gewährleistet werden. Während bei seltenen und einmaligen Abfragen die Daten in den Views noch aktuell sein können, sind sie bei wiederkehrenden Abfragen mit kurzen Zeitintervallen schnell veraltet. [1,3]  

### 3.2 Speed Layer
Während der Batch Layer alle Daten hält, speichert der Speed Layer nur ein begrenztes Datenfenster, zum Beispiel die letzten wenigen Stunden. Dabei hängt die Menge der Daten von der Hardware und vom Refresh-Intervall der Batch Views ab. Sobald die Batch Views aktualisiert werden, werden die alten Daten im Speed Layer gelöscht und der Vorgang neu gestartet. Durch diese Maßnahme können Berechnungen schneller durchgeführt werden und gewähren wegen der niedrigen Latenz eine Realt Time View auf die Daten. 

Dafür hält der Layer die ganze Komplexität. Hier wird mit Hilfe von verschiedenen Strategien entschieden, wie neue Ergebnisse mit bereits vorhandenen Informationen kombiniert werden können. Die Komplexität erlaubt es auch, bei Fehlern direkt eine automatische Korrektur auszuüben. [4] 

### 3.3 Serving Layer
Die Aufgabe des Serving Layers ist es, die Batch Views und Real Time Views zu holen, diese zusammenzuführen und sie in kombinierten Views dem Endnutzer zur Verfügung zu stellen. Dabei können die finalen Views entweder in einer effizienten Datenbank gespeichert oder ohne Speichern direkt an den Endnutzer weitergeleitet werden.  

Wenn die Ergebnisse gespeichert werden, müssen sie regelmäßig aktualisiert werden. Hierzu kann entweder ein Zeitintervall definiert werden, in dem aktualisiert werden soll, oder ein Benachrichtigungsmechanismus verwendet werden, der den Serving Layer benachrichtigt, wenn dieser seine Views aktualisieren soll. [4]


[☜ vorheriges Kapitel](2_Grundlagen.md)
   |   [nächstes Kapitel ☞](4_Technologien.md)