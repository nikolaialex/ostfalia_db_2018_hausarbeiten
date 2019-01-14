***
[<<< Inhaltsverzeichnis](README.md)
***

## 3. Funktionsweise

In diesem Kapitel wird die Funktionsweise von Blockchain Datenbanken erläutert. Dazu werden zunächst einige grundlegende kryptographische Begriffe eingeführt und kurz erklärt. Diese werden im restlichen Kapitel für die Erklärung der Funktionsweise der Blockchain Datenbank genutzt.

### 3.1 Kryptographische Grundlagen

Bei den hier eingeführten Begriffen handelt es sich um Grundlagen der Kryptographie auf denen die Funktionsweise der Blockchain Datenbank aufbaut. Dieses Kapitel eignet sich zum Nachschlagen von Fachbegriffen.

#### 3.1.1 Hashfunktion

Hashing oder Hashfunktionen haben mehrere Anwendungsgebiete. Allgemein erzeugt eine Hashfunktion aus einem Input beliebiger Länge ein Resultat fixer und kleinerer Länge. [01, 02]

Bei diesem Prozess treten sogenannte __Kollisionen__ auf. Dies bedeutet, dass zwei unterschiedliche Werte nach dem hashing den gleichen Wert liefern.
```
H(M) = H(M’) bei M != M’
```
Dies tritt auf, da die Menge des Inputs größer ist als die der Ergebnisse. Somit muss es mehrere Werte geben die gehasht den gleichen Hashwert liefern. Hashfunktionen im Allgemeinen, aber vor allem kryptographische Hashfunktionen sollten möglichst resistent gegen Kollisionen sein. Dazu mehr im Abschnitt Anforderungen. [03, 40]

##### 3.1.1.1 Anforderungen

Je nachdem ob eine Hashfunktion für die Kryptographie genutzt werden soll oder nicht existieren unterschiedliche Anforderungen an diese. Die ersten drei Anforderungen gelten im Allgemeinen für Hashfunktionen.

Als Erstes sollte eine Hashfunktion __effizient__ zu berechnen sein, auch für große Eingaben. Daraus lässt sich ableiten, für die Eingabe M ist es einfach den Hashwert h zu berechnen.
```
h = H (M)
```
Des Weiteren muss eine Hashfunktion __deterministisch__ sein. Dies bedeutet, dass identische Eingabewerte auch identische Ausgabewerte liefern. [04]
Als nächste Anforderung sollte eine Hashfunktion für zwei ähnliche Eingabewerte sehr unterschiedliche Resultate liefern. Man spricht hier von __Pseudozufälligkeit__. Aus dem Eingabewert darf es nicht möglich sein den erzeugten Hashwert vorherzusagen. [02, 04, 05]  

Für kryptographische Hashfunktionen gelten die bereits beschriebenen Anforderungen sowie die Folgenden.
Kryptographische Hashfunktionen müssen __Einwegfunktionen__ (eng. one-way) sein. Dies bedeutet, dass es nicht möglich sein sollte die Nachricht effizient aus einem gegebenen Hashwert zu berechnen. Daraus folgt, dass die Nachricht M aus einem gegebenen Hashwert h nicht effizient zu berechnen ist. [02, 05]

Zusätzlich darf es nicht effizient möglich sein Kollisionen zu finden. Wie bereits beschrieben führen Hashfunktionen immer zu Kollisionen, diese dürfen sich, jedoch nicht einfach berechnen lassen. Dies lässt sich in zwei weitere Anforderungen aufteilen. [02, 05]

Zum einen bedeutet dies, dass für eine gegebene Nachricht M es sehr aufwändig ist, eine andere Nachricht M’ zu finden, welche den gleichen Hashwert liefert.
```
H(M) = H(M’)
```
Zum anderen muss es aufwändig sein zwei beliebige M zu finden welche den gleichen Hashwert liefern. [02, 05]

##### 3.1.1.2 Anwendungen

