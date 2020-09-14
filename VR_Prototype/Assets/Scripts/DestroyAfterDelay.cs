using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    [SerializeField] float timeUntilDestroyed = 5f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelayRoutine());
    }

    private IEnumerator DestroyAfterDelayRoutine()
    {
        yield return new WaitForSeconds(timeUntilDestroyed);
        Destroy(gameObject);
    }

}
