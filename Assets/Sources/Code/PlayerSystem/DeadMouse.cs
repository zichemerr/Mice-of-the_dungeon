using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeadMouse : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void PlayDeadParticle()
    {
        if (this == null)
            return;
            
        // Root.Main.Get<ParticleRoot>()
        //     .Play(Resources.Load<GameObject>("Dead"),transform.position);
    }
}