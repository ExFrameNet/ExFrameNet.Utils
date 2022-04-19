# ExFrameNet.Utils

The ExFrameNet.Utils project adds some usefull extension methodes to c#.


## Implemented extension methodes 
- Task.Await
- INotifypropertyChanged.Subscribe


## PropertyContext

ExFrameNet.Utils provides a feature called PropertyContext. This feature provides an extension methode for all classes called `Property` it is used as an
propertyselector. The Context than you get back provides information for the property like it's name and it's value.

The Property context is used to provide easy extensibale functions to class properties such as transformations or action execution if the property has changed.

```cs
this.Property(x => x.numberAsString)
	.Changed()
	.Transform(x => int.Parse(x))
	.Subscribe(x => Console.WriteLine(x))
```