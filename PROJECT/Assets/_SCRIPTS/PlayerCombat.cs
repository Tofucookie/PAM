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
    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    private float attackSpeed = 0.5f;

    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
        {
            instSword = Instantiate(sword, transform.position, Quaternion.identity);
            isAttacking = true;

            instSword.transform.SetParent(transform);
            instSword.transform.position = new Vector3(transform.position.x, transform.position.y, 1);

            RGBLighting();

            finalDir = attackDir * offset;

            if (attackDir.Equals(Vector3.up))
            {
                instSword.transform.Rotate(0, 0, -90);
            }
            else if (attackDir.Equals(Vector3.down))
            {
                instSword.transform.Rotate(0, 0, 90);
                instSword.transform.position = new Vector3(instSword.transform.position.x, instSword.transform.position.y, -1);
            }

            instSword.transform.position += finalDir;

            //pm.DisableMove(true);

            StartCoroutine("attackTimer", attackSpeed);
        }
    }

    private void RGBLighting()
    {
        
        instSword.GetComponent<SpriteRenderer>().color = new Color32(
            (byte)Random.Range(0, 255), 
            (byte)Random.Range(0, 255), 
            (byte)Random.Range(0, 255), 
            (byte)255);
    }

    public void ChangeAttackDir(Vector3 v)
    {
        attackDir = v;
    }

    IEnumerator attackTimer(float t)
    {
        yield return new WaitForSeconds(t);
        isAttacking = false;
        finalDir = Vector3.zero;
        instSword.transform.position = new Vector3(instSword.transform.position.x, instSword.transform.position.y, 1);
        //pm.DisableMove(false);
        Destroy(instSword);
    }
}
