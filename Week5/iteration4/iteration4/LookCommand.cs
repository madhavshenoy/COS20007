﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration4
{
    class Look_Command : Command
    {
        public Look_Command(string[] ids) : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            else if (text[0] != "look")
            {
                return "Error in look input";
            }

            else if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            else if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }

            else if (text.Length == 3)
            {
                IHaveInventory inv = FetchContainer(p, text[4]);
                return LookAtIn(text[2],inv);
            }
            else if (text.Length == 5)
            {

                if (FetchContainer(p, text[4]) == null)
                {
                    return "I cannot find the " + text[4];
                }
                else
                {
                    return LookAtIn(text[2], FetchContainer(p, text[4]));
                }
            }

            return "Error: Unknown command";
        }

        public IHaveInventory FetchContainer(Player p, string containerid)
        {
            IHaveInventory container;
            return container = p.Locate(containerid) as IHaveInventory; //cast
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return "I cannot find the " + thingId;
            }
            else
            {
                Game_Object obj = container.Locate(thingId) as Game_Object;

                return obj.FullDescription;
            }

        }
    }
}
