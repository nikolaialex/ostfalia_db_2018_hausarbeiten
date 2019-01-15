## 5. Vorteile
Die Möglichkeit des Zugriffs auf alle vergangenen Werte eines Datensatzes kann in vielen Fällen einen großen Vorteil bieten. So ist es sinnvoll in einem Online-Shop die Zustände des Warenkorbs von Nutzern genauer zu analysieren. Mit der Lambda-Architektur ist nicht nur einsehbar, welche Artikel Kunden kaufen, sondern auch welche sie in ihren Warenkorb legen und wieder herausnehmen. [**[Soul14]**](7_Literaturverzeichnis.md)  

Systeme, die nach dieser Architektur entwickelt werden, sind leicht skalierbar. So müssen keine Änderungen an Architektur oder Code vorgenommen werden, wenn eine Skalierung erforderlich ist. Dabei kann sowohl vertikal, in Form von größerem Speicherplatz oder CPU, als auch horizontal, durch zusätzliche Rechner, skaliert werden, ohne das System anhalten zu müssen.  

Da Batch Layer und Speed Layer getrennt sind, haben Erweiterungen einer Schicht keine Auswirkungen auf die andere, sodass das System flexibel an sich ändernde Anforderungen angepasst werden kann. Dies hat weiterhin den Vorteil, dass die beiden Layer unabhängig voneinander gewartet werden können. 

Durch die Speicherung aller Daten können fehlerhafte Daten ohne viel Aufwand durch Neuberechnungen korrigiert werden. Treten zum Beispiel Bugs in einer View auf, kann diese einfach direkt verworfen und neu berechnet werden. Trotz der dadurch entstandenen hohen Datenmenge im Batch Layer können Endnutzer dank des Speed Layers auf die gewünschten Daten mit niedriger Latenz zugreifen. Die Aufteilung in mehrere Layer und die redundante Speicherung der Daten gewährleisten weiterhin eine hohe Ausfallsicherheit und Erreichbarkeit des Systems. 
[**[HaBi17]**](7_Literaturverzeichnis.md) [**[Wart16]**](7_Literaturverzeichnis.md)  

Für Entwickler bietet die Architektur den Vorteil, dass keine Abhängigkeiten zu bestimmten Tools bestehen. Jedes Unternehmen kann für sich selbst je nach Erfahrungen und Präferenzen entscheiden, welche der vielen Technologien bei der Umsetzung der Architektur verwendet werden können, sodass der Einarbeitungsaufwand minimal ausfällt.

[☜ 4. Technologien](4_Technologien.md)
   |   [6. Fazit ☞](6_Fazit.md)