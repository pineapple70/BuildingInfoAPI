﻿namespace BuildingInfoAPI.Models
{
	public class BuildingInfo
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? BuildingData { get; set; }
		public bool IsComplete { get; set; }
	}
}
