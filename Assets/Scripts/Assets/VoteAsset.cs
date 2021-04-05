using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Vote Asset", fileName = "Vote Asset")]
    public class VoteAsset : ScriptableObject
    {
        public string acceptPlayer;
    }
}