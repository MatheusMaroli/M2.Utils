using System;
using System.Collections.Generic;
using System.Text;

namespace M2.Utils.Crud.Pipeline
{
    public interface IOperationHandler<TCommand, TResponse>  
        where TCommand : class
        where TResponse : class
    {
        TResponse ValidateCommand(TCommand command);
    }
}
