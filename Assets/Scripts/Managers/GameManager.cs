using UnityEngine;
using System.Collections;

public enum Player{
	ONE,
	TWO
}
public class GameManager : BaseManager {
	private static Player _player;
	public static Player player{
		get{
			return _player;
		}
		set{
			_player = value;
			OnPlayerSet();
		}
	}

	public delegate void PlayerSet();
	public static event PlayerSet OnPlayerSet;

	public static void Initialize(){

	}
}
