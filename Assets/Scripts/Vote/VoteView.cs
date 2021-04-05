using System;
using Assets;
using UnityEngine;
using UnityEngine.UI;

namespace Vote
{
    public class VoteView : MonoBehaviour
    {
        //Кандидат на голосование
        public VoteAsset Candidate;
        //Поле, куда вводится номер игрока при выставлении
        public InputField PotentialCandidate; 

        //Текст, куда будут отображаться кандидаты
        public Text[] Candidates;
        //Текст, куда будут отображаться голоса
        public Text[] Votes;
        public int numberOfText = 0;
        public int numberOfVotes = 0;

        //инициализация VoteAsset
        private void Start()
        {
            Candidate = ScriptableObject.CreateInstance<VoteAsset>();
        }
    
        //написать текущего кандидата
        public void ShowCandidate()
        {
            Debug.Log(Candidate.acceptPlayer);
        }

        //напечатать номер кондидата в соответствубщее окно
        public void AddCandidateInText()
        {
            Candidates[numberOfText].text = Candidate.acceptPlayer;
            numberOfText++;
        }

        //добавить голоса за кандидата
        public void AddVotesForCandidate(string votes)
        {
            Votes[numberOfVotes].text = votes;
            numberOfVotes++;
        }
    }
}