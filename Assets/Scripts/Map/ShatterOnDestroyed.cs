using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnDestroyed : MonoBehaviour {

    public GameObject shatterModel;

    private void OnDestroy()
    {
        GameObject shattered = Instantiate(shatterModel, transform.position, transform.rotation, transform.parent);
        shattered.transform.localScale = transform.localScale;

        Destroy(shattered, 3f);
    }
}
