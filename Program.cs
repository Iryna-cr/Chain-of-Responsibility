using System;

class OrderHandler
{
    private OrderHandler next;

    public void SetNext(OrderHandler n) => next = n;

    public virtual void Handle(string request)
    {
        if (next != null) next.Handle(request);
    }
}

class PaymentHandler : OrderHandler
{
    public override void Handle(string request)
    {
        if (request == "оплата") Console.WriteLine("Оплата оброблена");
        else base.Handle(request);
    }
}

class DeliveryHandler : OrderHandler
{
    public override void Handle(string request)
    {
        if (request == "доставка") Console.WriteLine("Доставка оформлена");
        else base.Handle(request);
    }
}

class Program
{
    static void Main()
    {
        var payment = new PaymentHandler();
        var delivery = new DeliveryHandler();
        payment.SetNext(delivery);

        payment.Handle("доставка");
    }
}









