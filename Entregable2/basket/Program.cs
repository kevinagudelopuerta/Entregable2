using System;

interface IJugador {
    string Nombre { get; }
    string Posicion { get; }
    int Rendimiento { get; }
}

class Jugador : IJugador {
    public string Nombre { get; private set; }
    public string Posicion { get; private set; }
    public int Rendimiento { get; private set; }

    public Jugador(string nombre, string posicion, int rendimiento) {
        Nombre = nombre;
        Posicion = posicion;
        Rendimiento = rendimiento;
    }
}

class Equipo {
    private List<IJugador> jugadores = new List<IJugador>();

    public void MeterJugador(IJugador jugador) {
        jugadores.Add(jugador);
    }

    public int CalcularPuntaje() {
        return jugadores.Sum(jugador => jugador.Rendimiento);
    }
}

class Program {
    static void Main(string[] args) {
        List<IJugador> ListaDeJugadores = new List<IJugador> {
            new Jugador("LeBron James", "Ala-pívot", 10),
            new Jugador("Kevin Durant", "Base", 8),
            new Jugador("hormiga giannis", "Pívot", 6),
            new Jugador("Stephen Curry", "Base", 9),
            new Jugador("Michael Jordan", "Base", 10),
            new Jugador("Luka Doncic", "Alero", 7)
        };


        Equipo equipo1 = new Equipo();
        Equipo equipo2 = new Equipo();

        Random random = new Random();
        while (ListaDeJugadores.Count > 0) {
            int x = random.Next(ListaDeJugadores.Count);
            IJugador jugadorSeleccionado = ListaDeJugadores[x];
            if (equipo1.CalcularPuntaje() <= equipo2.CalcularPuntaje())
            {
                equipo1.MeterJugador(jugadorSeleccionado);
            }
            else
            {
                equipo2.MeterJugador(jugadorSeleccionado);
            }
            ListaDeJugadores.RemoveAt(x);
        }

        int puntajeEquipo1 = equipo1.CalcularPuntaje();
        int puntajeEquipo2 = equipo2.CalcularPuntaje();

        if (puntajeEquipo1 > puntajeEquipo2) {
            Console.WriteLine("El equipo 1 gana con un puntaje de " + puntajeEquipo1);
        }
        else if (puntajeEquipo2 > puntajeEquipo1) {
            Console.WriteLine("El equipo 2 gana con un puntaje de " + puntajeEquipo2);
        }
        else {
            Console.WriteLine("El partido termina en empate con un puntaje de " + puntajeEquipo1);
        }
    }
}
