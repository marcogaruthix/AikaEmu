using AikaEmu.GameServer.Managers;
using AikaEmu.GameServer.Network.GameServer;
using AikaEmu.GameServer.Packets.Game;
using AikaEmu.Shared.Network;

namespace AikaEmu.GameServer.Packets.Client
{
	public class IngameState : GamePacket
	{
		protected override void Read(PacketStream stream)
		{
			var character = Connection.ActiveCharacter;
			Connection.SendPacket(new SendUnitSpawn(character));
			WorldManager.Instance.ShowVisibleUnits(character);
			
			Connection.SendPacket(new UpdateStatus());
			Connection.SendPacket(new UpdateAttributes(character.CharAttributes));
			Connection.SendPacket(new UpdateExperience(character));
			Connection.SendPacket(new UpdateHpMp(character));
            
            Connection.SendPacket(new UpdateAccountLevel(Connection.Account));
            Connection.SendPacket(new UpdatePremiumStash());
		}
	}
}