using System;
using System.Runtime.Serialization;

namespace CalculoInvestimento.Domain
{
    /// <summary>
    /// Claase de dominio para gerenciar as exceções lançadas
    /// </summary>
    [Serializable]
    public class Exception : System.Exception
    {
        public Exception(string msg) : base(msg) { }

        protected Exception(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
