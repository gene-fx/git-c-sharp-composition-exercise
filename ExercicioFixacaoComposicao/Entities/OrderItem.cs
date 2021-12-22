using System.Globalization;
using System.Text;

namespace ExercicioFixacaoComposicao.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {        }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Price = product.Price;
            Product = product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Quantity);
            sb.Append(", ");
            sb.Append(SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
