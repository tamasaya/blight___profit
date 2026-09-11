using Sandbox;

public sealed class SoundForPlayer : Component
{
	[Property] public SoundEvent FootstepSound { get; set; }

	protected override void OnUpdate()
	{
		//
		// Is the W key down this frame?
		//
		if ( Input.Keyboard.Down( "W" ) )
		{
			Log.Info( "W is down!" );

		}

		//
		// Was the W key pressed this frame?
		//
		if ( Input.Keyboard.Pressed( "W" ) )
		{
			Log.Info( "W was pressed!" );
		}

		//
		// Was the W key released this frame?
		//
		if ( Input.Keyboard.Released( "W" ) )
		{
			Log.Info( "W was released!" );
		}

	}

	protected override void OnStart()
	{
		// Sound.Play( FootstepSound, WorldPosition );
	}
}



