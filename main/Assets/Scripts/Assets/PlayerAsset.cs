using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Player Asset", fileName = "Player Asset")]
    public class PlayerAsset : ScriptableObject
    {
        public int number;
        public string nickname;
        public int foul = 0;
        public string playingRole;
        public float extraPoints;
        public bool winOrLose;    
    }
}