Camada de Testes
===

Nesta camada estão os arquivos refentes aos testes unitários.
Para realização destes testes foram utilizadas as bibliotecas XUnit (test runner) e Moq (Mock).

**Importante**: para realização dos mocks dos repositórios foram utilizados mocks dos contextos da base de dados (DBContext) também por isso cada repositório (de cada modelo do domínio) possui sua própria implementação.

Não necessariamente esta é a melhor solução, já que, neste caso, todos os dados derivam de uma mesmo local. Contudo, para estes testes optei por **nào** utilizar a base de dados, mesmo que in-memory, uma vez que estava mais interessado no teste lógico do que na integração com uma base.

Além disso, os controladores **não** estão no escopo dos testes. A razão é exclusivamente a priorização de outras frentes haja vista o curto espaço de tempo para desenvolvimento. De toda forma, a implementação dos testes dos controladores, em momento posterior, nào representaria passivo consideravelmente grande. 

<br />
Para executar os testes:
<br /><br />

```dotnet test```