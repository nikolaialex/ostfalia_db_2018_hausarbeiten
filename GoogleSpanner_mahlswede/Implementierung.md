[<<2. Einleitung](Einleitung.md)

[>>4. TrueTime API](TrueTimeAPI.md)

***


## 3. Implementierung

Ein Spanner Deployment wird „Universe“ genannt. Dadurch, dass Spanner Daten global managed, wird es nur eine Handvoll „Universen“ geben. Zum Zeitpunkt des Artikels von James C. Corbett 2012 waren es das „Test/Playground Universe“, ein „Development/Production Universe“ und ein „Production-Only Universe“.<sup>14</sup>

Spanner ist als ein Satz von Zonen organisiert. Jede Zone entspricht grob dem Einsatz eines Bigtable-Servers. Der Satz von Zonen ist außerdem der Satz von Locations über die die Daten repliziert werden können. Zonen können hinzugefügt oder entfernt werden aus dem laufenden System, wenn neue Rechenzentren in Betrieb genommen werden und alte Rechenzentren vom Betrieb entfernt werden. Zonen sind auch die Einheiten der physischen Isolation, es kann eine oder mehrere Zonen in einem Rechenzentrum geben, zum Beispiel wenn verschiedene Applikationsdaten auf verschiedenen Servern des gleichen Rechenzentrums partitioniert werden.<sup>15</sup> 

Eine Zone hat einen Zonenmaster und zwischen hundert und tausend *Spanserver*. 

Die Per-Zone Location Proxies werden von den Clients genutzt um die *Spanserver* zu identifizieren, die genutzt werden ihre Daten zu speichern. Der *Universe Master* und der *Placement Driver* sind momentan einzigartig. Der *Universe Master* ist primär eine Konsole, die Status Informationen über alle Zonen für interaktives Debugging enthält. Der *Placement Driver* kommuniziert periodisch mit den *Spanservern* um Daten zu finden, die verschoben werden müssen, entweder um geupdateten Replication Contraints zu entsprechend oder um eine Lastverteilung zu erwirken (Load Balancing).<sup>16</sup>  

### 3.1.	Spanserver Software Stack ###

Anders als Bigtable ordnet Spanner den Daten Timestamps also Zeitstempel zu, das ist wichtig, denn das führt dazu, dass Spanner eher eine Multiversions-Datenbank ist als eine Schlüssel-Werte-Datenbank.<sup>17</sup>  

Der Status einer Tabelle wird in einer Gruppe von B-Tree-ähnlichen Dateien und einem Write-Ahead-Protokoll gespeichert, und zwar alle auf einem verteilten Dateisystem namens Colossus (der Nachfolger des Google File System).<sup>18</sup>    

Um die Replikation zu unterstützen, implementiert jeder Spanserver eine einzelne Paxos-Statusmaschine auf jeder Tabelle. Jede Zustandsmaschine speichert ihre Metadaten und den Verlauf in der entsprechenden Tabelle. Die Paxos-Implementierung unterstützt langlebige Leader mit zeitbasierten Leader-Leasingverträgen, deren Länge standardmäßig 10 Sekunden beträgt. Die jetzige Spanner-Implementierung protokolliert jedes Paxos zweimal: einmal im Protokoll der Tabelle und einmal im Paxos-Protokoll.<sup>19</sup> 

Die Paxos-Zustandsmaschinen werden verwendet, um einen konsistent replizierten Bag von zu implementieren Zuordnungen zu erstellen. Der Schlüsselwertzuordnungsstatus jedes Replikats wird in seiner entsprechenden Tabelle gespeichert. Schreibzugriffe muss das Paxos-Protokoll beim Leader initiieren. Lesezugriff erhält den Zugriffsstatus direkt von der zugrundeliegenden Tablette auf einem ausreichend aktualisierten Replikat. Die Menge von Nachbildungen sind zusammen eine Paxos-Gruppe.<sup>20</sup>  

Bei jedem Replikat, das ein Leader ist, implementiert ein Spanserver eine zu implementierende „Lock Table“ als Concurrency Control. Die „Lock Table“ enthält den Status für die zweiphasige Sperrung: sie ordnet Schlüsselbereiche dem einzelnen Sperrstatus zu. Sowohl  Bigtable als auch Spanner sind auf langlebige Transaktionen ausgelegt. (z. B. für  Berichterstellungen, die Minuten in  Anspruch nehmen). Diese Transaktionen sind darauf ausgelegt weiter zu laufen, auch wenn während der Durchführung Konflikte auftreten. Vorgänge, für die eine Synchronisierung erforderlich ist, z. B. transaktional Lesezugriffe, erhalten Sperren in der „Lock Table“; Andere Operationen umgehen die „Lock Table“.<sup>21</sup>   

