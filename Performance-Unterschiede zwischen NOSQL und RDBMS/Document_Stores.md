# Document Stores

Document Stores sind einfache Datenstrukturen, die über UUIDs identifizierte Dokumente enthalten. Dokument meint dabei aber nicht zwangsläufig einen Text. Stattdessen ist ein geeignetes Beispiel ein Blog-Post, der wiederum diverse Kommentare enthält. Diese Daten werden zusammenhängend als ein Dokument gespeichert, sodass etwa eine Web-Anwendung, die einen Blog-Post samt Kommentaren anzeigen soll, keine Daten über verschiedene Tabellen ermitteln muss, sondern durch einen einzigen Abruf bedient wird. Redundantes Speichern (z. B. Namen der Kommentatoren) ist somit nicht nur gewollt, sondern Kernelement des Ansatzes. Da es keine einzelnen Spalten oder Tabellen gibt, liegt die Überwachung der Korrektheit der inhaltlichen Daten beim Entwickler der zugreifenden Anwendung. Die Datenbank gewährleistet lediglich den Zugriff auf das hinter einer UUID hinterlegte Dokument. [1]

Eine Beispiel-Struktur in einer relationalen Datenbank (mit Fremdschlüsseln über Matrikelnummer und Fach-ID) könnte wie folgt aussehen:

| Matrikelnummer | Name           | Credit Points |
| -------------- | -------------- | ------------- |
| 123456789      | Max Mustermann | 10            |

| Matrikelnummer | Fach |
| -------------- | ---- |
| 123456789      | 1    |
| 123456789      | 2    |

| Fach | Name                       | Credit Points |
| ---- | -------------------------- | ------------- |
| 1    | Datenbanktechnologien      | 5             |
| 2    | Wissenschaftliches Seminar | 5             |

In einer dokumentenbasierten Datenbank würde ein Datensatz stattdessen so abgebildet werden:

```json
{
    '_id' : '60e8c8e7-7079-404f-9740-5c267a8bda13',
    'Matrikelnummer' : 123456789,
    'Name' : 'Max Mustermann',
    'Credit Points' : 10,
    'Faecher' : [
        {
            'Name' : 'Datenbanktechnologien',
            'Credit Points' : 5
        },
        {
            'Name' : 'Wissenschaftliches Seminar',
            'Credit Points' : 5
        }
    ]
}
```



## Foreign Key

Foreign Keys werden nicht von Document Stores angeboten. Die Grundidee von Document Stores besteht darin, dass idealerweise sämtliche für einen Kontext notwendigen Daten als ein zusammenhängender Eintrag im Storage abgelegt sind. Hierdurch besteht keine Notwendigkeit für Foreign Keys.



## Daten-Änderungen

Da ein Dokument zusammenhängend mit allen abhängigen Daten gespeichert ist, bedeutet die Änderung eines beliebigen Teilstücks, dass das komplette Dokument neu geschrieben werden muss. Da die Länge eines Dokuments nicht vorgegeben oder limitiert ist, genügt es nicht, einen Teilabschnitt des Speichermediums zu überschreiben. Als Änderung ist selbstverständlich bei Document Stores auch das Anhängen neuer Daten an einer Dokument anzusehen.



## Strukturelle Änderungen

Ein Document Store ist, wie bereits erläutert, eine einfache Ablage für ein zusammenhängendes Dokument. Das verwaltende System hat keine Kenntnis (bzw. kein "Interesse" an dieser) über die Struktur. Sie wird durch die zugreifende Anwendung definiert und interpretiert. Änderungen der Struktur stellen damit für das DBMS lediglich eine Änderung des Inhalts dar. Der Entwickler der Anwendung muss daher abwägen, ob er alte Dokumente unverändert belässt und beim Abrufen entscheidet, auf welche Weise das Dokument gelesen werden muss, damit die Anwendung damit umgehen kann. Alternativ kann er alle vorhandenen Dokumente auf den neuen Stand migrieren, was schlussendlich bedeutet, die gesamte Datenbank erneut auf das Speichermedium zu schreiben.



## Skalierung

In Document Stores werden Dokumente als Ganzes abgelegt. Solange das DBMS die Übersicht behält, welches Dokument auf welchem Rechner abgespeichert ist, können quasi beliebig viele Systeme als Storage verwendet werden. Document Stores skalieren also horizontal sehr gut. Da sie nur auf einfachen Datenstrukturen basieren, erhöht sich die Performance nicht durch den Einsatz von besserer Hardware - sie skalieren vertikal nur schlecht. [1]



## Performance-Vergleich (Fazit)

Im Vergleich zu relationalen Datenbanken ergeben sich folgende, die Performance betreffende Unterschiede:



* Das Lesen aus der Datenbank ist (wenn das Dokument dem anzuzeigenden Inhalt entspricht), je nach vergleichbarer relationaler Datenbank, erheblich schneller, da die Daten an einer Stelle abgelegt sind
* Das Schreiben eines neuen Dokuments ist schneller, da nur an einer Stelle an die Datenbank angehangen wird
* Das Verändern eines Dokuments ist deutlich langsamer, da beim Speichern das gesamte Dokument neu geschrieben werden muss
* Vertikales Skalieren ist nicht unendlich weit möglich. Während relationale Datenbanken also irgendwann technisch limitiert sind, können prinzipiell unendlich viele Knoten zum Verbund des Document Stores hinzugefügt werden



------

[< Relationale Datenbanken](Relationale_Datenbanken.md) | [Key-Value-Stores >](Key-Value-Stores.md)

***

```
Quellen

[1]: https://www.pro-linux.de/artikel/2/1455/3,dokumentenorientierte-datenbanken.html
[2]: https://database.guide/what-is-a-document-store-database/
```

***

