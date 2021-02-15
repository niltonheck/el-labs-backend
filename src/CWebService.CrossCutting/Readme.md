Camada de "Cross Cutting"
===

Nesta camada estão os arquivos refentes a implementações que trasncendem uma única camada.
Trata-se nessa camada especialmente do Container DI ([Simple Injector](https://simpleinjector.org/)).

A escolha do [Simple Injector](https://simpleinjector.org/) como controlador de dependência deu-se exclusivamente pela minha familiaridade com o modo de funcionamento e aderência ao framework MVC compouquíssimo esforço.
O arquivo de configuração (Compose.cs) é utilizado na Api, durante o bootstrap do MVC, portanto, no Entry Point, como esperado.