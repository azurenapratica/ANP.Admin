Funcionalidade: LoginUsuario
	Simple calculator for adding two numbers

Cenario: Efetuar Login com Dados Inválidos
	Dado que o usuario digite o email teste@teste.com.br
	E a senha teste123
	Quando o usuario clicar no botão login
	Então informará que o usuario e senha estão inválidos

Cenario: Efetuar Login com Dados Válidos
	Dado que o usuario digite o email teste@teste.com.br
	E a senha teste123
	Quando o usuario clicar no botão login
	Então informará que o usuario e senha estão inválidos
