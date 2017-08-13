﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Warcraft.Commands;
using Warcraft.Managers;
using Warcraft.Units.Humans;
using Warcraft.Util;
using Warcraft.Units.Orcs;
using Warcraft.Units;

namespace Warcraft.Buildings.Orcs
{
	class Barracks : Neutral.Barracks
	{
		public Barracks(int tileX, int tileY, ManagerMouse managerMouse, ManagerMap managerMap, ManagerUnits managerUnits) :
			base(tileX, tileY, 96, 96, managerMouse, managerMap, managerUnits)
		{
			information = new InformationBuilding("Barracks", 800, 700, 400, Util.Units.PEON, 200 * Warcraft.FPS, Util.Buildings.ORC_BARRACKS);

			Dictionary<AnimationType, List<Sprite>> sprites = new Dictionary<AnimationType, List<Sprite>>();
			List<Sprite> spriteBuilding = new List<Sprite>();
			// BUILDING
			spriteBuilding.Add(new Sprite(560, 737, 48, 39));
			spriteBuilding.Add(new Sprite(556, 865, 61, 52));
			spriteBuilding.Add(new Sprite(18, 260, 88, 77));
			spriteBuilding.Add(new Sprite(109, 242, 95, 96));

			sprites.Add(AnimationType.WALKING, spriteBuilding);

			Dictionary<string, Frame> animations = new Dictionary<string, Frame>();
			animations.Add("building", new Frame(0, 4));

			this.animations = new Animation(sprites, animations, "building", width, height, false, information.BuildTime / spriteBuilding.Count);

			textureName = "Orc Buildings (Summer) ";

            commands.Add(new BuilderUnits(Util.Units.GRUNT, managerUnits, Grunt.Information as InformationUnit));
            commands.Add(new BuilderUnits(Util.Units.TROLL_AXETHROWER, managerUnits, TrollAxethrower.Information as InformationUnit));
		}
	}
}
