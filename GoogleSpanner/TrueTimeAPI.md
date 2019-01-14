[<<3. Implementierung](Implementierung.md)

[>>4. Nutzung von Spanner](Nutzung.md)

***


## 4. TrueTime API
TrueTime repräsentiert Zeit als TTintervall, welches ein Intervall ist, das begrenzte zeitliche Ungewissheit erfasst (anders als andere Intervalle, die Clients keine Auskunft über Ungewissheiten geben). Der Endpunkt von einem TTintervall ist vom Typ TTstamp. Die TT.now() Methode gibt ein TTintervall wieder, das garantiert die absolute Zeit zu beinhalten während TT.now() ausgerufen wurde. Die Zeitepoche ist analog zur UNIX-Time mit Schaltsekunde.<sup>32</sup> 

Die Fehlergrenze wird als ∈ definiert, die Hälfte der Breite des Intervalls ist, und der durchschnittliche Fehlergrenze als <del>∈</del>. Die Methoden TT.after () und TT.before () sind Convenience-Wrapper um TT.now (). Die absolute Zeit eines Ereignisses e wird durch die Funktionsregister t<sup>abs</sup>(e) bezeichnet. In formellerer Hinsicht garantiert TrueTime, dass für einen Aufruf tt = TT.now (), tt.earliest ≤ tabs (e<sup>now</sup>) ≤ ist tt.latest, wobei e<sup>now</sup> das Aufrufereignis ist.<sup>33</sup>   

Die zugrunde liegenden Zeitreferenzen, die von TrueTime verwendet werden, sind GPS- und Atomuhren. TrueTime verwendet zwei Formen der Zeitreferenz, da sie unterschiedliche Fehlermodi haben. GPS-Referenzquellen-Schwachstellen umfassen Antennen- und Empfängerfehler sowie lokales Radiostörungen, korrelierte Fehler (z. B. Konstruktionsfehler, wie z. B. falsche Handhabung von Schaltsekunden und Spoofing) und GPS-Systemausfälle. Atomuhren können unkorreliert zu GPS-Fehlern Probleme haben und über lange Zeiträume treten Frequenzfehler auf.<sup>34</sup>   

TrueTime wird von einer Reihe von Zeit-Master-Maschinen pro Rechenzetrum implementiert und einem Timeslave-Daemon pro Maschine. Die Mehrheit der Master verfügt über GPS-Empfänger mit dedizierte Antennen; Diese Master sind physisch getrennt, um die Auswirkungen von Antennenausfälle, Funkstörungen und Spoofing zu reduzieren. Die restlichen Master (werden als Armageddon-Master bezeichnet) sind mit Atomuhren ausgestattet. Eine Atomuhr ist nicht so teuer: Die Kosten eines Armageddon-Masters liegen in der gleichen Größenordnung wie die eines GPS-Master. Die Zeitreferenzen aller Master werden regelmäßig miteinander verglichen.<sup>35</sup> 

Jeder Master vergleicht auch die Rate, mit der seine Referenzzeit gegen seine Referenzzeit verstellt wird mit der eigenen lokalen Uhr, und entfernt sich selbst, wenn es erhebliche Abweichungen gibt. Zwischen Synchronisierungen zeigen Armageddon-Master mit einer langsam zunehmenden Zeitunsicherheit, die aus konservativ angewendeten Worst-Case-Uhrenfehlern abgeleitet wird. GPS-Master zeigen eine Unsicherheit, die typischerweise nahe bei Null liegt. Jeder Daemon befragt verschiedene Master um die Anfälligkeit für Fehler zu verringern. Einige sind GPS-Master, die aus nahe gelegenen Rechenzentren ausgewählt werden. Der Rest sind GPS-Master von weiter entfernten Rechenzentren sowie einige Armageddon-Master. Daemons wenden eine Variante des Marzullo-Algorithmus an um Fehler zu erkennen und abzulehnen. Sie synchronisieren die lokalen Maschinenuhren mit den fehlerfreien Ergebnissen. Um gegen kaputte lokale Uhren, Maschinen, deren Frequenzauslenkungen größer sind als die Worst-Case-Schranke, zu vorzusorgen, werden diese abgeleitet von Komponentenspezifikationen und Betriebsumgebung vertrieben. Die Korrektheit hängt davon ab, dass die Worst-Case-Grenze auch durchgesetzt wird.<sup>36</sup> 

Zwischen den Synchronisierungen kündigt ein Daemon eine langsam zunehmende Zeitunsicherheit an. ∈ wird aus konservativ angewendeten lokalen Uhrenfehlern abgeleitet. ∈ hängt ebenfalls von der Zeitmaster-Unsicherheit und der Kommunikationsverzögerung zu den Zeitmastern ab.<sup>37</sup> 

In der Produktionsumgebung ist ∈ normalerweise eine Sägezahnfunktion der Zeit, die variiert von etwa 1 bis 7 ms über jedes Abfrageintervall. ∈ ist daher meistens 4 ms. Das Abfrageintervall des Daemons beträgt derzeit 30 Sekunden und die aktuell angewendete Fehlerrate ist auf 200 Mikrosekunden / Sekunde eingestellt, was zusammen die Sägezahngrenzen ausmacht von 0 bis 6 ms. Die verbleibenden 1 ms stammen von der Kommunikationsverzögerung der Zeit-Master-Exkursionen. Beispielsweise kann eine gelegentliche Nichtverfügbarkeit des Zeitmasters zum Rechenzentrum zu weiteren Erhöhungen führen in ∈. In ähnlicher Weise können überlastete Maschinen und Netzwerkverbindungen zu nur gelegentlich lokalisierten ∈ Spitzen führen. Die Korrektheit wird durch die ∈ Varianz nicht beeinflusst, da Spanner warten kann, bis die Zeitungenauigkeit behoben ist. Dieses Verfahren kann sich allerdings auf die Performance auswirken, wenn ∈ zu stark zunimmt.<sup>38</sup>  

***

Quellen:

<sup>32</sup>James C. Corbett (2012), S. 7 - 8

<sup>33</sup> James C. Corbett (2012), S. 8

<sup>34</sup>James C. Corbett (2012), S. 8

<sup>35</sup>James C. Corbett (2012), S. 7 - 8

<sup>36</sup>James C. Corbett (2012), S. 7 - 8

<sup>37</sup>James C. Corbett (2012), S. 7 - 8

<sup>38</sup>James C. Corbett (2012), S. 7 - 8

