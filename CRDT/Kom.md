[<- Einführung](Einfuehrung.md "Einführung")
# Kommunikation in Verteilten Systemen

Verteilte Systeme werden häufig eingesetzt, um echte Nebenläufigkeit zu erreichen, leichtere Skalierbarkeit, höhere Ausfallsicherheit, Lastverteilung und wirtschaftliche Zielsetzungen. CRDTs stellen dabei eine Möglichkeit dar, für inhaltliche Synchronisation verteilter Datenbestände zu sorgen.

Die Kommunikation in verteilten Systemen sieht sich mit verschiedenen Problemen konfrontiert, die aus der Verteilung auf autarke Einzelkomponenten entstehen. Da diese auf keinen gemeinsamen Speicher zugreifen können, muss ihre gesamte Kommunikation über den Austausch von Nachrichten erfolgen. Dabei kann es beispielsweise zum Ausfall einzelner Netzknoten kommen, zu Verbindungsstörungen, zu Laufzeitanomalien oder zum Verlust oder der Duplizierung von Nachrichten. In der Folge weichen Replikate der gemeinsamen Daten in den einzelnen Knoten voneinander ab.

## Beispiel zur Verbindungsstörung anhand eines Navigations-Programms

Zwei Benutzer verwenden ein Navigationsgerät um Informationen zu einem aktuellen Verkehrsstau bereitzustellen. Nutzer A meldet um 10 Uhr, dass es einen Stau gibt. Seine Nachricht wird aufgrund einer Netzwerkstörung aber erst um 11 Uhr effektiv versendet. Nutzer B meldet um 10:30 Uhr, dass sich der Stau aufgelöst hat. Seine Nachricht wird sofort versendet. Ohne weitere Vorkehrungen ergibt sich bei den Empfängern der Nachrichten das Bild eines um 11 Uhr noch bestehenden Verkehrsstaus, da die entsprechende Nachricht zuletzt eingetroffen ist.

Für dieses Beispiel sind natürlich einfache Vorkehrungen wie beispielsweise Zeitstempel denkbar, die das genannte Problem beseitigen. Es mag aber als plakative Illustration einer Situation dienen, die als “Last-Write-Wins” bezeichnet wird.

## Beispiel zu Laufzeitanomalien anhand verteilter Kontodaten

Ein städtisches Büchereisystem setzt je Filiale eigene Datenhaltungen der Benutzerdaten ein. Informationen über entliehene Medien und den Status der Mitgliedschaft werden zwischen den Systemen ausgetauscht. Ein Mitglied soll maximal 10 Bücher gleichzeitig entleihen können. Die Verbuchung eines Rückgabe- und Ausleihvorgangs wird in dieser Reihenfolge an die angeschlossenen Systeme übermittelt. Durch ein unterschiedliches Routing der zugehörigen Datenpakete werden angeschlossene Systeme aber in umgekehrter Reihenfolge informiert. Je nach Implementierung der Software ergibt sich dadurch ggf. ein ungültiger Zustand (mehr als 10 Medien entliehen).
Weitere Probleme können entstehen, wenn solche Datenpakete verloren gehen oder verdoppelt werden.

[Gemeinsamer Datenbestand ->](Gemein.md "Gemeinsamer Datenbestand")  

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")