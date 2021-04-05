using Player;
using UnityEngine;
using UnityEngine.UI;
using Vote;

namespace Global
{
    public class GlobalController : MonoBehaviour
    {
        //Контроллер всех игроков
        [SerializeField]
        private PlayersController m_PlayersController;
        
        //Контроллер голосования
        [SerializeField]
        private VoteController m_VoteController;
        
        
        
        private void Start()
        {
            LivePlayers.Init();
            m_PlayersController.PrepareEverythingBeforeStart();
        }

        public void StartGame(Button button)
        {
            m_PlayersController.SaveInfoAndStart(button);
        }

        public void AcceptCandidate()
        {
            m_VoteController.AddCandidate();
        }

        public void StartVoting()
        {
            m_VoteController.StartVoting();
        }
    }
}