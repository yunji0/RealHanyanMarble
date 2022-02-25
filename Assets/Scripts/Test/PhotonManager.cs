using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //버전 입력
    private readonly string version = "1.0f";
    //사용자 아이디 입력
    private string userId = "Mary";
    GameObject me;
    GameObject me2;
    public GameObject hanyang;
    PhotonView PV;
    CharacterController CCm;
    Vector3 ro1;
    int H;
    int V;

    //가장빨리 실행되는 함수 시작하자마자 실행됨
    private void Awake()
    {
        userId = $"{Random.Range(0, 1000)}Mary";
        //같은 룸의 유저들에게 자동으로 씬을 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
        // 같은 버전의 유저들끼리 접속 허용
        PhotonNetwork.GameVersion = version;
        //유저 아이디 할당
        PhotonNetwork.NickName = userId;

        //포톤 서버와 통신 횟수 설정 초당 30회
        Debug.Log(PhotonNetwork.SendRate);
        //서버 접속
        PhotonNetwork.ConnectUsingSettings();

       
    }

    //포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby();      // 로비입장
    }

    //로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // 랜덤 매치메이킹 기능 제공
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Failde {returnCode}:{message}");

        //룸의 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;       //룸의 오픈 여부
        ro.IsVisible = true;    //로비에서 룸 목록 노출 여부

        PhotonNetwork.CreateRoom("My Room", ro);
    }

    //룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    //룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        me=  PhotonNetwork.Instantiate("Player", new Vector3(0.0f, 3.0f, 0.0f), Quaternion.identity);
        PV = me.GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            CCm = me.GetComponent<CharacterController>();
            me2 = me.transform.GetChild(1).gameObject;
            me2.SetActive(true);
            hanyang = me.transform.GetChild(2).gameObject;
       //     ro1 = hanyang.transform.eulerAngles;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    float jumptime=0;
    void Jump() {

        for (; ; )
        {
            jumptime += Time.deltaTime;
            if (jumptime < 4.0f)
            {
                CCm.Move(new Vector3(0, 0.5f, 0) * Time.deltaTime);
            }
            else {
                break;
            }
        }

    }
    void Update()
    {
        try
        {
            if (PV.IsMine)
            {
                bool up1 = OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp) || Input.GetKey(KeyCode.W);
                bool down1 = OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown) || Input.GetKey(KeyCode.S);
                bool left1 = OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft) || Input.GetKey(KeyCode.A);
                bool right1 = OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight) || Input.GetKey(KeyCode.D); ;
                
                if (up1) { V = 1; }
                else if (down1) { V = -1; }
                else { V = 0; }

                if (left1) { H = -1; }
                else if (right1) { H = 1; }
                else { H = 0; }
                Vector3 ddir = new Vector3(H, 0, V).normalized;
                ddir = Camera.main.transform.TransformDirection(ddir);
                ddir.y = -0.8f;
                CCm.Move(ddir * Time.deltaTime * 5);

                Vector3 vec5 = Camera.main.transform.eulerAngles;
                hanyang.transform.eulerAngles = new Vector3(0, vec5.y, 0);

                //  ro1 = new Vector3(0, vec5.x, 0)*360 ;
                //  hanyang.transform.eulerAngles = ro1;
                //  me.transform.Rotate(vec5*10);
              //  print(Camera.main.transform.forward);


                if (OVRInput.GetDown(OVRInput.Button.One)||Input.GetMouseButtonDown(0))
                {
                    jumptime = 0;
                    Jump();
                    
                }

                if (OVRInput.GetDown(OVRInput.Button.Two))
                {
                    LoadingSceneControl.LoadScene("Menu");
                }


            }
        }
        catch (System.Exception)
        {

        }
      
       
    }



}
