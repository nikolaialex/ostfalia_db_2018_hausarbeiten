# 4.0 Fazit

Verteilte Systeme bieten viele Vorteile. Je nach Aufbau des verteilten Systems ist ein echter Parallelbetrieb möglich oder die Last kann auf mehrere Systeme verteilt werden. Verteilte Systeme sind also vielseitig und können für verschiedene Anwendungszwecke angepasst werden. Im Bereich der Datenbanken kann eine Datenbank zur Sicherung auf mehreren Systemen installiert sein und die gleichen Daten enthalten. Oder die Daten können auf mehrere Systeme verteilt sein, wenn zum Beispiel verschiedene Standorte involviert sind und diese jeweils nur auf bestimmte Daten zugreifen müssen. Dafür müssen verschiedene Sicherheitsmechanismen sicherstellen, dass die Daten in der Datenbank zu jedem Zeitpunkt konsistent sind und der Zugriff auf die Daten möglich ist. Damit die verteilten Systeme diese verschiedenen Aufgaben erfüllen können, kommt meist eine Middleware zum Einsatz, eine Schicht zwischen Anwendung und verteiltem System. Diese Schicht dient der Abstrahierung der Zugriffe auf das verteilte System. Für die Anwendung ist nicht ersichtlich, dass sie auf ein verteiltes System zugreift. Ebenso muss das verteilte System nicht direkt mit der Anwendung kommunizieren können, sondern bestimmte Prozeduren für die Kommunikation mit der Middleware bereitstellen. Damit die Vorteile der verteilten Systeme genutzt werden können, müssen diese Herausforderungen gemeistert werden.

-----
[Zurück](3.3_Latenzen_innerhalb_des_Netzwerkes.md) | [Weiter](Literatur-_und_Quellenverzeichnis.md)

[Zum Inhaltsverzeichnis](README.md)