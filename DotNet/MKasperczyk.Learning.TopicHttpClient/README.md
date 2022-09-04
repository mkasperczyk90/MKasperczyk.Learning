## First Version
This is *BAD IDEA!* Problem is with IDisposable in HTTPClient. IDisposable should clean everything from the object but HTTPClient is an exception about which We should remember because sockets are not released immediately. 

This means that the program creates more sockets opened than We expected.

## Secound Version
This is the better one because there are no problems with too many sockets open. 

But now the case is when DNS changes the IP address of the server then We will have a connection problem.

We could use PooledConnectionLifetime option but it is not recomended one to use HTTPClient. 

## Third Version
The most recomended version

## Fourth Version
Similar like Third version but used HttpClientFactory.

## Fifth Version
Add polly to httpClient - Try 3 times if status code is other then success.

Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, Rate-limiting and Fallback in a fluent and thread-safe manner.