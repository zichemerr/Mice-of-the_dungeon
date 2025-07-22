using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Code.Gameplay.PlayerSystem;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltars
{
    public abstract class MouseDeathBehaviour : MonoBehaviour
    {
        public abstract void Init(GhostScreamerView ghostScreamerView, PlayerInput playerInput);

        public abstract UniTask DeathRoutine(List<IImportable> importable, CancellationToken cancellationToken);
    }
}