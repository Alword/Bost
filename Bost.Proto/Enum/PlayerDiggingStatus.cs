using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Proto.Enum
{
	public enum PlayerDiggingStatus
	{
		StartedDigging = 0,
		CancelledDigging = 1,
		FinishedDigging = 2,
		DropItemStack = 3,
		DropItem = 4,
		ShootArrowFinishEating = 5,
		SwapItemInHand = 6,
	}
}
