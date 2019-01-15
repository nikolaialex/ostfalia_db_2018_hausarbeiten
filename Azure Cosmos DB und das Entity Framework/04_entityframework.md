# Entity Framework

Das Entity Framework (EF) ist ein Object Relational Mapper (ORM) zur Interaktion zwischen .NET Anwendungen und Datenbanken, das erstmals 2008 mit .NET 3.5 eingeführt wurde. [1]

Das Entity Framework unterstützt den Entwickler zur design-time und runtime.  Für die Datenbankerstellung, stehen zwei verschiedene Methoden zur Verfügung. Beim Code First Approach werden aus zuvor definierten Klassen Datenbankenmodelle erstellt. Beim Database First Approach wird aus einer vorhandenen Datenbank die Datenmodell-Klassen durch Reverse Engineering der Datenbank abgeleitet.

## LINQ

Linq steht für Language Integrated Query und ist ein Verfahren für den Zugriff auf Daten. Die Technik wurde erstmals mit .NET 3.5 eingeführt und seitdem stetig weiterentwickelt. Linq bündelt verschiedene Abfragesprachen unterschiedlicher Datenquellen zu einer übergreifenden Sprache.

Ein weiterer Vorteil besteht in der Validierung der Abfrage bereits zur design-time. Der Compiler (MIL?? ) kann schon vor dem Kompilieren und somit auch schon vor dem konkreten Zugriff Fehler in der Abfrage feststellen.

## Code First

Beim Code First Approach erstellt der Entwickler eine Klasse für die Modelle der Domäne, die persistiert werden sollen. Um Beziehungen zwischen den Entitäten zu gestalten wird innerhalb der Klassen eine Property angelegt, dessen Typisierung des zu referenzierenden Modells entspricht.

EF bietet komplexe Möglichkeiten zur Erstellung von Beziehungen zwischen Entitäten. Alle Funktionen vorzustellen würde den Umfang der Arbeit übersteigen. In dieser Arbeit werden die wichtigsten Funktionen vorgestellt, sodass der Leser in der Lage ist schnell in das EF einzusteigen.

Nachfolgend werden drei Verfahren zum Erstellen häufiger Beziehungsmuster dargestellt.

### 1:n

```c#
class Box
{
    public int BoxId { get; set; }

    public ICollection<Cat> Cats { get; set; }
}

class Cat
{
    public int CatId { get; }
    public bool IsAlive { get; }

    public int BoxId { get; set; }
    public Box Box { get; set; }
}
```

In diesem Beispiel haben wir eine one-to-many Beziehung durch das Hinzufügen einer ICollection Property definiert. Die Cat-Klasse bleibt unverändert bestehen.

Beim Anlegen der Datenbankstruktur wird EF eine zusätzliche Tabelle in der Datenbank schaffen, um diesen Beziehungstypen darzustellen.

Die Tabellen werden sich wie folgt gestalten:

| BoxId |
| ---   |
| 1     |

| CatId | IsAlive | BoxId |
| ---   | ---     | ---   |
| 1     | 1       | 1     |
| 5     | 0       | 1     |

### 1:1

```c#

class Box
{
    public int BoxId { get; set; }

    public Cat Cat { get; set; }
}

class Cat
{
    public int CatId { get; }
    public bool IsAlive { get; }

    public int BoxId { get; set; }
    public Box Box { get; set; }
}

```

In dem obigen Beispiel wurde eine Beziehung modelliert, die in der Datenbank in eine 1:1-Beziehung aufgelöst wird. Dies ist gleich zur Modellierung einer 1:n Beziehung. Bei der 1:1 Beziehung wird EF einen Unique Index erstellen, um so die Mehrfachbelegung eines Elementes zu verhindern. Das Entity Framework wird Tabellen in der Datenbank nach folgendem Muster erstellen:

| BoxId |
| ---   |
| 1     |

| CatId | IsAlive | BoxId |
| ---   | ---     | ---   |
| 1     | 1       | 1     |

EF wird dabei eine Entität auswählen, von dessen Fremdschlüssel die andere Entität abhängig sein wird. Dieser Prozess kann durch die Fluent-API beeinflusst werden, die später noch beschrieben wird.

Durch die Verknüpfung der Objekttypen kann EF die Relation feststellen. Diese Properties werden auch als Navigation Properties bezeichnet und ermöglichen den Zugriff auf die abhängige Entität.

### m:n

Zum jetzigen Zeitpunkt ist es noch nicht möglich many-to-many Beziehungen, ohne das Erstellen einer eigenen Jointabelle darzustellen.

```c#

class Box
{
    public int BoxId { get; set; }
    
    public BoxCat BoxCats { get; set; }
}

class Cat
{
    public int CatId { get; }
    public bool IsAlive { get; }

    public BoxCat BoxCats { get; set; }
}

```

Die Entitätsklassen wurden soweit angepasst, dass diese nun auf die Joinentität verweisen.

Die Joinentität enthält nun die Fremdschlüssel und Navigation Properties der Entitäten.

```c#
class BoxCat
{
    public int BoxId { get; set; }
    public Box Box { get; set; }

    public int CatId { get; set; }
    public Cat Cat { get; set; }
}

```


## Database First

## Fluent-API

---
[1] 