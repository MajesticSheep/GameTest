using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatronicSystem : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMA;
    [SerializeField] private GameObject[] Target;

    [SerializeField] private int CurrentTarget;

    [SerializeField] private float CoolDownTimer;
    [SerializeField] private float MinCoolDownTime;
    [SerializeField] private float MaxCoolDownTime;

    [SerializeField] private int MinChanceToMove = 1;
    [SerializeField] private int MaxChanceToMove = 20;

    [SerializeField] private int TresholdToPass = 3;

    [SerializeField] private int[] AggressionByHour;

    [SerializeField] private int MinAggressionToAdd = 2;
    [SerializeField] private int MaxAggressionToAdd = 5;

    [SerializeField] private int HoursChanged;
    // Start is called before the first frame update
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CoolDownTimer <= 0)
        {
            var chanceCheck = Random.Range(MinChanceToMove, MaxChanceToMove);

            if(chanceCheck <= TresholdToPass)
            {
                if (Vector3.Distance(transform.position, Target[CurrentTarget].transform.position) <= 0.5f)
                {
                    if (Target[CurrentTarget].GetComponent<DestinationPoint>().IsDoor)
                    {

                        if (Target[CurrentTarget].GetComponent<DestinationPoint>().Door.IsOpen)
                        {
                            CurrentTarget = Target.Length - 1;
                        }
                        else
                        {
                            CurrentTarget = 1;
                        }

                    }
                    else if (Target[CurrentTarget].GetComponent<DestinationPoint>().IsOffice)
                    {
                        Debug.Log("You Died");
                    }
                    else
                    {
                        CurrentTarget += 1;

                        if (CurrentTarget >= Target.Length)
                        {
                            CurrentTarget = 0;
                        }
                    }
                }
            }

            var CoolDownTime = Random.Range(MinCoolDownTime, MaxCoolDownTime);
            CoolDownTimer = CoolDownTime;
        }
        else
        {
            CoolDownTimer -= Time.deltaTime;
        }
        
        if (Target[CurrentTarget].GetComponent<DestinationPoint>().IsOffice)
        {
            Debug.Log("You Died");
        }

        NMA.destination = Target[CurrentTarget].transform.position;

    }

    public void ChangeAggrssionByHour(int hour)
    {
        if(HoursChanged != hour)
        {
            if (TresholdToPass < hour)
            {
                TresholdToPass = AggressionByHour[hour];
            }

            TresholdToPass += Random.Range(MinAggressionToAdd, MaxAggressionToAdd);
            HoursChanged += 1;
        }
    }
}
