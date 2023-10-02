using System;

public class Pokemon {
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Ataque1 { get; set; }
    public int Ataque2 { get; set; }
    public int Ataque3 { get; set; }
    public int Defensa { get; set; }

    public int Atacar(){
        Random random = new Random();
        int ataqueSeleccionado = random.Next(1, 4);
        int puntaje = 0;

        switch (ataqueSeleccionado) {
            case 1:
                puntaje = Ataque1;
                break;
            case 2:
                puntaje = Ataque2;
                break;
            case 3:
                puntaje = Ataque3;
                break;
        }

        int multiplicador = random.Next(0, 2);
        return puntaje * multiplicador;
    }

    public double Defender(){
        Random random = new Random();
        double multiplicador = random.NextDouble() < 0.5 ? 0.5 : 1;
        return Defensa * multiplicador;
    }
}

public class Batalla {
    public static void Main(string[] args) {
        Console.WriteLine("Ingrese los valores para el Pokémon 1:");
        Pokemon pokemon1 = CrearPokemon();

        Console.WriteLine("Ingrese los valores para el Pokémon 2:");
        Pokemon pokemon2 = CrearPokemon();

        Console.WriteLine("¡Comienza la batalla!");

        int resultado1 = 0;
        int resultado2 = 0;

        for (int i = 1; i <= 3; i++) {
            Console.WriteLine($"Turno {i}:");

            Console.WriteLine($"El Pokémon 1 ataca:");
            resultado1 += pokemon1.Atacar();
            Console.WriteLine($"El Pokémon 2 defiende con una defensa de {pokemon2.Defender()}");

            Console.WriteLine($"El Pokémon 2 ataca:");
            resultado2 += pokemon2.Atacar();
            Console.WriteLine($"El Pokémon 1 defiende con una defensa de {pokemon1.Defender()}");

            Console.WriteLine();
        }

        Console.WriteLine("Termino batalla");

        if (resultado1 > resultado2) {
            Console.WriteLine("Pokémon 1 gana");
        }
        else if (resultado1 < resultado2) {
            Console.WriteLine("Pokémon 2 gana");
        }
        else {
            Console.WriteLine("Empate!");
        }
    }

    public static Pokemon CrearPokemon() {
        Pokemon pokemon = new Pokemon();

        Console.Write("Nombre: ");
        pokemon.Nombre = Console.ReadLine();

        Console.Write("Tipo: ");
        pokemon.Tipo = Console.ReadLine();

        Console.Write("Ataque 1 (entre 0 y 40): ");
        pokemon.Ataque1 = int.Parse(Console.ReadLine());

        Console.Write("Ataque 2 (entre 0 y 40): ");
        pokemon.Ataque2 = int.Parse(Console.ReadLine());

        Console.Write("Ataque 3 (entre 0 y 40): ");
        pokemon.Ataque3 = int.Parse(Console.ReadLine());

        Console.Write("Defensa (entre 10 y 35): ");
        pokemon.Defensa = int.Parse(Console.ReadLine());

        Console.WriteLine();

        return pokemon;
    }
}