Bei jedem Replikat, das ein Leader ist, implementiert jeder Spanserver einen Transaktionsmanager um die verteilten Transaktionen zu unterstützen. Der Transaktionsmanager wird benutzt um einen „Participant-Leader“ zu implementieren, dem andere Replikationen aus der Gruppe als „Participant-Slave“ hinzugefügt werden. Wenn eine Transaktion nur eine Paxos-Gruppe umfasst, kann der Transaktionsmanager umgangen werden, da die Lock-Table und Paxos zusammen Transaktionalität garantieren. Beinhaltet eine Transaktion mehr als eine Paxos-Gruppe, koordinieren die jeweiligen Gruppenleiter den zweiphasigen Commit. Eine der teilnehmenden Gruppen wird als Koordinator, der „Participant-Leader“ der Gruppe wird als „Coordinator-Leader“ ausgesucht, die Slaves der Gruppe werden „Coordinator Slaves“ genannt. Der Status jedes Transaktionsmanagers wird in der zugrundeliegenden Paxos-Gruppe gespeichert.<sup>22</sup>   

### 3.2 Verzeichnisse und Platzierung ###
Zusätzlich zu den Schlüsselwertzuordnungen unterstützt die Implementierung von Spanner eine Bucketing-Abstraktion die als ein Verzeichnis/Directory bezeichnet wird, bei dem es sich um einen Satz zusammenhängender Schlüssel handelt, die ein gemeinsames Präfix nutzen. Mit Verzeichnissen können Anwendungen die Position ihrer Daten durch Auswahl von Schlüsseln steuern.<sup>23</sup>   

Ein Verzeichnis ist die Einheit der Datenplatzierung. Alle Daten in einem Verzeichnis haben dieselbe Replikationskonfiguration. Wenn Daten zwischen Paxos-Gruppen verschoben werden, werden sie Verzeichnis für Verzeichnis verschoben. Spanner kann Verzeichnisse, auf die besonders oft zugegriffen wird, in die gleiche Paxox-Gruppe verschieben, oder ein Verzeichnis wird in eine Gruppe verschoben, die näher an den Zugriffsmethoden befindet. Verzeichnisse können auch verschoben werden, während Client-Zugriffe noch laufen. Ein 50MB-Verzeichnis kann dabei in ein paar Sekunden verschoben werden.<sup>24</sup>  

*Movedir* ist die Hintergrundaufgabe, mit der Verzeichnisse zwischen Paxos Gruppen verschoben werden. *Movedir* wird auch zum Hinzufügen oder Entfernen von Replikaten aus Paxos-Gruppen verwendet indem alle Daten einer Gruppe in eine neue Gruppe verschoben werden. *Movedir* wird nicht als einzelne Transaktion implementiert, um zu vermeiden laufender Lese- und Schreibvorgänge bei sperrigen Datenbewegungen zu blockieren. Stattdessen registriert *Movedir*, das mit dem Datenverschieben begonnen wird und führt das Datenverschieben im Hintergrund durch. Ist der Großteil der Daten verschoben, nutzt *Movedir* eine Transaktion, die die letzten kleinen Datenreste überführt und die Metadaten für die zwei Paxos-Gruppen updatet.<sup>25</sup> 

Ein Verzeichnis ist die kleinste Einheit dessen geopgraphische-Replikations-Eigenschaften (oder kürzer: Platzierung) durch eine Anwendung spezifiziert werden können. Administratoren kontrollieren zwei Dimensionen: die Nummer und den Typ der Replikation, und die geographische Lage der Replikation. Sie suchen aus eine Menü aus benannten Optionen dieser zwei Dimensionen aus (Beispiel: Nordamerika, fünf Mal repliziert). Eine Anwendung kontrolliert dann, wie die Daten repliziert werden, indem jede Datenbank oder individuelle Verzeichnisse mit einer Kombination dieser Optionen getaggt werden.<sup>26</sup>    

### 3.3 Datenmodell ###
Spanner stellt die folgenden Datenfunktionen für Anwendungen zur Verfügung: Ein Datenmodell basiert in schematisierten semirelationalen Tabellen, einer Abfragesprache und Transaktionen für allgemeine Zwecke. Der Schritt zur Unterstützung dieser Funktionen wurde von vielen Faktoren beeinflusst. Viele Anwendungen bei Google nutzten Megastore<sup>27</sup> , obwohl es eine relativ schwache Performance aufweist. Das Datenmodell von Megastore  ist einfacher zu managen als das Datenmodell von Bigtable. Außerdem bietet auch Megastore die Replikation der Daten über verschiedene Rechenzentren. Bekannte Google-Anwendungen, die Megastore nutzen sind: Gmail, Picasa, Calendar, Android Market und AppEngine. Es war also schnell klar, dass Spanner ein SQL-ähnliches Datenmodell unterstützen muss. Bigtable hatte außerdem kein Feature um Cross-Row-Transaktionen zu ermöglichen, was zu wiederholten Beschwerden führte.<sup>28</sup> 

