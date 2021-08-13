#language: pt-br

Funcionalidade: CadastroSite
Registrar um novo usuário em um site
Assim será possível autenticar no site e utilizar suas funcionalidades

![Site Compras](http://automationpractice.com/index.php?controller=authentication&back=my-account)

Link para a funcionalidade: [Cadastro](AutomaçãoCadastro/Features/Cadastro.feature)


@mytag

Esquema do Cenário: Cadastro de um novo usuario
	Dado que estou na pagina de Cadastro com um <email> valido
	Quando informar os dados do usuario
	E clicar no botao Registro
	Entao o usuario deve ser redirecionado para pagina My Account

Exemplos: 
| email                             |
| "teste.automacao000001@hotmail.com" |