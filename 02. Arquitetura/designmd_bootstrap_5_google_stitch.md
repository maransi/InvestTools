# Sistema de Gestão de Investidores

## Framework Base

Este projeto deve ser desenvolvido utilizando:

- Bootstrap 5
- HTML5
- CSS3
- JavaScript ES6+
- JQuery
- JQuery DataTables
- JQuery Mask
- JQuery MaskMoney
- JQuery Validate
- Toastr

O layout deve ser totalmente responsivo e compatível com desktops, tablets e dispositivos móveis.

---

# Diretrizes Visuais

## Tema Visual

Utilizar um layout corporativo moderno.

### Paleta de cores

- Azul Primário: `#0d6efd`
- Cinza Escuro: `#343a40`
- Cinza Claro: `#f8f9fa`
- Verde Sucesso: `#198754`
- Vermelho Exclusão: `#dc3545`
- Branco: `#ffffff`

---

# Estrutura da Página

A tela deve possuir:

1. Caixa de filtros de pesquisa
2. Caixa de listagem de investidores
3. Modal de cadastro/edição
4. Layout responsivo

---

# Layout Principal

## Container Principal

- Utilizar `container-fluid`
- Centralizar conteúdo horizontalmente
- Manter margens esquerda e direita iguais
- Espaçamento superior de 24px

---

# Caixa de Filtros

## Estrutura

A caixa de filtros deve utilizar Bootstrap Card.

### Cabeçalho

- Fundo azul Bootstrap (`bg-primary`)
- Texto branco
- Título:

```text
Filtros de Pesquisa
```

### Corpo

Deve conter os seguintes campos:

| Campo | Tipo | Máscara |
|---|---|---|
| CPF do Investidor | Texto | 000.000.000-00 |
| Nome | Texto | Não |
| Usuário | Texto | Não |

---

## Botões

Os botões devem ficar:

- Dentro da caixa de filtros
- Na mesma linha horizontal dos campos
- Responsivos
- Com espaçamento uniforme

### Botão Pesquisar

- Cor: Primária
- Ícone de lupa
- Ao clicar:
  - Simular pesquisa
  - Preencher DataTable com dados fictícios
  - Exibir notificação Toastr

### Botão Novo

- Cor: Verde
- Ícone de adicionar
- Ao clicar:
  - Abrir modal vazio

### Botão Limpar

- Cor: Cinza
- Ícone de limpeza
- Ao clicar:
  - Limpar todos os campos do filtro

---

# Caixa de Listagem

## Estrutura

A listagem deve utilizar Bootstrap Card.

### Cabeçalho

- Fundo cinza escuro
- Texto branco
- Título:

```text
Lista de Investidores
```

---

# DataTable

Utilizar JQuery DataTable.

## Configurações

### Funcionalidades

- Responsivo
- Paginação habilitada
- Campo de busca interno desabilitado
- Tradução completa para português

### Colunas

| Coluna | Descrição |
|---|---|
| CPF | CPF do investidor |
| Nome | Nome completo |
| Usuário | Nome de usuário |
| Total das Carteiras | Valor monetário |
| Ações | Botões editar/excluir |

---

## Coluna Ações

### Botão Editar

- Ícone de lápis
- Cor amarela
- Abrir modal preenchido

### Botão Excluir

- Ícone de lixeira
- Cor vermelha
- Solicitar confirmação antes de excluir

---

# Modal de Cadastro

## Estrutura

Utilizar Bootstrap Modal.

### Campos

| Campo | Tipo | Obrigatório |
|---|---|---|
| CPF | Texto | Sim |
| Nome | Texto | Sim |
| Usuário | Texto | Sim |
| Total das Carteiras | Monetário | Sim |

---

## Máscaras

### CPF

Utilizar JQuery Mask:

```javascript
$("#cpf").mask("000.000.000-00");
```

### Valor Monetário

Utilizar JQuery MaskMoney:

```javascript
$("#total_carteiras").maskMoney({
  prefix: "",
  decimal: ",",
  thousands: "."
});
```

---

# Validação

Utilizar JQuery Validate.

## Regras

Todos os campos do modal devem ser obrigatórios.

Exibir mensagens de erro abaixo dos campos.

---

# Notificações

Utilizar Toastr.

## Eventos

### Pesquisa

```text
Dados carregados com sucesso
```

### Inclusão

```text
Investidor salvo com sucesso
```

### Exclusão

```text
Investidor excluído
```

---

# Responsividade

## Desktop

- Campos na horizontal
- Botões alinhados na mesma linha
- Tabela ocupando largura total

## Tablet

- Ajustar grid Bootstrap automaticamente
- Botões permanecem dentro da caixa

## Mobile

- Campos empilhados verticalmente
- Botões quebram linha automaticamente
- Modal ocupa quase toda largura

---

# Bibliotecas Obrigatórias

## CSS

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
<link rel="stylesheet" href="https://cdn.datatables.net/1.13.6/css/jquery.dataTables.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css">
```

---

## JavaScript

```html
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-maskmoney/3.0.2/jquery.maskMoney.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.5/jquery.validate.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
```

---

# Estrutura Esperada

## Fluxo Principal

1. Usuário preenche filtros
2. Usuário clica em pesquisar
3. Sistema exibe DataTable
4. Usuário pode:
   - Inserir
   - Editar
   - Excluir

---

# Objetivo do Design

Criar uma interface:

- Moderna
- Responsiva
- Corporativa
- Limpa
- Fácil de utilizar
- Compatível com Bootstrap 5
- Preparada para integração futura com APIs REST

