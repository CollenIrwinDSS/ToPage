# ToPage
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/collenirwin/ToPage/.NET%20Core)

A tiny paging library for .NET.

This library contains extension methods for `IEnumerable<T>` and `IOrderedQueryable<T>` types that make it easy to fetch a page of data from them.

## Installation
Package | Description
--- | ---
[ToPage](https://www.nuget.org/packages/ToPage) | The base library
[ToPage.EFCore](https://www.nuget.org/packages/ToPage.EFCore) | Provides `async` overloads using EF Core's `ToListAsync` and `CountAsync` methods
[ToPage.EF6](https://www.nuget.org/packages/ToPage.EF6) | Provides `async` overloads using EF6's `ToListAsync` and `CountAsync` methods

## Examples
#### Basic `IEnumerable` example
```csharp
var numbers = Enumerable.Range(1, 10);
var page = numbers.ToPage(pageNumber: 1, itemsPerPage: 3);

Console.WriteLine(string.Join(", ", page.Items));
// Output:
// 1, 2, 3
```
In this example, a `Page<int>` object is returned from `ToPage`.
Its only properties are the requested `PageNumber` (1), and the `Items` on the page.

#### Basic `IEnumerable` example with counts
```csharp
var numbers = Enumerable.Range(1, 10);
var page = numbers.ToPageWithCounts(pageNumber: 1, itemsPerPage: 3);

Console.WriteLine($"Total items: {page.ItemCount}, total pages: {page.PageCount}");
Console.WriteLine(string.Join(", ", page.Items));
// Output:
// Total items: 10, total pages: 4
// 1, 2, 3
```
In this example, a `PageWithCounts<int>` object is returned from `ToPage`.
It has the same properties as a `Page<int>`,
as well as an `ItemCount` and a `PageCount` which are calculated based on the size of the collection and the number of items per page requested.

*Note:* Both `Page<int>` and `PageWithCounts<int>` implement `IPage` and `IPage<int>` interfaces.

#### Entity Framework async example
```csharp
// Get the 5th page of 20 users ordered alphabetically by Name
var page = await context.Users
    .OrderBy(user => user.Name)
    .ToPageAsync(pageNumber: 5, itemsPerPage: 20);
```
*Note:* This example uses either the `ToPage.EFCore` or `ToPage.EF6` library (both APIs are the same, choose the one for the EF version you're using).
