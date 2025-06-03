using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MouseDeath : MouseDeathBehaviour
{
    //[SerializeField] private GhostView _ghostView;
    
    private float lastTime;
    private float cooldownTime = 0.2f;

    public override void Init()
    {
        
    }

    public IEnumerator DeathRoutine(IImportable importable)
    {
        if (Time.time - lastTime >= cooldownTime)
        {
            //Root.Audio.Play(Root.Sound.Scream, 0.3f);
            lastTime = Time.time;
        }

        //yield return _ghostView.HideDispaly();
        yield return new WaitForSeconds(0.05f);
        importable.PlayDeadParticle();
        importable.Destroy();
        //yield return _ghostView.ShowDispaly(0.5f);
    }

    public override IEnumerator DeathRoutine(List<IImportable> importable)
    {
        yield return new WaitForSeconds(0.5f);

        foreach (var mouse in importable)
        {
            yield return StartCoroutine(DeathRoutine(mouse));
        }
    }
}