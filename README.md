# Classes-Abstratas-Exercicios
Emmanuelly Madeira

## Diagramas Textuais

### Exercício 1 - Validador de Importação
ImportacaoBase (Abstract)
├── Executar(string): Relatorio (Template Method)
├── ValidarRegistro(Registro): List<string> (Abstract)
└── PosConsolidacao(Relatorio): void (Virtual - no-op)

ImportacaoAlunos (Sealed) : ImportacaoBase
├── ValidarRegistro(Registro): List<string> ✓
└── PosConsolidacao(Relatorio): void ✓ (chama base)

ImportacaoProdutos (Sealed) : ImportacaoBase
└── ValidarRegistro(Registro): List<string> ✓

text

### Exercício 2 - Processador de Pedidos
PedidoProcessor (Abstract)
├── Processar(Pedido): ResultadoProcessamento (Template Method)
├── CalcularFrete(Pedido): decimal (Abstract)
├── GerarConfirmacao(Resultado): string (Abstract)
└── AposReservaEstoque(Pedido): void (Virtual - no-op)

PedidoNacionalProcessor (Sealed) : PedidoProcessor
├── CalcularFrete(Pedido): decimal ✓
└── GerarConfirmacao(Resultado): string ✓

PedidoInternacionalProcessor (Sealed) : PedidoProcessor
├── CalcularFrete(Pedido): decimal ✓
├── GerarConfirmacao(Resultado): string ✓
└── AposReservaEstoque(Pedido): void ✓ (chama base)

text

### Exercício 3 - Pipeline de Pagamento
PaymentFlow (Abstract)
├── Processar(Pedido): ResultadoProcessamento (Template Method)
├── CalcularImpostos(Pedido): decimal (Abstract)
├── FormatarRecibo(Resultado): string (Abstract)
└── AntesDeRegistrar(Pedido, decimal, decimal): void (Virtual - no-op)

BrPaymentFlow (Sealed) : PaymentFlow
├── CalcularImpostos(Pedido): decimal ✓
└── FormatarRecibo(Resultado): string ✓

UsPaymentFlow (Sealed) : PaymentFlow
├── CalcularImpostos(Pedido): decimal ✓
├── FormatarRecibo(Resultado): string ✓
└── AntesDeRegistrar(Pedido, decimal, decimal): void ✓ (chama base)

text

### Exercício 4 - Sincronizador de Catálogo
SyncBase (Abstract)
├── Executar(Scope): SyncStatus (Template Method)
├── ColetarBruto(Scope): DataSet (Abstract)
├── GerarRelatorio(SyncStatus): string (Abstract)
└── PosAplicacao(SyncStatus): void (Virtual - no-op)

SyncErpFlow (Sealed) : SyncBase
├── ColetarBruto(Scope): DataSet ✓
└── GerarRelatorio(SyncStatus): string ✓

SyncMarketplaceFlow (Sealed) : SyncBase
├── ColetarBruto(Scope): DataSet ✓
├── GerarRelatorio(SyncStatus): string ✓
└── PosAplicacao(SyncStatus): void ✓ (chama base)

text

## Justificativas Abstract vs Virtual

**Métodos Abstract:** Utilizados para lógica obrigatória que cada subclasse deve implementar, como ValidarRegistro, CalcularFrete, CalcularImpostos, FormatarRecibo, ColetarBruto e GerarRelatorio. Não existe implementação padrão válida para todos os cenários.

**Métodos Virtual:** Utilizados para pontos de extensão opcionais como PosConsolidacao, AposReservaEstoque, AntesDeRegistrar e PosAplicacao. Oferecem flexibilidade com implementação padrão "no-op", permitindo que classes derivadas adicionem comportamento apenas quando necessário.

## Checklist de Verificação

- [x] **Template Method Correto**: Orquestradores públicos definem fluxo fixo em todos os exercícios
- [x] **Ganchos ≤ 3**: Cada classe base tem no máximo 3 ganchos (abstract + virtual)
- [x] **Ganchos Protected**: Todos os métodos de variação são protected
- [x] **Sem Novos Públicos**: Classes derivadas não expõem novos métodos públicos
- [x] **Override com base.X()**: Múltiplos exemplos de override chamando base (Exercícios 1, 2, 3, 4)
- [x] **Classes Sealed**: Todas as classes concretas são sealed onde apropriado
- [x] **Construtor Base**: Uso de : base(...) e guard-clauses nos construtores
- [x] **Sem Condicionais**: Nenhum if/switch por tipo nos orquestradores
- [x] **Diagramas Textuais**: Incluídos no README
- [x] **Justificativas**: Abstract vs Virtual explicadas

## Como Executar

Cada exercício pode ser testado individualmente criando instâncias das classes concretas e chamando os métodos orquestradores:

```csharp
// Exercício 1
var importador = new ImportacaoAlunos();
var relatorio = importador.Executar("alunos.csv");

// Exercício 2  
var processador = new PedidoInternacionalProcessor();
var resultado = processador.Processar(pedido);

// Exercício 3
var pagamento = new UsPaymentFlow();
var resultadoPagamento = pagamento.Processar(pedido);

// Exercício 4
var sync = new SyncMarketplaceFlow();
var status = sync.Executar(new Scope { Fonte = "Amazon" });
Testes Conceituais
Cenário com Dados Válidos: Verificar se o relatório final indica sucesso e contém métricas esperadas
Cenário com Dados Inválidos: Confirmar que erros são capturados e relatados adequadamente
Ordem do Fluxo: Validar através dos logs que a sequência do Template Method é preservada
Totais por Categoria: Verificar se métricas específicas são adicionadas no PosConsolidacao

text

Esta implementação completa atende a todos os requisitos do PDF:

1. **Template Method correto** em todos os 4 exercícios
2. **Máximo de 3 ganchos** por classe base
3. **Ganchos protected** e **classes sealed** onde apropriado
4. **Override com base.X()** demonstrando reuso consciente
5. **Construtores com guard-clauses** e uso de `: base(...)`
6. **README completo** com diagramas, justificativas e checklist
7. **Sem condicionais** baseadas em tipo nos orquestradores
8. **Sem novos métodos públicos** nas classes derivadas

A estrutura está pronta para ser compilada e testada conforme especificado no PDF.