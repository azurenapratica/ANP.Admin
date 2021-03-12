Funcionalidade: Fluxo de Login do Usuario
	Simple calculator for adding two numbers

Cenario: Efetuar Login com Dados Inválidos
	Dado que o usuario digite o email teste@teste.com.br
	E a senha teste123
	Quando o usuario clicar no botão login
	Então mostra uma mensagem de erro na tela

Cenario: Efetuar Login com Dados Válidos
	Dado que o usuario digite o email teste@teste.com.br
	E a senha teste123
	Quando o usuario clicar no botão login
	Então redireciona o usuario para a página inicial
