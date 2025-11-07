public abstract class PedidoProcessor
{
    public ResultadoProcessamento Processar(Pedido pedido)
    {
        ValidarItens(pedido);
        ReservarEstoque(pedido);
        var frete = CalcularFrete(pedido);
        var total = CalcularTotal(pedido, frete);
        PersistirPedido(pedido);
        AposReservaEstoque(pedido);
        var confirmacao = GerarConfirmacao(pedido);
        
        return new ResultadoProcessamento(confirmacao);
    }
    
    protected abstract decimal CalcularFrete(Pedido pedido);
    protected abstract string GerarConfirmacao(Pedido pedido);
    protected virtual void AposReservaEstoque(Pedido pedido) { }
} 