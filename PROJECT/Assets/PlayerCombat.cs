using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private Vector3 attackDir;
    [SerializeField]
    private GameObject sword;
    Vector3 finalDir = new Vector3();
    [SerializeField]
    private float offset = 2;
    private GameObject instSword;

    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            instSword = Instantiate(sword, transform.position, Quaternion.identity);

            instSword.transform.SetParent(transform);
            instSword.transform.position = new Vector3(transform.position.x, transform.position.y, 1);

            finalDir = attackDir * offset;

            if (attackDir.Equals(Vector3.up))
            {
                instSword.transform.Rotate(0,0,-90);
            }
            else if (attackDir.Equals(Vector3.down))
            {
                instSword.transform.Rotate(0, 0, 90);
                instSword.transform.position = new Vector3(instSword.transform.position.x, instSword.transform.position.y, -1);
            }

            instSword.transform.position += finalDir;

            pm.DisableMove(true);

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
        finalDir = Vector3.zero;
        instSword.transform.position = new Vector3(instSword.transform.position.x, instSword.transform.position.y, 1);
        pm.DisableMove(false);
    }
}
