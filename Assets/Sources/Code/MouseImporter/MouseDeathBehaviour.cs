using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public abstract class MouseDeathBehaviour : MonoBehaviour
{
    public abstract void Init(GhostView ghostView, PlayerInput playerInput);

    public abstract IEnumerator DeathRoutine(List<IImportable> importable);
}