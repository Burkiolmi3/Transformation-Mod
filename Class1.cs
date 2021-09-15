
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;
using System.IO;

namespace Switch
{
    public class Main : Script
    {
        ScriptSettings config;



        Keys changeModelKey;
        Keys ChangePedKey;
        PedHash WantedPed;
        PedHash WantedAnimal;
        Keys changecarkey;
        VehicleHash WantedVehicle;


        public Main()
        {
            Interval = 1;
            KeyDown += ChangePlrModel_KeyDown;

            config = ScriptSettings.Load("scripts\\Switch.ini");

            changeModelKey = config.GetValue<Keys>("Keys", "Animal Transform Key", Keys.NumPad1);
            ChangePedKey = config.GetValue<Keys>("Keys", "Ped Transform Key", Keys.NumPad3);
            WantedPed = config.GetValue("Options", "Ped", PedHash.Franklin);
            WantedAnimal = config.GetValue("Options", "Animal", PedHash.Cow);
            WantedVehicle = config.GetValue("Options", "Vehicle", VehicleHash.Adder);
            changecarkey = config.GetValue<Keys>("Keys", "Vehicle Transform Key", Keys.K);
        }

        private void ChangePlrModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == changecarkey)
            {
                Vehicle car = World.CreateVehicle(WantedVehicle, Game.Player.Character.Position);
                Game.Player.Character.SetIntoVehicle(car, VehicleSeat.Driver);
            }

            if (e.KeyCode == ChangePedKey)
            {
                Game.Player.ChangeModel(WantedPed);
            }

            if (e.KeyCode == changeModelKey)
            {
                Game.Player.ChangeModel(WantedAnimal);
            }
        }
    }
}