Eine wichtige Anwendung von Hashfunktionen sind __Hashtabellen__. Hier werden Hashfunktionen genutzt um effektiven Zugriff auf Große Datenmengen zu gewährleisten. Dazu wird an jedes neue Element ein Schlüssel vergeben und dieser gehashed. Der daraus gewonnene Hashwert referenziert den Ort der gesuchten Daten in der Hashtabelle. [06, 07]
Um das Konzept von Blockchain-Datenbanken zu verstehen ist, jedoch vor allem die kryptographische Nutzung von Hashverfahren interessant. In diesem Bereich werden Hashfunktionen auf verschiedene Arten genutzt.

###### 3.1.1.2.1 Prüfsummen

Spezielle Hashfunktionen können genutzt werden um Prüfsummen zu erzeugen. Diese wiederum dienen dazu die Integrität von Daten zu prüfen. Dazu erzeugt die Hashfunktion aus den ursprünglichen Daten einen Hashwert. Soll später die Integrität überprüft werden, werden die zu überprüfenden Daten gehasht und der neue Hashwert mit dem alten verglichen. Sind die Daten unverändert gleichen sich die Hashwerte. Sind die Daten verändert erzeugt die Hashfunktion einen anderen Hashwert, vorausgesetzt es tritt keine Kollision auf. Wie bereits angesprochen treten bei geeigneten Hashfunktionen selten Kollisionen auf und diese sind schwierig herbeizuführen. Damit sich eine Hashfunktion zur Generierung von Prüfsummen eignet sollte sie vor allem schnell zu berechnen sein, ähnliche Inputs sollten sehr unterschiedliche Hashwerte liefern und sie sollte möglichst kollisionsresistent sein. [06, 08, 09]

###### 3.1.1.2.2 Asymmetrische Verschlüsselung

Bei symmetrischer Verschlüsselung teilen sich Sender und Empfänger einen Schlüssel, welchen nur die beiden Kommunikationspartner wissen dürfen. Der Sender nutzt diesen um die Nachricht zu verschlüsseln, der Empfänger zum anschließenden Entschlüsseln. Der Schlüssel muss zuvor über einen anderen Kommunikationsweg vereinbart bzw. ausgetauscht worden sein. Der Schlüsselaustausch ist eine große Schwierigkeit für symmetrische Verfahren. Eine unsichere Übertragung des Schlüssels kompromittiert die Sicherheit der anschließend Übertragung. Ein Angreifer welcher den Schlüssel erlangt kann die anschließend Übertragung genauso entschlüsseln wie der Empfänger. Somit muss ein sicherer Kommunikationsweg für den Schlüsselaustausch gefunden werden. Im Falle zweier Personen können diese sich vorher treffen und einen Schlüssel austauschen. Dies ist, jedoch bei der Kommunikation mit vielen unterschiedlichen Personen oder Instanzen nicht praktikabel. Mit jedem Kommunikationspartner müsste ein Treffen arrangiert werden und ein Schlüssel ausgetauscht werden. Zusätzlich zu dem sehr hohen Aufwand die Schlüssel zu vereinbaren, müsste jeder Nutzer einen extra Schlüssel für jede Kommunikation speichern. Betrachtet man als Beispiel einen Teilnehmer welcher mit fünf Partnern sicher kommunizieren möchte. Dafür braucht er fünf verschiedene Schlüssel. Wollen die Teilnehmer nun untereinander kommunizieren, müsste jeder von Ihnen fünf Schlüssel speichern. Insgesamt werden also 25 Schlüssel benötigt. In einem großen Netzwerk würde dies zu einem sehr hohen Speicher- und Verwaltungsaufwand führen. [10, 11, 37]

Asymmetrische Verschlüsselung löst diese Schwierigkeiten. Es werden Schlüsselpaare bestehend aus zwei Schlüsseln generiert. Nachrichten welche mit einem der beiden Schlüssel verschlüsselt wurden können anschließend nur noch effizient mit dem entsprechenden anderen entschlüsselt werden. Gleichzeitig lässt sich aus einem der beiden Schlüssel der andere nicht effizient berechnen. [12, 13]

