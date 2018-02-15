using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TriggerdObjects {
    [Header("Personal variables")]
    public float upTime;
    public float amountToMoveUp = 1F;
    public float speed = 50;
    private bool isUp;

	public override void TriggerFunctionality()
	{
        if (!isUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + amountToMoveUp, transform.position.z);
            StartCoroutine(ReturnToFloor());
        }
    }

    IEnumerator ReturnToFloor()
    {
        isUp = true;
        yield return new WaitForSeconds(upTime);
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - amountToMoveUp, transform.position.z), speed * Time.deltaTime);

        isUp = false;
    }
}
