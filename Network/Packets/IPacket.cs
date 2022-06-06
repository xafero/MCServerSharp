using System;

namespace MCServerSharp.Network.Packets {
	/// <summary>
	/// Connection state
	/// </summary>
	public enum State {
		Handshaking,
		Status,
		Login,
		Play
	}
	/// <summary>
	/// Network packet
	/// </summary>
	public interface IPacket {
		/// <summary>
		/// Current supported lastest protocol version
		/// </summary>
		public static int LastestProtocolVersion = 754;
		/// <summary>
		/// Connection state of packet
		/// </summary>
		public abstract State PacketState { get; }
		/// <summary>
		/// Packet id
		/// </summary>
		public abstract byte PacketId { get; }
		/// <summary>
		/// Make a copy of the packet
		/// </summary>
		public abstract IPacket DeepClone();
		/// <summary>
		/// Create a new instance of this packet
		/// </summary>
		public abstract IPacket CreateInstance();
	}
}