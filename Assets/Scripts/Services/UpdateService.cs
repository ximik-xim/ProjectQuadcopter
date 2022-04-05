using System;
using UnityEngine;

public sealed class UpdateService : MonoBehaviour
{
    public static Action OnUpdate;
    public static Action OnFixedUpdate;

    private void Update() => OnUpdate?.Invoke();

    private void FixedUpdate() => OnFixedUpdate?.Invoke();
}
