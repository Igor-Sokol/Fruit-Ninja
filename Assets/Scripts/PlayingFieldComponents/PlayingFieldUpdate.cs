using Blocks.BlockServices.PlayingFieldServices;
using UnityEngine;

namespace PlayingFieldComponents
{
    public class PlayingFieldUpdate : MonoBehaviour
    {
        [SerializeField] private BlockContainer playingField;

        private void Update()
        {
            foreach (IOnPlayingField block in playingField.Blocks)
            {
                block.OnPlayingField();
            }
        }
    }
}