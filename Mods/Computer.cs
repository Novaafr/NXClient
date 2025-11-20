using Photon.Pun;
using GorillaNetworking;

namespace NXClient.Mods
{
    public class Computer
    {
        public static void JoinRoom(string roomid) => PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomid, JoinType.Solo);
        public static void Disconnect() => PhotonNetwork.Disconnect();
        public static void JoinRandom() => PhotonNetworkController.Instance.AttemptToJoinPublicRoom(PhotonNetworkController.Instance.currentJoinTrigger ?? GorillaComputer.instance.GetJoinTriggerForZone("Forest"));
    }
}
