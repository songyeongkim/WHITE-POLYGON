using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrainMove : CComponent
{
    [Header("SetMoveInfo")]

    public bool canNextTrain = true;
    private bool initCanNextTrain;

    [SerializeField]
    private bool autoStart = true;
    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform stopPos;
    [SerializeField]
    private Transform destPos;
    public Transform DestPos
    {
        set
        {
            destPos = value;
        }
    }

    public float moveSpeed;
    [SerializeField]
    private Transform nowDestination;

    [Header("SetNextTrain")]
    public CTrainMove nextTrain;
    [SerializeField]
    private Collider[] destCollider;

    [Header("RotateSetting")]
    [SerializeField]
    private CReverseRoadChangeButton reverseRoad;
    public CReverseRoadChangeButton ReverseRoad
    {
        set
        {
            reverseRoad = value;
        }
        get
        {
            return reverseRoad;
        }
    }
    public bool autoRotate = false;
    public bool autoMoveAfterRotate = false;
    [SerializeField]
    private CRoadChangeButton roadRotate;

    private bool canRotate;
    public bool CanRotate
    {
        set
        {
            canRotate = value;
        }
        get
        {
            return canRotate;
        }
    }

    private bool destinationChange = false;
    public bool DestinationChange
    {
        set
        {
            destinationChange = value;
        }

        get
        {
            return destinationChange;
        }
    }

    [Header("MoveStateSetting")]
    public bool nowMove = true;
    public bool destHide = true;
    public bool soundSetting = true;

    [Header("Active Objs")]
    [SerializeField]
    private GameObject[] objects;

    [Header("ForestShow")]
    [SerializeField]
    private CForestShow forestShow;

    private void OnEnable()
    {
        if(reverseRoad != null)
            reverseRoad.rotateEnd = false;

        if(objects != null)
        {
            for(int i=0;i<objects.Length;i++)
            {
                objects[i].SetActive(true);
            }
        }    
    }

    private void OnDisable()
    {
        if (objects != null)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }
    }


    public override void Start()
    {
        base.Start();
        initCanNextTrain = canNextTrain;
        MovingSoundPosSettting();

        ResetInitState();
    }


    //사운드 위치 세팅
    public void MovingSoundPosSettting()
    {
        if(soundSetting)
        {
            CTrainSoundPos trainSoundPos = CTrainSoundPos.instance;
            trainSoundPos.movingTrain = this;
            trainSoundPos.PlaySound();
        }
    }


    public override void Update()
    {
        if(nowMove)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nowDestination.position, moveSpeed);

            if(forestShow != null)
                forestShow.QuestStart = false;

            if (Mathf.Abs((gameObject.transform.position - nowDestination.position).magnitude) < 0.05f)
            {
                //목표지점 도착 후 회전 가능, 움직이지 않음 상태로 변경
                canRotate = true;
                nowMove = false;
                if(forestShow != null)
                {
                    forestShow.QuestStart = true;
                }

                //중간지점에 왔을 때, 자동회전이 온 되어있으면 회전 시작
                if (stopPos != null && autoRotate && nowDestination.gameObject.name == stopPos.gameObject.name)
                {
                    roadRotate.rotateStart = true;
                }

                //도착 시 위치 및 회전값 초기화
                if (destPos != null && nowDestination.gameObject.name == destPos.gameObject.name)
                {
                    ResetInitState();

                    if (destHide)
                    {
                        gameObject.SetActive(false);
                    }  
                }
            }
            else
            {
                canRotate = false;
            }
        }
    }

    //이동 정보 초기화
    public void ResetInitState()
    {
        canNextTrain = initCanNextTrain;

        gameObject.transform.position = startPos.position;
        gameObject.transform.rotation = startPos.rotation;

        if (autoStart)
            nowMove = true;

        if (stopPos != null)
            nowDestination = stopPos;
        else
            nowDestination = destPos;

        DestinationChange = autoMoveAfterRotate;
    }

    public void ChangeDestination()
    {
        if(canRotate)
        {
            //다음 목표 지점으로 목표지점 세팅 및 움직임 시작, 다음 기차로 교체 트리거 on
            nowDestination = destPos;
            nowMove = true;
            canNextTrain = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canNextTrain)
        {
            for (int i = 0; i < destCollider.Length; i++)
            {
                if (other == destCollider[i])
                {
                    nextTrain.gameObject.SetActive(true);
                    if (nextTrain.gameObject.GetComponent<CAutoChangeTrain>() != null)
                        nextTrain.gameObject.GetComponent<CAutoChangeTrain>().ChangeTrain(this);
                }
            }
        }    
    }
}
