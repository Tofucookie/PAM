using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private Vector3 attackDir;
    [SerializeField]
    private GameObject sword;
    private GameObject instSword;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            instSword = Instantiate(sword, transform.position, Quaternion.identity);

            instSword.transform.SetParent(transform);
            instSword.transform.position = new Vector3(instSword.transform.position.x, instSword.transform.position.y, 1);

            StartCoroutine("attackTimer", 1);
        }
    }

    public void ChangeAttackDir(Vector3 v)
    {
        attackDir = v;
    }

    IEnumerator attackTimer(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(instSword);
    }
}