Beim Public-Key Verfahren hat jeder Kommunikationspartner ein solches Schlüsselpaar. Ein Schlüssel wird zum verschlüsseln benutzt und ist öffentlich für jeden einsehbar. Er wird als public key bezeichnet. Der andere muss geheim gehalten werden und wird als private key bezeichnet.
Um eine Kommunikation zu verschlüsseln muss der Sender lediglich die Nachricht mit dem öffentlichen Schlüssel des Empfängers verschlüsseln und an diesen senden. Anschließend kann die Nachricht nur effizient vom Besitzer des entsprechenden privaten Schlüssels entschlüsselt werden. Wird er private key geheim gehalten, hat ein Angreifer nur Zugang zu den beiden öffentlichen Schlüssel der Kommunikationspartner. Mit diesem kann er die Kommunikation, jedoch nicht entschlüsseln. Es kommt zu keinem unsicheren Austausch des private keys. [14, 15, 16]

Asymmetrische Verschlüsselungsverfahren bringen viele Vorteile mit sich, jedoch sind diese bedeutend langsamer als symmetrische Verfahren. Beide Ansätze können miteinander kombiniert werden. Dabei dient das asymmetrische Verfahren dazu den Schlüssel für die symmetrische Verschlüsselung auszutauschen. Dies erlaubt eine effizientere Kommunikation und bietet weiterhin die Vorteile der asymmetrischen Verschlüsselung. Ein Verfahren für den dazu notwendigen Schlüsselaustausch wurde 1976 von Diffie und Hellman beschrieben. [17, 18, 19]

Die asymmetrische Verschlüsselung kann auch zur Authentifizierung des Senders verwendet werden, hierzu wird die Nachricht sowohl mit dem öffentlichen Schlüssel des Empfängers als auch mit dem eigenen privaten Schlüssel verschlüsselt. Stammt die Nachricht vom bekannten Absender kann der Empfänger diese mit seinem eigenen privaten und dem öffentlichen Schlüssel des Senders entschlüsseln. [15]

### 3.2 Blockchain

Grundsätzlich dient die Blockchaintechnologie dazu Transaktionsdaten dezentral, ohne eine zentrale Autorität zu speichern und gegen Manipulation zu sichern. Damit erlaubt es die sichere verteilte Speicherung von Daten in einem nicht vertrauenswürdigen Netzwerk. [20, 21, 22, 23]

#### 3.2.1 Merkmale

An dieser Stelle werden die Merkmale einer Blockchain definiert. Im weiteren Verlauf wird auf den Aufbau und die Funktionsweise eingegangen und dabei Rückschluss auf die Merkmale gezogen. In Fachliteratur finden sich unterschiedliche Definitionen für den Begriff Blockchain welche verschiedene Merkmale anführen. In diesem Abschnitt werden die Merkmale nach Sultan, Karim et. al. verwendet. [24, 20, 25]

Eine Blockchain ist __dezentralisiert__. Dies bedeutet, dass keine zentrale Instanz die Blockchain verwaltet oder Prozesse validiert. Die Daten sind nicht an einem Ort gespeichert, sondern können von allen Teilnehmern eingesehen und kopiert werden. Dadurch werden die Daten über das gesamte Netzwerk verteilt. Es existieren auch nicht dezentralisierte Blockchains. Darauf wird im Abschnitt Offenheit genauer eingegangen. Das Konzept von Dezentralität wird auch im Abschnitt Zentrale, Dezentrale und Verteilte Netzwerkstrukturen behandelt. [26]  

Die Daten einer Blockchain sind permanent gespeichert. Sie können nachträglich nicht entfernt oder manipuliert werden. Diese __Unveränderlichkeit__ ist ein weiteres wichtiges Merkmal der Technologie. Bei dem Begriff Unveränderlichkeit ist zu beachten, dass bei öffentlichen Blockchains eine Kopie der Daten bei jedem Teilnehmer hinterlegt wird. Dieser kann mit den Daten lokal nach Belieben vorgehen, die Blockchaintechnologie verhindert, jedoch die Verbreitung manipulierter Daten über das Blockchainnetzwerk. Zur Validierung von Blöcken verwendet eine Blockchain __Konsensmodelle__. Darauf wird im Abschnitt Publishing näher eingegangen. Eine Blockchain ist außerdem __transparent__. Jeder Nutzer kann die gesamte Transaktionshistorie einsehen, nachverfolgen und prüfen. Oftmals wird in Fachliteratur auch __Anonymität__ als Merkmal einer Blockchain angeführt. Nutzer haben eine Adresse und interagieren durch diese mit dem Blockchainnetzwerk. Die Adresse bietet keinen Rückschluss auf die Identität der Person. [20, 26, 27]

