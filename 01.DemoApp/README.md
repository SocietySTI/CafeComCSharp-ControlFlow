#Aplicação demo
Aplicação para exemplificar conceitos como: Separação de responsabilidades, desenvolvimento em camdas, injeção de dependencia.
foco deste demo será construir algumas funcionalidades para exercicitar alguns conceitos e posteriormente aplicar padrões de projeto para melhorar a leitura do código e complexidade.

##Funcionalidades implementadas
Neste momento está implementado, as seguintes funcionalidades neste demo:
1. Registro de usuários
2. Login de usuários
3. Depósito na conta de um usuário        

##Funcionalidades para implementar
Deverá ser implementado, em demais lições:
1. Saque de valor da conta do usuário
2. Compra de produtos através de débito na conta do usuário
3. Logout

##Detalhes da demo
Será detalhado, algumas caracteristicas mais importantes da solução, como:
. Sepração de camadas
. Padrão de trabalho utilizando **Comandos** para separação de responsabilidades
. Dependencia entre camadas

###Separação de camadas	
Esta demo está construída, utilizando apenas um projeto ```Console Application```. Contudo, dentro do projeto existem ***folders*** que representam algumas camadas (***layers***) da aplicação, que são:

1.```00_Apresentacao```: Camada para representar recursos de interface e onde o usuário realizará a interação com o software.
2.```01_Aplicacao```: Camada que orquestra ações que são solicitadas pela ```00_Apresentacao```. Não deve conter conhecimento de regras de negócio, apenas deve saber quais objetos chamar, quando e em que ordem.
3.```02_Dominio```: Camada onde reside as regras de negócio e objetos de negócio. Contudo, esta camada não sabe *como* fazer persistir ou recuperar dados.
4.```03_Infraestrutura```: Camada que implementa o *como* serão persistido e recuperado os dados e outros de detalhes de baixo nível.
		
É importante observar que, as camadas superiores não podem estar fortemente acopladas com as inferiroes. Ou seja, camadas superiores, devem depender apenas de uma *abstração* e jamais depender de uma *implementação* específica.
###Comandos	
A camada ```00_Apresentacao``` define diversos *comandos*, os quais representam ações que o usuário pode fazer no sistema. Por exemplo, o usuário pode se cadastrar no sistema, tal funcionalidade é controlada por um comando específico, que poderia ser ***RealizarCadastro***.
Cada comando é uma classe, que implementa o código necessário para realizar determinada tarefa. E para abstrair o que qualquer comando deveria fazer, todos comandos devem implementar a interface ```[IComando](\00_Apresentacao\Interfaces\IComando.cs)```. Tal interface, define apenas um método ```Executar()```.
Com isso, a interface pode simplesmente trabalhar com a abstração dos comandos, chamando apenas o método ```Executar()``` sem se preocupar com os detalhes da implementação do comando.
A forma que os comandos são utilizados pela aplicação é através da classe
	