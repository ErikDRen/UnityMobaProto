using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysticShot : MonoBehaviour
{
    //In Script Stuff
    Animator anim;
    RaycastHit hit;
    Movement moveScript;

    [Header("Mystic Shot Ability")]
    //public Image mysticShotImage;
    public float cooldown = 10;
    bool isCooldown = false;
    public KeyCode ability;
    bool canSkillshot = true;
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    //Ability Input Variables
    [Header("Ability Inputs")]
    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillshot;
    public Transform player;

    void Start()
    {
        //mysticShotImage.fillAmount = 0;

        skillshot.GetComponent<Image>().enabled = false;

        moveScript = GetComponent<Movement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        

        SkillshotAbility();
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Ability 1 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //Ability 1 Canvas Inputs
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        transRot.eulerAngles = new Vector3(0, transRot.eulerAngles.y, transRot.eulerAngles.z);

        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);
    }

    public void SkillshotAbility()
    {

        
        //Enable the Skillshot Indicator
        if (Input.GetKey(ability) && isCooldown == false)
        {
            
            skillshot.GetComponent<Image>().enabled = true;
        }


        if (skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            //ROTATE
            Quaternion rotationToLookAt = Quaternion.LookRotation(position - transform.position);
            float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y,
            ref moveScript.rotateVelocity, 0);

            transform.eulerAngles = new Vector3(0, rotationY, 0);

            moveScript.agent.SetDestination(transform.position);
            moveScript.agent.stoppingDistance = 0;

            if (canSkillshot)
            {
                isCooldown = true;
                //mysticShotImage.fillAmount = 1;

                //Call the Animation (setting the animation transition to true & false)
                StartCoroutine(corMysticShot());
            }
        }

        if (isCooldown)
        {
            //mysticShotImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;

            /*if (mysticShotImage.fillAmount <= 0)
            {
                mysticShotImage.fillAmount = 0;
                isCooldown = false;
            }*/
        }
    }

    IEnumerator corMysticShot()
    {
        canSkillshot = false;
        anim.SetBool("MysticShot", true);
        SpawnMysticShot();

        yield return new WaitForSeconds(1.5f);

        anim.SetBool("MysticShot", false);
    }

    //Called in Animation Event
    public void SpawnMysticShot()
    {
        canSkillshot = true;
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
        Instantiate(projPrefab, projSpawnPoint.transform.position, projSpawnPoint.transform.rotation);
    }
}