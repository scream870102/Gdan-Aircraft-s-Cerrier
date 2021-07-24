using UnityEngine;
using Lean.Pool;
public class FxAnimationRecycleHandler : MonoBehaviour
{
    void OnAnimationFinishAE()
    {
        LeanPool.Despawn(gameObject);
    }

}