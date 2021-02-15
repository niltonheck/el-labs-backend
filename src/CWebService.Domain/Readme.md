Camada de Domínio
===

Nesta camada estão os arquivo que dizem respeito a linguagem de domínio da aplicação. Isto é, suas definições de modelo e interfaces de repositório.

De maneira complementar, alguns ENUMs são definidos aqui também.

O objetivo desta camada é servir como base para toda a aplicação, de modo que ela depesempenhe um papel centralizador (também chamado de Core), deixando que as camadas externas trabalhem utilizando-a como "fonte de conhecimento" sobre o domínio.

**Importante**: neste caso tratei as entidades de banco de dados como modelos de domínio, mas isso não necessariamente precisa ser o caso. Tratei assim apenas para reduzir a complexidade da solução, uma vez que tenho copntrole total da base durante o desenvolvimento. Em solução legadas o cenário pode nào ser o mesmo e modelos específicos para a base (posteriormente transformados em modelos de domínio) poderiam ser necessários.