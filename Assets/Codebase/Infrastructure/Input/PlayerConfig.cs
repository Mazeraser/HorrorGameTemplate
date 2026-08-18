using UnityEngine;

namespace Infrastructure.Input{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [Range(1,5)]public float WalkSpeed;
        [Range(3,10)]public float RunSpeed;
        [Range(0,5)]public float JumpPower;
        public bool CanJump;
        public bool CanRun;
        [Range(1,10)]public int inventorySize;
        [Range(0,1)]public float Sensitivity;
    }
}