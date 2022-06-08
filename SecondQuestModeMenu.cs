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
    internal class SecondQuestModeMenu : ModeMenuConstructor
    {
        MenuPage SteelSoulSelector;
        private ToggleButton steelSoulToggle;

        public static void Register()
        {
            ModeMenu.AddMode(new SecondQuestModeMenu());
        }

        public override void OnEnterMainMenu(MenuPage modeMenu)
        {
            SteelSoulSelector = new MenuPage("The Glimmering Realm", modeMenu);

            steelSoulToggle = new ToggleButton(SteelSoulSelector, "Steel Soul Mode");

            var mainLabel = new MenuLabel(SteelSoulSelector, "The Glimmering Realm");

            var startButton = new BigButton(SteelSoulSelector, "Start", "");
            startButton.OnClick += StartGame;


            steelSoulToggle.SetNeighbor(Neighbor.Down, startButton);

            new VerticalItemPanel(SteelSoulSelector, new UnityEngine.Vector2(0, 300), 300, true, new IMenuElement[]
            {
                mainLabel,
                steelSoulToggle,
                startButton
            });

            startButton.MoveTo(new UnityEngine.Vector2(-100, -300));
        }

        public void StartGame()
        {
            HKSecondQuest.Instance.SetEnabled(true);
            UIManager.instance.StartNewGame(permaDeath: steelSoulToggle.Value);
        }

        public override void OnExitMainMenu()
        {
            SteelSoulSelector = null;
        }

        public override bool TryGetModeButton(MenuPage modeMenu, out BigButton button)
        {
            button = new BigButton(modeMenu,"The Glimmering Realm", "Explore a whole new world");
            button.AddHideAndShowEvent(modeMenu, SteelSoulSelector);
            return true;
        }
    }
}
