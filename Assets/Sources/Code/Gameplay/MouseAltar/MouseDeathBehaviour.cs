using System.Collections;
using System.Collections.Generic;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltar
{
    public abstract class MouseDeathBehaviour : MonoBehaviour
    {
        public abstract void Init(GhostView ghostView, PlayerInput playerInput);

        public abstract IEnumerator DeathRoutine(List<IImportable> importable);
    }
}