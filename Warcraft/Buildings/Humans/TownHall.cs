﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Warcraft.Commands;
using Warcraft.Managers;
using Warcraft.Units.Humans;
using Warcraft.Util;
using Warcraft.Buildings.Neutral;
using Warcraft.Units;

namespace Warcraft.Buildings.Humans
{
    class TownHall : CityHall
    {
        public TownHall(int tileX, int tileY, ManagerMouse managerMouse, ManagerMap managerMap, ManagerUnits managerUnits) : 
            base(tileX, tileY, managerMouse, managerMap, managerUnits)
        {
            information = new InformationBuilding("Town Hall", 1200, 1200, 800, Util.Units.PEASANT, 250 * Warcraft.FPS, Util.Buildings.TOWN_HALL);

            Dictionary<AnimationType, List<Sprite>> sprites = new Dictionary<AnimationType, List<Sprite>>();
            List<Sprite> spriteBuilding = new List<Sprite>();
            // BUILDING
            spriteBuilding.Add(new Sprite(576, 708, 48, 39));
            spriteBuilding.Add(new Sprite(572, 836, 61, 52));
            spriteBuilding.Add(new Sprite(270, 154, 111, 95));
            spriteBuilding.Add(new Sprite(270, 17, 119, 104));

            sprites.Add(AnimationType.WALKING, spriteBuilding);

            Dictionary<string, Frame> animations = new Dictionary<string, Frame>();
            animations.Add("building", new Frame(0, 4));

            this.animations = new Animation(sprites, animations, "building", width, height, false, information.BuildTime / spriteBuilding.Count);

            textureName = "Human Buildings (Summer)";

            commands.Add(new BuilderUnits(Util.Units.PEASANT, managerUnits, Peasant.Information as InformationUnit));
        }
    }
}
