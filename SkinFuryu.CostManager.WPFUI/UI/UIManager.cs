using SkinFuryu.CostManager.UIFront.UI;
using SkinFuryu.CostManager.UIFront.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkinFuryu.CostManager.WPFUI.UI
{
    public class UIManager : IUIManager
    {
        public async Task ShowMessage(MessageBoxViewModel message)
        {
            await Task.Run(() => MessageBox.Show(message.Message, message.Title));
        }
    }
}