Das Anwendungsdatenmodell wird auf den Schlüsselwert des Verzeichnisses gesetzt – auf Zuordnungen, die von der Implementierung unterstützt werden. Eine Anwendung erstellt eine oder mehrere Datenbanken in einem Universum. Jede Datenbank kann eine unbegrenzte Anzahl schematisiert Tabellen enthalten. Tabellen sehen aus wie relationale Datenbanktabellen mit Zeilen, Spalten und versionierten Tabellenwerten. Die Anfragesprache von Spanner sieht aus wie SQL mit einigen Erweiterungen zur Unterstützung von Feldern mit Protokollpufferwert. Das Datenmodell von Spanner ist nicht rein relational. Zeilen müssen Namen haben. Genau genommen muss jede Tabelle einen oder mehrere Primärschlüssel-Spalten besitzen. Bei dieser Anforderung sieht Spanner immer noch wie ein Schlüsselwertspeicher aus: der Primarykey bildet den Namen der Zeile und jede Tabelle definiert ein Mapping der Primary-Key-Spalten mit den Non-Primary-Key-Spalten. Eine Zeile existiert nur, wenn ein Wert (auch wenn er NULL ist) als Zeilen-Schlüssel definiert ist. Anwendungen können ihre Daten damit über die Auswahl der Schlüssel kontrollieren.<sup>29</sup>    

### 3.4 Veränderungen an Spanner ###
Spanner wurde über die Jahre von den Google-Entwicklern weiterentwickelt und verändert. Spanner startete als ein Key-Value-Store mit Multirow-Transaktionen, externer Konsistenz und einer transparenten Ausfallsicherung über verschiedene Rechenzentren. In den vergangenen sieben Jahren entwickelte sich Spanner zu einem Relationalen Datenbankensystem. In dieser Zeit wurde ein streng typisiertes Schema System und ein SQL Query Prozessor ergänzt.<sup>30</sup>   

Anfangs wurden einige der Datenbanken-Features an Spanner angedockt – die erste Version des Query Systems nutzte hochrangige APIs fast wie eine externe Anwendung. Diese externe Anwendung nutzte wenige der Features, die Spanner zu seinem Durchbruch verhalfen. Der Wunsch das Datenbankensystem an das Verhalten traditioneller Datenbankensysteme anzupassen, zwang die Entwickler, dass System grundlegend weiterzuentwickeln. Die Architektur der verteilten Datenhaltung führte zu fundamentalen Änderungen in der Abfrage-Zusammenstellung und –durchführung. Die Bedarfe des Query Processor haben wiederum Auswirkungen darauf, wie Daten gespeichert und behandelt werden. Alle diese Änderungen haben dazu geführt, dass Spanners große Skalierbarkeit beibehalten werden konnte und den Kunden trotzdem eine mächtige Plattform für Datenbankenanwendungen angeboten wird.<sup>31</sup>   


***
Quellen: 

<sup>14</sup>James C. Corbett (2012), S. 3

<sup>15</sup>James C. Corbett (2012), S. 3

<sup>16</sup>James C. Corbett (2012), S. 3

<sup>17</sup> James C. Corbett (2012), S. 4

<sup>18</sup>James C. Corbett (2012), S. 4

<sup>19</sup>James C. Corbett (2012), S. 4

<sup>20</sup>James C. Corbett (2012), S. 4

<sup>21</sup>James C. Corbett (2012), S. 4 - 5

<sup>22</sup>James C. Corbett (2012), S. 5

<sup>23</sup>James C. Corbett (2012), S. 5

<sup>24</sup>James C. Corbett (2012), S. 5

<sup>25</sup>James C. Corbett (2012), S. 5 - 6
  
<sup>26</sup>James C. Corbett (2012), S. 6
  
<sup>27</sup>Baker, Jason; Bond, Chris; Corbett, James (2011), S. 1
  
<sup>28</sup>James C. Corbett (2012), S. 6
  
<sup>29</sup>James C. Corbett (2012), S. 6 - 7

<sup>30</sup>Chirkova, Rada; Yang, Jun; Suciu, Dan (2017), S. 1

<sup>31</sup>Chirkova, Rada; Yang, Jun; Suciu, Dan (2017), S. 1






