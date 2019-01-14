# Entity Framework

Das Entity Framework (EF) ist ein Object Relational Mapper (ORM) zur Interaktion zwischen .NET Anwendungen und Datenbanken, das erstmals 2008 mit .NET 3.5 eingeführt wurde. [1]

Das Entity Framework unterstützt den Entwickler zur design-time und runtime.  Für die Datenbank Erstellung, Stehen zwei verschiedene Methoden zur Verfügung. Bei den Code First Approach, Werden aus zuvor definierten Klassen Datenbankenmodelle erstellt. Bei den Database First Approach wird aus einer vorhandenen Datenbank das Datenmodell-Klassen durch Reverse Engineering der Datenbank abgeleitet.

## LINQ

Linq steht für Language Integrated Query und ist ein Verfahren für den Zugriff auf Daten und wurde mit dem .NET 3.5 Framework eingeführt. Linq bündelt verschiedene Abfragensprachen unterschiedlicher Datenqellen zu einem übergreifenden Verfahren.

Ein weitere Vorteil besteht in der Validierung der Abfrage zur Designzeit. Der Compiler MIL?? kann schon vor dem Compilieren und somit auch schon vor dem konkreten Zugriff Fehler in der Abfrage festellen.

## Code First

Beim Code First Approach erstellt der Entwickler eine Klasse für die Modelle der Domäne die persistiert werden sollen. Um Beziehungen zwischen den Entitäten zu gestalten wird innerhalb der Klassen eine Property angelegt, dessen Typisierung des zu referenzierenden Modells entspricht.

EF bietet komplexe Möglichkeiten zur Erstellung von Beziehungen zwischen Entitäten. Alle Funktionen zu beleuchten würde den Umfang der Arbeit deutlich übersteigen. In dieser Arbeit werden die wichtigsten Funktionen vorgestellt, so das der Leser in der Lage ist schnell in das EF einzusteigen.

Beispiel einer 1:1 Beziehung:

```c#

class SchroedingersBox
{
    public int SchroedingersBoxId { get; set; }
    public Cat Cat { get; set; }
}

class Cat
{
    public int CatId { get; }
    public bool IsAlive { get; }

    public int SchroedingersBoxId { get; set; }
    public SchroedingersBox SchroedingersBox { get; set; }
}

```

In dem obigen Beispiel wurde eine Beziehung modeliert, die in der Datenbank in eine 1:1-Beziehung aufgelöst wird. Das Entity Framework wird Tabellen in der Datenbank nach folgendem Muster erstellen:

| SchroedingersBoxId |
| ---                |
| 1                  |

| CatId | IsAlive | SchroedingersBoxId |
| ---   | ---     | ---                |
| 1     | 1       | 1                  |

EF wird dabei eine Entität auswählen, von dessen Fremdschlüssel die andere Entität abhängig sein wird. Dieser Prozess kann durch die Fluent-API beeinflusst werden, die noch später beschrieben wird.

## Database First

## Fluent-API

---
[1] 