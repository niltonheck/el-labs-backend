Teste EL - Backend
===

Esta solução está organizada em 5 camadas, seguindo o mais próximo póssivel o DDD e demais Design Patterns.
**Cada camada possui seu próprio arquivo de readme e possui uma breve explicação do conteúdo, além de serem pontuadas algumas decisões de design.**

<br />

Estrutura
---


- [CWebService.**Api**](https://github.com/niltonheck/el-labs-backend/tree/master/src/CWebService.Api): Camada de Apresentação.
- [CWebService.**Application**](https://github.com/niltonheck/el-labs-backend/tree/master/src/CWebService.Application): Camada de Negócio 
- [CWebService.**CrossCutting**](https://github.com/niltonheck/el-labs-backend/tree/master/src/CWebService.CrossCutting): Camada de IoC
- [CWebService.**Infrastructure**](https://github.com/niltonheck/el-labs-backend/tree/master/src/CWebService.Infrastructure): Camada de Dados
- [CWebService.**Domain**](https://github.com/niltonheck/el-labs-backend/tree/master/src/CWebService.Domain): Camada de Domínio
- [CWebService.**Tests**](https://github.com/niltonheck/el-labs-backend/tree/master/src/CWebService.Tests): Testes

<br />

Overview
---

- O projeto foi desenvolvido em .NET Core (.NET 5) tendo como base o modelo de webapi.
- Os endpoint protegidos o fazem através do uso de token JWT, exposto através da rota v1/account/login.
- O controle de dependências é feito utilizando SimpleInjector e dada escolha deu-se exclusivamente pela familiaridade com a biblioteca.
- A camada de dados tem como principal ferramenta o Entity Framework, suplantada pelo uso de Linq para dar mais clareza ao código.
- Fora utilizado SQLite como banco de dados de desenvolvimento exclusivamente pela praticidade.
- Para os testes unitários foi utlizado XUnit com mocks criados utilizando a biblioteca Moq.
- As definições quanto a quebra das camadas tem como objetivo uma maior adesão aos princípios do SOLID.

<br />

Know Issues
---

Alguns pontos de falha importantes em relação a aplicação que acho justo dar visibilidade (e noção do impacto):

- Os controladores não estão no escopo de teste;
- Não há rota de listagem de todas reservas "GET /bookings";
- Lançamento de exceções genéricas para falhas conhecidas (não validação, por exemplo); Embora em grande parte haja tratamento para estes erros.
- Não há implementação, na solução, para extração de code coverage dos testes unitários;
- Algumas rotas poderiam ter seus objetos de "request" melhor trabalhados, para evitar envio de propriedades indesejadas; Isto é feito exclusivamente em uma ou outra rota.

<br />

Referências
---

Muitas das decisões de organização e/ou implementação desse projeto tiveram como base conceitos e ideias fundamentadas (em partes ou totalmente) em alguams obras. Principalmente:

- [Dependency Injection Principles, Practices, and Patterns](https://www.amazon.com.br/Dependency-Injection-NET-Second-Seemann/dp/161729473X) (Steven van Deursen and Mark Seemann)
- [Domain-Driven Design](https://www.amazon.com.br/Domain-Driven-Design-Eric-Evans/dp/8550800651/ref=asc_df_8550800651/?tag=googleshopp00-20&linkCode=df0&hvadid=379739109739&hvpos=&hvnetw=g&hvrand=15817736385912429545&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=1001625&hvtargid=pla-809277038576&psc=1) (Eric Evans)
- [Clean Code](https://www.amazon.com.br/C%C3%B3digo-limpo-Robert-C-Martin/dp/8576082675/ref=asc_df_8576082675/?tag=googleshopp00-20&linkCode=df0&hvadid=379792215563&hvpos=&hvnetw=g&hvrand=2683233254377265655&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=1001625&hvtargid=pla-398225630878&psc=1) (Robert Cecil Martin)
- [Web API Design: The Missing Link - Best Practices for Crafting Interfaces that Developers Love](https://pages.apigee.com/rs/351-WXY-166/images/Web-design-the-missing-link-ebook-2016-11.pdf) (Whitepaper Apigee).
