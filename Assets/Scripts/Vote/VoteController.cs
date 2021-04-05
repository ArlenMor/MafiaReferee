using System;
using Global;
using UnityEngine;
using UnityEngine.UI;

namespace Vote
{
    public class VoteController : MonoBehaviour
    {
        public VoteView[] VoteViews;

        
        public void AddCandidate()
        {
            //проверяю валидность выставленного игрока
            foreach (var voteView in VoteViews)
            {
                int candidate = Convert.ToInt32(voteView.PotentialCandidate.text);
                if (candidate < 0 || candidate > 10)
                {
                    voteView.PotentialCandidate.text = "";
                    Debug.Log("Неправильная кандидатура");
                }
                else if(!LivePlayers.CheckAlivePlayer(candidate - 1))
                {
                    voteView.PotentialCandidate.text = "";
                    Debug.Log("Этот игрок мертв");
                }else
                {
                    //if (!CheckRepeatCandidatesInText(voteView.Candidate.acceptPlayer)) continue;
                    if (!CheckRepeatCandidatesInText(candidate.ToString())) continue;
                    voteView.Candidate.acceptPlayer = voteView.PotentialCandidate.text;
                    voteView.PotentialCandidate.text = "";

                    voteView.AddCandidateInText();
                    voteView.ShowCandidate();
                }
            }
        }
        private bool CheckRepeatCandidatesInText(string inputCandidate)
        {
            foreach (var voteView in VoteViews)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (voteView.Candidates[i].text != inputCandidate) continue;
                    voteView.PotentialCandidate.text = "";
                    Debug.Log("Такой кандидат уже есть");
                    return false;
                }
            }
            return true;
        }

        public void StartVoting()
        {
            int numberVotingPlayer = LivePlayers.NumberOfAlive;
            foreach (var voteView in VoteViews)
            {
                int numberVotes = Convert.ToInt32(voteView.PotentialCandidate.text);
                for (int i = 0; i < voteView.numberOfText || numberVotingPlayer > 0; i++)
                {
                    if (numberVotes < 0 || numberVotes > numberVotingPlayer)
                    {
                        voteView.PotentialCandidate.text = "";
                        Debug.Log("Неправильное количество проголосовавших игроков");
                    }
                }
                voteView.AddVotesForCandidate(numberVotingPlayer.ToString());
                numberVotingPlayer -= numberVotes;
            }
        }
    }
}