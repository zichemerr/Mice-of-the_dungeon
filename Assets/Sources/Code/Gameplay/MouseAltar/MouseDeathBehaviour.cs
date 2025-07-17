using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltar
{
    public abstract class MouseDeathBehaviour : MonoBehaviour
    {
        public abstract void Init(GhostView ghostView, PlayerInput playerInput);

        public abstract UniTask DeathRoutine(List<IImportable> importable, CancellationToken cancellationToken);
    }
}