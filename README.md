# TesteTecnico_Vaivoa
Iniciei o desenvolvimento do projeto proposto como teste t�cnico, criando a pasta onde estar� todo o projeto da API em .NET, para isso inseri o comando dotnet new webapi -o newCardNumber no meu terminal:

![img.1](img/1.png)

Com a pasta �Template� j� criada, primeiramente fiz uma limpeza, tirei o conte�do desnecess�rio para o meu projeto, que nesse caso foram os controladores MVC padr�es e criei a pasta �Models�, onde vim a escrever as minhas entidades: Card.cs, Client.cs e NewCardNumber.cs

![img.2](img/2.png)

Em seguida, iniciei a implementa��o do Entity Framework Core, comecei estabelecendo que os banco de dados seriam armazenados em memoria:

![img.3](img/3.png)

Ent�o estabeleci os tipos e tamanhos para cada componente das minhas entidades Client e Card:

![img.4](img/4.png)

Agora com as minhas entidades devidamente criadas precisava s� criar um banco de dados para cada, primeiro criei a pasta Data em que criei o DataContext.cs, no meu DataContext.cs iniciei os banco de dados Clients e cards: 

![img.5](img/5.png)

Nesse momento, fui trabalhar com a l�gica da cria��o do numero para um novo cart�o, todo o processo ocorre na fun��o CreateCardNumber() da classe NewCardNumberClass, essa fun��o recebe como par�metro um char representando a bandeira do cart�o a ser gerado podendo ela ser Visa ou  Mastercard, esse � um par�metro do tipo char que pode receber �v� para Visa ou �m� para Mastercard, trabalhei na fun��o com um switch case, onde repito a l�gica da cria��o do cart�o dependendo sua bandeira. O numero de um cart�o � divido em 3 partes a primeira � o prefixo que identifica a bandeira do cart�o a seguir vem uma sequ�ncia de n�meros que representa o dono do cart�o, como um id para o mesmo, e por fim um caractere de seguran�a gerado com a utiliza��o do algoritmo de Luhn, o qual funciona da seguinte forma: voc� multiplica os elementos em posi��es pares por 2 e os soma de forma que, se isso resultar em algum n�mero com dois d�gitos, voc� soma os dois, ent�o soma o resultado aos elementos impares por fim � somar cada algarismo do seu atual resultado. Sendo assim, a fun��o definira o prefixo com o uso das constantes definidas por mim MastercardPrefix e VisaPrefix, ira gerar o id aleat�rio com a fun��o Random().Next()  e por fim aplicar� a logica do algoritmo de Luhn

![img.6](img/6.png)

Por fim, escrevi os controller NewCardNumberController.cs, onde estabeleci dois m�todos http sendo um Post para o registro de novos clientes com o seus emails e um Get para resgatar os cart�es criados de forma que pode ser visto o email do dono de cada cart�o e todos os cart�es j� gerados, o json do Post deve ser feito da forma apresentada a seguir:

![img.7](img/7.png)