Camada de Aplicação
===

Nesta camada ficam os arquivos referentes as regras de negócio do domínio. Aqui estão os arquivos que tratam, principalmente (mas não somente) das interfaces e implementações dos serviços.

Os serviços são responsáveis por permitir a comunicação com a camada de infraestrutura e serve como fonte de dados para a camada de apresentação.

Nesta camada também estão os modelos de domínio, que compreendem parte fundamental da arquitetura, expondos objetos ricos (nem todos, contudo).
Justo dos modelos também estão os validadores, implementados utilizando [Fluent Validation](https://fluentvalidation.net/) com objetivo de evitar validações manuais com "!= null", ou testes de propriedades específicas.

Para geração e validação das senhas os usuário optei por utilizar um helper que adiciona algumas camadas extras de proteção quando comparada a implemntações do framework, adicionando um salt e permitindo mais iterações. Neste ponto a geração do próprio Identity poderia ser suficiente. Optei pela geração "manual", contudo.

Por fim, também estão aqui os *Profiles* utilizados pelo [AutoMapper](https://automapper.org/) para fazer a conversão de tipos de objeto (entro domínio e infraestrutura, por exemplo). Optei pelo AutoMapper pela popularidade e facilidade no uso - definitivamente realizar as conversdões manualmente seria poquíssimo eficiente.

