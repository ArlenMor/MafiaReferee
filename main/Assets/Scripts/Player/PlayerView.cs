
using System;
using Assets;
using Global;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public Text Number;
        public InputField Nickname;
        public Dropdown Role;
        public Toggle[] Fouls;
        public Text WinOrLose;
        public Dropdown ExPoints;
        
        public PlayerAsset PlayerData;

        //init playerData and turn off the toggle and ExPoints
        private void Start() 
        {
            PlayerData = ScriptableObject.CreateInstance<PlayerAsset>();
        }
        
        //when you've pressed on toggle
        public void OnFoul(Toggle toggle)
        {
            PlayerData.foul++;
            toggle.isOn = true;
            toggle.interactable = false;
        
            if (PlayerData.foul == 4)
            {
                LivePlayers.RemovePlayer(PlayerData.number);
            }
        }

        public void ShowInfoAboutPlayer()
        {
            Debug.Log("Number: " + PlayerData.number);
            Debug.Log("Nickname: " + PlayerData.nickname);
            Debug.Log("Role: " + PlayerData.playingRole);
        }
        
        //turn on or off toggle
        public void EnableToggle(bool flag)
        {
            for (var i = 0; i < 4; i++)
            {
                Fouls[i].interactable = flag;
            }
        }

        public void EnableExPoint(bool flag)
        {
            ExPoints.enabled = flag;
        }

        public void EnableNickname(bool flag)
        {
            Nickname.interactable = flag;
        }

        public void ReadOnlyNickname(bool flag)
        {
            Nickname.readOnly = flag;
        }

        public void EnableRole(bool flag)
        {
            Role.interactable = flag;
        }

    }
}