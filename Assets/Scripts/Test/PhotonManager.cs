using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //���� �Է�
    private readonly string version = "1.0f";
    //����� ���̵� �Է�
    private string userId = "Mary";
    GameObject me;
    GameObject me2;
    public GameObject hanyang;
    PhotonView PV;
    CharacterController CCm;
    Vector3 ro1;
    int H;
    int V;

    //���廡�� ����Ǵ� �Լ� �������ڸ��� �����
    private void Awake()
    {
        userId = $"{Random.Range(0, 1000)}Mary";
        //���� ���� �����鿡�� �ڵ����� ���� �ε�
        PhotonNetwork.AutomaticallySyncScene = true;
        // ���� ������ �����鳢�� ���� ���
        PhotonNetwork.GameVersion = version;
        //���� ���̵� �Ҵ�
        PhotonNetwork.NickName = userId;

        //���� ������ ��� Ƚ�� ���� �ʴ� 30ȸ
        Debug.Log(PhotonNetwork.SendRate);
        //���� ����
        PhotonNetwork.ConnectUsingSettings();

       
    }

    //���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinLobby();      // �κ�����
    }

    //�κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinRandomRoom(); // ���� ��ġ����ŷ ��� ����
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Failde {returnCode}:{message}");

        //���� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;
        ro.IsOpen = true;       //���� ���� ����
        ro.IsVisible = true;    //�κ񿡼� �� ��� ���� ����

        PhotonNetwork.CreateRoom("My Room", ro);
    }

    //�� ������ �Ϸ�� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    //�뿡 ������ �� ȣ��Ǵ� �ݹ� �Լ�
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
