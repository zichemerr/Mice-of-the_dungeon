using System;
using UnityEngine;

namespace Sources.Code.Gameplay.MouseAltar
{
    public class ImporterZone : MonoBehaviour
    {
        public event Action<IImportable> Entered;
        public event Action<IImportable> Exited;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IImportable mouse))
            {
                Entered?.Invoke(mouse);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IImportable mouse))
            {
                Exited?.Invoke(mouse);
            }
        }
    }
}