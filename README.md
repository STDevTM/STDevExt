# STDevExt
Extensions from STDev. Target is .NET 4.6, UWP, Xamarin(Android, iOS, Forms) and .NET Standard 1.3.

![Version](https://img.shields.io/nuget/v/STDevExt.svg) ![Downloads](https://img.shields.io/nuget/dt/STDevExt.svg)

## Supported Platforms

STDevExt supports the following platforms
* .NET Framework 4.6+
* .NET Standard 1.3+ (including .NET Core, Xamarin and others)
* UWP

## Installation

STDevRxExt is available through [NuGet](http://nuget.org). To install
it, simply run the following command to your Package Manager Console:

```powershell
PM> Install-Package STDevExt
```

## Usage

Add following in top of your file:
```csharp
using STDevExt.Extensions;
```

## List of All Extensions

* [Collection Extensions](#collection-extensions)
* [Rx Extensions](#rx-extensions)
* _more coming soon_


## Collection Extensions

**Inserting**

Insert element to `IList` to provided index and return result:

```csharp
IList<string> list = new List<string>()
    .Inserting(0, "second")
    .Inserting(0, "first");

list.ToList().ForEach(element => Debug.WriteLine(element));
```

Output will be:

```text
first
second
```

---
**Adding**

Add element to end of `ICollection` and return result:

```csharp
ICollection<string> list = new List<string>()
    .Adding("first")
    .Adding("second");

list.ToList().ForEach(element => Debug.WriteLine(element));
```

Output will be:

```text
first
second
```

---
**WhereNotNull**

Filter `IEnumerable` and keep only not `null` elements:

```csharp
IEnumerable<string> list = new List<string>()
    .Adding("first")
    .Adding(null)
    .Adding("second")
    .WhereNotNull();

list.ToList().ForEach(element => Debug.WriteLine(element));
```

Output will be:

```text
first
second
```

## Rx Extensions

**WhereNotNull**

Filter `IObservable` and keep only not `null` elements:

```csharp
Subject<string> subject = new Subject<string>();

subject
    .WhereNotNull()
    .Subscribe(element => Debug.WriteLine(element));

subject.OnNext("first");
subject.OnNext(null);
subject.OnNext("second");
```

Output will be:

```text
first
second
```
> If you prefer only `null` elements you can use `WhereNull` method.

---
**WhereNotEmpty**

Filter `IObservable<string | ICollection>` and keep only not empty elements:

```csharp
Subject<string> subject = new Subject<string>();

subject
    .WhereNotEmpty()
    .Subscribe(element => Debug.WriteLine(element));

subject.OnNext("first");
subject.OnNext("");
subject.OnNext("second");
```

Output will be:

```text
first
second
```
> If you prefer only empty elements you can use `WhereEmpty` method.

---
**WhereTrue**

Filter `IObservable<bool>` and keep only `true` elements:

```csharp
Subject<bool> subject = new Subject<bool>();

subject
    .WhereTrue()
    .Subscribe(element => Debug.WriteLine(element));

subject.OnNext(true);
subject.OnNext(false);
subject.OnNext(true);
subject.OnNext(true);
subject.OnNext(false);
```

Output will be:

```text
True
True
True
```
> If you prefer only `false` elements you can use `WhereFalse` method.

---
**SelectTo**

Map `IObservable` all elements with provided value:

```csharp
Subject<bool> subject = new Subject<bool>();

subject
    .SelectTo("ping")
    .Subscribe(element => Debug.WriteLine(element));

subject.OnNext(true);
subject.OnNext(false);
subject.OnNext(true);
subject.OnNext(true);
subject.OnNext(false);
```

Output will be:

```text
ping
ping
ping
ping
ping
```

## Author

Tigran Hambardzumyan, tigran@stdevmail.com

## Support

Feel free to [open issuses](https://github.com/stdevteam/STDevExt/issues/new) with any suggestions, bug reports, feature requests, questions.

## Let us know!

We’d be really happy if you sent us links to your projects where you use our component. Just send an email to developer@stdevmail.com And do let us know if you have any questions or suggestion.

## License

STDevRxExt is available under the MIT license. See the [LICENSE](LICENSE) file for more info.
