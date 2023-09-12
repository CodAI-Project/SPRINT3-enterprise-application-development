# SPRINT3-enterprise-application-development

# Integrantes do grupo:

- 94898-Luan Santos dos Reis
- 94067-Gustavo de Souza Fonseca
- 94282-Dennys Alvarenga do Nascimento
- 94276-Henrique Cesar de Souza

### Projeto que contém a API de um serviço de automatização de templates. 

# Sumário
- [Objetivo do projeto](#objetivo-do-projeto)

- [Swagger](#swagger)
  
- [Arquitetura](#arquitetura)

- [Figma](#figma)

- [Inicialização](#inicialização)
  
- [Protótipo](#protótipo)
  
- [Funcionalidades](#funcionalidades)


# Objetivo do projeto:
O CodAI Backend é a espinha dorsal da plataforma CodAI, responsável por gerenciar, armazenar e fornecer acesso aos dados essenciais para a funcionalidade da aplicação. Este componente é vital para o funcionamento do sistema, possibilitando a criação, leitura, atualização e exclusão de informações relacionadas ao desenvolvimento de código.

# Swagger
 Link do Swagger [aqui](https://app.swaggerhub.com/apis-docs/LUANSSRR/CodAI/1.0.0-oas3).
 
# Arquitetura
![Desenho da arquitetura](https://firebasestorage.googleapis.com/v0/b/codai-development.appspot.com/o/codai-arquitetura-CodAI.drawio.png?alt=media&token=8098019e-2bd0-4f2e-b604-ba9338a22e91)

# Figma: 
### Representação visual do projeto com a parte da UX e interação do usuário.
- [clique para visualizar](https://www.figma.com/file/7hc3JzFMJWcso1QT2zNAfJ/CodAI?type=design&node-id=0%3A1&mode=design&t=76rIXyljoFxOdjHN-1)  

# Inicialização:
## Como Inicializar Localmente
Para executar o CodAI Back-end localmente, siga estas etapas:

**Observações:** 
Como o projeto usa Firebase, você deve estar logado no firebase na sua maquina pra conseguir usar o projeto. ele será instanciado na sua maquina com as suas credenciais.
  

1. Clone o repositório:
   ```
   git clone https://github.com/CodAI-Project/SPRINT3-enterprise-application-development.git
    ```
2. 
    ```
    
    ```

# Protótipo: 
### Neste link está o Prótotipo do projeto.
- [clique aqui]( https://codai-hub-development.web.app/ )

# Funcionalidades
### As principais funcionalidades do sistema são criar usuário com seus respectivos chats gerados,cada chat tem uma interação com o ChatGPT que pega o Array das ultimas 6 mensagens enviadas para conseguir trabalhar em cima do contexto e enviar a resposta mais assertiva ao usuário. Assim gerando uma interação fluída, flexivel, dinâmica e objetiva de criação de um template.

## Principais Recursos do CodAI Backend

O CodAI Backend oferece uma série de recursos essenciais que impulsionam a funcionalidade da plataforma:

1. **API RESTful:** Fornece uma API RESTful que segue as melhores práticas de design de API para interações eficazes entre o frontend e o backend.

2. **Banco de Dados Firebase:** Utiliza o Firestore como banco de dados para armazenar e recuperar dados de forma eficiente e escalável.

3. **CRUD de Chats (Projetos):** Oferece operações CRUD (Create, Read, Update e Delete) para projetos de desenvolvimento, permitindo que os usuários gerenciem seus projetos.
