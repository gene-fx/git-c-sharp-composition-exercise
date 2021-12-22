using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioFixacaoComposicao.Entities
{
    class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }

        public Client()
        {        }

        public Client(string name, string email, DateTime date)
        {
            Name = name;
            Email = email;
            Date = date;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Client ");
            sb.Append(Name);
            sb.Append(" (" + Date.ToString("dd/MM/yyyy") + ") - ");
            sb.Append(Email);
            return sb.ToString();
        }
    }
}
