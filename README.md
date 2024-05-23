# 🛡️ Knights Challenge 🛡️

O Knights Challenge é um projeto completo, englobando o desenvolvimento de um sistema abrangente para cadastro e gerenciamento de heróis.

Inclui tanto o desenvolvimento do backend, responsável pela lógica de negócios e interação com o banco de dados, quanto o frontend, que proporciona a interface de usuário para interação com o sistema.

Este documento fornecerá uma visão geral do projeto, instruções detalhadas para instalação e execução, bem como uma descrição dos principais endpoints da API.

## 📚 Visão Geral

O Knights Challenge é uma aplicação desenvolvida com as seguintes tecnologias:

- **Back-end:** .NET 8.0 com MongoDB para a construção da API
- **Front-end:** Vue.js com Vuetify para a interface de usuário
- **Containerização:** Docker e Docker Compose para gerenciamento de serviços em containers

## 🎯 Funcionalidades

### Endpoints da API

- **[GET] /knights**: Exibe a lista com todos os knights.
- **[GET] /knights?filter=heroes**: Exibe uma lista contendo apenas os guerreiros que se tornaram heróis.
- **[POST] /knights**: Cria um knight.
- **[GET] /knights/:id**: Mostra informações de um knight específico.
- **[DELETE] /knights/:id**: Remove um guerreiro. Esse guerreiro deve entrar no Hall of Heroes.
- **[UPDATE] /knights/:id**: Permite alterar o apelido de um knight.

### Regras de Negócio

#### Lista de Knights

A lista de knights deve incluir os seguintes atributos:
- **Nome**: Nome do knight
- **Idade**: Anos corridos desde o nascimento
- **Armas**: Quantidade de armas
- **Atributo**: Atributo chave do knight
- **Ataque**: Poder de ataque
- **Exp**: Experiência

Exemplo:
| Nome     | Idade | Armas | Atributo | Ataque | Exp    |
|----------|-------|-------|----------|--------|--------|
| Laurenti | 29    | 2     | Strength | 22     | 25987  |

#### Estrutura do Knight

```json
{
  "name": "",
  "nickname": "",
  "birthday": "",
  "weapons": [
    {
      "name": "sword",
      "mod": 3,
      "attr": "strength",
      "equipped": true
    }
  ],
  "attributes": {
    "strength": 0,
    "dexterity": 0,
    "constitution": 0,
    "intelligence": 0,
    "wisdom": 0,
    "charisma": 0
  },
  "keyAttribute": "strength"
}
```

#### Cálculo de Ataque

O ataque de um knight é calculado da seguinte forma:
```
attack = 10 + mod(keyAttribute) + equippedWeapon.mod
```

Tabela de Modificadores:
| Valor | Mod |
|-------|-----|
| 0-8   | -2  |
| 9-10  | -1  |
| 11-12 | 0   |
| 13-15 | +1  |
| 16-18 | +2  |
| 19-20 | +3  |

#### Cálculo de Experiência

A experiência de combate é calculada da seguinte maneira:
```
exp = Math.floor((age - 7) * Math.pow(22, 1.45))
```
Um knight só começa seu treinamento a partir dos 7 anos de idade.

## 🚀 Instalação e Execução

### Pré-requisitos

- Docker
- Docker Compose

### Passos para Instalação

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/gabr1eeeel/KnightsChalllenge.git
   cd KnightsChalllenge
   ```

2. **Construa os Containers:**
   ```
   docker-compose up --build
   ```

## 📄 Licença

Este projeto está sob a licença MIT.

---

**[Voltar ao topo](#knights-challenge)**