Funcionalidade: Fluxo de Login do Usuario

Cenario: Efetuar Login com Dados Inválidos
	Dado que o usuario digite o email teste@teste.com.br
	E a senha teste123
	Quando o usuario clicar no botão login com dados invalidos
	Então mostra uma mensagem de erro na tela

Cenario: Efetuar Login com Dados Válidos
	Dado que o usuario digite o email suporte@azurenapratica.com
	E a senha teste@123
	Quando o usuario clicar no botão login com dados validos
	Então redireciona o usuario para a página inicial
