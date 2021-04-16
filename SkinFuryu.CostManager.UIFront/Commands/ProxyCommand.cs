using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkinFuryu.CostManager.UIFront.Commands
{
    public class ProxyCommand : ICommand
    {
        private readonly Action command;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public ProxyCommand(Action command)
        {
            this.command = command;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            command();
        }
    }
}
