namespace Galactica
{
    public enum Startype { YellowDwarf, White, BlueNeutron, RedGiant }
    public enum PlanetType { Terrestial, Giant, Dwarf, Gas_Giant }
    abstract public class SpaceObjects
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public Position Pos { get; set; }
        public class Position
        {
            public Position() { }
            public Position(double x, double y)
            {
                X = x;
                Y = y;
            }
            public double X { get; set; }
            public double Y { get; set; }
        }
    }
    public class Star : SpaceObjects
    {
        public Startype Type;
        public double Temperature;
        List<Star> Planet;
        override public Position Pos { get; set; } = new Position(0, 0);
    }
    public class Planet : SpaceObjects
    {
        public int Diameter { get; set; } // I meter
        public int RotationPeriod { get; set; } // I Timer (Rundt om sig selv)
        public PlanetType Type;

        public double RevolutionPeriod { get; set; } // I Dage (Rundt om solen)
        //public double DistanceToSol { get; set; }
        public List<Moon> Moon { get; set; }

        public double Distance(Star sol) // ?????
        {
            return Math.Sqrt(Math.Pow((sol.Pos.X - Pos.X), 2) + Math.Pow((sol.Pos.Y - Pos.Y), 2));
        }

    }
    sealed public class Moon : Planet
    {
        public Planet Oribiting;

        public double Distance(Planet p) // ?????
        {
            return Math.Sqrt(Math.Pow((p.Pos.X - Pos.X), 2) + Math.Pow((p.Pos.Y - Pos.Y), 2));
        }
    }
    public class Run
    {
        public void AddData()
        {
            List<SpaceObjects> DataList = new();
            // Star
            Star Sun = new Star()
            {
                Name = "Sun",
                Id = 0,
                Type = Startype.RedGiant,
                Temperature = 5000
            };
            DataList.Add(Sun);


            // Moons

            // Luna
            Moon Luna = new Moon()
            {
                Id = 100,
                Name = "Luna"
            };

            // Titan
            Moon Titan = new Moon()
            {
                Id = 101,
                Name = "Titan"
            };

            // Phobos
            Moon Phobos = new Moon()
            {
                Id = 102,
                Name = "Phobos"
            };

            // Europa
            Moon Europa = new Moon()
            {
                Id = 103,
                Name = "Europa"
            };

            // Deimos
            Moon Deimos = new Moon() 
            { 
                Id = 104,
                Name = "Deimos"
            };

            // Ganymedes
            Moon Ganymedes = new Moon()
            {
                Id = 105,
                Name = "Ganymede"
            };

            // Io
            Moon Io = new Moon()
            {
                Id = 106,
                Name = "Io"
            };

            // Mimas
            Moon Mimas = new Moon()
            {
                Id = 107,
                Name = "Mimas"
            };



            // Planets

            // Mercury
            Planet Mercury = new Planet()
            {
                Id = 1,
                Name = "Mercury",
                Pos = new() { X = 1.0, Y = 1.0 },
                Diameter = 4879000,
                RotationPeriod = 1407,
                RevolutionPeriod = 88,
                Moon = new List<Moon>() { },
                Type = PlanetType.Giant
            };
            DataList.Add(Mercury);

            // Venus
            Planet Venus = new Planet()
            {
                Id = 2,
                Name = "Venus",
                Pos = new() { X = 2.0, Y = 1.5 },
                Diameter = 12103000,
                RotationPeriod = 2802,
                RevolutionPeriod = 225,
                Moon = new List<Moon>() {  },
                Type = PlanetType.Giant
            };
            DataList.Add(Venus);

            // Earth
            Planet Earth = new Planet()
            {
                Id = 3,
                Name = "Earth",
                Pos = new() { X = 2.5, Y = 2.0 },
                Diameter = 12742000,
                RotationPeriod = 24,
                RevolutionPeriod = 365.256,
                Moon = new List<Moon>() {Luna},
                Type = PlanetType.Terrestial
            };
            Luna.Oribiting = Earth;
            DataList.Add(Earth);

            // Mars
            Planet Mars = new Planet()
            {
                Id = 4,
                Name = "Mars",
                Pos = new() { X = 3.0, Y = 2.9 },
                Diameter = 6779000,
                RotationPeriod = 25,
                RevolutionPeriod = 687,
                Moon = new List<Moon>() { Phobos, Deimos },
                Type = PlanetType.Giant
            };
            Phobos.Oribiting = Mars;
            Deimos.Oribiting = Mars;
            DataList.Add(Mars);

            // Jupiter
            Planet Jupiter = new Planet()
            {
                Id = 5,
                Name = "Jupiter",
                Pos = new() { X = 4.4, Y = 3.7 },
                Diameter = 139820000,
                RotationPeriod = 10,
                RevolutionPeriod = 4380,
                Moon = new List<Moon>() { Europa, Ganymedes, Io },
                Type = PlanetType.Gas_Giant
            };
            Europa.Oribiting = Jupiter;
            Ganymedes.Oribiting = Jupiter;
            Io.Oribiting= Jupiter;
            DataList.Add(Jupiter);

            // Saturn
            Planet Saturn = new Planet()
            {
                Id = 6,
                Name = "Saturn",
                Pos = new() { X = 5.5, Y = 4.0 },
                Diameter = 116460000,
                RotationPeriod = 11,
                RevolutionPeriod = 10585,
                Moon = new List<Moon>() { Titan, Mimas },
                Type = PlanetType.Giant
            };
            Titan.Oribiting = Saturn;
            Mimas.Oribiting = Saturn;
            DataList.Add(Saturn);

            // Uranus
            Planet Uranus = new Planet()
            {
                Id = 7,
                Name = "Uranus",
                Pos = new() { X = 5.9, Y = 6.2 },
                Diameter = 50724000,
                RotationPeriod = 17,
                RevolutionPeriod = 30660,
                Moon = new List<Moon>() {  },
                Type = PlanetType.Gas_Giant
            };
            DataList.Add(Uranus);

            // Neptune
            Planet Neptune = new Planet()
            {
                Id = 8,
                Name = "Neptune",
                Pos = new() { X = 7.7, Y = 7.9 },
                Diameter = 49244000,
                RotationPeriod = 16,
                RevolutionPeriod = 60225,
                Moon = new List<Moon>() {  },
                Type = PlanetType.Giant
            };
            DataList.Add(Neptune);



            // Display the Data

            Console.WriteLine("Welcome to our solar system");
            Console.WriteLine("It contains the following objects: \n 1 Star: ");

            foreach (var objects in DataList)
            {
                if (objects is Star)
                {
                    Console.WriteLine($"{objects.Name} \n" +
                        $"It is a {((Star)objects).Type}" +
                        $"And is {((Star)objects).Temperature} degrees Celcius");
                }
            }
            Console.WriteLine("\n\n\n It also contains 8 Planets:");
            foreach (var objects in DataList)
            {
                if (objects is Planet)
                {
                    Planet p = (Planet)objects;
                    Console.WriteLine($"{p.Name} \n" +
                        $"This is a {((Planet)objects).Type} \n" +
                        $"And has a diameter of {((Planet)objects).Diameter} Meters \n" +
                        $"It is {p.Distance(Sun)} from the Star \n" + // Distance
                        $"With a Revolution Period of {((Planet)objects).RevolutionPeriod} Days" + $"\tAnd a Rotation Period of {p.RotationPeriod} Hours \n");
                    if (p.Moon.Count() > 0)
                    {
                        Console.Write($"It has {((Planet)objects).Moon.Count()} Moons, named: \n");
                        foreach (var moons in ((Planet)objects).Moon)
                        {
                            Console.WriteLine(moons.Name);
                        }
                    } else {
                        Console.Write("It has no moons");
                    }
                    Console.WriteLine("\n\n");
                }
            }
            Console.ReadKey();
        }
    }
}
