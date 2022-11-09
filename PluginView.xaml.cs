using Hearthstone_Deck_Tracker.API;
using System.Windows;
using System.Windows.Controls;

namespace hdt_plugin_combo_counter
{
    /// <summary>
    /// Interaction logic for PluginView.xaml
    /// </summary>
    public partial class PluginView : UserControl
    {
        public PluginView()
        {
            InitializeComponent();
            UpdatePosition();
        }

        public void SetCount(int count)
        {
            this.ComboBlock.Text = count.ToString();
        }

        public void UpdatePosition()
        {
            Canvas.SetBottom(this, Core.OverlayWindow.Height * 32 / 100);
            Canvas.SetRight(this, Core.OverlayWindow.Width * 28.5 / 100);
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
