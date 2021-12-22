using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using ExercicioFixacaoComposicao.Entities.Enum;

namespace ExercicioFixacaoComposicao.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; private set; }
        public Client Client { get; set; }
        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();

        public Order()
        {        }

        public Order(DateTime date, string status, Client client)
        {
            Date = date;
            Client = client;
            SetStatus(status);
        }

        public void AddItem(OrderItem item)
        {
            Itens.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Itens.Remove(item);
        }

        public double Total()
        {
            double sum = 0.00;
            foreach(OrderItem item in Itens)
            {
                sum += item.SubTotal(); 
            }
            return sum;
        }

        public void SetStatus(string status)
        {
            if (status.Equals("pa"))
                Status = OrderStatus.PandingPayment;
            else if (status.Equals("pr"))
                Status = OrderStatus.Processing;
            else if (status.Equals("sh"))
                Status = OrderStatus.Shipperd;
            else
                Status = OrderStatus.Delivered;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Date);
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine(Client.ToString());
            sb.AppendLine("Order items:");
            foreach(OrderItem item in Itens)
            {
                sb.Append(item.Product.ToString());
                sb.AppendLine(", " + item);
            }
            sb.Append("Total price: " + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
