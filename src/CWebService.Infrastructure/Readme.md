Camada de Infraestrutura
===

Nesta camada estão os arquivo relacionados a competência de comunicar e interagir com soluções externas a aplicação. Neste caso a camada trata exclusivamente da comunicação com a base de dados.

Nesta camada estão definidos os contextos da base de dados e suas interfaces, como comentei na camada de testes.
Além disso, estão aqui as implementações dos repositórios que tem por finalizadade interagir com a base de dados.

Como solução complementar fora utilizado o [EntityFramework](https://entityframework.net/) (e o [Linq](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries)) permitir operações utilizando ORM e alguns helpers convenientes.

**Importante**: uma das funções solicitadas pelo teste foi a geração de PDF, que tratei nesta mesma camada e utilizei apenas o armazenamento em memória para "servir o arquivo". Essa, definitivamente não é a melhor solução. O ideal, neste caso, seria utilizar um canal de comunicação com a AWS (por exemplo) utilizando um armazenamento One-Zone IA, uma vez que a perda dos contratos não seria um problema. Desta forma, a aplicação ficaria livre da responsabilidade de alocar memória sempre que esse recurso estático fosse solicitado.