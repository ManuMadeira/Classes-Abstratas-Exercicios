public abstract class PaymentFlow
{
    public ResultadoPagamento Processar(Pedido pedido)
    {
        ValidarPedido(pedido);
        var subtotal = CalcularSubtotal(pedido);
        var impostos = CalcularImpostos(pedido);
        AplicarDescontos(pedido);
        AntesDeRegistrar(pedido, subtotal, impostos);
        RegistrarPagamento(pedido);
        AposRegistrar(pedido);
        var recibo = FormatarRecibo(pedido);

        return new ResultadoPagamento(recibo);
    }

    protected abstract decimal CalcularImpostos(Pedido pedido);
    protected abstract string FormatarRecibo(Pedido pedido);
    protected virtual void AntesDeRegistrar(Pedido pedido, decimal subtotal, decimal impostos) { }
    protected virtual void AposRegistrar(Pedido pedido) { }
}
