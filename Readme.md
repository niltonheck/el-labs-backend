Teste EL - Backend
===

Esta solução está organizada em 6 camadas de "aplicação" + 1 de "teste".
Cada camada possui seu próprio arquivo de readme e possui uma breve explicação do conteúdo, além de serem pontuadas algumas decisões de design.

<br />

Estrutura
---

- [CWebService.**Api**](http://): Camada de Apresentação.
- [CWebService.**Applicação**](http://): Camada de Negócio 
- [CWebService.**CrossCutting**](http://): Camada de IoC
- [CWebService.**Data**](http://): Camada de Dados
- [CWebService.**Domain**](http://): Camada de Domínio
- [CWebService.**Infraestructure**](http://): Camada de Infraestrutura

<br />

Overview
---

O projeto foi desenvolvido em .NET Core (.NET 5) tendo como base o modelo de webapi.

Os endpoint protegidos o fazem através do uso de token JWT, exposto através da rota v1/account/login.

O controle de dependências é feito utilizando SimpleInjector e dada escolha deu-se exclusivamente pela familiaridade com a biblioteca.

A camada de dados tem como principal ferramenta o Entity Framework, suplantada pelo uso de Linq para dar mais clareza ao código.

Fora utilizado SQLite como banco de dados de desenvolvimento exclusivamente pela praticidade.

Para os testes unitários foi utlizado XUnit com mocks criados utilizando a biblioteca Moq.

As definições quanto a quebra das camadas tem como objetivo uma maior adesão aos princípios do SOLID.

Embora talvez não evidentes os DTOs estão localizados na pasta "Models" do pacote Application.

<br />

Referências:
---

Muitas das decisões de organização e/ou implementação desse projeto tiveram como base conceitos e ideias fundamentadas (em partes ou totalmente) em alguams obras. Principalmente:

- Dependency Injection Principles, Practices, and Patterns (Steven van Deursen and Mark Seemann)
- Domain-Driven Design (Eric Evans)
- Clean Code (Robert Cecil Martin)
- Web API Design: The Missing Link - Best Practices for Crafting Interfaces that Developers Love (Whitepaper Apigee).