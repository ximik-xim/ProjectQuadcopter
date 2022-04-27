using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Quadcopter", fileName = "New Quadcopter Config")]
    public class QuadcopterConfig : ActorConfig<Quadcopter> 
    {
        [SerializeField][Range(0, 1)] private float _motionDuration;

        public float MotionDuration => _motionDuration;
    }
}
