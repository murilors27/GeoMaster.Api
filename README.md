# 🌐 GeoMaster API
API RESTful desenvolvida em **.NET 8** para cálculos geométricos 2D e 3D, com arquitetura extensível (SOLID) e documentação via Swagger.

---

## 🚀 Tecnologias
- .NET 8 (ASP.NET Core Web API)
- Swagger / Swashbuckle
- Injeção de Dependência (DI)
- Reflection + Attributes para extensibilidade

---

## 📦 Estrutura do Projeto
GeoMaster.Api/
Controllers/
Domain/
Interfaces/
Shapes/
Dtos/
Services/
Program.cs

- **Domain** → Interfaces + formas geométricas.  
- **Services** → Calculadora central e fábrica de formas.  
- **Controllers** → Endpoints REST.  
- **Dtos** → Objetos de transporte para requests/responses.  

---

## 📂 Endpoints Disponíveis

### 🔹 Cálculos 2D
- **Área**: `POST /api/v1/calculos/area`
- **Perímetro**: `POST /api/v1/calculos/perimetro`

### 🔹 Cálculos 3D
- **Volume**: `POST /api/v1/calculos/volume`
- **Área Superficial**: `POST /api/v1/calculos/area-superficial`

### 🔹 Validações
- **Forma contida**: `POST /api/v1/validacoes/forma-contida`

---

## 📝 Exemplos de Requisição

### Área de um círculo
{
  "tipoForma": "circulo",
  "propriedades": { "raio": 10 }
}
#### ➡️ Resposta:
314.1592653589793

### Perímetro de um retângulo
{
  "tipoForma": "retangulo",
  "propriedades": { "largura": 5, "altura": 8 }
}
#### ➡️ Resposta:
26

### Volume de uma esfera
{
  "tipoForma": "esfera",
  "propriedades": { "raio": 3 }
}
#### ➡️ Resposta:
113.09733552923255

### Validação de forma contida
{
  "formaExterna": { "tipoForma": "retangulo", "propriedades": { "largura": 10, "altura": 10 } },
  "formaInterna": { "tipoForma": "circulo", "propriedades": { "raio": 5 } }
}
#### ➡️ Resposta:
true

---

## 🛠️ Como Executar o Projeto
### 1. Clonar o repositório
#### Abra o terminal e rode:
git clone https://github.com/murilors27/GeoMaster.Api.git
cd GeoMaster.Api

### 2. Restaurar dependências
dotnet restore

### 3. Rodar a API
dotnet run

### A API estará disponível em:
https://localhost:5001/swagger

---

## 🔮 Extensibilidade
Adicionar uma nova forma geométrica é simples:
- Criar uma classe em Domain/Shapes.
- Decorar com [Shape("nome-da-forma")].
- Implementar a interface correta (ICalculos2D ou ICalculos3D).

---

Pronto! Sem modificar serviços ou controllers.

## 👨‍💻 Autor
Desenvolvido por Murilo Ribeiro Santos
