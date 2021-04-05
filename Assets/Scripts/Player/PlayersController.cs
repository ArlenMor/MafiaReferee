using System;
using Global;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayersController : MonoBehaviour
    {
        public PlayerView[] playerViews;


        private void Update()
        {
            for (int i = 0; i < 10; i++)
            {
                if(LivePlayers.Alive[i] == false)
                    DeletePlayer(i);
            }
        }

        //сохранение ника, роли, включение фолов, проверка корректности
        //ролей, проверка на введенность всех никнеймов
        public void SaveInfoAndStart(Button button)
        {
            //Сохранение информации
            foreach (PlayerView player in playerViews)
            {
                player.PlayerData.nickname = player.Nickname.text;
                player.PlayerData.playingRole = player.Role.captionText.text;
                player.PlayerData.number = Convert.ToInt32(player.Number.text) - 1;
            }
            
            //проверка ников и ролей
            if (!Validate())
                return;

            //Отключение ника, роли, кнопки сохранения; включение фолов
            foreach (var player in playerViews)
            {
                player.ReadOnlyNickname(true);
                player.Role.captionText.text = "";
                player.EnableRole(false);
                
                player.EnableToggle(true);
                //player.ShowInfoAboutPlayer();

                button.interactable = false;
            }
        }

        //Проверяет верно ли введены роли
        private bool CheckRoles()
        {
            int m = 0;
            int d = 0;
            int c = 0;
            int sher = 0;
            foreach (PlayerView player in playerViews)
            {
                if (player.PlayerData.playingRole == "S")
                    sher++;
                if (player.PlayerData.playingRole == "D")
                    d++;
                if (player.PlayerData.playingRole == "M")
                    m++;
                if (player.PlayerData.playingRole == "C")
                    c++;
            }

            return m == 2 && d == 1 && sher == 1 && c == 6;
        }
        
        //Проверяет, все ли ники введены
        private bool CheckNickname()
        {
            foreach (PlayerView player in playerViews)
            {
                if (player.PlayerData.nickname.Length == 0)
                    return false;
            }
            return true;
        }
        
        //проверка на корректность входных данных
        private bool Validate()
        {
            return CheckNickname() && CheckRoles();
        }

        //выклчить фолы, доп балы, заполнить w/l нулями и сохранить нормер игроков 
        public void PrepareEverythingBeforeStart()
        {
            foreach (PlayerView player in playerViews)
            {
                player.EnableToggle(false);
                player.EnableExPoint(false);
                player.WinOrLose.text = "0";
            }
        }
        
        //функции для взаимодействия с игроком

        //выключить фолы, заблокировать ник
        private void DeletePlayer(int index)
        {
            playerViews[index].EnableNickname(false);
            playerViews[index].EnableToggle(false);
        }
    }
}