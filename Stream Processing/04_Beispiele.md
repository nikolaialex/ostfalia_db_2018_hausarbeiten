# Beispiele
Im folgenden werden einige Anwendungsfälle aufgezeigt, bei denen Stream Processing eingesetzt wird:
## Big Data
Im Big Data Bereich wird Stream Processing eingesetzt, wenn Batch Processing zu zeitintensiv wird. Gerade wenn kurzfristige Erkenntnisse gefragt sind kann Batch Processing, dass die Daten ja erst für eine gewisse Zeit buffern muss, zu langsam sein, um die Anforderungen zu erfüllen. Auch wenn die Datenmenge, die gebuffered werden müsste, sehr groß ist, bietet sich Stream Processing an.

Einer der größten Probleme beim Einsatz im Big Data Umfeld ist das State Management, dass viele Machine Learning Algorithmen benötigen. Häufig basiert die Auswertung auf einem kompletten Datenset, beispielsweise eines Tages, und dieser random access ist bei Stream Processing nicht gegeben.

Häufig werden Vorberechnungen/ Filterungen für das anschließende Machine Learning mithilfe von Stream Processing durchgeführt, um die Datenmenge im Vorfeld zu optimieren. Der intensive Trainings-Prozess kann dann auf einer optimierten Datengrundlage stattfinden.

## Logfile Analyse
Logfiles unterlaufen häufig einer Reihe von Modifikationen, bis diese für den endgültigen Konsum vorbereitet sind. Beispielsweise setzen unterschiedliche Metering/Monitoring-Lösungen auf den Applikationslogs sowie den Zugriffslogs auf. Um diese erweiterten Informationen, beispielsweise Zugriffe pro Minute, zu ermitteln, bietet sich Stream Processing an. Während der Logstream der Zugriffslogs importiert wird kann beispielsweise ein Zähler hochgezählt werden, der dann genutzt werden kann, um die Zugriff pro Minute zu monitoren.
Weiterhin können auch Informationen aus den Logfiles gefiltert werden. Durch die DSGVO beispielsweise ist Anfang 2018 ein neues Gesetz in Kraft getreten, dass auch die Arbeit mit Logfiles, die personenbeziehbare Daten enthalten, reguliert. Um die Logs nun DSGVO compliant zu machen, können diese während des Imports beispielsweise um die IP-Adresse etc. beschnitten werden. Damit diese sensiblen Informationen nicht gebuffert werden müssen und damit länger als nötig im Arbeitsspeicher/ im schlimmsten Fall in einem Festplattencache zwischengespeichert werden bietet sich der Einsatz von Stream Processing an.

Es ist auch möglich, via Stream Processing weitere Daten an Logfiles zu schreiben. Beispielsweise können Informationen, die nicht durch eine logfileerzeugende Applikationsinstanz geliefert werden können, während des Stream Processings an das Logfile geschrieben werden. Handelt es sich bei diesen Informationen um Informationen mit starkem temporalem Bezug ist es umso wichtiger, diese Informationen so schnell wie möglich zu ermitteln, um die Korrektheit sicherzustellen. Würden diese Informationen beispielsweise im Batch ermittelt und dann an die Logfiles geschrieben werden würde dies die Aussagekraft extrem senken, da sie zeitlich versetzt ermittelt wurden.
## User Tracking
Mithilfe von Stream Processing ist es möglich, ein Usertracking in Echtzeit zu implementieren. Dieser Anwendungsfall hat einige Parallelen zur Logfile Analyse.

So ist es beispielsweise möglich, bei jeder relevanten Aktion, die ein User innerhalb der Applikation auslöst, einen neuen Eintrag in den Usertracking-Stream zu schreiben. Dieser Eintrag kann daraufhin via Stream Processing verarbeitet werden. Beispielsweise können uninteressante User herausgefilert werden oder es können weitere Informationen, die von einem anderen System beispielsweise aus der Session eines Users ermittelt werden, ergänzt werden. 

Weiterhin können die Daten in das korrekte Format gebracht werden, dass ein abnehmendes System erwartet. All dies kann ohne Buffering bzw. Speichern der Daten passieren. Abschließend können diese Informationen an diverse abnehmende Systeme, wie beispielsweise Adobe Analytics oder Google Analytics, publiziert werden.
