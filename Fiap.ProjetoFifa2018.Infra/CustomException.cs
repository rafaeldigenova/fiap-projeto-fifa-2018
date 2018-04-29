using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.ProjetoFifa2018.Infra
{
    public abstract class CustomException : Exception
    {
        public CustomException()
            : base()
        {

        }

        public CustomException(string message)
            : base(message)
        {

        }

        public CustomException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
