using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace hdt_plugin_combo_counter
{
    public class PluginMain : IPlugin
    {
        private PluginView _view;

        public string Name => "Combo Counter";

        public string Description => "Keeps the count of cards played in a single turn";

        public string ButtonText => null;

        public string Author => "ollanket";

        public Version Version => new Version(1, 0, 0);

        public MenuItem MenuItem => null;

        public void OnButtonPress()
        {

        }

        public void OnLoad()
        {
            _view = new PluginView();
            Core.OverlayCanvas.Children.Add(_view);
            PluginService service = new PluginService(_view);
            Core.OverlayCanvas.SizeChanged += (e, s) => service.Rezize();
            GameEvents.OnGameStart.Add(service.GameStart);
            GameEvents.OnInMenu.Add(service.InMenu);
            GameEvents.OnTurnStart.Add(service.TurnStart);
            GameEvents.OnPlayerPlay.Add(service.PlayCard);
        }

        public void OnUnload()
        {
            Core.OverlayCanvas.Children.Remove(_view);
        }

        public void OnUpdate()
        {

        }
    }
}
