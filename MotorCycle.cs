using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MotorCykelApp
{
    internal class MotorCycle
    {
        //Fields
        //   started 	– af typen boolean
        public bool _started;
        //   rpm		- heltal
        public int _rpm;
        //   gear		- heltal, kan være 0-5
        public int _gear;
        //   name		- tekst
        public string _name;

        //Properties
        //Name
        //Henter og bringer til field name
        public string Name { get; set; }


        //Constructors
        //En constructor, der ikke modtager nogen parametre, og sætter den nye motorcycle til at have intet navn, være stoppet, rpm til 0 og gear til 0.
        public MotorCycle()
        {
            _name = "";
            _started = false;
            _rpm = 0;
            _gear = 0;

        }

        //En constructor, der modtager navn som string og en bool om den er startet. Hvis startet skal rmp være 1000, ellers skal rmp være 0. Gear skal være 0.
        public MotorCycle(string name, bool started)
        {
            if (started)
            {
                _started = started;
                _rpm = 1000;
                _name = name;
                Start();
            }
            else
            {
                _rpm = 0;
                _gear = 0;
            }
        }

        //Metoder

        //Acceleration
        public void Acceleration()
        {
            List<ConsoleKeyInfo> keyBuffer = new List<ConsoleKeyInfo>();
            while (_started) 
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                



                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            ShiftGearsUp();
                            break;
                        case ConsoleKey.DownArrow:
                            ShiftGearsDown();
                            break;
                        case ConsoleKey.LeftArrow:
                            SpeedDown(500);
                            break;
                        case ConsoleKey.RightArrow:
                            SpeedUp(500);
                            break;
                    }
                }
            }
        }

        private void SpeedUp(int v)
        {
            if (_gear > 0 && _rpm < 8000)
            {
                _rpm += v;
                Console.WriteLine(ToString());
            }
            else
            {
                Console.WriteLine($"Du har nået max omdrejninger og suser derudad. VROOOM");
            }
        }
        private void SpeedDown(int v)
        {
            if (_gear > 0 && _rpm > 1000)
            {
                _rpm -= v;
                Console.WriteLine(ToString());
            }
            else
            {
                Stop();
            }
        }



        //setRpm()
        //Med denne skal omdrejninger kunne sættes og hentes. Omdrejningerne kan kun sættes hvis motor er startet. Omdrejninger må ikke komme over 8000 og hvis de kommer under 1000 skal motor stoppes.
        public object Rpm(int rpm)
        {
            _started = true;

            while (_started)
            {
                if (rpm > 8000)
                {
                    _rpm = 8000;
                    return $"Du har nået max omdrejninger og suser derudad med {_rpm} omdrejninger.";
                }
                else if (rpm > 1000)
                {
                    _rpm = rpm;
                    return $"Du suser derudad med {_rpm} omdrejninger.";
                }
                else
                    Stop();
                Console.WriteLine("Motoren stopper");
            }
            return _rpm;
        }


        //isStarted()
        //Som returnerer værdien af attributten started.
        public bool isStarted(bool _started)
        {
            return _started;
        }

        //start()
        //Hvis motoren ikke er startet, skal den sætte motoren til startet, omdrejninger til 1000 og gear til 0.
        public void Start()
        {
            isStarted(true);
            _rpm = 1000;
            _gear = 0;
        }

        //stop()
        //Skal sætte motor til stoppet , omdrejninger til 0 og gear til 0.
        public void Stop()
        {
            _started = false;
            _rpm = 0;
            _gear = 0;
            Console.WriteLine($"Du er i gear: { _gear}. Omdrejninger: { _rpm} rpm."); 
        Console.WriteLine("Motorcyklen er stoppet.");


        }

        //getSpeed()
        //Skal returnere hastigheden som omdrejninger * gear / 200.
        public int GetSpeed()
        {
            int speed = (_rpm * _gear) / 200;
            return speed;
        }

        //shiftGearsUp()
        //Skal forøge gearet med 1 hvis det er under 5 og motoren er startet.
        public int ShiftGearsUp()
        {
            if (_gear < 5 && isStarted(true))
            {
                _gear++;
                Console.WriteLine(ToString());
            }
            return _gear;
        }

        //shiftGearsDown(int g)
        //Skal geare ned til det angivne, hvis g er lavere end det aktuelle gear, og gear er højere end 0.
        //public int ShiftGearsDown(int g)
        //{
        //    if (g < _gear && _gear > 0)
        //    {
        //        _gear = g;
        //    }

        //    return _gear;
        //}
        public int ShiftGearsDown()
        {
            if (_gear > 0 && isStarted(true))
            {
                _gear--;
                Console.WriteLine(ToString());
            }
            else { Stop(); }
            return _gear;
        }

        //getGear()
        //Skal returnere det aktuelle gear.
        public int GetGear()
        {
            return _gear;
        }

        //toString()
        //Skal returnere tekst med samlede oplysninger inkl. hastighed.
        public override string ToString()
        {
            return $"Du kører {GetSpeed()} km/t på en {_name}. Du er i gear: {_gear}. Omdrejninger: {_rpm} rpm.";
        }
    }
}
