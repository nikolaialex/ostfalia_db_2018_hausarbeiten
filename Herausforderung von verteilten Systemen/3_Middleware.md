# 3.0 Middleware

Die Transaktionskontrolle und auch andere Sicherheitsmechanismen werden in den meisten Fällen von einer Middleware übernommen. Als Middleware wird eine zusätzliche Schicht bezeichnet, die zwischen dem verteilten System und der eigentlichen Anwendung steht. Dadurch ist für die Anwendung nicht ersichtlich, dass es sich um ein verteiltes System handelt und wie dieses aufgebaut ist. Dies ist für die Anwendung auch nicht notwendig. Ebenso ist für das verteilte System z. B. eine Datenbank nicht zwingend erforderlich, die verschiedenen Anwendungen zu kennen, die auf sie zugreifen. 

Bei Middleware wird zwischen kommunikationsorientierter und anwendungsorientierter Middleware unterschieden. Die kommunikationsorientierte Middleware stellt hauptsächlich die logische Infrastruktur für die Kommunikation bereit. Die anwendungsorientierte Middleware bietet zusätzlich eine Erweiterung der Laufzeitumgebung und ein Komponentenmodell. Da beim Einsatz von Middleware eine zusätzliche Schicht eingeführt wird, steigert dies nicht unbedingt die Performance des gesamten Systems. Es kann auch zu Geschwindigkeitseinbußen kommen.

![Abbildung 1: Verbindung Client-Middleware-Server](/images/Abbildung1.png)

Abbildung 1: Verbindung Client-Middleware-Server

Typische Dienste der Middleware sind dabei: Kommunikationsdienste, Systemdienste, Informationsdienste, Ablaufkontrolldienste, Präsentationsdienste und Berechtigungsdienste. Für die Datenbank sind lediglich die Kommunikationsdienste wichtig, welche auf hochentwickelten Kommunikationsgeräten arbeiten. Im Grunde funktioniert es so, dass vom Klienten Datenbankabfragen kommen, welche die Middleware entgegennimmt. Diese leitet die Anfrage dann an einen verfügbaren Datenbankserver weiter, welcher die Anfrage bearbeitet und wieder zurücksendet, bis es beim Klienten ist. Die Herausforderung dabei ist, wie die Middleware die eingehenden Daten handhabt und an die verschiedenen Server weiterleitet, ohne großen Zeit- und Rechenaufwand.

-----
[Zurück](2.2_Transaktinskontrolle.md) | [Weiter](3.1_Lastverteilung.md)

[Zum Inhaltsverzeichnis](README.md)