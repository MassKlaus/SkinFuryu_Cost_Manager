using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkinFuryu.CostManager.UIFront.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged([CallerMemberName]string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}
