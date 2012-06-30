`DapperWrapper` is a library that wraps the [Dapper]() extension methods on `IDbConnection` to make unit testing easier.

Why bother? Because stubbing the extension methods used in a method-under-unit-test is a pain in the ass. For instance, you can't just use a library like [Moq]() to stub the `.Query` extension method on a fake `IDbConnection`. To work around this, I introduce a new abstraction, `IDbExecutor`.

## The `IDbExecutor` Interface

The IDbExectuor interface has four methods, each corresponding to one of the four Dapper extension methods: `Execute`, `Query`, `Query<T>`, and `QueryMultiple`. Wherever you would previously inject an IDbConnection to use with Dapper, you instead inject an `IDbExecutor`. There is a single concrete implementation of `IDbExecutor` included in `DapperWrapper`, `SqlExecutor`, that uses the `Dapper` extension methods against `SqlConnection`. Adding your own `IDbExecutor` against other concrete implementations of `IDbConnection` is easy.

Example use of `IDbExecutor`:

```
public IEnumerable<string> ReadAllAdministratorAliases(IDbExecutor dbExecutor) {
  return dbExecutor.Query<Member>("SELECT m.alias FROM members m WHERE m.is_admin = 1");
}
``` 

## Injecting `IDbExecutor`

You probably already have an apporach to injecting `IDbConnection` into your app that you're happy with. That same approach will probably work just as well with `IDbExecutor`. 

Personally, in my dependency container or service locator, I like to bind `IDbExecutor` to a method that instantiates a new `SqlConnection` and `SqlExecutor`. If you need to control the creation of the executor (for instance, you only need it conditionally), you could bind `Func<IDbExecutor>`. There's also an `IDbExecutorFactory` interface in `DapperWrapper` you could use, but it comes with the same downsides as any factory type.

Example of binding `IDbExecutor` and `IDbExecutorFactory` using Ninject:

```
public class DependenciesRegistrar : NinjectModule {
  public override void Load() {
    Bind<IDbExecutor>()
      .ToMethod(context => {
	    var sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		return new SqlExecutor(sqlConnection);
      });
	Bind<IDbExecutorFactory>()
      .ToMethod(context => {
	    return new SqlExecutorFactory(connectionString);
      })
	  .InSingletonScope();
  }
}
```

## Transactions

I sometimes need to assert whether a method-under-unit-test completes a transaction via `TransactionScope`. To make this easier, `DapperWrapper` also has an `ITransactionScope` interface (and `TransactionScopeWrapper` implementation) that makes it easy to create a fake transaction, and stub (and assert on) the `Complete` method. As with `IDbExecutor`, you can bind it directly, via `Func<ITransactionScope>`.