#### 3.2.2 Offenheit

Es gibt drei unterschiedliche Arten von Blockchains bezüglich ihrer Offenheit und Dezentralität. Zum einen gibt es die __öffentlichen__ Blockchains. Hier kann jeder Teilnehmer auf die Blockchain zugreifen, diese lokal auf seinem Computer speichern und erweitern. Es existiert keine übergeordnete Instanz zur Kontrolle, dadurch ist diese Variante die am stärksten dezentralisierte. Die Verteilung aller Informationen über das Netzwerk und die verteilte Validierung führen zu geringerer Effizienz. Bitcoin gilt als die erste offene Blockchain und startete 2009. [21, 23, 26, 27]

Die nächste Kategorie sind __hybride__ Blockchains. Prinzipiell hat jeder Zugriff auf die Blockchain, jedoch nicht zu allen Blöcken. Nutzer haben verschiedene Zugriffsrechte. Die Blockchain ist somit teilweise dezentralisiert. Ein Beispiel ist R3 Corda oder b3i. [23, 28, 29]

Die letzte Kategorie stellen die __privaten__ Blockchain-Netzwerke dar. Hier bestimmt eine zentrale Entität die Rechte für den Zugriff und die Bearbeitung. Die Blockchain ist zentralisiert, aber immer noch kryptographisch gesichert. Die zentralisierte Validierung führt zu einer höheren Effizienz als bei den dezentralisierten Variationen. Aufgrund der mangelnden Dezentralität ist es im allgemeinen strittig ob es sich bei dieser Variante noch um eine Blockchain handelt.
Diese Art wird vor allem von Unternehmen eingesetzt um den Zugriff auf interne Informationen zu sicher und regulieren. Beispiele für diesen Typ sind die Blockchains Hyperledger und Ripple. [23, 30]

#### 3.2.3 Blöcke

Eine Blockchain besteht aus einer Reihe von miteinander verknüpften Blöcken. Die Blöcke halten die zu speichernden Daten.
Sollen neue Daten zu einer Blockchain hinzugefügt werden, werden diese zunächst zu einem Knoten des Blockchain-Netzwerkes geschickt. Von dort werden die Informationen an anderen Knote im Netzwerk verteilt. Damit ein neuer Block zur Blockchain hinzugefügt wird, muss er von einem Knoten veröffentlicht werden. Dieser Prozess wird im Abschnitt Publishing näher erläutert. Abhängig von der Implementierung der Blockchain werden die Blocks in eine Warteliste eingereiht und nach einem Zeitintervall publiziert. Dadurch werden sie fester Teil der Blockchain. [20]

Der Aufbau eines Blocks ist dabei abhängig von der Implementierung, die meisten Blockchains haben, jedoch einen Aufbau ähnlich wie im Folgenden beschrieben.

Ein Block besteht hierbei aus zwei Teilen, einem Header und einem Body. Der Body enthält in erster Linie die gesammelten Transaktionsdaten. Diese sollen in der Blockchain gespeichert werden. Der Header beinhaltet unter anderem die Nummerierung des Blocks, seine Größe und den Zeitpunkt wann dieser der Blockchain hinzugefügt wurde. Des Weiteren liegt ein Hash des Headers des unmittelbar davor gepublishten Blocks bei. Ein weiteres Element welches vor allem für Blockchain-Netzwerke genutzt wird welche Proof of Work nutzen ist das sogenannte nonce value. Das Konzept von Proof of Work wird im gleichnamigen Abschnitt erläutert dargestellt. Alternativ kann dieses Element auch für andere Zwecke genutzt werden oder es entfällt. Zusätzlich beinhaltet eine Block noch eine Hash welches die Daten in seinem Body repräsentiert. Je nach Implementierung gibt es unterschiedliche Umsetzungen. [20, 25, 26]

Die grundsätzliche Idee ist, dass ein Header eine Repräsentation der Daten beinhaltet welche im Körper gespeichert sind. Der nächste Block beinhaltet die Repräsentation des Headers des vorherigen Blocks und somit auch indirekt seiner Daten. Es kommt also zu einer Verknüpfung der Daten mit dem Header und zwischen den Headern aufeinander folgender Blöcke. [24]

