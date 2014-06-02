learning-ninject
================

Playing around with Ninject in various scenarios.

## The flow of dependencies

* `Core` depends on nothing.
* `Dependency projects` (SQL, PayPal, etc.) depend on `Core` (for interface/contract definitions).
* `DependencyResolution` depends on `Core` (for interfaces), `Dependency projects` (for implementation), and `Ninject` (to wire up IoC)
* `UI Projects` (Console, Web Forms, MVC, etc.) depend on `Core` (for interfaces) and `DependencyResolution` (to initialize IoC and retrieve instances of interfaces).


With this setup, `Core` is free of any dependencies, and the rest of your project is actually not even dependent on which IoC container you choose to use (the only thing that knows which IoC you're using is `DependencyResolution`). Your UI need only know about your `Core` and `DependencyResolution` projects, without any concern for concrete implementations.
