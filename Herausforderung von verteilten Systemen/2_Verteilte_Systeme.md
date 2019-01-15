# 2.0 Verteilte Systeme

Verteilte Systeme werden in vielen verschiedenen Bereichen und auf verschiedene Weisen eingesetzt. Es gibt Client-Server Systeme, bei denen ein oder mehrere Clients auf ein oder mehrere Server zugreifen. Für die Anwender ist nicht unbedingt sichtbar, dass sie nicht auf ihrem lokalen Rechner, sondern auf einem entfernten Server arbeiten. Die Anwendung selbst kann dabei auch auf verschiedene Server verteilt sein.

Mit Hilfe von verteilten Systemen können mehrere Prozesse gleichzeitig ablaufen, also eine Nebenläufigkeit erreicht werden, die auf einem einzelnen System nicht ohne Weiteres möglich wäre. In diesem Fall spricht man auch von parallelen Systemen.

Im Bereich der Datenbanken gibt es verschiedene Möglichkeiten verteilte Systeme einzusetzen. Durch den Einsatz von mehreren Systemen kann die Ausfallsicherheit erhöht werden. Dazu ist es notwendig, die komplette Datenbank, also den gesamten Datenbestand auf mehr als einem System gespeichert zu haben. Dies erfordert mehr Speicherplatz, die Daten sind aber besser geschützt. Wichtig ist bei diesem Szenario, dass die Daten abgeglichen werden müssen. Es muss, während ein Datensatz geändert wird, ein Trigger ausgelöst werden, der diese Daten auch auf den anderen Systemen ändert oder es muss in bestimmten Zeitintervallen ein Abgleich der Daten stattfinden. Letzteres hat den Nachteil, dass zwischen diesen Intervallen die Daten eventuell nicht konsistent sein können. Beim Einsatz eines Triggers besteht dieses Problem nicht. Es kann aber passieren, dass sich die Datenbank-Jobs behindern, wenn eine neue Änderung bereits eintritt und übermittelt werden muss, bevor die vorherige Transaktion abgeschlossen ist. 

Soll die Performance gesteigert werden, bietet es sich an, den Datenbestand in einem Speicherbereich vorzuhalten, auf den mehrere Systeme zugreifen können, auf denen eine Anwendung läuft, mit der auf die Daten zugegriffen werden kann. Hier ist sichergestellt, dass auf die gleichen Daten zugegriffen wird, es müssen also keine Daten abgeglichen werden. Es muss aber verhindert werden, dass von beiden Systemen auf denselben Datensatz zugegriffen wird und es zu Inkonsistenzen kommt. Ein Datensatz, der verändert werden soll, muss also gelockt werden, bis die Transaktion vollständig abgeschlossen ist.

-----
[Zurück](1_Einleitung.md) | [Weiter](2.1_Arten_von_verteilten_Datenbanken.md)

[Zum Inhaltsverzeichnis](README.md)