#### 3.2.4 Verknüpfung

Der Begriff Blockchain kommt von der Verknüpfung mehrerer Blöcke zu einer Kette. Diese Verknüpfung geschieht logisch durch den Aufbau der Blöcke. Wie im Abschnitt Blöcke beschrieben, beinhaltet jeder Header einen Hash des Headers des vorherigen Blocks sowie eine Nummerierung. Dadurch entsteht aus einer Reihe einzelner Datenblöcken eine logische Kette. [25,21]
Diese Verknüpfung ist entscheidend für den Schutz vor Manipulation an der Blockchain. Ein Block innerhalb der Kette kann nicht nach Belieben geändert werden. Eine Veränderung an den Daten des Blockes hat einen anderen Hashwert zur Folge. Dadurch würde der Block praktisch aus der Kette fallen, da der darauffolgende Block den originalen Hashwert beinhaltet. Ein Vergleich der beiden Hashwerte würde die Manipulation aufdecken. Auch das Einfügen eines zusätzlichen Blocks in die Blockchain wird dadurch verhindert. Der neue Block kann zwar den Hashwert seines Vorgängers beinhalten, der nächste Block verweist, jedoch über den gespeicherten Hashwert auf den eigentlichen Vorgänger. Die Blockchain ist somit unveränderbar. [21, 24, 26]

#### 3.2.5 Publishing

Das sogenannte publishing bezeichnet das Hinzufügen eines neuen Blocks zur Blockchain.  Dies ist vor allem in öffentlichen Blockchains ein kritischer Prozess, da verschiedene Knoten in der Lage sind Blöcke zu publishen und es keine zentrale Instanz gibt welche diese Aufgabe kontrolliert. Des Weiteren können die Teilnehmer im Allgemeinen nicht als vertrauenswürdig betrachtet werden. Hier stellt sich die Frage welcher Nutzer den nächsten Block hinzufügt. Dazu existieren unterschiedliche Konsensmodelle welche den Prozess des publishing regeln. Sie legen fest welcher Nutzer den nächsten Block veröffentlicht und wie möglicherweise auftretende Konflikte zu lösen sind. [20]

##### 3.2.5.1 Proof of Work (PoW)

Beim Proof of Work (PoW) Modell lösen Teilnehmer ein mathematisches Problem, dessen Lösung einen hohen Rechenaufwand erfordert. Der erste Nutzer welcher die Lösung findet darf den nächsten Block publizieren. Die Rätsel sind so konstruiert, dass die Lösung schwer zu finden, aber leicht zu überprüfen ist. Dadurch können alle anderen Nutzer des Blockchain-Netzwerkes die Lösung und damit den dazugehörigen Block schnell verifizieren. [20, 31] Die zu lösende Aufgabe könnte zum Beispiel sein, dass der Hashwert, welcher aus dem Header des zu publizierenden Blocks gewonnen wird unter einem vorgegebenen Wert liegt. Um dies erreichen zu können, kann ein Nutzer kleine Änderungen an dem Header an dafür vorgesehenen Stellen vornehmen. Der Aufbau eines Blocks wurde im Kapitel Blöcke beschrieben. Das dort genannte nonce value kann zum Beispiel je nach Implementierung der Blockchain für diesen Zweck verwendet werden. Dies bedeutet der Nutzer kann dieses Feld nach Belieben verändern um das gewünschte Resultat zu erreichen. [20, 31]

Wie im Kapitel Hashfunktionen beschrieben wurde ist es nicht effizient möglich aus einem Hash den ursprünglichen Wert zu berechnen. Aus diesem Grund kann ein Nutzer nicht einfach aus einem gewünschten Hashwert die Eingangsvariablen errechnen. Stattdessen muss er den Header verändern und anschließend den Hashwert des Headers berechnen. Entspricht der Wert nicht den Vorgaben muss das Verfahren wiederholt werden. Das häufige berechnen des Hashwertes ist mit hohem Rechnaufwand verbunden. [20]

