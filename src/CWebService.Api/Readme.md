Camada de Aplicação
===

Nesta camada estão os arquivos relacionados a camada de apresentação e é nesta que é feita a inicialização do framework. Consequentemente é aqui também que é iniciado o "Composition Root" que montará a árvore de dependências e instanciará tudo aquilo que será necessário ou durante a vida da aplicação (singleton) ou de acordo com as requisições recebidas(scoped).

Nesta camada deixei também o modelo (AuthenticateRequest) que trata exclusivamente da autenticação. Como este modelo não traz conhecimento em relaçào do domínio e também nào é utilizado por qualquer outra camada, achei por justo mantelo aqui (torcendo para nenhum guru discordar hehe).

Quanto as rotas da aplicação busquei utilizar o modelo mais **flat** possível, evitando aninhamentos mesmo quando estes pareciam evidentes. Optei por utilizar o conceito de "links" e permitir a navegação hierárquica, dando maior familiaridade ao funcionamento da API. A ideia, contudo, não é minha e teve como base o livro de [Best Practices da Apigee](https://pages.apigee.com/rs/351-WXY-166/images/Web-design-the-missing-link-ebook-2016-11.pdf).

Na definição dos controladores optei por utilizar o IActionResult, retornando códigos HTTPs específicos, para permitir respostas dinâmica. Contudo, uma falha que **não** tratei, cabível de julgamento, porém já previamente avisado, é o lançamento de erros genéricos, sem tratamento quanto a erros técnicos, funcionais, ou mesmo relacionados a alguma parte específica do fluxo da requisição. Mantive este ponto também visível na seção "know Issue" no começo do repositório.

De toda forma, o lançamento das exceções é tratado e um erro genério é apresentado, mesmo que, por exemplo seja um erro qualquer de "NotFound".
