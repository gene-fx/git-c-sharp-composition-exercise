using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioFixacaoComposicao.Entities.Enum
{
    enum OrderStatus : int
    {
        PandingPayment = 0,
        Processing = 1,
        Shipperd = 2,
        Delivered = 3
    }
}