Ein wichtiger Aspekt für das PoW Modell ist, dass eine Hashfunktion aus zwei ähnlichen Inputs sehr unterschiedliche Resultate liefert. Dies führt dazu, dass der Nutzer nur durch Veränderung eines Wertes im Header des Blockes sehr unterschiedliche Hashwerte erhält. Zum anderen kann er aus einem mit bekanntem Input erzeugten Hashwert nicht effizient Rückschlüsse für die Korrektur des Inputs ziehen.  

Durch Änderungen an den Vorgaben für die Lösung des Problems kann die Schwierigkeit und damit die Geschwindigkeit in welcher neue Blocks publiziert werden geregelt werden. Ein Beispiel für die Anwendung eines PoW Modells liefert Bitcoin. Das Verfahren wird hier als Mining bezeichnet und die Nutzer als Miner. [31, 32]

Ein PoW Modell verbraucht aufgrund des hohen Aufwands die Lösung eines Rätsel zu finden sehr viel Energie. Viele Teilnehmer versuchen zudem gleichzeitig das gleiche aufwändige Problem zu lösen, letzendlich kommt es, aber nur zur Erstellung eines neuen Blocks. [33, 34, 35]

##### 3.2.5.2 Proof of Stake (PoS)

Bei Proof of Stake erfolgt die Auswahl des Nutzers, welcher den nächsten Block publiziert basierend auf seinem Anteil und einem Zufallsverfahren. Nutzer welche einen hohen Anteil besitzen und diesen setzen werden priorisiert, dies ersetzt das Lösen des mathematischen Problems bei PoW. Das Konzept von PoS basiert auf der Annahme, dass ein Nutzer mit einem hohen Anteil an dem Netzwerk an dessen Fortbestand interessiert ist. [26] Eine beispielhafte Umsetzung bei Kryptowährungen wäre, dass Nutzer mit einem Teil ihres Vermögens für den zu erstellenden Block bürgen. Ihre Bürgschaft wird für die Dauer des Auswahlprozesses gesperrt. Je größer die Bürgschaft desto höher ist ihre Chance ausgewählt zu werden. Im Gegensatz zu PoW ist PoS sehr viel energieeffizienter. Es existieren, jedoch Zweifel an der Sicherheit von PoS und den Implementierungen. [26, 33, 34, 35]

Zwei weiter verbreitete Modelle sind Delegate Proof of Stake (DPoS) und Delegate Byzantine Fault Tolerance (dBFT). Das Delegate Proof of Stake ist eine sehr effektive Variante des PoS. Teilnehmer stimmen kontinuierlich darüber ab wer Blöcke publiziert. Jeder Teilnehmer kann sich selber zur Wahl stellen und anschließend eine Anzahl an Blöcken abhängig vom Anteil der erhaltenen Stimmen publizieren. Es existieren weitere Konsensmodelle. Einige Beispiele sind Proof of Activity, Proof of Burn, Ripple und Tendermint. [26, 31, 34, 36]

#### 3.2.6 Konflikte

In einem dezentralisierten System kann es trotz den bereits beschriebenen Konsensmodellen zu Konflikten kommen, vor allem bei sehr großen Netzwerken. Es ist zum Beispiel vorstellbar, dass zwei Teilnehmer eine Aufgabe bei Proof of Work zum gleichen Zeitpunkt lösen. Beide sind somit berechtigt einen neuen Block hinzuzufügen. In diesem Beispiel erstellen beide Teilnehmer aus ihren jeweiligen gesammelten Transaktionen einen neuen Block und fügen diesen an den letzten veröffentlichten Block an. Beide Teilnehmer verpacken unterschiedliche Transaktionen in dem Block und es entsteht ein Konflikt. Es existieren zwei verschiedene Stränge der Blockchain. [25] Beide Blöcke werden über das Netzwerk verbreitet und andere Teilnehmer arbeiten beliebig mit einem der beiden Blöcke. Sobald ein neuer Block an eine der beiden Stränge angehängt wird löst sich der Konflikt auf. Der Strang an welchem zuerst ein weiterer Block angehängt wird ist Teil der Blockchain der andere Strang fällt raus und wird als orphan bezeichnet. Dies passiert dadurch, dass Teilnehmer mit der aktuellsten Version der Blockchain arbeiten. Sobald der neu angefügte Block über das Netzwerk verbreitet wird nutzen alle Teilnehmer die neueren Daten. Der verwaiste Strang fällt somit aus dem Netzwerk. [25, 27]

