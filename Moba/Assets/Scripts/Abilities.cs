using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    //Ability 1 Variables
    [SerializeField]
    [Header("Ability 1")]
    private Image abilityImage1;
    [SerializeField] private float cooldown1 = 5;
    bool isCooldown = false;
    [SerializeField] private KeyCode ability1;

    Vector3 position;
    [SerializeField] private Canvas ability1Canvas;
    [SerializeField] private Image skillshot;
    [SerializeField] private Transform player;


    //Ability 2 Variables
    [Header("Ability 2")]
    [SerializeField] private Image abilityImage2;
    [SerializeField] private float cooldown2 = 10;
    bool isCooldown2 = false;
    [SerializeField] private KeyCode ability2;

    [SerializeField] private Image targetCircle;
    [SerializeField] private Image indicatorRangeCircle;
    [SerializeField] private Canvas ability2Canvas;
    private Vector3 posUp;
    [SerializeField] private float maxAbility2Distance;


    //Ability 3 Variables
    [Header("Ability 3")]
    [SerializeField] private Image abilityImage3;
    [SerializeField] private float cooldown3 = 7;
    bool isCooldown3 = false;
    [SerializeField] private KeyCode ability3;


    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        skillshot.GetComponent<Image>().enabled = false;
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Skill 1 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //Skill 2 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                posUp = new Vector3(hit.point.x, 10f, hit.point.z);
                position = hit.point;
            }
        }


        //Skill 1 Canvas Inputs
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);
        ability1Canvas.transform.Rotate(90f, 0f, 0f);

        //Skill 2 Canvas Inputs
        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxAbility2Distance);

        var newHitPos = transform.position + hitPosDir * distance;
        ability2Canvas.transform.position = (newHitPos);

    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            skillshot.GetComponent<Image>().enabled = true;

            //Disable Other UI
            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;
        }

        if (skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            indicatorRangeCircle.GetComponent<Image>().enabled = true;
            targetCircle.GetComponent<Image>().enabled = true;

            //Disable Other UI
            skillshot.GetComponent<Image>().enabled = false;
        }

        if (targetCircle.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
