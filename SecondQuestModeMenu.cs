using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuChanger;
using MenuChanger.Extensions;
using MenuChanger.MenuElements;
using MenuChanger.MenuPanels;

namespace HKSecondQuest
{
    /// <summary>
    /// Handles the "Glimmering Realm" game mode menu
    /// </summary>
    internal class SecondQuestModeMenu : ModeMenuConstructor
    {
        MenuPage SteelSoulSelector;
        private ToggleButton steelSoulToggle;

        /// <summary>
        /// Registers the menu with the ModeMenu
        /// </summary>
        public static void Register()
        {
            ModeMenu.AddMode(new SecondQuestModeMenu());
        }

        /// <summary>
        /// Set up the menu page
        /// </summary>
        public override void OnEnterMainMenu(MenuPage modeMenu)
        {
            SteelSoulSelector = new MenuPage("The Glimmering Realm", modeMenu);

            steelSoulToggle = new ToggleButton(SteelSoulSelector, "Steel Soul Mode");

            var mainLabel = new MenuLabel(SteelSoulSelector, "The Glimmering Realm");

            var mapWarningLabel = new MenuLabel(SteelSoulSelector, "No map included - make one yourself or venture forth at your own risk", MenuLabel.Style.Body);

            var startButton = new BigButton(SteelSoulSelector, "Start", "");
            startButton.OnClick += StartGame;


            steelSoulToggle.SetNeighbor(Neighbor.Down, startButton);

            new VerticalItemPanel(SteelSoulSelector, new UnityEngine.Vector2(0, 300), 300, false, new IMenuElement[]
            {
                mainLabel,
                steelSoulToggle,
                mapWarningLabel,
                startButton
            });

            mapWarningLabel.MoveTo(new UnityEngine.Vector2(250, -200));
            startButton.MoveTo(new UnityEngine.Vector2(-100, -300));
        }

        /// <summary>
        /// Enable the mod, and start a new game
        /// </summary>
        public void StartGame()
        {
            HKSecondQuest.Instance.SetEnabled(true);
            UIManager.instance.StartNewGame(permaDeath: steelSoulToggle.Value);
        }

        /// <summary>
        /// Clear the menu instance if the menu is left
        /// </summary>
        public override void OnExitMainMenu()
        {
            SteelSoulSelector = null;
        }

        /// <summary>
        /// Initialize the "Glimmering Realm" game mode button
        /// </summary>
        public override bool TryGetModeButton(MenuPage modeMenu, out BigButton button)
        {
            button = new BigButton(modeMenu,"The Glimmering Realm", "Explore a whole new world");
            button.AddHideAndShowEvent(modeMenu, SteelSoulSelector);
            return true;
        }
    }
}
