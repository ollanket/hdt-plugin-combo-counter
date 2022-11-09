using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;
using System.Windows.Controls;
namespace hdt_plugin_combo_counter
{
    internal class PluginService
    {
        private int _combo = 0;
        private readonly PluginView _view = null;

        public PluginService(PluginView view)
        {
            _view = view;
            if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
            {
                _view.Hide();
            }
        }

        internal void Rezize()
        {
            _view.UpdatePosition();
        }

        internal void GameStart()
        {
            _combo = 0;
            _view.SetCount(this._combo);
            _view.Show();
        }

        internal void InMenu() => _view.Hide();

        internal void TurnStart(ActivePlayer player)
        {
            if (player == ActivePlayer.Player)
            {
                _combo = 0;
                _view.SetCount(this._combo);
                _view.Show();
            }
        }

        internal void PlayCard(Card card)
        {
            _view.UpdatePosition();
            _combo++;
            _view.SetCount(this._combo);
        }
    }
}
