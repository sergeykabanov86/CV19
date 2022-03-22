using CV19Wpf.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Wpf.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {

        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object,bool> CanExeceute = null)
        {
            _Execute = Execute ??  throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExeceute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => Execute(parameter);
    }
}