#### 3.2.7 Forks

Neben den bereits auftretenden Konflikten kann es auch zu sogenannten Forks kommen. Diese treten auf wenn die der Blockchain zugrunde liegende Implementierung oder deren Regeln geändert werden. Es handelt sich somit um Methoden zur Aktualisierung der Blockchain. [25]
Es werden zwei Typen von Forks unterschieden, hard forks und soft forks. Bei einem __hard fork__ ersetzen die neuen Regeln die Ursprünglichen, welche somit ungültig werden. In einem großen verteilten Netzwerk wollen oder können nicht alle Teilnehmer die Aktualisierung durchführen. Dadurch verwenden diese weiterhin die Blockchain mit den ursprünglichen Vorgaben, dadurch entsteht eine Verzweigung der Blockchain. [25, 27]

Ein __soft fork__ ist eine Erweiterung der existierenden Regeln. Die bisherigen Vorgaben bleiben bestehen und sind weiterhin gültig. Es müssen nicht alle Knoten aktualisiert werden, sondern lediglich jene welche am Konsensmodell teilnehmen. [25]

### 3.2.8 Double Spending Problem

Der Begriff des Double Spending Problems wurde bereits in dem gleichnamigen Kapitel eingeführt. An dieser Stelle wird die von Satoshi Nakamoto vorgestellte Lösung näher erläutert. Sie löst das Double Spending Problem ohne die Nutzung einer zentrale Instanz. Essentiell dafür ist die stetige Aktualisierung der Blockchain. Alle Teilnehmer erhalten beständig die neue Version über das Netzwerk. Die Blockchain hält Informationen über alle getätigten Transaktionen in den bereits beschriebenen Blöcken. Diese enthalten in der von Satoshi Nakamoto vorgeschlagenen Lösung einen Zeitstempel. Dadurch kann nachverfolgt werden, wer aktuell im Besitz der digitalen Währung ist beziehungsweise ob diese bereits ausgegeben wurde. Durch den Zeitstempel wird auch deutlich welche die ursprüngliche Transaktion war und alle nachfolgenden Versuche das digitale Geldstück erneut zu transferieren scheitern. [38, 39]

***

[<< Grundlagen](Grundlagen.md) | [Anwendungsbeispiele >>](Anwendungsbeispiele.md)

***

```

Quellenangabe:

[01] - Blockgeeks, 2018
[02] - C. Eilers, 2016
[03] - C. Stachniss, o.A.
[04] - D. Drescher, 2017
[05] - K. Pommerening, M. Sergl, 2007
[06] - Ryte, 2018
[07] - M. Teschner, 2012  
[08] - C. Hoffmann, 2018
[09] - T. Fischer, 2018
[10] - T. Whitaker, 2018a
[11] - SSL2BUY, 2018
[12] - M. Rouse, 2016
[13] - R. Almeida, 2016
[14] - Elektronik-Kompendium, o.A.
[15] - o.A., 2010
[16] - C. Stobitzer, 2018
[17] - Dr. R. Wobst, 2003
[18] - Pyler, 2018
[19] - M. Rouse, 2007
[20] - W. Ross, 2018
[21] - M. Gupta, 2018
[22] - M. Andreessen, o.A.
[23] - P. Adam-Kalfon, S. El Moutaouakil, 2017
[24] - K. Sultan et al., 2018
[25] - L. Severeijns, 2017
[26] - Z. Zigin et al., 2017
[27] - A. Shanti Bruyn, 2017
[28] - B3i, 2018
[29] - K. Schiller, 2018
[30] - K. Schiller, 2018a
[31] - Blockgeeks, 2018a
[32] - B. Asolo, 2018
[33] - W. Li et al., o.A.
[34] - Unbekannt, 2015
[35] - M. Thake, 2018
[36] - A. Castor, 2017
[37] - A. Czernik, 2015
[38] - Team InnerQuest Online, 2018
[39] - N. Reiff, 2018
[40] - P. Schnabel, o.J.
```

***
[Quellen >>>](Quellen.md)
***
