﻿ 





// Generated by PIDL compiler.
// Do not modify this file, but modify the source .pidl file.

using System;
using System.Collections.Generic;
namespace PowerupS2G
{
	internal class Common
	{
		// Message ID that replies to each RMI method. 
			public const Nettention.Proud.RmiID GameStart = (Nettention.Proud.RmiID)2000+1;
			public const Nettention.Proud.RmiID GameEnd = (Nettention.Proud.RmiID)2000+2;
			public const Nettention.Proud.RmiID PlayersReady = (Nettention.Proud.RmiID)2000+3;
			public const Nettention.Proud.RmiID TimeNow = (Nettention.Proud.RmiID)2000+4;
			public const Nettention.Proud.RmiID PlayerMove = (Nettention.Proud.RmiID)2000+5;
			public const Nettention.Proud.RmiID PlayersRank = (Nettention.Proud.RmiID)2000+6;
		// List that has RMI ID.
		public static Nettention.Proud.RmiID[] RmiIDList = new Nettention.Proud.RmiID[] {
			GameStart,
			GameEnd,
			PlayersReady,
			TimeNow,
			PlayerMove,
			PlayersRank,
		};
	}
}
namespace PowerupS2C
{
	internal class Common
	{
		// Message ID that replies to each RMI method. 
			public const Nettention.Proud.RmiID PlayerEnter = (Nettention.Proud.RmiID)2100+1;
			public const Nettention.Proud.RmiID PlayerExit = (Nettention.Proud.RmiID)2100+2;
		// List that has RMI ID.
		public static Nettention.Proud.RmiID[] RmiIDList = new Nettention.Proud.RmiID[] {
			PlayerEnter,
			PlayerExit,
		};
	}
}
namespace PowerupC2S
{
	internal class Common
	{
		// Message ID that replies to each RMI method. 
			public const Nettention.Proud.RmiID EnterRoom = (Nettention.Proud.RmiID)2200+1;
			public const Nettention.Proud.RmiID ExitRoom = (Nettention.Proud.RmiID)2200+2;
			public const Nettention.Proud.RmiID GetReady = (Nettention.Proud.RmiID)2200+3;
			public const Nettention.Proud.RmiID Move = (Nettention.Proud.RmiID)2200+4;
			public const Nettention.Proud.RmiID HasPoint = (Nettention.Proud.RmiID)2200+5;
		// List that has RMI ID.
		public static Nettention.Proud.RmiID[] RmiIDList = new Nettention.Proud.RmiID[] {
			EnterRoom,
			ExitRoom,
			GetReady,
			Move,
			HasPoint,
		};
	}
}






				 
